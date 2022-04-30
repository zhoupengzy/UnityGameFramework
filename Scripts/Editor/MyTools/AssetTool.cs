using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class AssetDependenciesTool : EditorWindow
{
    //Prefab/Scene的引用资源
    private Dictionary<string,string[]> prefabDependDic = new Dictionary<string,string[]>();
    //被Prefab/Scene引用的资源
    private Dictionary<string,List<string>> assetRelatedDic = new Dictionary<string,List<string>>();
    //所有引用资源类型
    private string[] assetExtentArray = new string[0];
    //资源路径
    private string assetRootPath;
    //忽略资源
    private string ignoreFilePath;
    private Dictionary<string, string> ignoreAssetDic = new Dictionary<string, string>();
    //需要显示的资源
    private List<AssetRelatedItem> showAssetItemList = new List<AssetRelatedItem>();
    //需要显示的Prefab
    private List<PrefabDependItem> showPrefabItemList;

    private int displayIndex = 0;
 
    private int lastExtentIndex = -1;
    private int showExtentIndex = -1;
 
    private bool showUsedAsset = true;
    private bool showUnusedAsset = true;
 
    private Color listItemColor = new Color(0.9f,0.9f,0.9f,1);
 
    [MenuItem("MyTools/查找资源引用关系")]
    public static void FindAssets()
    {
        GetWindow<AssetDependenciesTool>();
    }
 
    private void OnEnable()
    {
        lastExtentIndex = -1;
        showExtentIndex = -1;
        showUsedAsset = true;
        showUnusedAsset = true;
        assetRootPath = Application.dataPath;
        ignoreFilePath = Application.dataPath + "/IgnoreAsset";
        //FindAllPrefabDependencies(ref prefabDependDic,ref assetRelatedDic,out assetExtentArray);
    }
 
    private string[] displayBarArray = new string[] { "查找引用方","查找被引用方","引用关系","被引用关系","忽略资源" };
 
    private void OnGUI()
    {
        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("有引用资源的Prefab&Scene数量 : " + prefabDependDic.Count);
        EditorGUILayout.LabelField("被Prefab|Scene引用的资源数量 : " + assetRelatedDic.Count);
        EditorGUILayout.LabelField("所统计的资源引用关系，不包含代码动态加载");
        assetRootPath = EditorGUILayout.TextField("资源路径：", assetRootPath, GUILayout.Width(500));
        if(GUILayout.Button("加载资源", GUILayout.Width(100), GUILayout.Height(40)))
        {
            FindAllPrefabDependencies(ref prefabDependDic, ref assetRelatedDic, ref ignoreAssetDic, out assetExtentArray);
        }
        EditorGUILayout.EndVertical();

        displayIndex = GUILayout.Toolbar(displayIndex,displayBarArray);

        switch (displayIndex)
        {
            case 0:
                OnGUI_FindAssets();
                break;
            case 1:
                OnGUI_FindPrefab();
                break;
            case 2:
                OnGUI_AllPrefab();
                break;
            case 3:
                OnGUI_AllAssets();
                break;
            case 4:
                OnGUI_AllIgnore();
                break;
            default:
                break;
        }
    }
 
    Object selectPrefabObject;
    PrefabDependItem selectPrefabDependItem;
    Vector2 scrollViewPos01;
    private void OnGUI_FindAssets()
    {
        EditorGUILayout.BeginHorizontal();
        selectPrefabObject = EditorGUILayout.ObjectField("引用资源:",selectPrefabObject,typeof(GameObject),true,GUILayout.Width(400));
        if(GUILayout.Button("引用详情",GUILayout.Width(100)))
        {
            if(selectPrefabObject != null)
            {
                string prefabPath = AssetDatabase.GetAssetPath(selectPrefabObject);
 
                string[] depPathArray;
                if(!prefabDependDic.TryGetValue(prefabPath,out depPathArray))
                    depPathArray = new string[0];
 
                selectPrefabDependItem = new PrefabDependItem(prefabPath,depPathArray);
                selectPrefabDependItem.LoadDependObjects();
            }
        }
        EditorGUILayout.EndHorizontal();
 
        if(selectPrefabDependItem != null && selectPrefabDependItem.dependPathArray != null)
        {
            EditorGUILayout.Space(5);
            scrollViewPos01 = EditorGUILayout.BeginScrollView(scrollViewPos01);
            for (int i = 0; i < selectPrefabDependItem.dependObjectArray.Length; i++)
            {
                EditorGUILayout.ObjectField($"({i}) 引用资源:",selectPrefabDependItem.dependObjectArray[i],typeof(Object),true,GUILayout.Width(400));
            }
            EditorGUILayout.EndScrollView();
        }
    }
 
    Object selectAssetObject;
    AssetRelatedItem selectAssetRelatedItem;
    Object replaceAssetObject;
    AssetRelatedItem replaceAssetRelatedItem;
    Vector2 scrollViewPos02;
    bool isChange = false;
    private void OnGUI_FindPrefab()
    {
        EditorGUILayout.BeginHorizontal();
        selectAssetObject = EditorGUILayout.ObjectField("被引用资源:",selectAssetObject,typeof(Object),true,GUILayout.Width(400));
 
        if(GUILayout.Button("引用详情",GUILayout.Width(100)))
        {
            if(selectAssetObject != null)
            {
                string prefabPath = AssetDatabase.GetAssetPath(selectAssetObject);
 
                List<string> depPathArray;
                if(!assetRelatedDic.TryGetValue(prefabPath,out depPathArray))
                    depPathArray = new List<string>();

                selectAssetRelatedItem = new AssetRelatedItem(prefabPath,depPathArray.ToList());
                selectAssetRelatedItem.LoadRelatedObjects();
            }
        }
        if (GUILayout.Button("修改", GUILayout.Width(100)))
        {
            isChange = !isChange;
        }
        EditorGUILayout.EndHorizontal();

        if (isChange)
        {
            EditorGUILayout.Space(10);
            EditorGUILayout.BeginHorizontal();
            replaceAssetObject = EditorGUILayout.ObjectField("替换资源：", replaceAssetObject, typeof(Object), true, GUILayout.Width(400));
            if (GUILayout.Button("一键替换", GUILayout.Width(100)))
            {
                string selectAssetObjectPath = AssetDatabase.GetAssetPath(selectAssetObject);
                string replaceAssetObjectPath = AssetDatabase.GetAssetPath(replaceAssetObject);
                if (string.IsNullOrEmpty(selectAssetObjectPath))
                {
                    EditorUtility.DisplayDialog("修改", "被引用资源未找到！", "确认");
                    return;
                }
                if (string.IsNullOrEmpty(replaceAssetObjectPath))
                {
                    EditorUtility.DisplayDialog("修改", "替换资源未找到！", "确认");
                    return;
                }
                string extent = Path.GetExtension(selectAssetObjectPath);
                if (Path.GetExtension(replaceAssetObjectPath) != extent)
                {
                    EditorUtility.DisplayDialog("修改", "资源类型不一致！", "确认");
                    return;
                } 
                for (int i = 0; i < selectAssetRelatedItem.relatedObjectList.Count; i++)
                {
                    bool prefabChange = false;
                    GameObject obj = (GameObject)(selectAssetRelatedItem.relatedObjectList[i]);
                    switch(extent)
                    {
                        case ".jpg":
                        case ".png":
                            //Image[] images = obj.GetComponentsInChildren<Image>(true);
                            //for (int j = 0; j < images.Length; j++)
                            //{
                            //}
                            break;
                        case ".TTF":
                            Text[] labels = obj.GetComponentsInChildren<Text>(true);
                            for(int j = 0; j < labels.Length; j++)
                            {
                                if(labels[j].font != null && labels[j].font.name.Equals(selectAssetObject.name))
                                {
                                    Undo.RecordObject(labels[j], labels[j].gameObject.name);
                                    labels[j].font = (Font)replaceAssetObject;
                                }
                                prefabChange = true;
                                EditorUtility.SetDirty(labels[j]);
                            }
                            EditorUtility.DisplayCancelableProgressBar("替换资源", $"遍历所有引用方 : {i}/{selectAssetRelatedItem.relatedObjectList.Count}", (float)i / selectAssetRelatedItem.relatedObjectList.Count);
                     
                            break;
                        default:
                            EditorUtility.DisplayDialog("修改", "先添加类型！", "确认");
                            return;
                    }
                    if(prefabChange)
                    {
                        EditorUtility.SetDirty(obj);
                    }
                }
                AssetDatabase.SaveAssets();
                EditorUtility.ClearProgressBar();
            }
            EditorGUILayout.EndHorizontal();
        }


        if (selectAssetRelatedItem != null && selectAssetRelatedItem.relatedObjectList != null)
        {
            EditorGUILayout.Space(5);
            scrollViewPos02 = EditorGUILayout.BeginScrollView(scrollViewPos02);
            EditorGUILayout.BeginVertical("box");
            for(int i = 0; i < selectAssetRelatedItem.relatedObjectList.Count; i++)
            {
                EditorGUILayout.ObjectField($"({i}) 引用方:",selectAssetRelatedItem.relatedObjectList[i],typeof(GameObject),true,GUILayout.Width(400));
            }
            EditorGUILayout.EndScrollView();
        }
    }
 
    int showPageIndex = 0;
    Vector2 scrollViewPos03;
    private void OnGUI_AllPrefab()
    {
        if(showPrefabItemList == null)
        {
            FindAllPrefabDepend(prefabDependDic,out showPrefabItemList);
        }
 
        EditorGUILayout.LabelField($"有引用的资源数量: { showPrefabItemList.Count}");
 
        scrollViewPos03 = EditorGUILayout.BeginScrollView(scrollViewPos03);
 
        for(int i = showPageIndex; i < showPageIndex + 100; i++)
        {
            if(i >= showPrefabItemList.Count)
                break;
 
            PrefabDependItem prefabDependItem = showPrefabItemList[i];
 
            GUI.color = i % 2 == 0 ? listItemColor : Color.white;
            EditorGUILayout.BeginVertical("box");
            GUI.color = Color.white;
 
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.ObjectField($"{i}. 资源文件: ",prefabDependItem.prefabObject,typeof(GameObject),true,GUILayout.Width(400));
            EditorGUILayout.LabelField($"引用数量: { prefabDependItem.dependPathArray.Length}",GUILayout.Width(200));
            if(GUILayout.Button("引用详情",GUILayout.Width(100)))
            {
                if(prefabDependItem.dependObjectArray == null)
                    prefabDependItem.LoadDependObjects();
                else
                    prefabDependItem.dependObjectArray = null;
            }
            EditorGUILayout.EndHorizontal();
 
            if(prefabDependItem.dependObjectArray != null)
            {
                EditorGUILayout.Space(5);
                EditorGUILayout.BeginVertical();
                for(int j = 0; j < prefabDependItem.dependObjectArray.Length; j++)
                {
                    EditorGUILayout.ObjectField($"({j}) 引用资源:",prefabDependItem.dependObjectArray[j],typeof(Object),true,GUILayout.Width(400));
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndScrollView();
 
        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("上一页",GUILayout.Width(200)))
        {
            if(showPageIndex >= 100)
                showPageIndex -= 100;
        }
        EditorGUILayout.LabelField($"{showPageIndex}/{showPrefabItemList.Count}");
        if(GUILayout.Button("下一页",GUILayout.Width(200)))
        {
            if((showPageIndex + 100) < showPrefabItemList.Count)
                showPageIndex += 100;
        }
        EditorGUILayout.EndHorizontal();
    }
 
    Vector2 scrollViewPos04;
    string selectAssetExtent;
    private void OnGUI_AllAssets()
    {
        showExtentIndex = EditorGUILayout.Popup("查找资源类型 : ",showExtentIndex,assetExtentArray,GUILayout.MaxWidth(300));
 
        if(showExtentIndex < 0 || showExtentIndex >= assetExtentArray.Length)
            return;
        selectAssetExtent = assetExtentArray[showExtentIndex];
 
        if(lastExtentIndex != showExtentIndex)
        {
            lastExtentIndex = showExtentIndex;
 
            FindAssetsByExtent(selectAssetExtent,assetRelatedDic,ref showAssetItemList);
        }
 
        EditorGUILayout.BeginVertical("box");
 
        EditorGUILayout.LabelField($"被引用资源的数量: { showAssetItemList.Count}");
        showUsedAsset = EditorGUILayout.Toggle("显示被使用资源",showUsedAsset);
        showUnusedAsset = EditorGUILayout.Toggle("显示未使用资源",showUnusedAsset);
        EditorGUILayout.EndVertical();
 
        scrollViewPos04 = EditorGUILayout.BeginScrollView(scrollViewPos04);
 
        for(int i = 0; i < showAssetItemList.Count; i++)
        {
            AssetRelatedItem assetRelatedItem = showAssetItemList[i];
 
            if((!showUsedAsset && assetRelatedItem.relatedPathList.Count > 0) || (!showUnusedAsset && assetRelatedItem.relatedPathList.Count == 0))
                continue;
 
            GUI.color = i % 2 == 0 ? listItemColor : Color.white;
            EditorGUILayout.BeginVertical("box");
            GUI.color = Color.white;
 
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.ObjectField($"{i}. 资源文件: ",assetRelatedItem.assetObject,typeof(GameObject),true,GUILayout.Width(400));
            EditorGUILayout.LabelField($"被引用次数: { assetRelatedItem.relatedPathList.Count}",GUILayout.Width(200));
            if(GUILayout.Button("忽略", GUILayout.Width(100)))
            {
                assetRelatedItem.isIgnore = !assetRelatedItem.isIgnore;
            }
        
            if(assetRelatedItem.relatedPathList.Count > 0)
            {
                if(GUILayout.Button("引用详情",GUILayout.Width(100)))
                {
                    if(assetRelatedItem.relatedObjectList == null)
                        assetRelatedItem.LoadRelatedObjects();
                    else
                        assetRelatedItem.relatedObjectList = null;
                }
            }
            else
            {
                if (GUILayout.Button("删除", GUILayout.Width(100)))
                {
                    if(EditorUtility.DisplayDialog("删除",$"是否删除：\n{assetRelatedItem.assetPath}", "确认", "取消"))
                    {
                        showAssetItemList.Remove(assetRelatedItem);
                        Debug.Log($"删除：{assetRelatedItem.assetPath}");
                        AssetDatabase.DeleteAsset(assetRelatedItem.assetPath);
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
            if (assetRelatedItem.relatedObjectList != null)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.BeginVertical();
                for(int j = 0; j < assetRelatedItem.relatedObjectList.Count; j++)
                {
                    EditorGUILayout.ObjectField($"({j}) 引用方:",assetRelatedItem.relatedObjectList[j],typeof(GameObject),true,GUILayout.Width(400));
                }
                EditorGUILayout.EndVertical();
            }
            if (assetRelatedItem.isIgnore)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.BeginHorizontal();
                assetRelatedItem.logInfo = EditorGUILayout.TextField("日志：", assetRelatedItem.logInfo, GUILayout.Width(600));
                if (GUILayout.Button("确认", GUILayout.Width(100)))
                {
                    showAssetItemList.Remove(assetRelatedItem);
                    Debug.Log($"忽略：{assetRelatedItem.assetPath}，日志：{assetRelatedItem.logInfo}");

                    StreamWriter writer = new StreamWriter(ignoreFilePath, true);
                    writer.WriteLine(assetRelatedItem.assetPath);
                    writer.WriteLine(assetRelatedItem.logInfo);
                    writer.Close();

                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
        }
 
        EditorGUILayout.EndScrollView();
    }
    // 忽略文件
    private void OnGUI_AllIgnore()
    {

        EditorGUILayout.LabelField($"忽略的资源数量: { ignoreAssetDic.Count}");

        scrollViewPos03 = EditorGUILayout.BeginScrollView(scrollViewPos03);
        foreach (var item in ignoreAssetDic)
        {
            EditorGUILayout.BeginHorizontal();
            Object tempObj = AssetDatabase.LoadAssetAtPath<Object>(item.Key);
            EditorGUILayout.ObjectField("资源文件: ", tempObj, typeof(GameObject), true, GUILayout.Width(400));
            EditorGUILayout.LabelField($"日志: { item.Value }", GUILayout.Width(200));
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndScrollView();
    }

    //==========

    private void FindAllPrefabDependencies(ref Dictionary<string,string[]> prefabDic,ref Dictionary<string,List<string>> assetDic, ref Dictionary<string, string> ignoreDic, out string[] extentArray)
    {
        prefabDic.Clear();
        assetDic.Clear();
        ignoreDic.Clear();
        extentArray = new string[0];

        //读取忽略文件
        if (File.Exists(ignoreFilePath))
        {
            StreamReader reader = new StreamReader(ignoreFilePath);
            while (!reader.EndOfStream)
            {
                string path = reader.ReadLine();
                string log = reader.ReadLine();
                ignoreDic.Add(path, log);
            }
            reader.Close();
        }

        //获取所有资源路线
        string[] allFilePathArray = Directory.GetFiles(assetRootPath, "*.*",SearchOption.AllDirectories);
        EditorUtility.DisplayProgressBar("读取项目所有资源","读取所有资源",0);
        for(int i = 0; i < allFilePathArray.Length; i++)
        {
            allFilePathArray[i] = allFilePathArray[i].Replace("\\", "/");
            if (allFilePathArray[i].EndsWith(".meta"))
                allFilePathArray[i] = null;
            else
                allFilePathArray[i] = "Assets" + allFilePathArray[i].Replace(Application.dataPath,"");

        }
        EditorUtility.ClearProgressBar();
 
        //----------
 
        EditorUtility.DisplayProgressBar("获取资源引用关系","遍历所有资源",0);
        for(int i = 0; i < allFilePathArray.Length; i++)
        {
            if(string.IsNullOrEmpty(allFilePathArray[i]))
                continue;
            if(allFilePathArray[i].EndsWith(".prefab"))// || allFilePathArray[i].EndsWith(".unity"))
            {
                if(i % 100 == 0 && EditorUtility.DisplayCancelableProgressBar("获取资源引用关系",$"遍历所有文件 : {i}/{allFilePathArray.Length}",(float)i / allFilePathArray.Length))
                    break;
                prefabDic[allFilePathArray[i]] = AssetDatabase.GetDependencies(allFilePathArray[i],true);
            }
        }
        EditorUtility.ClearProgressBar();
 
        //----------
 
        EditorUtility.DisplayProgressBar("反向解析引用关系","遍历所有资源",0);
        for(int i = 0; i < allFilePathArray.Length; i++)
        {
            if(string.IsNullOrEmpty(allFilePathArray[i]))
                continue;
            if(i % 100 == 0 && EditorUtility.DisplayCancelableProgressBar("反向解析引用关系",$"遍历所有文件 : {i}/{allFilePathArray.Length}",(float)i / allFilePathArray.Length))
                break;
            if(!assetDic.TryGetValue(allFilePathArray[i],out var relList))
            {
                relList = assetDic[allFilePathArray[i]] = new List<string>();
            }
 
            foreach(var item in prefabDic)
            {
                if(item.Value.Contains(allFilePathArray[i]))
                {
                    relList.Add(item.Key);
                }
            }
        }
        EditorUtility.ClearProgressBar();
 
        //统计文件类型
        EditorUtility.DisplayProgressBar("读取引用资源类型","获取所有引用文件类型",0);
        string extentName;
        List<string> extensionList = new List<string>();
        foreach(var item in assetDic.Keys)
        {
            extentName = Path.GetExtension(item);
            if(!extensionList.Contains(extentName))
            {
                extensionList.Add(extentName);
            }
        }
        extentArray = extensionList.ToArray();

        EditorUtility.ClearProgressBar();
    }
 
    private void FindAssetsByExtent(string targetExtent,Dictionary<string,List<string>> assetRelDic,ref List<AssetRelatedItem> assetItemList)
    {
        assetItemList.Clear();
 
        if(string.IsNullOrEmpty(targetExtent))
            return;
 
        int index = 0;
        foreach(var item in assetRelDic)
        {
            if(item.Key.EndsWith(targetExtent))
            {
                if(EditorUtility.DisplayCancelableProgressBar("查找指定类型的资源引用",$"遍历所有引用 : {assetItemList.Count}",(float)(++index) / assetRelDic.Count))
                {
                    EditorUtility.ClearProgressBar();
                    return;
                }
                if (!ignoreAssetDic.TryGetValue(item.Key, out var log))
                {
                    assetItemList.Add(new AssetRelatedItem(item.Key,item.Value));
                }
            }
        }
 
        EditorUtility.ClearProgressBar();
    }
 
    private void FindAllPrefabDepend(Dictionary<string,string[]> prefabDepDic,out List<PrefabDependItem> prefabItemList)
    {
        prefabItemList = new List<PrefabDependItem>();
 
        int index = 0;
        foreach(var item in prefabDepDic)
        {
            if(EditorUtility.DisplayCancelableProgressBar("查找所有资源的引用关系",$"加载所有资源文件: {prefabItemList.Count}",(float)(++index) / prefabDepDic.Count))
            {
                EditorUtility.ClearProgressBar();
                return;
            }
            if (!ignoreAssetDic.TryGetValue(item.Key, out var log))
            {
                prefabItemList.Add(new PrefabDependItem(item.Key,item.Value));
            }
        }
        EditorUtility.ClearProgressBar();
    }
 
    //==========
 
    public class AssetRelatedItem
    {
        public string assetPath;
        public List<string> relatedPathList; 
 
        public Object assetObject;
        public List<Object> relatedObjectList;

        public bool isIgnore = false;
        public string logInfo = "无";


        public AssetRelatedItem(string _assetPath,List<string> _relatedPathList)
        {
            assetPath = _assetPath;
            relatedPathList = _relatedPathList;
 
            assetObject = AssetDatabase.LoadAssetAtPath<Object>(assetPath);
        }
 
        public void LoadRelatedObjects()
        {
            if(relatedObjectList != null)
                return;
            if(relatedPathList == null || relatedPathList.Count == 0)
                return;
 
            relatedObjectList = new List<Object>(relatedPathList.Count);
            for(int i = 0; i < relatedPathList.Count; i++)
            {
                if(EditorUtility.DisplayCancelableProgressBar("加载引用该资源的Prefab|Scene",$"加载进度 : {i}/{relatedPathList.Count}",(float)i / relatedPathList.Count))
                {
                    EditorUtility.ClearProgressBar();
                    return;
                }
                Object tempObj = AssetDatabase.LoadAssetAtPath<Object>(relatedPathList[i]);
                relatedObjectList.Add(tempObj);
            }
            EditorUtility.ClearProgressBar();
        }
    }
 
    public class PrefabDependItem
    {
        public string prefabPath;
        public string[] dependPathArray;
 
        public Object prefabObject;
        public Object[] dependObjectArray;
 
        public PrefabDependItem(string _prefabPath,string[] _dependPathArray)
        {
            prefabPath = _prefabPath;
            dependPathArray = _dependPathArray;
 
            prefabObject = AssetDatabase.LoadAssetAtPath<Object>(prefabPath);
        }
 
        public void LoadDependObjects()
        {
            if(dependObjectArray != null)
                return;
            if(dependPathArray == null || dependPathArray.Length == 0)
                return;
 
            dependObjectArray = new Object[dependPathArray.Length];
            for(int i = 0; i < dependPathArray.Length; i++)
            {
                if(EditorUtility.DisplayCancelableProgressBar("加载引用该资源的Prefab|Scene",$"加载进度 : {i}/{dependPathArray.Length}",(float)i / dependPathArray.Length))
                {
                    EditorUtility.ClearProgressBar();
                    return;
                }
                Object tempObj = AssetDatabase.LoadAssetAtPath<Object>(dependPathArray[i]);
                dependObjectArray[i] = tempObj;
            }
            EditorUtility.ClearProgressBar();
        }
    }
 
}
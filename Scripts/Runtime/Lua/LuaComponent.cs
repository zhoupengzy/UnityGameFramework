using UnityEngine;
using System.Collections;
using LuaInterface;
using GameFramework;
using GameFramework.Lua;
using GameFramework.Resource;
using UnityGameFramework.Runtime;
using System;

namespace UnityGameFramework.Runtime
{
    public class LuaComponent : GameFrameworkComponent
    {
        private ILuaManager luaManager;
        private EventComponent m_EventComponent = null;
        private IResourceManager m_ResourceManager = null;
        private BaseComponent m_BaseComponent = null;
        public bool isInit = false;


        // Use this for initialization
        protected override void Awake()
        {
            base.Awake();

            luaManager = GameFrameworkEntry.GetModule<ILuaManager>();

            if (luaManager == null)
            {
                Log.Fatal("Localization manager is invalid.");
                return;
            }
        }

        void Start()
        {
            m_BaseComponent = GameEntry.GetComponent<BaseComponent>();
            if (m_BaseComponent == null)
            {
                Log.Fatal("Base component is invalid.");
                return;
            }

            m_EventComponent = GameEntry.GetComponent<EventComponent>();
            if (m_EventComponent == null)
            {
                Log.Fatal("Event component is invalid.");
                return;
            }

            m_ResourceManager = m_BaseComponent.EditorResourceMode ? m_BaseComponent.EditorResourceHelper : GameFrameworkEntry.GetModule<IResourceManager>();
            if (m_ResourceManager == null)
            {
                Log.Fatal("Resource manager is invalid.");
                return;
            }
        }

        private void OnApplicationPause(bool pause)
        {
            if (m_EventComponent)
            {
                //m_EventComponent.FireNow(this, new OnApplicationPauseEventArgs(pause));
            }

        }


        public void Initialization()
        {
            if (isInit) return;

            if (luaManager == null) Debug.Log("luaManager is null");

            luaManager.Initialize();

            if (m_BaseComponent.EditorResourceMode)
            {
//                 luaManager.SetResourceManager(m_BaseComponent.EditorResourceHelper);
//                 luaManager.SetBeZip(false);
                luaManager.AddSearchPath(LuaConst.luaDir);
                luaManager.AddSearchPath(LuaConst.toluaDir);
             }
             else
             {
//                 bool IsDebug = m_BaseComponent.Channel.Contains("_debug");
//                 luaManager.SetDebug(IsDebug);
//                 if (IsDebug) luaManager.AddSearchPath(Application.dataPath + "/Lua");
//                 luaManager.SetResourceManager(GameFrameworkEntry.GetModule<IResourceManager>());
//                 luaManager.SetBeZip(true);
             }
// 
//             //如果想在编辑器中以加载AB的方式实时调试LUA代码就打开这个注释
//             // luaManager.SetBeZip(false);
// 
             isInit = true;
             luaManager.Start(gameObject, this);
// #if UNITY_EDITOR
//             if (m_BaseComponent.EditorResourceMode)
//             {
//                 luaManager.DoFile("Editor/Hotfix.lua");
//                 LuaFileWatcher.CreateLuaFileWatcher(luaManager.GetLuaState(), Application.dataPath + "/ProjectResources/Lua");
//             }
// #endif 
            this.DoFile("Main.lua");

        }

        public void DoFile(string filename)
        {
            if (!isInit)
            {
                throw new GameFrameworkException("lua maanger not init");
            }

            luaManager.DoFile(filename);
        }

        // Update is called once per frame
        public object[] CallFunction(string funcName, params object[] args)
        {
            if (!isInit)
            {
                throw new GameFrameworkException("lua maanger not init");
            }

            return luaManager.CallFunction(funcName, args);
        }

        public void LuaGC()
        {
            if (!isInit)
            {
                throw new GameFrameworkException("lua maanger not init");
            }

            luaManager.LuaGC();
        }

        /// <summary>
        /// 执行Lua方法
        /// </summary>
        public object[] CallMethod(string module, string func, params object[] args)
        {
            if (!isInit)
            {
                throw new GameFrameworkException("lua maanger not init");
            }

            return luaManager.CallFunction(module + "." + func, args);
        }

        public LuaFunction GetFunction(string funcName)
        {
            if (!isInit)
            {
                throw new GameFrameworkException("lua maanger not init");
            }

            return luaManager.GetFunction(funcName);
        }

        public T Require<T>(string luaModule)
        {
            if (!isInit)
            {
                throw new GameFrameworkException("lua maanger not init");
            }

            return luaManager.Require<T>(luaModule);
        }

        public LuaTable DoString(string luaString)
        {
            if (!isInit)
            {
                throw new GameFrameworkException("lua maanger not init");
            }

            return luaManager.DoString(luaString);
        }

        public byte[] LoadLuaBytes(string file)
        {
            //            TextAsset result = m_ResourceManager.LoadAsset(file) as TextAsset;
            //             return result == null ? null : result.bytes;
            return null;
        }
    }
}
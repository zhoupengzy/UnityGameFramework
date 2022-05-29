﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityGameFramework_Runtime_UnloadSceneSuccessEventArgsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs), typeof(GameFramework.Event.GameEventArgs));
		L.RegFunction("Create", Create);
		L.RegFunction("Clear", Clear);
		L.RegFunction("New", _CreateUnityGameFramework_Runtime_UnloadSceneSuccessEventArgs);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("EventId", get_EventId, null);
		L.RegVar("Id", get_Id, null);
		L.RegVar("SceneAssetName", get_SceneAssetName, null);
		L.RegVar("UserData", get_UserData, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityGameFramework_Runtime_UnloadSceneSuccessEventArgs(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs obj = new UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs();
				ToLua.PushSealed(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameFramework.Scene.UnloadSceneSuccessEventArgs arg0 = (GameFramework.Scene.UnloadSceneSuccessEventArgs)ToLua.CheckObject(L, 1, typeof(GameFramework.Scene.UnloadSceneSuccessEventArgs));
			UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs o = UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs.Create(arg0);
			ToLua.PushSealed(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs obj = (UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs));
			obj.Clear();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_EventId(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs.EventId);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Id(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs obj = (UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs)o;
			int ret = obj.Id;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Id on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SceneAssetName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs obj = (UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs)o;
			string ret = obj.SceneAssetName;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index SceneAssetName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UserData(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs obj = (UnityGameFramework.Runtime.UnloadSceneSuccessEventArgs)o;
			object ret = obj.UserData;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index UserData on a nil value");
		}
	}
}


﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityGameFramework_Runtime_ResourceUpdateStartEventArgsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityGameFramework.Runtime.ResourceUpdateStartEventArgs), typeof(GameFramework.Event.GameEventArgs));
		L.RegFunction("Create", Create);
		L.RegFunction("Clear", Clear);
		L.RegFunction("New", _CreateUnityGameFramework_Runtime_ResourceUpdateStartEventArgs);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("EventId", get_EventId, null);
		L.RegVar("Id", get_Id, null);
		L.RegVar("Name", get_Name, null);
		L.RegVar("DownloadPath", get_DownloadPath, null);
		L.RegVar("DownloadUri", get_DownloadUri, null);
		L.RegVar("CurrentLength", get_CurrentLength, null);
		L.RegVar("CompressedLength", get_CompressedLength, null);
		L.RegVar("RetryCount", get_RetryCount, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityGameFramework_Runtime_ResourceUpdateStartEventArgs(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityGameFramework.Runtime.ResourceUpdateStartEventArgs obj = new UnityGameFramework.Runtime.ResourceUpdateStartEventArgs();
				ToLua.PushSealed(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityGameFramework.Runtime.ResourceUpdateStartEventArgs.New");
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
			GameFramework.Resource.ResourceUpdateStartEventArgs arg0 = (GameFramework.Resource.ResourceUpdateStartEventArgs)ToLua.CheckObject(L, 1, typeof(GameFramework.Resource.ResourceUpdateStartEventArgs));
			UnityGameFramework.Runtime.ResourceUpdateStartEventArgs o = UnityGameFramework.Runtime.ResourceUpdateStartEventArgs.Create(arg0);
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
			UnityGameFramework.Runtime.ResourceUpdateStartEventArgs obj = (UnityGameFramework.Runtime.ResourceUpdateStartEventArgs)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.ResourceUpdateStartEventArgs));
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
			LuaDLL.lua_pushinteger(L, UnityGameFramework.Runtime.ResourceUpdateStartEventArgs.EventId);
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
			UnityGameFramework.Runtime.ResourceUpdateStartEventArgs obj = (UnityGameFramework.Runtime.ResourceUpdateStartEventArgs)o;
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
	static int get_Name(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.ResourceUpdateStartEventArgs obj = (UnityGameFramework.Runtime.ResourceUpdateStartEventArgs)o;
			string ret = obj.Name;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Name on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DownloadPath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.ResourceUpdateStartEventArgs obj = (UnityGameFramework.Runtime.ResourceUpdateStartEventArgs)o;
			string ret = obj.DownloadPath;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index DownloadPath on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DownloadUri(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.ResourceUpdateStartEventArgs obj = (UnityGameFramework.Runtime.ResourceUpdateStartEventArgs)o;
			string ret = obj.DownloadUri;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index DownloadUri on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CurrentLength(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.ResourceUpdateStartEventArgs obj = (UnityGameFramework.Runtime.ResourceUpdateStartEventArgs)o;
			int ret = obj.CurrentLength;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index CurrentLength on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CompressedLength(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.ResourceUpdateStartEventArgs obj = (UnityGameFramework.Runtime.ResourceUpdateStartEventArgs)o;
			int ret = obj.CompressedLength;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index CompressedLength on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_RetryCount(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.ResourceUpdateStartEventArgs obj = (UnityGameFramework.Runtime.ResourceUpdateStartEventArgs)o;
			int ret = obj.RetryCount;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index RetryCount on a nil value");
		}
	}
}


﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityGameFramework_Runtime_NetworkErrorEventArgsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityGameFramework.Runtime.NetworkErrorEventArgs), typeof(GameFramework.Event.GameEventArgs));
		L.RegFunction("Create", Create);
		L.RegFunction("Clear", Clear);
		L.RegFunction("New", _CreateUnityGameFramework_Runtime_NetworkErrorEventArgs);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("EventId", get_EventId, null);
		L.RegVar("Id", get_Id, null);
		L.RegVar("NetworkChannel", get_NetworkChannel, null);
		L.RegVar("ErrorCode", get_ErrorCode, null);
		L.RegVar("SocketErrorCode", get_SocketErrorCode, null);
		L.RegVar("ErrorMessage", get_ErrorMessage, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityGameFramework_Runtime_NetworkErrorEventArgs(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityGameFramework.Runtime.NetworkErrorEventArgs obj = new UnityGameFramework.Runtime.NetworkErrorEventArgs();
				ToLua.PushSealed(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityGameFramework.Runtime.NetworkErrorEventArgs.New");
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
			GameFramework.Network.NetworkErrorEventArgs arg0 = (GameFramework.Network.NetworkErrorEventArgs)ToLua.CheckObject(L, 1, typeof(GameFramework.Network.NetworkErrorEventArgs));
			UnityGameFramework.Runtime.NetworkErrorEventArgs o = UnityGameFramework.Runtime.NetworkErrorEventArgs.Create(arg0);
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
			UnityGameFramework.Runtime.NetworkErrorEventArgs obj = (UnityGameFramework.Runtime.NetworkErrorEventArgs)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.NetworkErrorEventArgs));
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
			LuaDLL.lua_pushinteger(L, UnityGameFramework.Runtime.NetworkErrorEventArgs.EventId);
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
			UnityGameFramework.Runtime.NetworkErrorEventArgs obj = (UnityGameFramework.Runtime.NetworkErrorEventArgs)o;
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
	static int get_NetworkChannel(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.NetworkErrorEventArgs obj = (UnityGameFramework.Runtime.NetworkErrorEventArgs)o;
			GameFramework.Network.INetworkChannel ret = obj.NetworkChannel;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index NetworkChannel on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ErrorCode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.NetworkErrorEventArgs obj = (UnityGameFramework.Runtime.NetworkErrorEventArgs)o;
			GameFramework.Network.NetworkErrorCode ret = obj.ErrorCode;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index ErrorCode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SocketErrorCode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.NetworkErrorEventArgs obj = (UnityGameFramework.Runtime.NetworkErrorEventArgs)o;
			System.Net.Sockets.SocketError ret = obj.SocketErrorCode;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index SocketErrorCode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ErrorMessage(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.NetworkErrorEventArgs obj = (UnityGameFramework.Runtime.NetworkErrorEventArgs)o;
			string ret = obj.ErrorMessage;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index ErrorMessage on a nil value");
		}
	}
}


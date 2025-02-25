﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityGameFramework_Runtime_SettingComponentWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityGameFramework.Runtime.SettingComponent), typeof(UnityGameFramework.Runtime.GameFrameworkComponent));
		L.RegFunction("Save", Save);
		L.RegFunction("GetAllSettingNames", GetAllSettingNames);
		L.RegFunction("HasSetting", HasSetting);
		L.RegFunction("RemoveSetting", RemoveSetting);
		L.RegFunction("RemoveAllSettings", RemoveAllSettings);
		L.RegFunction("GetBool", GetBool);
		L.RegFunction("SetBool", SetBool);
		L.RegFunction("GetInt", GetInt);
		L.RegFunction("SetInt", SetInt);
		L.RegFunction("GetFloat", GetFloat);
		L.RegFunction("SetFloat", SetFloat);
		L.RegFunction("GetString", GetString);
		L.RegFunction("SetString", SetString);
		L.RegFunction("GetObject", GetObject);
		L.RegFunction("SetObject", SetObject);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("Count", get_Count, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Save(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
			obj.Save();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAllSettingNames(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
				string[] o = obj.GetAllSettingNames();
				ToLua.Push(L, o);
				return 1;
			}
			else if (count == 2)
			{
				UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
				System.Collections.Generic.List<string> arg0 = (System.Collections.Generic.List<string>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.List<string>));
				obj.GetAllSettingNames(arg0);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityGameFramework.Runtime.SettingComponent.GetAllSettingNames");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasSetting(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
			string arg0 = ToLua.CheckString(L, 2);
			bool o = obj.HasSetting(arg0);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveSetting(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
			string arg0 = ToLua.CheckString(L, 2);
			obj.RemoveSetting(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveAllSettings(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
			obj.RemoveAllSettings();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBool(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
				string arg0 = ToLua.CheckString(L, 2);
				bool o = obj.GetBool(arg0);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 3)
			{
				UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
				string arg0 = ToLua.CheckString(L, 2);
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				bool o = obj.GetBool(arg0, arg1);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityGameFramework.Runtime.SettingComponent.GetBool");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetBool(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
			string arg0 = ToLua.CheckString(L, 2);
			bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
			obj.SetBool(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInt(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
				string arg0 = ToLua.CheckString(L, 2);
				int o = obj.GetInt(arg0);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 3)
			{
				UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
				string arg0 = ToLua.CheckString(L, 2);
				int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
				int o = obj.GetInt(arg0, arg1);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityGameFramework.Runtime.SettingComponent.GetInt");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetInt(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
			string arg0 = ToLua.CheckString(L, 2);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
			obj.SetInt(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFloat(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
				string arg0 = ToLua.CheckString(L, 2);
				float o = obj.GetFloat(arg0);
				LuaDLL.lua_pushnumber(L, o);
				return 1;
			}
			else if (count == 3)
			{
				UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
				string arg0 = ToLua.CheckString(L, 2);
				float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
				float o = obj.GetFloat(arg0, arg1);
				LuaDLL.lua_pushnumber(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityGameFramework.Runtime.SettingComponent.GetFloat");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetFloat(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
			string arg0 = ToLua.CheckString(L, 2);
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
			obj.SetFloat(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetString(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
				string arg0 = ToLua.CheckString(L, 2);
				string o = obj.GetString(arg0);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else if (count == 3)
			{
				UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
				string arg0 = ToLua.CheckString(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				string o = obj.GetString(arg0, arg1);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityGameFramework.Runtime.SettingComponent.GetString");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetString(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
			string arg0 = ToLua.CheckString(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			obj.SetString(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetObject(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
				System.Type arg0 = ToLua.CheckMonoType(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				object o = obj.GetObject(arg0, arg1);
				ToLua.Push(L, o);
				return 1;
			}
			else if (count == 4)
			{
				UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
				System.Type arg0 = ToLua.CheckMonoType(L, 2);
				string arg1 = ToLua.CheckString(L, 3);
				object arg2 = ToLua.ToVarObject(L, 4);
				object o = obj.GetObject(arg0, arg1, arg2);
				ToLua.Push(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityGameFramework.Runtime.SettingComponent.GetObject");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetObject(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)ToLua.CheckObject(L, 1, typeof(UnityGameFramework.Runtime.SettingComponent));
			string arg0 = ToLua.CheckString(L, 2);
			object arg1 = ToLua.ToVarObject(L, 3);
			obj.SetObject(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Count(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityGameFramework.Runtime.SettingComponent obj = (UnityGameFramework.Runtime.SettingComponent)o;
			int ret = obj.Count;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Count on a nil value");
		}
	}
}


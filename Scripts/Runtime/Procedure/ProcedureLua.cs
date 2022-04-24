using GameFramework;
using GameFramework.Localization;
using System;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Procedure;

namespace UnityGameFramework.Runtime
{
    public class ProcedureLua : ProcedureBase
    {
        private LuaComponent m_LuaComponent = null;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            //资源加载完成开始加载LUA
            m_LuaComponent = GameEntry.GetComponent<LuaComponent>();

            if (m_LuaComponent == null) Debug.Log("lua component is null");

            //初始化lua
            m_LuaComponent.Initialization();
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        }
    }
}

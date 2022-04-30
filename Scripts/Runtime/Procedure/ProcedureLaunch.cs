using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace UnityGameFramework.Runtime
{
    public class ProcedureLaunch : ProcedureBase
    {
        private BaseComponent m_BaseComponent;


        // ��Ϸ��ʼ��ʱִ�С�
        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
        }

        // ÿ�ν����������ʱִ�С�
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            string welcomeMessage = Utility.Text.Format("Hello Game Framework {0}.", Version.GameFrameworkVersion);

            // ��ӡ���Լ�����־�����ڼ�¼��������־��Ϣ
            Log.Debug(welcomeMessage);

            // ��ӡ��Ϣ������־�����ڼ�¼��������������־��Ϣ
            Log.Info(welcomeMessage);

            // ��ӡ���漶����־�������ڷ����ֲ������߼����󣬵��в��ᵼ����Ϸ�������쳣ʱʹ��
            Log.Warning(welcomeMessage);

            // ��ӡ���󼶱���־�������ڷ��������߼����󣬵��в��ᵼ����Ϸ�������쳣ʱʹ��
            Log.Error(welcomeMessage);

            // ��ӡ���ش��󼶱���־�������ڷ������ش��󣬿��ܵ�����Ϸ�������쳣ʱʹ�ã���ʱӦ�����������̻��ؽ���Ϸ���
            Log.Fatal(welcomeMessage);

            m_BaseComponent = GameEntry.GetComponent<BaseComponent>();

            
        }

        // ÿ����ѯִ�С�
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            
            if(m_BaseComponent.EditorResourceMode)
            {
                ChangeState<ProcedureLua>(procedureOwner);
            }
        }

        // ÿ���뿪�������ʱִ�С�
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        // ��Ϸ�˳�ʱִ�С�
        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);
        }
    }
}
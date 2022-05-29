using GameFramework.Event;

namespace GameFramework.Lua
{
    /// <summary>
    /// ��Ϸ�����̨��Ϸ��ͣ�¼�
    /// </summary>
    public sealed class OnApplicationPauseEventArgs : GameEventArgs
    {
        /// <summary>
        /// ��ʼ����Ϸ�����̨��Ϸ��ͣ�¼�
        /// </summary>
        /// <param name="isPause">�Ƿ���ͣ</param>
        public OnApplicationPauseEventArgs(bool isPause)
        {
            IsPause = isPause;
        }

        public bool IsPause
        {
            get;
            private set;
        }

        public override int Id
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}

using GameFramework.Event;

namespace GameFramework.Lua
{
    /// <summary>
    /// 游戏进入后台游戏暂停事件
    /// </summary>
    public sealed class OnApplicationPauseEventArgs : GameEventArgs
    {
        /// <summary>
        /// 初始化游戏进入后台游戏暂停事件
        /// </summary>
        /// <param name="isPause">是否暂停</param>
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

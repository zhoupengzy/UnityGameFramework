namespace GameFramework.Lua
{
    public sealed class LoadLuaBoundleSuccessEventArgs : GameFrameworkEventArgs
    {
        public LoadLuaBoundleSuccessEventArgs(string luaAssetName, object userData)
        {
            LuaAssetName = luaAssetName;
            UserData = userData;
        }

        public string LuaAssetName
        {
            get;
            private set;
        }

        public object UserData
        {
            get;
            private set;
        }

        public override void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}

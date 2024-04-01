using System;

namespace mLAMB
{
    
    public static class RecentCommand
    {
        private static string _data
        {
            get
            {
                
                return mLAMB.Properties.Settings.Default.recent_cmd;
            }
            set
            {
                mLAMB.Properties.Settings.Default.recent_cmd = value;
                mLAMB.Properties.Settings.Default.Save();
            }
        }
        public static string Load()
        {
            return _data;
        }
        public static void Save(string data)
        {
            _data = data;
        }
    }
}

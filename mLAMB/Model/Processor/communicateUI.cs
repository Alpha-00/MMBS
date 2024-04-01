using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mLAMB
{
    public partial class Processor
    {
        public partial class Command
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="cmd"></param>
            /// <param name="def">Default Value: Return def when cmd can't work\nIt's should be 100</param>
            /// <returns></returns>
            public bool ask(string cmd, int level, bool def, params string[] message)
            {
                // the less level the more its need to get feedback
                if (level <= Properties.Settings.Default.setConProc)
                    switch (cmd)
                    {
                        case "y/n":
                            {
                                shell($" ?? {message[0] ?? "y/n"}\n(y/n)>>");
                                string cache = shellfeed("y/n");
                                if (string.IsNullOrWhiteSpace(cache)) return def;
                                else return cache == "y" ? true : cache == "n" ? false : def;
                            }
                            break;
                    }
                return def;
            }
        }
    }
}

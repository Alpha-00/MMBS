using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMB.Lib
{
    public class Database
    {

    }
    public class Enum
    {
        //IsSupported
        public enum Source
        {
            platinmods,
            /// <summary>
            /// Haven't supported yet
            /// </summary>
            NONE
            ,
            /// <summary>
            /// Self supported
            /// </summary>
            LAMB
        }
    }
    public class Type
    {
        public class Link
        {
            public string link;
            public Uri uri;
            public Enum.Source source;
            public DateTime date;
            public outputMMBS output;
            public Link(string link)
            {
                this.link = link;
                this.uri = new Uri(link);
                CheckSource();
            }
            public void CheckSource()
            {
                if (uri.Host.Contains("platinmods.com"))
                {
                    this.source = Enum.Source.platinmods;
                }
            }

        }
        public class sourceHTML
        {
            public string source;
            public sourceHTML(string source)
            {
                this.source = source;
            }
        }
        public class outputMMBS
        {
            public Dictionary<string, string> FreeData;
        }
    }
}

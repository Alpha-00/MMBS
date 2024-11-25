using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace MMBS
{
    public partial class ZZZOptions : Form
    {
        public ZZZOptions()
        {
            InitializeComponent();
            InitItem();
        }
        public void InitItem()
        {
          //  if (System.IO.File.Exists("C:\BloggerSupporter\CustomOption.txt"))
        }
    }
}
namespace MyConfigSupporter
{
    public class BBtxtFile
    {
        public Collection Data;
        public Collection OnWork;
        public string RAW;
        public BBtxtFile(string source)
        {
            try
            {
                RAW = System.IO.File.ReadAllText(source);
                ParseToData();
            }
            catch(Exception e)
            {

            }
            void ParseToData()
            {
                Data = parse(RAW);
            }
        }
        public Collection parse(string RAW)
        {
            //Init
            Collection cache = new Collection();
            string[] raw = RAW.Split('\n');
            string head = "0000";
            string content="";
            //Start
            foreach (string line in raw)
            {
                head = line.Remove(4);
                content = line.Substring(4);
                switch (head)
                {
                    case "****": special_command(content);break;
                    case "####": Comment(content);break;
                }
            }
            return cache;
            
            
            
        }
    // Process Parser
        public void Reset() => Data = new Collection();
        public string Nothing(string content) => "";
        public string Comment(string content)
        {
            Console.WriteLine(content);
            return "";
        }
        public string Variable(string content)
        {
            Console.WriteLine("Define a new variable");

            return "";
        }
        public string special_command(string content)
        {
            if (content == "bbtxt.v1.customoption.default")
            {
                OnWork.specific = "bbtxt.v1.customoption.default";
                
            }
            else if (content.Contains("="))
            {
                string code = content.Split('=')[0];
                string res = content.Substring(code.Length);
            }
            return "";
        }

    /// <summary>
    /// Use for contruct data
    /// </summary>
    public class Collection
        {
            public Collection[] Data;
            /// <summary>
            /// <strong>EXAM</strong><br/>
            /// bbtxt.v1.customoption.default<br/>
            ///
            /// collection
            /// text
            /// </summary>
            public string specific;
            /// <summary>
            /// v1
            /// </summary>
            public string version;
            public Value value;
            /// <summary>
            /// Working with inside Data, default = -1
            /// </summary>
            public int onWork = -1;
            public class Value
            {
                public Value() { }
            }
            public class Keyvar<T> : Value
            {
                string key;
                T value;


                T get => value;
                void set(T n) => value = n;

            }
            public class Keyvar : Keyvar<string>
            {

            }
        }
        
    }
}

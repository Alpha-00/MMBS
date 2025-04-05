//For Post Data Define
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
namespace MMBS
{
    public class DefineInfoPack
    {
        public class relationship
        {
            List<string> rdata;
            List<string> rcode;
            string rname;
        }
        public class imageinfo
        {
            public string name;
            public string codename;
            /// <summary>
            /// jpg png gif
            /// </summary>
            public string packtype;
            /// <summary>
            /// by link, share to drive,...
            /// </summary>
            public string sharetype;
            public bool isLocal;
            /// <summary>
            /// Upload Url
            /// </summary>
            public string link;
            /// <summary>
            /// Local Direction
            /// </summary>
            public string dir;
            public bool enable;
            public List<relationship> duplicant;
            public double height;
            public double width;
            public System.Drawing.Image image;
            public imageinfo()
            {
                duplicant = new List<relationship>();
            }
            public imageinfo(string name, string dir, string link, int height, int width, System.Drawing.Image image)
            {
                duplicant = new List<relationship>();
                this.name = name;
                this.dir = dir;
                this.link = link;
                this.height = Convert.ToDouble(height);
                this.width = Convert.ToDouble(width);
                this.image = image;
            }
        }
        public class Linker
        {
            public string link;
            public bool actived;//can connect
            public bool check;//wanna use
            public bool legal;
            public string size;
            public string usefor;
            public string server;
            public string cache;
            public struct datapart { string name; dynamic data; }
            public string shortenlink;
            public string hidenlink;
            public string linkalias;//Part to show like name
            public string mark;//link 123:, play:
            public string FAicon = "download";//https://fontawesome.com/v4.7.0/icons/
            public string host;
            public bool IsMarked;
            public object Spec_Data;

            public Linker(string name)
            {
                switch (name)
                {
                    case "download": check = true; usefor = "download";linkalias = "Download";
                        break;
                    case "obb": usefor = "download"; linkalias = "OBB"; break;
                    case "omirror": usefor = "download"; linkalias = "Mirror"; break;
                    case "mirror": check = true; usefor = "mirror"; linkalias = "Mirror"; FAicon = "rocket"; break;
                }
            }
            public Linker()
            {

            }
            public void Check()
            {
                legal = true;
                //SimpleTextCheck
                if (String.IsNullOrWhiteSpace(link)) legal = false;
                else if (!link.Contains('.')) legal = false;
                else if (link.Contains('.')) if (!link.ToLower().Contains("://")) link = "http://"+link.Trim(' ');
                //Check online here
                //
                if (legal) link = link.Trim(' ');
                if (linkalias == "Download") check = legal;//check only for  download
            }
        }
    }
    public class PostDataBundle : ICloneable
    {
        /// <summary>
        /// Init PostDataBunble
        /// </summary>
        public PostDataBundle()
        {
            folderlink = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            
            //App Info
            appInfo.androidReq = "";
            appInfo.androidReqcode = 0;
            appInfo.datasource = "";
            appInfo.description.rawText = "";
            appInfo.description.bold = true;
            appInfo.description.noline = true;
            appInfo.description.spec_bold = "";
            appInfo.description.spec_boldnoline = "";
            appInfo.description.spec_noline = "";
            appInfo.miscellaneous = new Dictionary<string, string>();
            appInfo.icon = new DefineInfoPack.imageinfo();
            appInfo.icon.codename = "";
            appInfo.icon.dir = "";
            appInfo.icon.enable = false;
            appInfo.icon.height = 0;
            appInfo.icon.width = 0;
            appInfo.icon.link = "";
            appInfo.icon.isLocal = false;
            appInfo.icon.name = "icon";
            appInfo.icon.packtype = "";
            appInfo.icon.sharetype = "bylink";
            appInfo.extpermReq = false;
            appInfo.internetReq = false;
            appInfo.rootReq = false;
            appInfo.obbReq = false;
            appInfo.name = "App name";
            appInfo.nameword = new List<string>();
            appInfo.searchkeyword = "";
            appInfo.seriesver = "";
            appInfo.size = "";
            appInfo.sizeinbyte = 0;
            appInfo.version = "";
            //Download Link
            downloadlink.Downloadlink = new DefineInfoPack.Linker("download");
            downloadlink.OBBlink = new DefineInfoPack.Linker("obb");
            downloadlink.OMirrorlink = new DefineInfoPack.Linker("omirror");
            downloadlink.linklist = new List<DefineInfoPack.Linker>();
            //
            modInfo.UI = new ProjectInterfaceData.ModType(0);
            postMedia = new PostMediapack();
            postMedia.ImageList = new List<DefineInfoPack.imageinfo>();
            postMedia.VideoReview.Cover = new DefineInfoPack.imageinfo();
            postMedia.VideoReview.Cover.enable = false;
            postMedia.VideoReview.link = "";
            //
            credit = new creditpack();
            //
            appInfo.dataSourceQuery = "hl=en";
        }
        public PostDataBundle(string folderlink, appinfopack appinfo, PostMediapack postmedia, DownloadLinkpack downloadlink, modinfopack modinfo, creditpack credit)
        {
            this.folderlink = folderlink;
            this.appInfo = appinfo;
            this.postMedia = postmedia;
            this.downloadlink = downloadlink;
            this.modInfo = modinfo;
            this.credit = credit;
        }
        
        public string folderlink;
        public string specialcmd;
        public appinfopack appInfo;
        public PostMediapack postMedia;
        public DownloadLinkpack downloadlink;
        public modinfopack modInfo;
        public creditpack credit;
        public Dictionary<string,string> custom_data;
        public struct appinfopack
        {
            public string name;
            public string packageName;
            public Dictionary<string, string> miscellaneous;
            public List<string> nameword;//after analyst
            public string searchkeyword;
            public string version;
            public long sizeinbyte;
            public string size;
            public string seriesver; // series version
            public string androidReq;
            public decimal androidReqcode;
            public bool extpermReq;
            public bool internetReq;
            public bool rootReq;
            public bool obbReq;
            public bool armv8aReq;
            public bool playCheckMessage;
            public bool menuModFlag;
            public DefineInfoPack.imageinfo icon;
            public Descriptionpack description;
            public string datasource;
            public string datasourcetype;//play,apkpure,...
            public string datasourcemask;//Play Store, APKpure
            public string datasourcepage;//cache
            public string dataSourceQuery;//hl=en
            public struct Descriptionpack
            {
                public string rawText;
                public string rtf;
                public string spec_boldnoline;
                public string spec_bold;
                public string spec_noline;
                public bool bold;
                public bool noline;
                public string cache;
                public string[] sentence;
                public List<List<string>> result;
                public string GetDat()
                {
                    if (bold && noline) return spec_boldnoline;
                    else if (!bold && noline) return spec_noline;
                    else if (bold && !noline) return spec_bold;
                    else return rawText;
                }
                public void SetDat(string data)
                {
                    if (!bold && !noline)
                    {
                        rawText = data;
                        spec_bold = processAutoBold(data);
                        spec_noline = processNoline(data);
                        spec_boldnoline = processNoline(spec_bold);
                        
                    }
                    else if (!bold&& noline)
                    {
                        spec_noline = data;
                    }
                    else if (bold &&!noline)
                    {
                        spec_bold = data;
                    }
                    else
                    {
                        spec_boldnoline = data;
                    }
                }
                public string processAutoBold(string data)
                {
                    //Process Here
                    return data;
                }
                public string processNoline(string data)
                {
                    string cache = data;
                    if (!string.IsNullOrEmpty(cache)) { 
                    
                    while (cache.Contains("\n\n"))
                    {
                        cache = cache.Replace("\n\n", "\n");
                    }
                    }
                    return cache;
                }
                public string OldprocessInputProtocoForPlayProc(string desc,string Desc)//desc stock & desc simple bold
                {
                    rawText = desc;
                    spec_bold = Desc;
                    bold = true;
                    noline = true;
                    spec_boldnoline = processNoline(spec_bold);
                    spec_noline = processNoline(desc);
                    
                    return "";
                }
            }
            
        }
        public class PostMediapack
        {
            public List<DefineInfoPack.imageinfo> ImageList;
            public bool ImageInScript;
            public VideoReviewpack VideoReview;
            public struct VideoReviewpack
            {
                public DefineInfoPack.imageinfo Cover;
                public string ID;
                public string link;
                public string generateID()
                {
                    if (!string.IsNullOrWhiteSpace(link))
                    {
                        var uri = new Uri(link);

                        // you can check host here => uri.Host <= "www.youtube.com"

                        var query = System.Web.HttpUtility.ParseQueryString(uri.Query);

                        //exception for youtu.be/{ID}
                        if (query.Count == 0)
                        {
                            ID = uri.Segments[1];
                            if (ID.Contains("/"))
                                ID = ID.Remove(ID.IndexOf("/"));
                            return ID;
                        }

                        ID = string.Empty;

                        if (query.AllKeys.Contains("v"))
                        {
                            ID = query["v"];
                        }
                        else
                        {
                            ID = uri.Segments.Last();
                        }
                    }
                    
                    return ID;
                }
                public void ImportFromLink (string link,string dir)
                {
                    if (!string.IsNullOrWhiteSpace(link))
                    {
                        this.link = link;
                        generateID();
                        this.link = "https://www.youtube.com/embed/" + this.ID;//Some miss here//Nhớ thêm vô đó
                        OldProcessor.ProcSupporter.ImageDownloader image = new OldProcessor.ProcSupporter.ImageDownloader("https://i.ytimg.com/vi/" + ID + "/0.jpg", "Review", dir);
                        Cover = new DefineInfoPack.imageinfo(image.name, image.ImageDir, image.Link, image.height, image.width, image.image);
                    }
                }
            }
            public void ImportImagelistFromImageDownloadList(OldProcessor.ProcSupporter.ImageDownloader[] images)
            {

                if (images != null)
                {
                    ResetImageList();
                    for (int i = 0; i < images.Length; i++)
                    {
                        ImageList.Add(new DefineInfoPack.imageinfo(images[i].name, images[i].ImageDir, images[i].Link, images[i].height, images[i].width, images[i].image));
                    }
                }
            }
            public void ResetImageList()
            {
                ImageList = new List<DefineInfoPack.imageinfo>();
            }
        }
        public struct DownloadLinkpack
        {
            public DefineInfoPack.Linker Downloadlink;
            public DefineInfoPack.Linker OBBlink;
            public DefineInfoPack.Linker OMirrorlink; //Official Mirror Link
            public List<DefineInfoPack.Linker> linklist;//list of Mirror Link
            public bool MListEnable;
            
        }
        public struct modinfopack
        {
            public string modtype;
            //
            //Summary:
            //      "Paid" or "Mod"
            public string moddata;
            public bool usedata;
            public ProjectInterfaceData.ModType UI;
        }
        public class creditpack
        {
            public static string definestring = "<one name=\"[Cname]\" host=\"[Chost]\">[Csub]</one>";
            public string creditFileDir = "C:\\BloggerSupporter\\creditList.xml";
            public static bool isFirstRun = true;
            public static string creditStringForm = "$$$.creditNameString$$$$$$$.creditHostString$$$$";
            public static string creditNameFormat = "$$$.creditName$$$$";
            public static string creditHostFormat = " ($$$.creditHost$$$$)";
            /// <summary>
            /// This string use for store that I don't know where to get
            /// </summary>
            public static string tmp = "";
            public int nowIndex = 0;
            public int defIndex = 0;
            public CreditsList.CreditItem now = new CreditsList.CreditItem();
            enum xmlkeylist
            {
                credits,//Root
                item,//Child
                numofCredits,
                name,
                host,
                time,
                last,
                isDef
            };
            public creditpack()
            {
                Console.WriteLine("***Debug creditpack_new");
                
                if (isFirstRun)
                {
                    Console.WriteLine("***###First Run");
                    LoadData();
                    isFirstRun = false;
                    Console.WriteLine("***///First Run");
                }
                if (System.IO.File.Exists("C:\\BloggerSupporter\\creditList.txt"))
                {
                    ConvertOldVerToNewVer();
                }
                Console.WriteLine("///Debug");
            }
            public int Search_and_Set(string name)
            {
                int i = 0;
                try
                {

                    this.now= CreditsList.list.First((x) => { i++; return x.name == name; });
                }
                catch(Exception e)
                {
                    i = 0;
                }
                i--;
                if (i > 0)
                {
                    this.nowIndex = i;
                }
                return -1;
            }
            public void ConvertOldVerToNewVer()
            {


                using (System.IO.StreamReader cache = System.IO.File.OpenText("C:\\BloggerSupporter\\creditList.txt"))
                {
                    string line = cache.ReadLine();
                    string cmdtitle;
                    string cmddata;
                    string[] cmdData;
                    while (!string.IsNullOrEmpty(line))
                    {
                        if (line.Contains(":="))
                        {
                            cmdtitle = line.Remove(line.IndexOf(":="));
                            cmddata = line.Substring(line.IndexOf(":=") + 2);
                        }
                        else
                        {
                            cmdtitle = line.Trim(' ');
                            cmddata = "";
                        }
                        cmdData = null;
                        if (cmddata.Contains("::==::"))
                        {
                            cmdData = cmddata.Split("::==::");

                        }
                        else
                        {
                            List<string> justcache = new List<string>();
                            justcache.Add(cmddata);
                            cmdData = justcache.ToArray();
                        }
                        switch (cmdtitle)
                        {
                            case "creditStringForm": break;
                            case "creditNameFormat": break;
                            case "creditHostFormat": break;
                            case "one":
                                if (cmdData != null)
                                    if (cmdData.Length >= 1 && cmdData.Length <= 4)
                                        CreditsList.New(cmdData[0], cmdData.Length >= 2 ? cmdData[1] : "", cmdData.Length >= 3 ? Convert.ToInt32(cmdData[2]) : 0, cmdData.Length == 4 ? cmdData[3].ToLower() == "true" : false);
                                break;
                        }
                        line = cache.ReadLine();
                    }
                }
                System.IO.File.Delete("C:\\BloggerSupporter\\creditList.txt");
                    
                
                
            }
            public bool LoadData()
            {
                if (System.IO.File.Exists(creditFileDir))
                {
                    Console.Write("***###Load Data ");
                    XmlReader cache = XmlReader.Create(creditFileDir);
                    Console.WriteLine($"{(!(cache == null))} {cache.ReadState}");
                    try
                    {
                        cache.MoveToContent();
                    }
                    catch (Exception e)
                    {
                        if (e.Message.ToLower().Contains("root"))
                        {
                            cache.Close();
                            Init();
                            return true;
                        }
                    }
                    int indexer = 0;
                    while (cache.Read())
                    {

                        Console.WriteLine("***###***"+cache.ToString());
                        switch (cache.NodeType)
                        {
               
                            case XmlNodeType.Element:
                                {
                                    Console.WriteLine(cache.AttributeCount);
                                    if (cache.Name == "item")
                                    {
                                        Dictionary<string, string> minicache = new Dictionary<string, string>() { { "name", "" }, { "host", "" }, { "isDef", "" }, { "time", "" }, { "last", "" }  };
                                        
                                        if (cache.HasAttributes)
                                            for (int i =0; i < cache.AttributeCount; i++)
                                            {
                                                cache.MoveToAttribute(i);
                                                switch (cache.Name)
                                                {
                                                    case "name":minicache["name"] = cache.Value; break;
                                                    case "host": minicache["host"] = cache.Value; break;
                                                    case "isDef": minicache["isDef"] = cache.Value;  break;
                                                    case "time": minicache["time"] = cache.Value; break;
                                                    case "last": minicache["last"] = cache.Value; break;
                                                }
                                            }
                                        CreditsList.New(minicache["name"], minicache["host"], minicache["isDef"]=="true");
                                        if (minicache["isDef"] == "true") { nowIndex = indexer;defIndex = indexer; now = CreditsList.list.LastOrDefault(); }
                                        cache.MoveToContent();
                                        indexer++;
                                    }
                                } break;
                        }
                        
                    }
                    cache.Close();
                }
                else Init();
                return true;
                
            }
            public bool SaveData()
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.Encoding = Encoding.UTF8;
                if (!System.IO.File.Exists(creditFileDir)) System.IO.File.Create(creditFileDir).Close();
                XmlWriter cache = XmlWriter.Create(creditFileDir,settings);
                cache.WriteStartDocument();
                
                cache.WriteStartElement("credits");
                if (CreditsList.list.Count < 1)//Preset
                {
                    cache.WriteAttributeString("numberofCredits", "1");
                    cache.WriteStartElement("item");
                        {
                        cache.WriteAttributeString("name", "OfflineMods.Net");
                        cache.WriteAttributeString("host", "offlinemods");
                        cache.WriteAttributeString("isDef", "True");
                        };
                    cache.WriteEndElement();
                }
                else
                {
                    cache.WriteAttributeString("numberofCredits", CreditsList.list.Count.ToString());
                    foreach (creditpack.CreditsList.CreditItem item in CreditsList.list)
                    {
                        if (string.IsNullOrEmpty(item.name)) { continue; }
                        cache.WriteStartElement("item");
                        {
                            
                            cache.WriteAttributeString(xmlkeylist.name.ToString(),item.name);
                            if (!string.IsNullOrEmpty(item.host))
                            cache.WriteAttributeString(xmlkeylist.host.ToString(),item.host);
                            cache.WriteAttributeString(xmlkeylist.isDef.ToString(), item.isDefault.ToString());
                            cache.WriteAttributeString(xmlkeylist.time.ToString(), item.usedtime.ToString());
                        };
                        cache.WriteEndElement();
                        
                    }
                    
                }
                cache.WriteEndElement();
                cache.Close();
                return true;
            }
            public bool Init()
            {
                SaveData();
                LoadData();
                return true;
            }
            
            public class CreditsList
            {
                public static List<CreditItem> list = new List<CreditItem>();
                
                public string this[int c,bool u]
                {
                    get
                    {
                        if (u)
                            return list[c].ToString();
                        else
                            return list[c].ToString();
                    }
                    
                }
                public CreditItem this[int c]
                {
                    set
                    {
                        if (c < list.Count)
                            list[c] = value;
                    }
                }
                
                public static void New(string name,string host)
                {
                    if (!CheckDuplicate(name, host))
                    {
                        list.Add(new CreditItem(name, host));
                    }
                }
                public static bool New(string creditName, string creditHost, bool isDefault)
                {
                    list.Add(new CreditItem(creditName, creditHost,isDefault));
                    return true;
                }
                public static bool New(string creditName, string creditHost, int creditUsedtime, bool isDefault)
                {
                    if (!CheckDuplicate(creditName,creditHost))
                    list.Add(new CreditItem(creditName, creditHost, isDefault));
                    return true;
                }
                public static bool CheckDuplicate(string name,string host)
                {
                    
                    foreach (CreditItem cache in list.ToArray())
                    {
                        if (cache.name == name && cache.host == host)
                        {
                            return true;
                        }
                    }
                    return false;
                }
               public bool MarkDefault(CreditItem that)
                {
                    foreach (CreditItem cache in list.ToArray())
                    {
                        if (cache.name == that.name && cache.host == that.host)
                        {
                            cache.isDefault = true;
                            return true;
                        }
                    }
                    return false;
                }
                public class CreditItem
                {
                    public System.DateTime lastused;
                    public bool isDefault;
                    public int usedtime;
                    public string name;
                    public string host;
                    public CreditItem()
                    {

                    }
                    public CreditItem(string name, string host)
                    {
                        this.name = name;
                        this.host = host;
                    }
                    public CreditItem (string name, string host, bool isDef)
                    {
                        this.name = name;
                        this.host = host;
                        if (isDef)
                        foreach (CreditItem a in list)
                            {
                                a.isDefault = false;
                            }
                        this.isDefault = isDef;
                    }
                    public string GetPreview(bool UseHost)
                    {
                        if (name == "OfflineMods.Net") return name;
                        if (string.IsNullOrEmpty(name))
                        {
                            return "";
                        }
                        else if (UseHost)
                        {
                            string creditNameString = creditNameFormat.Replace("$$$.creditName$$$$", name);
                            string creditHostString = string.IsNullOrEmpty(host) ? "" : creditHostFormat.Replace("$$$.creditHost$$$$", host);
                            return ExtendingFunction.MultiReplace(creditStringForm, "$$$.creditNameString$$$$", creditNameString, "$$$.creditHostString$$$$", creditHostString);
                        }
                        else
                        {
                            return name;
                        }

                    }
                    public string GetToUse()
                    {
                        usedtime++;
                        return GetPreview(true);
                    }
                }
            }
        }
        /*public class creditpack
        { 
            public string creditFileDir = "C:\\BloggerSupporter\\creditList.txt";
            /*Format Type
             * creditStringForm:=$$$$
             * creditNameFormat:=$$$$
             * creditHostFormat:=$$$$
             * one:=$$$$::==::$$$$::==::$$$$::==::$$$$  {name,host,defautl,use time}
             */
         /*   bool isFirstTime = true;
            public bool New(string creditName, string creditHost, bool isDefault)
            {
                CreditsList.Add(new Credit(creditName, creditHost, 0, isDefault));
                return true;
            }
            public bool ReLoad(string creditName, string creditHost,int use_time, bool isDefault)
            {
                CreditsList.Add(new Credit(creditName, creditHost, use_time, isDefault));
                return true;
            }
            public  creditpack()
            {
                if (isFirstTime)
                {
                    CreditsList = new List<Credit>();
                    LoadData();
                    
                }
                foreach (Credit x in CreditsList)
                {
                    if (x.isdefault)
                    {
                        this.now = x;
                    }
                }
            }
            public bool LoadData()//only first time
            {
                if (System.IO.File.Exists(creditFileDir))
                {
                    using (System.IO.StreamReader cache=System.IO.File.OpenText(creditFileDir))
                    {
                        string line = cache.ReadLine();
                        string cmdtitle;
                        string cmddata;
                        string[] cmdData;
                        while (!string.IsNullOrEmpty(line))
                        {
                            if (line.Contains(":="))
                            {
                                cmdtitle = line.Remove(line.IndexOf(":="));
                                cmddata = line.Substring(line.IndexOf(":=") + 2);
                            }
                            else { cmdtitle = line.Trim(' ');
                                cmddata = "";
                            }
                            cmdData = null;
                            if (cmddata.Contains("::==::"))
                            {
                                cmdData = cmddata.Split("::==::");

                            }
                            else
                            {
                                List<string> justcache = new List<string>();
                                justcache.Add(cmddata);
                                cmdData = justcache.ToArray();
                            }
                            switch (cmdtitle)
                            {
                                case "creditStringForm": break;
                                case "creditNameFormat": break;
                                case "creditHostFormat": break;
                                case "one":
                                    if (cmdData != null)
                                        if (cmdData.Length >= 1&&cmdData.Length<=4)
                                            this.ReLoad(cmdData[0], cmdData.Length >= 2 ? cmdData[1] : "", cmdData.Length >= 3 ? Convert.ToInt32(cmdData[2]) : 0,cmdData.Length==4?cmdData[3].ToLower()=="true":false);
                                        break;
                            }
                            line = cache.ReadLine();
                        }
                    }
                    int i = -1;
                    for (int j = 0; j < CreditsList.Count; j++)
                    {
                        if (CreditsList[j].isdefault)
                            if (i == -1) i = j;
                            else
                            {
                                CreditsList[i].isdefault = false;
                                i = j;
                            }
                    }
                    defIndex = i;
                    return true;
                }
                else
                {
                    SaveData("new");
                    New("TigerOMs", "
         s",true);
                    return true ;
                }
            }
            public bool SaveData(string cmd)
            {
                if (cmd == "new")
                {
                    System.IO.File.WriteAllText(creditFileDir, "one:=TigerOMs::==::offlinemods::==::0::==::True");
                    return true;
                }

                using (System.IO.StreamWriter cache = new System.IO.StreamWriter(creditFileDir, false))
                {
                    cache.WriteLine(ReFormatData("creditStringForm",""));
                    cache.WriteLine(ReFormatData("creditNameFormat",""));
                    cache.WriteLine(ReFormatData("creditHostFormat",""));
                    if (CreditsList != null)
                        foreach (Credit x in CreditsList)
                        {
                            if (string.IsNullOrEmpty(x.creditHost)) cache.WriteLine(ReFormatData("one", x.creditName));
                            else
                            cache.WriteLine(ReFormatData("one",x.creditName,x.creditHost,x.use_time.ToString(),x.isdefault.ToString()));
                        }
                    else
                    {
                        SaveData("new");
                    }
                }
                return true;
                string ReFormatData(string key, params string[] data)
                {
                    if (!string.IsNullOrWhiteSpace(key))
                        if (data == null || data.Length == 0)
                        {
                            return key;
                        }
                        else
                        {
                            string cache = key + ":=";
                            foreach (string part in data)
                                if (!string.IsNullOrEmpty(part))
                                {
                                    cache += part + "::==::";
                                }
                            if (cache == key + ":=") return key;

                            cache = cache.Remove(cache.Length - 6);
                            return cache;
                        }
                    else return "";
                }
               
            }
            
            public  static List<Credit> CreditsList;
            public Credit now;
            public int nowIndex;
            public int defIndex;
            public static string creditStringForm = "$$$.creditNameString$$$$$$$.creditHostString$$$$";
            public static string creditNameFormat = "$$$.creditName$$$$";
            public static string creditHostFormat = " ($$$.creditHost$$$$)";
            public class Credit
            {
                public Credit(string cN,string cH,int ut,bool def)
                {
                    creditName = cN;
                    creditHost = cH;
                    use_time = ut;
                    isdefault = def;
                }
                public string creditName;
                public string creditHost;
                public bool isnull = true;
                public bool isdefault = false;
                public int use_time;
                public string GetPreview(bool UseHost)
                {
                  
                    if (string.IsNullOrEmpty(creditName))
                    {
                        return "";
                    }
                    else if (UseHost)
                    {
                        string creditNameString = creditNameFormat.Replace("$$$.creditName$$$$",creditName);
                        string creditHostString = string.IsNullOrEmpty(creditHost) ?"": creditHostFormat.Replace("$$$.creditHost$$$$", creditHost);
                        return MyFunction.MultiReplace(creditStringForm, "$$$.creditNameString$$$$", creditNameString, "$$$.creditHostString$$$$", creditHostString);
                    }
                    else
                    {
                        return creditName;
                    }
                    
                }
                public string GetToUse()
                {
                    use_time++;
                    return GetPreview(true);
                }
            }
        }*/
        public Object Clone()
        {
            return new PostDataBundle(this.folderlink, this.appInfo, this.postMedia, this.downloadlink, this.modInfo, this.credit);
        }
    }
}

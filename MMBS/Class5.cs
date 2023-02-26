//For Process Support Module
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Blogger.v3;
using Google.Apis.Blogger.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Auth.OAuth2;
using System.Threading;

using Newtonsoft.Json.Linq;
namespace MMBS
{
    
    class Class5 //Extent Function
    {
        
    }
    public static class StringExtension
    {
        public static string[] Split(this String str, string separator)
        {
            
            List<string> cache = new List<string>();
            string mini = str;
            
            while (mini.Contains(separator))
            {
                string proc_cache = mini.Remove(mini.IndexOf(separator));
                if (!string.IsNullOrEmpty(mini))
                {
                    cache.Add(proc_cache);
                }
                mini = mini.Substring(mini.IndexOf(separator) + separator.Length);

            }
            if (!string.IsNullOrEmpty(mini)) cache.Add(mini);
            return cache.ToArray();
            
        }
    }
    public static class UriExtension
    {
        public static string QueryKey(this Uri uri, string key)
        {
            if (String.IsNullOrEmpty(uri.Query) && (uri.Query.Trim() != "?")) return null;

            return (from string x in new List<string>(uri.Query.Split('?')) where (x.Split('=')[0] == key) select x.Split('=')[1]).SingleOrDefault();
        }
    }
    public static class MyFunction
    {
        public static String FirstCharEachWordUpcase(string str)//perword
        {
            string res = FirstCharUpcase(str.ToLower());
            string[] cache;
            char[] sep = new char[] { ' ', '.', ',', '!', '?' };
            
            foreach (char seperator in sep)
            {
                //System.Windows.Forms.MessageBox.Show(res.Contains(seperator).ToString());
                if (res.Contains(seperator))
                {
                    cache = res.Split(seperator);
                    res = "";
                   // System.Windows.Forms.MessageBox.Show(cache.Length.ToString());
                    foreach (string cache2 in cache)
                    {
                        res += FirstCharUpcase(cache2) + seperator;
                    }
                    res = res.Substring(0, res.Length - 2);
                }
            }
            return res;
        }
        public static string FirstCharUpcase(string cache)
        {
           // System.Windows.Forms.MessageBox.Show(Char.ToUpper(cache.ToCharArray()[0]).ToString());
            return Char.ToUpper(cache.ToCharArray()[0])+cache.Substring(1);
        }
        [System.Diagnostics.DebuggerStepThrough]
        public static string MultiReplace(string Data, params string[] par)
        {
            string cache = Data;
            if (par.Length % 2 == 0 && par.Length>=2)
            {
                for (int i  = 0; i+2<=par.Length; i = i+2)
                {
                    cache=cache.Replace(par[i], par[i + 1]);
                }
                
                return cache;
            }
            return "";
        }
        public static readonly string[] SizeSuffixes =
                  { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value, decimalPlaces); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }
    }
   
    public static class ApisCall
    {
        public class BloggerAPI
        {
            string ApplicationName = "MMBS";
            UserCredential credential;
            BloggerService service;
            public Post postcache;
            public string BlogID;
            public BloggerAPI(string BlogID)
            {
                this.BlogID = BlogID;
                string[] Scopes = { BloggerService.Scope.Blogger };
                using (var stream =
                    new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                                    Scopes,
                                    "user",
                                    CancellationToken.None,
                                    new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }
                service = new BloggerService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
                
            }
            public Google.Apis.Blogger.v3.Data.Post NewPost(string Title, string Content, string[] Labels, string CustomMetaData)
            {
                postcache = new Post();
                postcache.Title = Title;
                postcache.Content = Content;
                postcache.Labels = Labels.ToList<string>();
                postcache.CustomMetaData = CustomMetaData;
                return postcache;
            }
            public string SendPost(bool isDraft)
            {
                PostsResource.InsertRequest request = service.Posts.Insert(postcache, BlogID);
                request.IsDraft = isDraft;
                postcache = request.Execute();
                return postcache.Id;
            }
            public void OpenPostInBrowser()
            {
                System.Diagnostics.Process.Start("https://draft.blogger.com/blogger.g?blogID=" + BlogID + "#editor/postID=" + postcache.Id);
            }
        }
    }
}

﻿//For Process Support Module
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

using Imgur.API;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using System.Net.Http;
using Imgur.API.Models;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OpenQA.Selenium.DevTools;
using System.Net;
using Scriban.Parsing;
using static MMBS.DefineInfoPack;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MMBS
{

    class Class5 //Extent Function
    {

    }
    /// <summary>
    /// Custom Function for templating in string type
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Split a string by a long separator
        /// </summary>
        /// <param name="str"></param>
        /// <param name="separator">May have multiple character</param>
        /// <returns></returns>
        public static string[] Split(this String str, string separator)
        {

            List<string> cache = new List<string>();
            var mini = str;

            while (mini.Contains(separator))
            {
                var proc_cache = mini.Remove(mini.IndexOf(separator));
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
    /// <summary>
    /// Extends basic function for Image type
    /// </summary>
    public static class ImageExtension
    {
        /// <summary>
        /// Conver Image to a stream file using Memory Stream
        /// </summary>
        /// <param name="image"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static Stream ToStream(this System.Drawing.Image image, System.Drawing.Imaging.ImageFormat format)
        {
            var stream = new System.IO.MemoryStream();
            image.Save(stream, format);
            stream.Position = 0;
            return stream;
        }
    }
    /// <summary>
    /// Extends some uri behavior
    /// </summary>
    public static class UriExtension
    {
        /// <summary>
        /// Get value of the query part by finding base on key
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string QueryKey(this Uri uri, string key)
        {
            if (String.IsNullOrEmpty(uri.Query) && (uri.Query.Trim() != "?")) return null;

            return (from string x in new List<string>(uri.Query.Split('?')) where (x.Split('=')[0] == key) select x.Split('=')[1]).SingleOrDefault();
        }
    }
    public static class MyFunction
    {
        public static string CapitalizeEachWord(string str)
        {
            return Regex.Replace(str, @"\b\w", match=> match.Value.ToUpper());
        }
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
            return Char.ToUpper(cache.ToCharArray()[0]) + cache.Substring(1);
        }
        /*[System.Diagnostics.DebuggerStepThrough]*/
        public static string MultiReplace(string Data, params string[] par)
        {
            string cache = Data;
            if (par.Length % 2 == 0 && par.Length >= 2)
            {
                for (int i = 0; i + 2 <= par.Length; i = i + 2)
                {
                    cache = cache.Replace(par[i], par[i + 1]);
                }

                return cache;
            }
            return "";
        }
        [System.Diagnostics.DebuggerStepThrough]
        public static string MultiReplace(string Data, Dictionary<String, String> par)
        {
            string cache = Data;
            for (int i = 0; i <= par.Count; i++)
            {
                cache = cache.Replace(par.Keys.ElementAt(i), par.Values.ElementAt(i));
            }

            return cache;
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
    /// <summary>
    /// Service for External API
    /// </summary>
    public static class ApiService
    {
        public class BloggerAPI
        {
            const string ApplicationName = "MMBS";
            UserCredential credential;
            private BloggerService service;
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
        public class ImgurAPI
        {
            private string _id = "";
            private string _secret = "";
            private string _refresh = "";
            private string imgurID {
                get
                {
                    // If already load
                    if (!String.IsNullOrEmpty(_id))
                    {
                        return _id;
                    }
                    if (!loadIdFromFile())
                        loadIdFromForm();
                    if (String.IsNullOrEmpty(_id)) throw new Exception("Imgur ID required");
                    return _id;
                }
            }
            private string imgurSecret
            {
                get
                {
                    // If already load
                    if (!String.IsNullOrEmpty(_secret))
                    {
                        return _secret;
                    }
                    if (!loadIdFromFile())
                        loadIdFromForm();
                    if (String.IsNullOrEmpty(_secret)) throw new Exception("Imgur Secret required");
                    return _secret;
                }
            }
            private string imgurRefreshToken
            {
                get
                {
                    if (String.IsNullOrEmpty(_refresh)) return "";

                    return _refresh;

                }
                set
                {
                    _refresh = value;
                }
            }

            private class ImgurIdModel
            {
                public string id;
                public string secret;
                public string refresh;
                public string token;
                public ImgurIdModel(string id, string secret, string refresh = "", string token = "")
                {
                    this.id = id;
                    this.secret = secret;
                    this.refresh = refresh;
                    this.token = token;
                }
                public ImgurIdModel()
                {
                }
            }
            private bool loadIdFromFile()
            {
                // Loading from file
                var path = Class1.GetToken("imgurDir");
                if (!System.IO.File.Exists(path)) return false;
                var text = System.IO.File.ReadAllText(path);
                var data = System.Text.Json.JsonSerializer.Deserialize<ImgurIdModel>(text);
                if (data == null) return false;
                if (data.id == null) return false;
                if (data.secret == null) return false;
                
                this._secret = data.secret;
                this._id = data.id;
                this._refresh = data.refresh;
                return true;
            }
            private void saveToFile(string id = null, string secret = null, string refresh = null, string token = null)
            {
                var data = new ImgurIdModel(id??_id, secret??_secret, refresh??_refresh, token);
                var path = Class1.GetToken("imgurDir");
                var text = System.Text.Json.JsonSerializer.Serialize(data);
                System.IO.File.WriteAllText(path, text);
            }
            private void loadIdFromForm()
            {
                var form = new QueryForm.ImgurIdQueryForm();
                form.Location = new System.Drawing.Point((Screen.PrimaryScreen.WorkingArea.Width - form.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - form.Height) / 2);
                if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) { System.Windows.Forms.MessageBox.Show("Dialog closed. Process can't be continue"); }
                // Set data
                _id = form.imgurID;
                _secret = form.imgurSecret;

                // Save data
                var path = Class1.GetToken("imgurDir");
                var data = new ImgurIdModel(_id, _secret);
                var text = System.Text.Json.JsonSerializer.Serialize(data);
                System.IO.File.WriteAllText(path, text);
            }
            private void loadIdFromOAuth()
            {
                System.Net.HttpListener listener = new System.Net.HttpListener();
                if (!System.Net.HttpListener.IsSupported)
                {
                    System.Windows.Forms.MessageBox.Show("OAuth unsupported. Please contact dev to use secret file again");
                    return;
                }
                Imgur.API.Authentication.ApiClient client = new ApiClient(imgurID, imgurSecret);
                //client.SetOAuth2Token()
                HttpClient httpClient = new HttpClient();
                Imgur.API.Endpoints.OAuth2Endpoint oAuth = new OAuth2Endpoint(client, httpClient);
                
                System.Diagnostics.Process.Start(oAuth.GetAuthorizationUrl());
                listener.Prefixes.Add("https://*:7371/");
                listener.Start();
                var context = listener.GetContext();
                var uri = context.Request.Url;
                var getToken = oAuth.GetTokenAsync(uri.QueryKey("refresh_token"));
                getToken.Start();
                getToken.Wait();
                var result = getToken.Result;
                //var x = new IOAuth2Token();
                saveToFile(refresh: result.RefreshToken, token: result.AccessToken);
                listener.Stop();
                //https://localhost:7371/#access_token=c34c1a854d492673518910e75ad18fa68c52694d&expires_in=315360000&token_type=bearer&refresh_token=83588d9e0e94791e137476cb108eceb8cca67c6f&account_username=Honmyou&account_id=116285171
                //String oauthTarget = $"https://api.imgur.com/oauth2/authorize?client_id={imgurID}&response_type=code";
                //System.Diagnostics.Process.Start(oauthTarget);
                
                //listener.Prefixes.Add("https://*:7371/");
                //listener.Start();
                //var context = listener.GetContext();
                //var request = context.Request;
                //var url = request.Url;

                //listener.Stop();


            }
            /// <summary>
            /// Secret Key of Imgur
            /// </summary>
            private ApiClient _apiClient = null;
            public ApiClient apiClient {
                get
                {
                    if (_apiClient == null) { 
                        _apiClient = new ApiClient(imgurID, imgurSecret);
                    }
                    return _apiClient;
                } }
            public HttpClient httpClient = new HttpClient();

            public string url;

            public async Task<int> Upload(string path)
            {
                var filePath = path;
                try
                {
                    using (var fileStream = System.IO.File.OpenRead(filePath))
                    {
                        var imageEndpoint = new ImageEndpoint(apiClient, httpClient);
                        var imageUpload = await imageEndpoint.UploadImageAsync(fileStream);
                        url = imageUpload.Link;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Imgur Upload Failed");
                    Console.WriteLine(ex.Message);
                    throw ex;
                    return 1;
                }
                return 0;
            }
            public async Task<string[]> Upload(string[] paths)
            {
                try
                {
                    var imageEndpoint = new ImageEndpoint(apiClient, httpClient);
                    List<string> result = new List<string>();
                    foreach (var filePath in paths)
                    {
                        using (var fileStream = System.IO.File.OpenRead(filePath))
                        {

                            var imageUpload = await imageEndpoint.UploadImageAsync(fileStream);
                            url = imageUpload.Link;
                            result.Add(url);
                        }
                    }
                    return result.ToArray();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Imgur Upload Failed");
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            } 
            public async Task<int> Upload(Stream stream)
            {
                try
                {
                        var imageEndpoint = new ImageEndpoint(apiClient, httpClient);
                        var imageUpload = await imageEndpoint.UploadImageAsync(stream);
                    url = imageUpload.Link;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Imgur Upload Failed");
                    Console.WriteLine(ex.Message);
                    throw ex;
                    return 1;
                }
                return 0;
            }
            public string GetUrl()
            {
                return url;
            }
            public static imageinfo quickUploadImageSync(string path)
            {
                imageinfo result = new imageinfo();
                AsyncHelpers.RunSync(async () =>
                {
                    ApiService.ImgurAPI service = new ApiService.ImgurAPI();
                    string[] links = await service.Upload(new string[] {path});
                    for (int i = 0; i < links.Length; i++)
                    {
                        var file = (new Uri(path)).Segments.Last();
                        var link = links[i];
                        // Update Data
                        var fileName = Path.GetFileNameWithoutExtension(file);
                        var image = System.Drawing.Image.FromFile(file);
                        DefineInfoPack.imageinfo imageData = new DefineInfoPack.imageinfo(fileName, file, link, image.Height, image.Width, image);
                        result = imageData;

                    }
                });
                return result;
            }
        }
        public class Based64ImageAlternativeAPI
        {

            //public static ApiClient apiClient = new ApiClient(imgurID, imgurSR);
            //public HttpClient httpClient = new HttpClient();

            public string url;

            private string imgToBase64(System.Drawing.Image image)
            {
                string _base64String = null;

                using (MemoryStream _mStream = new MemoryStream())
                {
                    image.Save(_mStream, image.RawFormat);
                    byte[] _imageBytes = _mStream.ToArray();
                    _base64String = Convert.ToBase64String(_imageBytes);

                    return "data:image/jpg;base64," + _base64String;
                }
            }

            public async Task<int> Upload(string path)
            {
                var filePath = path;
                try
                {
                        url = imgToBase64(System.Drawing.Image.FromFile(filePath));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Imgur Upload Failed");
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
                return 0;
            }
            public async Task<string[]> Upload(string[] paths)
            {
                try
                {
                    
                    List<string> result = new List<string>();
                    foreach (var filePath in paths)
                    {
                            url = imgToBase64(System.Drawing.Image.FromFile(filePath));
                            result.Add(url);
                    }
                    return result.ToArray();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Imgur Upload Failed");
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
            public async Task<int> Upload(Stream stream)
            {
                try
                {
                    url = imgToBase64(System.Drawing.Image.FromStream(stream));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Imgur Upload Failed");
                    Console.WriteLine(ex.Message);
                    throw ex;
                    return 1;
                }
                return 0;
            }
            public string GetUrl()
            {
                return url;
            }
        }
        public class QuickWatermarkApi
        {
            protected class QuickWatermarkRequestWatermark
            {
                int version = 100;
                string type = "watermark";
                public RequestData[] request;
                public class RequestData
                {
                    string image;
                    string preset;
                }
            }
            protected class QuickWatermarkRequestSplitImage
            {
                public int _version = 100;
                [JsonProperty(PropertyName = "version")]
                public int version
                {
                    get => _version;
                    set => _version = value;
                }
                public string _type = "split";
                [JsonProperty(PropertyName = "type")]
                public string type
                {
                    get => _type;
                    set => _type = value;
                }
                [JsonProperty(PropertyName = "request")]
                public RequestData[] request { get; set; }
                public class RequestData
                {
                    [JsonProperty(PropertyName = "image")]
                    public string image {
                        get;set;
                    }
                    
                    [JsonProperty(PropertyName = "preset")]
                    public string preset
                    {
                        get; set;
                    }
                    public RequestData(string image, string preset="default")
                    {
                        this.image = image;
                        this.preset = preset;
                    }
                }
            }
            public void screenshotSplitImage(string sourceFilePath)
            {
                var request = new QuickWatermarkRequestSplitImage()
                {
                    request = new List<QuickWatermarkRequestSplitImage.RequestData>()
                    {
                        new QuickWatermarkRequestSplitImage.RequestData($"file:\\\\\\{sourceFilePath}")
                    }.ToArray()
                };
                var wrapper = new Dictionary<string, object>()
                {
                    { "QwRequest",request } 
                };
                var requestJson = System.Text.Json.JsonSerializer.Serialize(wrapper);
                var requestFilePath = Path.Combine(Environment.CurrentDirectory, @"External\quick_watermark", "quick_watermark.json");
                System.IO.File.WriteAllText(requestFilePath, requestJson);

                System.Diagnostics.ProcessStartInfo command = new System.Diagnostics.ProcessStartInfo();
                command.CreateNoWindow = true;
                command.FileName = Path.Combine(Environment.CurrentDirectory, @"External\quick_watermark", "quick_watermark.exe");
                command.Arguments = $"--config quick_watermark.json";
                //command.UseShellExecute = false;
                var process = System.Diagnostics.Process.Start(command);
                process.WaitForExit(3000);

                var sourceFolder = sourceFilePath.Remove(sourceFilePath.LastIndexOf("\\"));
                var resultFilePath1 = Path.Combine(Environment.CurrentDirectory, @"External\quick_watermark", "split1.png");
                var resultFilePath2 = Path.Combine(Environment.CurrentDirectory, @"External\quick_watermark", "split2.png");
                System.IO.File.Move(resultFilePath1, Path.Combine(sourceFolder, "Screenshot 1.png"));
                System.IO.File.Move(resultFilePath2, Path.Combine(sourceFolder, "Screenshot 2.png"));
                
            }

        }
    }
}

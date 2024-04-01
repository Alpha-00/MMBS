using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Auth.OAuth2;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net;
using System.Web;
using System.Windows;
using System.Runtime.CompilerServices;

using HtmlAgilityPack;
using mLAMB.Resources.Dialogs;
using Google.Apis.Requests;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
namespace mLAMB
{
    public partial class Processor
    {
        public class Support
        {
            public static class Check
            {
                public static bool isLink(string str)
                {
                    if (string.IsNullOrWhiteSpace(str)) return false;
                    Uri cache = null;
                    return Uri.TryCreate(str,UriKind.Absolute,out cache);
                }
            }
            public static string ByteToSize(long? bytenum)
            {
                if (bytenum != null)
                {
                    if ((bytenum < 100) && (bytenum > 0))
                    {
                        return bytenum.ToString() + (bytenum > 1 ? " Bytes" : "Byte");
                    }
                    else if (bytenum < 1024 * 1024)
                    {
                        return (bytenum / 1024f).Value.ToString("0.00") + " KB";
                    }
                    else if (bytenum < 1024 * 1024 * 1024)
                    {
                        return (bytenum / 1024f / 1024f).Value.ToString("0.00") + " MB";
                    }
                    else if (Convert.ToDouble(bytenum) < Math.Pow(1024, 4))
                    {
                        return (bytenum / Math.Pow(1024, 4)).Value.ToString("0.00") + " GB";
                    }
                }
                return "";
            }
        }
        public partial class Command
        {
            public MainWindow windows;
            public MainWindow.shellcall shell = null;
            public MainWindow.shellcall listencall = null;
            public MainWindow.shellfeed shellfeed = null;
            public Core.Data dat = new Core.Data();
            public int exitcode = 0;
            public Command()
            {

            }
            public enum commander {
                mmbs = 0,
                lastest = 1,
                news = 2,
                apple = 10,
                lastest_apple = 11,
                lastest_apple_nonjailbreak = 12,
                test_getlink_android = 21,
                test_getlink_apple = 22,
                exit = 1000000000
            };
            public int start(MainWindow.shellcall shell, MainWindow.shellcall listencall, MainWindow.shellfeed shellfeed, string cmd, params string[] code)
            {
                //cmd = "https://platinmods.com/threads/random-merge-defense-ver-1-1-0-mod-apk-free-upgrade.105766/";
                /*
                //!Sandbox
                string result = "";
                bool dialogResult = false;
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    userpassWindow prompt = new userpassWindow("Platinmods Login", "platinmodsToken.txt");
                    JObject mainwinloc = JObject.Parse(shellfeed("?location"));
                    prompt.Top = mainwinloc["top"].ToObject<double>() + (mainwinloc["height"].ToObject<double>() - prompt.Height) / 2;
                    prompt.Left = mainwinloc["left"].ToObject<double>() + (mainwinloc["width"].ToObject<double>() - prompt.Width) / 2;
                    dialogResult = prompt.ShowDialog() ?? false;
                    result = userpassWindow.RetrieveResult;
                }
                ), System.Windows.Threading.DispatcherPriority.Normal);
                return 0;
                //!SandboxEnd*/
                this.shell = shell;
                this.shellfeed = shellfeed;
                this.listencall = listencall;
                if (string.IsNullOrWhiteSpace(cmd)) return 255;
                shell("prepare");
                shell("`INIT PROCESSOR");

                cmd = cmd.TrimStart();
                if (cmd.StartsWith("http")) { exitcode = proclink(cmd, code); goto doneprocess; }

                if (cmd.StartsWith("cmd:"))
                {
                    shell("`detected CMD");
                    cmd = cmd.Substring(4);
                    switch (cmd.Split(':')[0])
                    {
                        case nameof(commander.mmbs): {
                                shell("`Sending...");
                                dat.SendToMMBS();
                                shell("`\tSENT");
                                if (ask("y/n",100,true, "Do you want to exit mLAMB?")) 
                                {
                                    exitcode = 1000000000; goto doneprocess; 
                                }
                            } break;
                        case nameof(commander.exit): { exitcode = 1000000000; goto doneprocess; } break;
                        case nameof(commander.lastest): { proclink(getlastest(), ""); } break;
                        case nameof(commander.news): { proclink(getnewest(code), ""); } break;
                        case nameof(commander.apple): { proclink_apple(cmd.Substring(cmd.IndexOf(':')+1)); } break;
                        case nameof(commander.lastest_apple): { proclink_apple(getlastest_apple(), "");  } break;
                        case nameof(commander.test_getlink_apple): { shell("`getlink_apple()=>" + getlastest_apple()); }; break;
                        default: { shell("`\twrong cmd"); exitcode = 255; } break;
                    }
                    return 0;
                }
            doneprocess:
                shell("`\nEXIT PROCESSOR");
                return exitcode;
            }

            public static MainWindow sshell;

            public static string[] SupportedHost = { "platinmods.com", };
            
            

            
            public int errorcode = 0;
            public void DataFixer()
            {
                bool isfix_mod = false;
                string cache_mod = "";
                foreach (var x in dat.temp)
                {
                    
                    switch (x.Key)
                    {
                        case "mod":
                            {
                               
                                
                                foreach (String xx in x.Value.Split('\n'))
                                {
                                    string xxx = xx;
                                    if (string.IsNullOrWhiteSpace(xxx)) continue;
                                    // Check numbered list
                                    Regex pattern = new Regex(@"^(\d+).\s+([^\r\n]+)(?:[\r\n]*)");

                                    if (pattern.IsMatch(xx))
                                    {
                                        xxx = xxx.Substring(xxx.IndexOf(" ") + 1);
                                        isfix_mod = true;
                                    }
                                    //Check dot at end
                                    
                                    if (!xxx.EndsWith(",")) xxx.Remove(xxx.Length - 1);
                                    if (!(xxx.EndsWith(".") || xxx.EndsWith("!") || xxx.EndsWith("?")||xxx.EndsWith("-")))
                                    {
                                        xxx += ".";
                                        isfix_mod = true;
                                    }
                                    // spcial character
                                    if (xxx.Contains("&quot;")) xxx.Replace("&quot;", " ");
                                    cache_mod += xxx+"\n";
                                }
                                if (isfix_mod) { 
                                    cache_mod = cache_mod.Trim();
                                    shell($"`fix mod:{cache_mod}");
                                };
                            }
                            break;
                    }
                }
                if (isfix_mod)
                {
                    dat.temp["mod"] = cache_mod;
                }
            }
            
            
            
        }
        public class WindowCommands
        {
            public class fileurlprocWindowCommand
            {
                public Uri downlink;
                public Uri mirrorlink;
                public fileurlprocWindow.shellfeed shell;
                public fileurlprocWindow.updateprog udown;
                public fileurlprocWindow.updateprog umirr;
                public fileurlprocWindow.updateprog ureup;
                public int returncode = 0;
                public DriveService driveService = null;
                public fileurlprocWindowCommand(Uri down, Uri mirror)
                {
                    downlink = down;
                    mirrorlink = mirror;
                }
                public int start(fileurlprocWindow.updateprog udown, fileurlprocWindow.updateprog umirr, fileurlprocWindow.updateprog ureup, fileurlprocWindow.shellfeed feed)
                {
                    this.shell = feed;
                    this.udown = udown;
                    this.umirr = umirr;
                    this.ureup = ureup;
                    shell("`INIT DOWNLOAD PROCESS");
                downloadprocess:
                    {
                        shell("`\tDownload: " + downlink.AbsoluteUri);
                        shell("`\t\thost: " + downlink.Host);
                        switch (downlink.Host)
                        {
                            //!Drive Link Process
                            case "drive.google.com":
                                {
                                    shell("`\t\t\t-supported");
                                    string[] Scopes = { DriveService.Scope.Drive };
                                    string ApplicationName = "mLAMB";
                                    UserCredential credential;
                                    
                                    using (var stream =
                                        new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                                    {
                                        // The file token.json stores the user's access and refresh tokens, and is created
                                        // automatically when the authorization flow completes for the first time.
                                        string credPath = "token4D.json";
                                        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                                            GoogleClientSecrets.Load(stream).Secrets,
                                            Scopes,
                                            "user",
                                            CancellationToken.None,
                                            new FileDataStore(credPath, true)).Result;
                                        Console.WriteLine("Credential file saved to: " + credPath);
                                    }
                                    
                                    driveService = new DriveService(new BaseClientService.Initializer()
                                    {
                                        HttpClientInitializer = credential,
                                        ApplicationName = ApplicationName,
                                    });
                                    string fname = "";
                                    string fsize = "";
                                    int validID = 0;
                                    string fileID = "";
                                    
                                    if (downlink.AbsolutePath.StartsWith("https://drive.google.com/open?id=")) { if (downlink.Segments.Length > 1) { fileID = HttpUtility.ParseQueryString(downlink.Query).Get("id"); } }
                                    else if (downlink.AbsolutePath.StartsWith("https://drive.google.com/file/d/")) if (downlink.Segments.Length > 3) fileID = downlink.Segments[3].Replace("/", "");
                                    if (!string.IsNullOrWhiteSpace(fileID) || fileID.Length < 5)
                                    {
                                        try
                                        {
                                            string ID = fileID;
                                            var tryget = driveService.Files.Get(ID);
                                            tryget.Fields = "name,size";
                                            Google.Apis.Drive.v3.Data.File metaget = tryget.Execute();
                                            fname = metaget.Name;
                                            shell($"`Name: {fname}");
                                            shell($"?set label downname\n{fname}");
                                            fsize = Processor.Support.ByteToSize(metaget.Size);
                                            shell($"`\nSize: {fsize}");
                                            shell($"?set label downsize\n{fsize}");

                                            shell($"?set down ready");
                                            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\mLAMP\\");
                                            StartDownload(tryget, metaget.Size, Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\mLAMP\\"+fname);

                                        }
                                        catch (Google.GoogleApiException e)
                                        {
                                            shell($"`+++++\nError Code: 'Gdrive API error'.PROCESSOR.class fileurlprocWindowCommand.in start.is downloadprocess! \n{e.Message}\n{e.HelpLink}");
                                        }
                                        catch (Exception e)
                                        {
                                            shell($"`+++++\nError Code: 'Download error'.PROCESSOR.class fileurlprocWindowCommand.in start.is downloadprocess! \n{e.Message}");
                                        }
                                    }
                                }
                                break;
                            default: 
                                {
                                    shell("`\t\t\t-UNSUPPORTED");
                                    goto mirrorprocess;
                                } break;
                        }
                        //!Function for Gdrive proce
                        //https://stackoverflow.com/questions/57607729/cannot-update-progress-bar-when-download-in-google-drive-in-c-sharp
                        
                        
                    }
                    mirrorprocess:
                    reuploadprocess:
                    {
                        //!For Gdrive upload only
                        /*var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                        {
                            Name = "fname",
                            MimeType = "application/vnd.google-apps.folder",
                            // MimeType = "application/vnd.google-apps.spreadsheet"
                        };
                        FilesResource.CreateMediaUpload request;
                        using (var stream = new System.IO.FileStream("files/report.csv",
                                                System.IO.FileMode.Open))
                        {
                            request = driveService.Files.Create(
                                fileMetadata, stream, "text/csv");
                            request.Fields = "id";
                            request.Upload();
                        }
                        var file = request.ResponseBody;
                        Console.WriteLine("File ID: " + file.Id);
                        */
                        System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\mLAMP\\");
                    }    
                    endprocess:
                    shell("`DOWNLOAD PROCESS DONE");
                    return returncode;
                }
                public async void StartDownload(FilesResource.GetRequest tryget,long? size, string filename)
                {
                    // Creating an instance of Progress<T> captures the current 
                    // SynchronizationContext (UI context) to prevent cross threading when updating the ProgressBar
                    IProgress<double> progressReporter =
                      new Progress<double>(value => udown(value));
                    await DownloadAsync(progressReporter, tryget, size,filename);
                }
                public async Task DownloadAsync(IProgress<double> progressReporter, FilesResource.GetRequest tryget,long? size, string filename)
                {
                    var streamDownload = new MemoryStream();
                    // Report progress to UI via the captured UI's SynchronizationContext using IProgress<T>
                    tryget.MediaDownloader.ProgressChanged +=
                      (progress) => ReportProgress(progress, progressReporter, streamDownload, size,filename);

                    // Execute download asynchronous
                    await Task.Run(() => tryget.Download(streamDownload));
                }
                private void ReportProgress(Google.Apis.Download.IDownloadProgress progress, IProgress<double> progressReporter, MemoryStream streamDownload, long? fileSize,string filename)
                {
                    switch (progress.Status)
                    {
                        case Google.Apis.Download.DownloadStatus.Downloading:
                            {
                                double progressValue = Convert.ToDouble(progress.BytesDownloaded * 100 / fileSize);

                                // Update the ProgressBar on the UI thread
                                progressReporter.Report(progressValue);
                                break;
                            }
                        case Google.Apis.Download.DownloadStatus.Completed:
                            {
                                shell("`Completed");
                                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                                {
                                    streamDownload.WriteTo(fs);
                                    fs.Flush();
                                }
                                break;
                            }
                        case Google.Apis.Download.DownloadStatus.Failed:
                            {
                                break;
                            }
                    }
                }
            }
        }
    }
}

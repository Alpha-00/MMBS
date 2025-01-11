using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework;
using RTF;
using static MMBS.CPTConvert;
using MMBS.Model.PostForm;
using OpenQA.Selenium.Internal;
using Google.Apis.Util;
using OpenQA.Selenium.Chrome;
using Scriban;
using System.Threading;
using static MMBS.Model.PostForm.PostFormGeneralCustom;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.Primitives;
namespace MMBS
{
    public partial class TemplateToolForm : Form
    {
        CustomPostTemplateModel data;
        CPTServices service;
        public TemplateToolForm()
        {
            InitializeComponent();
            CustomizeBinding();
            CustomInit();

        }
        public void CustomizeBinding()
        {
            
            data = new CustomPostTemplateModel();
            binder.DataSource = data;
            // One way custom binding with logs object
            data.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(onLogsChanged);
            this.boxActiviesLog.Rtf = data.logs;
            // Two way binding data select list
            data.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(onDataListChanged);
            this.boxSelectData.VirtualListSize = virtualDataFileItems.Count;
            // One way binding template list
            data.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(onTemplateListChanged);
            data.log("Initialization");
            service = new CPTServices(ref data);

        }
        public void CustomInit()
        {
            if (this.boxSelectTemplate.Items.Count > 0)
            {
                //this.boxSelectTemplate.SelectedItem = boxSelectTemplate.Items[0];
                this.boxSelectTemplate.SelectedIndex = 0;
                //this.boxSelectTemplate.DataBindings["SelectedValue"].WriteValue();
                //this.boxSelectTemplate.Refresh();

            }
            if (this.boxSelectData.Items.Count > 0)
            {
                this.boxSelectData.Items[0].Checked = true;
                /*for (int i = 0; i < this.boxSelectData.Items.Count; i++)
                {
                    this.boxSelectData.Items[i].Checked = true;
                }*/
            }
            logTimer.Elapsed += updateLogsBox;
            logTimer.AutoReset = false;
        }
        private System.Timers.Timer logTimer = new System.Timers.Timer(500);
        public void onLogsChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "logs")
            {
                if (!logTimer.Enabled)
                {
                    logTimer.Start();
                }
            }
        }
        public void updateLogsBox(object sender, System.Timers.ElapsedEventArgs args)
        {
            logTimer.Stop();
            boxActiviesLog.Invoke(new MethodInvoker(delegate {
                var rtfContent = data.logs;
                if (rtfContent == "")
                    this.boxActiviesLog.Clear();
                else
                    this.boxActiviesLog.Rtf = rtfContent;
                this.boxActiviesLog.Update();
                if (boxActiviesLog.Text.Length > 0)
                    boxActiviesLog.SelectionStart = boxActiviesLog.Text.Length - 1;
            }));
            
        }
        public void onDataListChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "dataFiles")
            {
                updateVirtualDataFileItems();
                this.boxSelectData.Items.Clear();
                this.boxSelectData.Items.AddRange(virtualDataFileItems.ToArray());
                this.boxSelectData.Refresh();
            }
                
        }
        public void onTemplateListChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "templateFiles")
            {
                this.boxSelectTemplate.Items.Clear();
                this.boxSelectTemplate.Items.AddRange(data.templateFiles.Select((x)=>x.name).ToArray());
                this.boxSelectTemplate.Refresh();
            }
        }
        private void butStart_Click(object sender, EventArgs e)
        {
            service.start();
        }

        private void butStart_EnabledChanged(object sender, EventArgs e)
        {
            butStop.Enabled = !butStart.Enabled;
        }

        private void butTemplatePath_Click(object sender, EventArgs e)
        {
            var result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK){
               boxTemplatePath.Text = folderBrowser.SelectedPath;
            }
        }

        private void butDataPath_Click(object sender, EventArgs e)
        {
            var result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                boxDataPath.Text = folderBrowser.SelectedPath;
            }
        }

        private void butOutputPath_Click(object sender, EventArgs e)
        {
            var result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                butOutputPath.Text = folderBrowser.SelectedPath;
            }
        }

        private void butStop_Click(object sender, EventArgs e)
        {
            service.stop();
        }

        private void textStatus_TextChanged(object sender, EventArgs e)
        {
            bool isRunning = data.isRunning; 
            textStatus.Font = isRunning ? new Font(textStatus.Font,FontStyle.Bold) : new Font(textStatus.Font, FontStyle.Regular);
            textStatus.ForeColor = isRunning ? Color.Green : Color.Black;
        }

        private void butLoadDefaults_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Override File will delete old file with no backup. Are you sure to do it?", "Load Default", MessageBoxButtons.YesNo);
            if (response == DialogResult.Yes)
            {
                PostFormGeneralCustom.installDefaultTemplate(new PostFormGeneralCustom.defaultTemplate[]
                {
                    PostFormGeneralCustom.defaultTemplate.page,
                    PostFormGeneralCustom.defaultTemplate.title
                });
            }
        }

        private void butOpenTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CPTServices.validatePath(data.templateDir))
                Process.Start(data.templateDir);
            }
            catch
            {

            }
        }

        private void butOpenData_Click(object sender, EventArgs e)
        {
            try
            {
                if (CPTServices.validatePath(data.dataDir))
                    Process.Start(data.dataDir);
            }
            catch
            {

            }
        }

        private void butOpenOutput_Click(object sender, EventArgs e)
        {
            try
            {
                if (CPTServices.validatePath(data.outputDir))
                    Process.Start(data.outputDir);
            }
            catch
            {

            }
        }

        private void butClearLogs_Click(object sender, EventArgs e)
        {
            data.clearLogs();
        }

        private void boxTemplatePath_TextChanged(object sender, EventArgs e)
        {

        }
        List<ListViewItem> virtualDataFileItems = new List<ListViewItem>();
        private void updateVirtualDataFileItems()
        {
            var selectedNames = new List<string>();
            for (int i = 0; i<virtualDataFileItems.Count; i++)
            {
                if (virtualDataFileItems[i].Checked) selectedNames.Add(virtualDataFileItems[i].Text);
            }
            virtualDataFileItems.Clear();
            for (int i = 0; i < this.data.dataFiles.Length; i++)
            {
                virtualDataFileItems.Add(new ListViewItem(this.data.dataFiles[i].name));
                
                if (selectedNames.Contains(this.data.dataFiles[i].name))
                {
                    virtualDataFileItems.Last().Checked = true;
                    selectedNames.Remove(this.data.dataFiles[i].name);
                }
            }
            this.boxSelectData.VirtualListSize = virtualDataFileItems.Count;
        }
        private void boxSelectData_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex < virtualDataFileItems.Count)
                e.Item = virtualDataFileItems[e.ItemIndex];
        }

        private void boxSelectData_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            updateVirtualDataFileItems();
        }

        private void boxSelectData_SearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e)
        {
            for (int i = 0; i < virtualDataFileItems.Count; i++)
                if (virtualDataFileItems[i].Text == e.Text) { e.Index = i; break; }
        }

        private void boxSelectData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxSelectData.SelectedIndices.Count == 0)
            {
                data._mainTargetDataFile = "";
                return;
            }
            data._mainTargetDataFile = data.dataFiles[boxSelectData.SelectedIndices[0]].path;
        }

        private void boxSelectData_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (boxSelectData.CheckedIndices.Count == 0)
            {
                data.targetDataFiles = new string[0]; return;
            }
            data.targetDataFiles = this.boxSelectData.CheckedIndices.OfType<int>().Select(x => data.dataFiles[x].path).ToArray();
        }

        private void boxActiviesLog_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void boxActiviesLog_SelectionChanged(object sender, EventArgs e)
        {
            boxActiviesLog.ScrollToCaret();
        }

        private void butBackupTemplate_Click(object sender, EventArgs e)
        {
            if (File.Exists(data.targetTemplateFile))
            {
                File.Copy(data.targetTemplateFile, data.targetTemplateFile + ".backup", true);
            }
        }

        private void boxSelectTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxSelectTemplate.SelectedIndex == -1)
            {
                data.targetTemplateItem = null;
                return;
            }
            data.targetTemplateItem = data.templateFiles[boxSelectTemplate.SelectedIndex];
        }

        private void butOpenInBrowser_Click(object sender, EventArgs e)
        {
            
        }

        private void butForce_Click(object sender, EventArgs e)
        {
            data.log("Force Re-generate all data");
            service.render();
        }
    }

    [Serializable]
    public class CustomPostTemplateModel: Bindable
    {
        #region Basic Properties
        private bool _isRunning = false;
        [TypeConverter(typeof(CPTConvert.RunningStatusConverter))]
        public bool isRunning
        {
            get => _isRunning;
            set {
                Set(ref _isRunning, value);
                Notify("isNotRunning");
            }
        }
        [TypeConverter(typeof(CPTConvert.RunningStatusConverter))]
        public bool isNotRunning
        {
            get => !_isRunning;
            set {
                isRunning = !value;
            }
        }
        #endregion

        #region Directories
        private string _templateDir = @"C:\BloggerSupporter\template\";
        [TypeConverter(typeof(CPTConvert.PathStatusConverter))]
        public string templateDir
        {
            get => _templateDir;
            set {
                Set(ref _templateDir, value);
                log("Change Template Directory", LogType.debug, indent: 1);
            }
        }

        private string _dataDir = @"C:\BloggerSupporter\data\";
        [TypeConverter(typeof(CPTConvert.PathStatusConverter))]
        public string dataDir
        {
            get => _dataDir;
            set {
                Set(ref _dataDir, value);
                log("Change Data Directory", LogType.debug, indent: 1);
            }
        }

        private string _outputDir = @"C:\BloggerSupporter\output\";
        [TypeConverter(typeof(CPTConvert.PathStatusConverter))]
        public string outputDir
        {
            get => _outputDir;
            set { 
                Set(ref _outputDir, value);
                log("Change Output Directory", LogType.debug, indent: 1);
            }
        }
        #endregion

        #region Logs
        private List<CPTConvert.LogItem> _activityLogs = new List<CPTConvert.LogItem>();

        public string logs
        {
            get => CPTConvert.LogConverter.renderRtf(_activityLogs);
            set => log(value);
        }
        public void log(string message, CPTConvert.LogType level = CPTConvert.LogType.info,string context = "", int indent = 0, bool isRtf = false)
        {
            _activityLogs.Add(new CPTConvert.LogItem(message, level, context, indent, isRtf));
            Notify("logs");
        }
        public void clearLogs() => Set(ref _activityLogs, new List<CPTConvert.LogItem>(), "logs");
        #endregion

        #region Files
        private FileItem[] _templateFiles = new FileItem[] { };
        public FileItem[] templateFiles

        {
            get => _templateFiles;
            set => Set(ref _templateFiles, value);
        }

        private FileItem[] _dataFiles = new FileItem[] { };
        public FileItem[] dataFiles
        {
            get => _dataFiles;
            set => Set(ref _dataFiles, value);
        }
        #endregion

        #region Selected Files
        private FileItem _targetTemplateItem = null;
        private string _targetTemplateFile = "";
        public string targetTemplateFile

        {
            get => _targetTemplateFile;
            set {
                Set(ref _targetTemplateFile, value);
                log("Change Target Template", LogType.debug, indent: 1);
            }
        }
        public FileItem targetTemplateItem
        {
            get => _targetTemplateItem;
            set
            {
                Set(ref _targetTemplateItem, value);
                Set(ref _targetTemplateFile, _targetTemplateItem.path, "targetTemplateFile");
                log("Change Target Template", LogType.debug, indent: 1);
            }
        }

        private string[] _targetDataFiles = new string[] { };
        public string[] targetDataFiles
        {
            get => _targetDataFiles;
            set {
                Set(ref _targetDataFiles, value);
                log("Change Target Data", LogType.debug, indent: 1);
            }
        }
        public string _mainTargetDataFile = "";
        #endregion
    }

    public class CPTConvert
    {
        public class RunningStatusConverter : TypeConverter
        {

            public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, Type destinationType) => new Type[] { typeof(string)}.Contains(destinationType);

            public override object ConvertTo(ITypeDescriptorContext context,
                                     CultureInfo culture,
                                     object value,
                                     Type destinationType)
            {
                bool check = (bool)value;
                if (destinationType == typeof(string))
                {
                    return check? "Running" : "Paused";
                }
                return value;
            }
        }
        public class PathStatusConverter : TypeConverter
        {
            public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, Type destinationType) => new Type[] { typeof(bool) }.Contains(destinationType);

            public override object ConvertTo(ITypeDescriptorContext context,
                                     CultureInfo culture,
                                     object value,
                                     Type destinationType)
            {
                bool check = !String.IsNullOrWhiteSpace((string)value);
                if (destinationType == typeof(bool))
                {
                    return check;
                }
                return value;
            }
        }
        public enum LogType
        {
            plain = 0,
            debug = 10,
            info = 20,
            warning = 30,
            error = 100,
            newLine = 21,
            newSection = 22
        }
        public class LogItem
        {
            public string message;
            public LogType level;
            public DateTime time = DateTime.Now;
            public string context;
            public int indent = 0;
            public bool isRtf = false;
            public LogItem(string message, LogType level, string context = "", int indent = 0, bool isRtf = false)
            {
                this.message = message;
                this.level = level;
                this.context = context;
                this.indent = indent;
                this.isRtf = isRtf;
            }
        }
        public static class LogConverter
        {
            public static float defaultFontSize => 16f;
            public static Dictionary<LogType, Color> logColor = new Dictionary<LogType, Color>() 
            {
                {LogType.plain, Color.Black},
                {LogType.debug, Color.Blue},
                {LogType.info, Color.Green},
                {LogType.warning, Color.Orange},
                {LogType.error, Color.Red},
                {LogType.newSection, Color.Black}
            };
            public static string _rtfCache = "";
            public static int _rtfCacheKey = 0;
            public static string renderRtf(List<LogItem> logs, int targetWidth = 20)
            {
                if (logs == null) return "";
                if (logs.Count == _rtfCacheKey) return _rtfCache;
                _rtfCacheKey = logs.Count;
                if (logs.Count == 0) return "";
                RTFBuilder rtf = new RTFBuilder(defaultFontSize);
                for (int i = 0; i < logs.Count; i++)
                {
                    if (logs[i].level == LogType.newLine)
                    {
                        rtf.AppendLine();
                        continue;
                    }
                    if (logs[i].level == LogType.newSection)
                    {
                        rtf.Append(new string('=',targetWidth));
                        rtf.AppendLine();
                        continue;
                    }
                    rtf.ForeColor(logColor[logs[i].level]);
                    rtf.FontStyle(FontStyle.Bold);
                    rtf.Append($"[{logs[i].time.ToString("HH:mm:ss:ff")}]");
                    rtf.Append(" : ");
                    if (logs[i].isRtf)
                    {
                        rtf.AppendLine();
                        rtf.AppendRTFDocument(logs[i].message.Replace(@"\\",@"\"));
                        rtf.AppendLine();
                        continue;
                    }
                    if (logs[i].indent>0) rtf.Append("└─".PadLeft(logs[i].indent * 2));
                    rtf.ForeColor(Color.Black);
                    rtf.FontStyle(FontStyle.Regular);
                    rtf.Append(logs[i].message);
                    rtf.AppendLine();
                }
                _rtfCache = rtf.ToString();
                return _rtfCache;
            }
            public static void setting()
            {
            }
        }
        [Serializable]
        public class FileItem:Bindable
        {
            private string _path;
            public string path
            {
                get => _path;
                set => Set(ref _path, value);
            }
            private string _name;
            public string name
            {
                get => _name;
                set => Set(ref _name, value);
            }
            public FileItem(string path)
            {
                this.path = path;
                this.name = Path.GetFileNameWithoutExtension(path);
            }
        }
    }
    
    public class CPTServices
    {
        CustomPostTemplateModel data;
        private FileSystemWatcher templateWatcher = new FileSystemWatcher();
        private FileSystemWatcher dataWatcher = new FileSystemWatcher();
        public CPTServices(ref CustomPostTemplateModel data)
        {
            this.data = data;
            data.PropertyChanged += new PropertyChangedEventHandler(updateTemplateList);
            data.PropertyChanged += new PropertyChangedEventHandler(updateDataList);
            updateTemplateList(this, new PropertyChangedEventArgs("templateDir"));
            updateDataList(this, new PropertyChangedEventArgs("dataDir"));
            initWatcher();
            data.PropertyChanged += new PropertyChangedEventHandler(bindTargetTemplate);
            data.PropertyChanged += new PropertyChangedEventHandler(bindDataTemplate);
        }
        ~CPTServices()
        {
            disposeWatcher();
        }

        #region Event
        public void updateTemplateList(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "templateDir")
            {
                data.templateFiles = collectFiles(data.templateDir,"Template", FileFormat.scriban);
            }

        }
        public void updateDataList(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "dataDir")
            {
                data.dataFiles = collectFiles(data.dataDir,"Data", FileFormat.json);
            }

        }
        public void bindTargetTemplate(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "targetTemplateFile" && data.isRunning)
            {
                render();
            }
        }
        public void bindDataTemplate(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "targetDataFiles" && data.isRunning)
            {
                render();
            }
        }
        public void bindTargetTemplateUpdate(object sender, FileSystemEventArgs e)
        {
            if (e.FullPath != data.targetTemplateFile) return;
            render();
        }
        public void bindTargetDataUpdate(object sender, FileSystemEventArgs e)
        {
            if (!data.targetDataFiles.Contains(e.FullPath)) return;
            render(e.FullPath);
        }
        #endregion

        public void initWatcher()
        {
            data.log("Init Watcher", indent: 1);
            // Init Template
            templateWatcher = new FileSystemWatcher(data.templateDir);
            templateWatcher.NotifyFilter = NotifyFilters.LastWrite;
            templateWatcher.Error += new ErrorEventHandler((obj, arg) => stop());
            templateWatcher.Filter = "*.scriban-html";
            templateWatcher.IncludeSubdirectories = false;
            templateWatcher.Changed += new FileSystemEventHandler(bindTargetTemplateUpdate);
            // Init Data
            dataWatcher = new FileSystemWatcher(data.dataDir);
            dataWatcher.NotifyFilter = NotifyFilters.LastWrite;
            dataWatcher.Error += new ErrorEventHandler((obj, arg) => stop());
            dataWatcher.Filter = "*.json";
            dataWatcher.IncludeSubdirectories = false;
            dataWatcher.Changed += new FileSystemEventHandler(bindTargetDataUpdate);
        }
        public void watch(bool enable = true)
        {
            templateWatcher.EnableRaisingEvents = enable;
            dataWatcher.EnableRaisingEvents = enable;
            data.log(enable?"Watcher online 👁️‍🗨️": "Watcher offline 💤");
        }
        public void disposeWatcher()
        {
            templateWatcher.Dispose();
            dataWatcher.Dispose();
        }
        /// <summary>
        /// Start tracking folder and watch for file changes
        /// </summary>
        public void start()
        {
            data.log("Running", LogType.info);
            data.isRunning = true;
            if (!validatePaths()) { stop(); return; }
            watch(true);
            render();
        }

        /// <summary>
        /// Stop service
        /// </summary>
        public void stop()
        {
            data.isRunning = false;
            watch(false);
            data.log("Stopped");
            data.log("", CPTConvert.LogType.newSection);
        }
        public enum FileFormat
        {
            json,
            scriban
        }
        private FileItem[] collectFiles(string path, string label = "", FileFormat? format = null)
        {
            // Check
            if (!validatePath(path)) { 
                data.log("Invalid Path", CPTConvert.LogType.error, indent: 1);
                return new FileItem[0]; }
            //Search
            string search = "";
            if (format == FileFormat.json) search = "*.json";
            if (format == FileFormat.scriban) search = "*.scriban-html";
            var files = Directory.GetFiles(path,search);
            data.log(label+" Found " + files.Length + " files", CPTConvert.LogType.debug, indent: 1);
            //Return
            return stringToFile(files);
        }
        public static bool validatePath(string path)
        {
            if (String.IsNullOrWhiteSpace(path)) { return false; }
            if (!Directory.Exists(path)) return false;
            return true;
        }
        public bool validatePaths()
        {
            // Check path emptiness
            if (String.IsNullOrWhiteSpace(data.templateDir))
            {
                data.log("Template Path is Empty", CPTConvert.LogType.error, indent: 1);
                return false;
            }
            if (String.IsNullOrWhiteSpace(data.dataDir))
            {
                data.log("Data Path is Empty", CPTConvert.LogType.error, indent: 1);
                return false;
            }
            if (String.IsNullOrWhiteSpace(data.outputDir))
            {
                data.log("Output Path is Empty", CPTConvert.LogType.error, indent: 1);
                return false;
            }
            // Check existance of Directories
            bool isTemplateFolderExist = Directory.Exists(data.templateDir);
            bool isDataFolderExist = Directory.Exists(data.dataDir);
            bool isOutputFolderExist = Directory.Exists(data.outputDir);
            if (!isTemplateFolderExist)
            {
                data.log("Template Folder does not exist", CPTConvert.LogType.error, indent: 1);
                return false;
            }
            if (!isDataFolderExist)
            {
                data.log("Data Folder does not exist", CPTConvert.LogType.error, indent: 1);
                return false;
            }
            if (!isOutputFolderExist)
            {
                Directory.CreateDirectory(data.outputDir);
                data.log("Output Folder does not exist => Auto Created Output Folder",  CPTConvert.LogType.warning,indent: 1);
            }
            
            data.log("Validated Paths");
            return true;
        }
        private FileItem[] stringToFile(string[] str)
        {
            List<FileItem> files = new List<FileItem>();
            for (int i = 0; i < str.Length; i++)
            {
                files.Add(new FileItem(str[i]));
            }
            return files.ToArray();
        }
        public static string ToRtfString(ScribanLogMessage e, float defaultFontSize, string content = "")
        {
            RTFBuilder rtf = new RTFBuilder(defaultFontSize);
            rtf.FontStyle(FontStyle.Bold);
            rtf.ForeColor(LogConverter.logColor[LogType.error]);
            rtf.AppendLine("Error Details");
            rtf.ForeColor(Color.Black);
            rtf.FontStyle(FontStyle.Regular);
            // Type
            rtf.Append("Type: ");
            rtf.FontStyle(FontStyle.Bold);
            rtf.Append(e.type.ToString());
            rtf.FontStyle(FontStyle.Regular);
            rtf.AppendLine();
            // Message
            rtf.Append("Message: ");
            rtf.Append(e.message);
            rtf.AppendLine();
            // Position
            rtf.Append("Position: ");
            rtf.FontStyle(FontStyle.Bold);
            rtf.Append(renderPosStrip(e.span));
            rtf.FontStyle(FontStyle.Regular);
            rtf.AppendLine();
            if (content == null) return rtf.ToString();
            // Source
            rtf.AppendLine("Source: ");
            rtf.AppendRTFDocument(renderSourceStrip());
            return rtf.ToString();

            string renderPosStrip(Scriban.Parsing.SourceSpan span)
            {
                return "l"+span.Start.Line.ToString() + "c" + span.Start.Column.ToString() + " - l" + span.End.Line.ToString() + "c" + span.End.Column.ToString();
            }
            string renderSourceStrip()
            {
                RTFBuilder r = new RTFBuilder(defaultFontSize);
               
                int prependStart = e.span.Start.Offset;
                int reqBeforeMore = 2;
                while (prependStart > 0)
                {
                    
                    if (content[prependStart-1] == '\n')
                    {
                        reqBeforeMore -= 1;
                    }
                    if (reqBeforeMore == 0) break;
                    prependStart--;
                }
                int appendEnd = e.span.End.Offset;
                int reqAfterMore = 2;
                while (appendEnd < content.Length-2)
                {

                    if (content[appendEnd + 1] == '\n')
                    {
                        reqAfterMore -= 1;
                    }
                    if (reqAfterMore == 0) break;
                    appendEnd++;
                }
                
                r.Append(content.Substring(prependStart+1, e.span.Start.Offset - prependStart - 1).Replace("\n","~MMBSNewLine~"));

                r.FontStyle(FontStyle.Bold);
                r.ForeColor(Color.Red);
                r.Append(content.Substring(e.span.Start.Offset, e.span.Length).Replace("\n", "~MMBSNewLine~"));
                r.ForeColor(Color.Black);
                r.FontStyle(FontStyle.Regular);
                
                if (e.span.End.Offset < content.Length - 1) 
                r.Append(content.Substring(e.span.End.Offset + 1, appendEnd - e.span.End.Offset).Replace("\n", "~MMBSNewLine~"));
                return r.ToString().Replace("~MMBSNewLine~",@"\line");
            }
        }
        public void render(string dataPath = null)
        {
            data.log("Generating...");
            string[] dataPaths;
            if (String.IsNullOrEmpty(data.targetTemplateFile)) {
                data.log("Failed: No Template", LogType.error, indent: 2);
                return; }
            if (String.IsNullOrEmpty(dataPath))
            {
                data.log("...all data", indent: 1);
                dataPaths = data.targetDataFiles;
            }
            else
            {
                dataPaths = new string[] { dataPath };
                data.log("..." + Path.GetFileNameWithoutExtension(dataPath), indent: 1);
            }

            for (int i = 0; i < dataPaths.Length; i++)
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                string templatePath = data.targetTemplateFile;
                dataPath = dataPaths[i];
                string outputPath = Path.Combine(data.outputDir, Path.GetFileNameWithoutExtension(dataPath) + ".html");

                data.log($"Template: {Path.GetFileNameWithoutExtension(templatePath)}", LogType.debug, indent: 2);
                data.log($"Data: {Path.GetFileNameWithoutExtension(dataPath)}", LogType.debug, indent: 2);
                data.log($"Output: {outputPath}", LogType.debug, indent: 2);
                try
                {
                    PostFormGeneralCustom.generateAndExport(templatePath, dataPath, outputPath);
                }
                catch (PostFormGeneralCustom.ScribanException e)
                {
                    foreach (var error in e.messages)
                    {
                        data.log("Syntax Error", LogType.error, indent: 2);
                        string content = File.ReadAllText(templatePath);
                        data.log(ToRtfString(error, LogConverter.defaultFontSize, content), LogType.error, isRtf: true);
                        //MessageBox.Show("Invalid template. Please check Activity Log for more information", "Render Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    continue;
                }
                catch (Exception e)
                {
                    data.log("Render Error", LogType.error, indent: 2);
                    data.log(e.Message, LogType.error, indent: 2);
                    MessageBox.Show(e.Message,"Render Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    continue;
                }
                timer.Stop();
                data.log($"Completed in {timer.Elapsed.ToString(@"s\.ffff")} seconds", indent: 2);
            }
            data.log($"-----");
        }
    }
}

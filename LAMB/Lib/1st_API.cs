using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Diagnostics;
namespace LAMB.Lib
{
    public class API
    {
        public class Take
        {

        }
        public class Give
        {
            public class toMMBS
            {
                public void Test()
                {
                    MessageBox.Show("Test");
                    Process firstProc = new Process();
                    try
                    {
                        firstProc.StartInfo.FileName = "D:\\Unpublished Project\\Unpublished Project\\Ya4r.net\\Minimize MyBloggerSupporter\\MMBS\\bin\\Debug\\MMBS.exe";
                        firstProc.EnableRaisingEvents = true;
                        firstProc.StartInfo.Arguments = "lamb call you";
                        firstProc.Start();
                        firstProc.WaitForExit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred!!!: " + ex.Message);

                    }
                    MessageBox.Show($"Completed{firstProc.ExitCode}");
                }
                public void Send(Type.outputMMBS dat)
                {
                    //Temporary
                    //"[App name]::::[MMBS cmd]::::[other information]\n[DATA]
                    string cache = "LAMB::::AFFcmd::::FreeData\n";
                    foreach (KeyValuePair<string, string> x in dat.FreeData)
                    {
                        cache += $"[{x.Key.Length}]{x.Key}[{x.Value.Length}]{x.Value}";
                    }
                    Process firstProc = new Process();
                    try
                    {
                        firstProc.StartInfo.FileName = "D:\\Unpublished Project\\Unpublished Project\\Ya4r.net\\Minimize MyBloggerSupporter\\MMBS\\bin\\Debug\\MMBS.exe";
                        firstProc.EnableRaisingEvents = true;
                        firstProc.StartInfo.Arguments = "lamb call you";
                        firstProc.Start();
                        firstProc.WaitForExit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred!!!: " + ex.Message);

                    }
                    
                }
            }
        }
    }
   
    public class localAPI
        {
        /// <summary>
        /// Using for communicate with developer and user
        /// </summary>
        public static class Overmind
        {
            public static void Error(string content)
                {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine(content);
                System.Console.ResetColor();
                }
            public class Dialog
            {
                public Forms.formFreeCustomizable form;
                public define Define;
                public string result;
                public enum define { 
                    /// <summary>
                    /// Default dialog for Login
                    /// </summary>
                    ddLogin
                };
                
                public Dialog(define Define, string cmd)
                {
                    this.Define = Define;
                    switch (Define)
                    {
                        case define.ddLogin: 
                            {
                                form = new Forms.formFreeCustomizable();
                                form.Title = "Login";
                                
                                //form.MainGrid.Background = new SolidColorBrush(Color.FromRgb(255,0,0));
                                form.MainGrid.Margin = new Thickness(5, 3, 3, 0);

                                var preset_column = new ColumnDefinition();
                                preset_column.Width = new GridLength(1, GridUnitType.Star);
                                form.MainGrid.ColumnDefinitions.Add(preset_column);
                                preset_column = new ColumnDefinition();
                                preset_column.Width = new GridLength(1, GridUnitType.Star);
                                form.MainGrid.ColumnDefinitions.Add(preset_column);
                                
                               
                                var preset_row = new RowDefinition();
                                preset_row.Height = new GridLength(1, GridUnitType.Star);
                                form.MainGrid.RowDefinitions.Add(preset_row);
                                preset_row = new RowDefinition();
                                preset_row.Height = new GridLength(1, GridUnitType.Star);
                                form.MainGrid.RowDefinitions.Add(preset_row);
                                preset_row = new RowDefinition();
                                preset_row.Height = new GridLength(1, GridUnitType.Star);
                                form.MainGrid.RowDefinitions.Add(preset_row);
                                preset_row = new RowDefinition();
                                preset_row.Height = new GridLength(1, GridUnitType.Star);
                                form.MainGrid.RowDefinitions.Add(preset_row);
                                preset_row = new RowDefinition();
                                preset_row.Height = new GridLength(1, GridUnitType.Star);
                                form.MainGrid.RowDefinitions.Add(preset_row);

                                UIElement preset;
                                preset = new Label();
                                ((Label)preset).Content = "Username";
                                Grid.SetRow(preset, 0);
                                Grid.SetRowSpan(preset, 1);
                                Grid.SetColumn(preset,0);
                                Grid.SetColumnSpan(preset, 2);
                                form.MainGrid.Children.Add(preset);

                                var preset_username = new TextBox();
                                ((TextBox)preset_username).Text = "";
                                Grid.SetRow(preset_username, 1);
                                Grid.SetRowSpan(preset_username, 1);
                                Grid.SetColumn(preset_username, 0);
                                Grid.SetColumnSpan(preset_username, 2);
                                form.MainGrid.Children.Add(preset_username);

                                preset = new Label();
                                ((Label)preset).Content = "Password";
                                Grid.SetRow(preset, 2);
                                Grid.SetRowSpan(preset, 1);
                                Grid.SetColumn(preset, 0);
                                Grid.SetColumnSpan(preset, 2);
                                form.MainGrid.Children.Add(preset);

                                var preset_password = new PasswordBox();
                                ((PasswordBox)preset_password).Password = "";
                                Grid.SetRow(preset_password, 3);
                                Grid.SetRowSpan(preset_password, 1);
                                Grid.SetColumn(preset_password, 0);
                                Grid.SetColumnSpan(preset_password, 2);
                                form.MainGrid.Children.Add(preset_password);

                                preset = new Button() { Content = "Login and Save",Margin = new Thickness(0,4,0,4) };
                                ((Button)preset).Click += (s,e)=> { result = $"return\n{preset_username.Text}\n{preset_password.Password}"; form.Close(); };
                                Grid.SetRow(preset, 4);
                                Grid.SetRowSpan(preset, 1);
                                Grid.SetColumn(preset, 0);
                                Grid.SetColumnSpan(preset, 2);
                                form.MainGrid.Children.Add(preset);
                            } break;
                    }
                }
                public string Perform()
                {
                    switch (Define)
                    {
                        case define.ddLogin:
                            {
                                form.ShowDialog();
                                return result;
                            }
                            break;
                    }
                    return "";
                }
            }
        }
        public static class File
        {
            public static void txtTest(string content)
            {
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //Uri dir = new Uri(name);
                string name = "txtTest.txt";
                if (content.Contains("::::")) { name += content.Remove(content.IndexOf("::::")); content = content.Substring(content.IndexOf("::::")); }
                System.IO.File.CreateText($"{dir}\\{name}").Dispose();
                System.IO.File.WriteAllText($"{dir}\\{name}", content);
            }
            public class SecurityFile
            {
                //Variables
                
                public string dir;
                private Encode E;
                private encode e;
                //Endof Variables
                //Define
                public enum Encode { Caesar }
                public abstract class encode
                {
                    public string key;
                    public void Init(string keycmd)
                    {
                        this.key = keycmd;
                    }
                    public string Decode(string decmd)
                    {
                        return decmd;
                    }
                    public string Encode(string encmd)
                    {
                        return encmd;
                    }
                }
                public class encodeCaesar : encode
                    //Can't use
                {
                    
                    public encodeCaesar(string keycmd)
                    {
                        Init(keycmd);
                    }
                    
                }
                //Endof Define
                public SecurityFile(string name, Encode E)
                {
                    dir = SLink.dirCache + name;
                    this.E = E;
                    switch (E)
                    {
                        case Encode.Caesar:e = new encodeCaesar(""); break;
                    }
                }
                public bool Save(string cmd)
                {
                    using (System.IO.StreamWriter stream = System.IO.File.CreateText(dir))
                    {
                        stream.Write(e.Encode(cmd));
                    }
                    return true;
                }
                public string Load(string cmd)
                {
                    return System.IO.File.ReadAllText(cmd);
                }
            }
        }
        /// <summary>
        /// Use for store link and global const
        /// </summary>
        public static class SLink
        {
            public static string dirCache = "C:\\BloggerSupporter\\";
            public static string dirMMBS = "";
        }
        }
}

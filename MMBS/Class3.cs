//For User Data
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
namespace MMBS
{
    class UsersClass
    {
        string username;
        string password;

    }
    enum FormStyle
    {
        OldStyle,
        Default
    }
    public static class ThemeSystem {
        static Color OldBack = Color.FromKnownColor(KnownColor.Control);
        static Color Ol2Back = Color.FromKnownColor(KnownColor.Window);
        static Color OldFore = Color.FromKnownColor(KnownColor.ControlText);
        static Color Ol2Fore = Color.FromKnownColor(KnownColor.WindowText);
        static bool callWhenNew = false;
        public static void Call(string s)
        {
            if (callWhenNew) { MessageBox.Show(s);}
        }
        public static Color KeepAoldBack(int A)//Keep Alpha , Old Background Color
        {
            return Color.FromArgb(A, OldBack.R, OldBack.B, OldBack.G);
        }
        
        public static void LoadOldStyle(Control control)
        {
            // Type[] supportList = new Type[] {System.Windows.Forms.RichTextBox}
            Control c = new Control();
            c = control;
             Dictionary<Type, Action> @switch = new Dictionary<Type, Action>();
            Type cache = control.GetType();
            cache = (cache == typeof(MMBS.MainMenu)||cache == typeof(MMBS.AFForm)||cache ==typeof(MMBS.FMForm)||cache==typeof(MMBS.FormResult)) ? typeof(Form) : cache;
            if (@switch.Count == 0)
            {
                @switch.Add(typeof(RichTextBox), () => { { c.BackColor = Ol2Back; c.ForeColor = Ol2Fore; } });
                @switch.Add(typeof(Button), () => { (c as Button).FlatStyle = FlatStyle.Standard; c.BackColor = Color.Transparent; c.ForeColor = Color.Black;c.Font = c.Font.Size > 9 ? c.Font : new Font(c.Font.FontFamily, 10f); });
                @switch.Add(typeof(Label), () => { c.BackColor = OldBack; c.ForeColor = c.ForeColor == Color.White ?OldFore: c.ForeColor; });
                @switch.Add(typeof(CheckBox), () => { c.BackColor = OldBack; c.ForeColor = OldFore; });
                @switch.Add(typeof(LinkLabel), () => { c.BackColor = OldBack; c.ForeColor = OldFore;(c as LinkLabel).LinkColor = (c as LinkLabel).LinkColor == Color.White ? OldFore : (c as LinkLabel).LinkColor;  });
                @switch.Add(typeof(PictureBox), () => { });
                @switch.Add(typeof(TextBox), () => { c.BackColor = Ol2Back;c.ForeColor = Ol2Fore; });
                @switch.Add(typeof(ProgressBar), () => { });
                @switch.Add(typeof(CheckedListBox), () => { c.BackColor = Ol2Back; c.ForeColor = Ol2Fore; });
                @switch.Add(typeof(ImageList), () => { c.BackColor = Ol2Back; c.ForeColor = Ol2Fore; });
                @switch.Add(typeof(ListView), () => { c.BackColor = Ol2Back; c.ForeColor = Ol2Fore; });
                /////
                @switch.Add(typeof(GroupBox), () =>
                {

                    c.BackColor = KeepAoldBack(c.BackColor.A);
                    c.ForeColor = OldFore;
                    foreach (Control cs in c.Controls)
                    {

                        cache = cs.GetType();

                        if (@switch.ContainsKey(cache))
                            LoadOldStyle(cs);
                        else Call(cache.ToString());
                    }
                });
                /////
                @switch.Add(typeof(Panel), () =>
                {

                    c.BackColor = KeepAoldBack(c.BackColor.A);
                    c.ForeColor = OldFore;
                    foreach (Control cs in c.Controls)
                    {

                        cache = cs.GetType();

                        if (@switch.ContainsKey(cache))
                            LoadOldStyle(cs);
                        else Call(cache.ToString());
                    }
                });
                /////
                @switch.Add(typeof(Form), () =>
                {
                    c.BackColor = OldBack;
                    c.ForeColor = OldFore;
                    //c.BackgroundImage = null;
                    foreach (Control cs in c.Controls)
                    {
                        if (cs.Name.EndsWith("_Syswarn")) continue;
                        cache = cs.GetType();
                        if (@switch.ContainsKey(cache))
                            LoadOldStyle(cs);
                        else Call(cache.ToString());
                    }
                });
            }
            if (@switch.ContainsKey(cache))
                @switch[cache]();
            else Call(cache.ToString());
        }
    }
    public static class User_DebugSystem
    {
        static bool activated = false;
        static bool Active()
        {
            activated = true;
            return activated;
        }
        static bool DeActive()
        {
            activated = false;
            return activated;
        }
        public static dynamic Command(string str)
        {
            if (str==("s"))
            {
                activated = !activated;
                System.Windows.Forms.MessageBox.Show(activated?"Đã kích hoạt debug":"Đã huỷ");
                return activated;
            }
            else if (str.Contains("call"))
            {
                if (activated)
                {
                    if (str.Contains("\n"))
                    System.Windows.Forms.MessageBox.Show(str.Replace("call\n",""));
                    else if (str == "call") System.Windows.Forms.MessageBox.Show("Message","Message");
                }
            }
            return null;
        }
        public static void Prog(string cmd)
        {
            switch (cmd)
            {
                case "wait": MessageBox.Show("Click to continue");break;
                default:  Console.WriteLine(cmd);break;
            }
           
        }
    }
}

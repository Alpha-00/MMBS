﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace MMBS.Misc_Form
{
    public partial class ModDescriptionQuickEditor : Form
    {
        /// <summary>
        /// Translation between template and template reader
        /// </summary>
        Dictionary<string, string> templateInterpret = new Dictionary<string, string>()
            {
                {@"- (content).\n", @"- (?<content>.+)\.\n?"},
                {@"(content).\n", @"(?<content>.+)\.\n?"},
                {@"(content), ", @"(?<content>[^,]+)\,?\s?"},
                {@"(index). (content).\n", @"(\d+)\. (?<content>.+)\.\n?" }
            };
        public ModDescriptionQuickEditor()
        {
            InitializeComponent();
            initContent();
            initTemplate();
        }
        public void initTemplate()
        {
            templateList.BeginUpdate();
            templateList.Items.Clear();
            foreach (var item in templateInterpret)
            {
                templateList.Items.Add(item.Key);
            }
            templateList.SelectedIndex = 0;
            templateList.EndUpdate();
        }
        public void initContent()
        {
            if (!System.IO.File.Exists(Class1.GetToken("modCustom")))
            {
                var items = new List<string>();
                foreach (var item in contentList.Items)
                {
                    items.Add(item as String);
                }
                System.IO.File.WriteAllText(Class1.GetToken("modCustom"), String.Join("\n",items));
            }
            try
            {
                var data = System.IO.File.ReadAllText(Class1.GetToken("modCustom"));
                var collection = data.Split("\n");
                if (collection.Length == 0) return;
                contentList.BeginUpdate();
                contentList.Items.Clear();
                foreach (var item in collection)
                {
                    contentList.Items.Add(item);
                }
                contentList.EndUpdate();
                ClearContentCheck();
            }
            catch (Exception e)
            {

            }
        }
        public void UpdateOptions(string content)
        {
            
            try
            {
                var matches = Regex.Matches(content, templateInterpret[templateList.SelectedItem as string]);

                contentList.BeginUpdate();
                ClearContentCheck();
                for (int i = 0; i< matches.Count; i++)
                {
                    var contentItem = matches[i].Groups["content"].Value;
                    var exist = UpdateContentCheck(contentItem);
                    if (!exist) contentList.Items.Add(contentItem);
                }
                contentList.EndUpdate();
            }
            catch (Exception e)
            {
                
            }
        }
        protected void ClearContentCheck()
        {
            contentList.BeginUpdate();
            for (int i = 0; i< contentList.Items.Count; i++)
            {
                contentList.SetItemCheckState(i, CheckState.Unchecked);
            }
            contentList.EndUpdate();
        }
        protected bool UpdateContentCheck(string value, bool check = true)
        {
            bool exist = false;
            for (int i = 0; i < contentList.Items.Count; i++)
            {
                if (contentList.Items[i] as string != value) continue;
                contentList.SetItemCheckState(i, check? CheckState.Checked: CheckState.Unchecked);
                exist = true;
            }
            return exist;
        }
        public HashSet<String> contents = new HashSet<string>();

        public string RenderContent()
        {
            var builder = new StringBuilder();
            var template = templateList.Text;
            int id = 1;
            for (int i = 0; i < contentStringList.Count; i++)
            {
                //if (contentList.GetItemCheckState(i) == CheckState.Unchecked) continue;
                
                var output = ExtendingFunction.MultiReplace(template,
                    "\\n","\n",
                    "(content)", contentStringList[i],
                    "(index)", id.ToString()
                    );
                builder.Append(output);
                id++;
            }
            return builder.ToString().Trim();
        }

        private void mod_desc_quick_editor_MouseLeave(object sender, EventArgs e)
        {
            //this.Hide();

        }

        private void mainLayoutPanel_MouseLeave(object sender, EventArgs e)
        {
            Console.WriteLine($"{Cursor.Position.X}.{Cursor.Position.Y}:{this.DesktopBounds.Left}-{this.DesktopBounds.Right}-{this.DesktopBounds.Top}-{this.DesktopBounds.Bottom}");
            if (Cursor.Position.X < this.DesktopBounds.Left
                || Cursor.Position.X > this.DesktopBounds.Right
                || Cursor.Position.Y > this.DesktopBounds.Bottom
                || Cursor.Position.Y < this.DesktopBounds.Top)
                this.Hide();
        }

        private void ModDescriptionQuickEditor_VisibleChanged(object sender, EventArgs e)
        {
        }
        public delegate void registerChanged();
        public registerChanged callback;
        public List<string> contentStringList = new List<string>();
        private void contentList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                contentStringList.Add(contentList.Items[e.Index] as string);
            }
            if (e.NewValue == CheckState.Unchecked)
            {
                contentStringList.Remove(contentList.Items[e.Index] as string);

            }
            if (callback != null)
            callback();
        }

        private void ModDescriptionQuickEditor_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void templateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (callback != null)
            callback();
        }
    }
}

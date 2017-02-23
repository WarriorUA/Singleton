using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Singleton
{
    public partial class Form : System.Windows.Forms.Form
    {
        Singleton single = Singleton.GetInstance();
        public Form()
        {
            InitializeComponent();
            foreach (var key in single.langDictionary.Keys)
            {
                int count = languageToolStripMenuItem.DropDownItems.Count;
                languageToolStripMenuItem.DropDownItems.Add(key);
                languageToolStripMenuItem.DropDownItems[count].Tag = key;
                languageToolStripMenuItem.DropDownItems[count].Click += ToolStripMenuItem_Click;
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var thisTool = (ToolStripMenuItem) sender;
            buttonOpen.Text = single.langDictionary[thisTool.Tag.ToString()].menuOpenWinIndex;
            buttonSave.Text = single.langDictionary[thisTool.Tag.ToString()].menuSaveWinIndex;
            buttonClose.Text = single.langDictionary[thisTool.Tag.ToString()].menuCloseWinIndex;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTLauncher
{
    public partial class Form2 : Form
    {
        private Config config;

        public Form2(Config config)
        {
            InitializeComponent();

            Screen screen = Screen.FromPoint(new Point(Cursor.Position.X, Cursor.Position.Y));
            int x = screen.WorkingArea.X + screen.WorkingArea.Width - this.Width;
            int y = screen.WorkingArea.Y + screen.WorkingArea.Height - this.Height;
            this.Location = new Point(x, y);

            this.config = config;

            this.checkBox1.Checked = this.config.EnableScreenShot == "true" ? true : false;
            this.checkBox2.Checked = this.config.EnableOCR == "true" ? true : false;
            this.checkBox3.Checked = this.config.EnableUtility == "true" ? true : false;
            this.checkBox4.Checked = this.config.AutoRun == "true" ? true : false;
            this.checkBox5.Checked = this.config.ScrollVol == "true" ? true : false;
            this.checkBox6.Checked = this.config.RunTip == "true" ? true : false;
            this.checkBox7.Checked = this.config.LaunchShow == "true" ? true : false;
            this.checkBox8.Checked = this.config.DebugConsole == "true" ? true : false;
            this.checkBox9.Checked = this.config.DbgConsole == "true" ? true : false;
            this.checkBox10.Checked = this.config.KillXPlugin == "true" ? true : false;
            this.checkBox11.Checked = this.config.AutoNTVOpen == "true" ? true : false;
            this.checkBox12.Checked = this.config.AutoExitClear == "true" ? true : false;
            this.checkBox13.Checked = this.config.EnablePlugin == "true" ? true : false;
            this.checkBox14.Checked = this.config.EnableHotKey == "true" ? true : false;

            string[] hotKey = this.config.HotKey.Split('+');

            this.textBox1.Text = this.config.QQScreenShot;
            this.textBox2.Text = this.config.UsrLib;
            this.textBox3.Text = this.config.WeChatOCR;
            this.textBox4.Text = this.config.WeChatUtility;
            this.textBox5.Text = this.config.PythonDir;
            this.textBox6.Text = this.config.PluginDir;
            this.textBox7.Text = hotKey[0];
            this.textBox8.Text = hotKey[1];
            this.textBox9.Text = hotKey[2];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.config.EnableScreenShot = this.checkBox1.Checked ? "true" : "false";
            this.config.EnableOCR = this.checkBox2.Checked ? "true" : "false";
            this.config.EnableUtility = this.checkBox3.Checked ? "true" : "false";
            this.config.AutoRun = this.checkBox4.Checked ? "true" : "false";
            this.config.ScrollVol = this.checkBox5.Checked ? "true" : "false";
            this.config.RunTip = this.checkBox6.Checked ? "true" : "false";
            this.config.LaunchShow = this.checkBox7.Checked ? "true" : "false";
            this.config.DebugConsole = this.checkBox8.Checked ? "true" : "false";
            this.config.DbgConsole = this.checkBox9.Checked ? "true" : "false";
            this.config.KillXPlugin = this.checkBox10.Checked ? "true" : "false";
            this.config.AutoNTVOpen = this.checkBox11.Checked ? "true" : "false";
            this.config.AutoExitClear = this.checkBox12.Checked ? "true" : "false";
            this.config.EnablePlugin = this.checkBox13.Checked ? "true" : "false";
            this.config.EnableHotKey = this.checkBox14.Checked ? "true" : "false";

            this.config.QQScreenShot = this.textBox1.Text;
            this.config.UsrLib = this.textBox2.Text;
            this.config.WeChatOCR = this.textBox3.Text;
            this.config.WeChatUtility = this.textBox4.Text;
            this.config.PythonDir = this.textBox5.Text;
            this.config.PluginDir = this.textBox6.Text;
            this.config.HotKey = this.textBox7.Text + "+" + this.textBox8.Text + "+" + this.textBox9.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\Capture";
            if (Directory.Exists(folder))
            {
                string[] files = Directory.GetFiles(folder);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }
        }
    }
}

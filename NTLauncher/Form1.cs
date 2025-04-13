using System.Runtime.InteropServices;

namespace NTLauncher
{
    public partial class Form1 : Form
    {
        private ConfigHandler handler;
        private Config config;
        private IntPtr parent;
        private int pid;
        private int ID_SCREENSHOTHOTKEY = 61166;

        private QQIpcWrapper.CallbackIpc callbackIpc = (IntPtr pArg, string msg, int arg3, string addition_msg, int addition_msg_size) =>
        {
            //string message = $"进程消息：{msg}，大小：{arg3}\n附加消息：{addition_msg}，大小：{addition_msg_size}";
            //MessageBox.Show(message, "回调提示");
        };

        public Form1()
        {
            InitializeComponent();

            this.handler = new ConfigHandler(Application.StartupPath + "config.ini");
            this.config = this.handler.Read();

            this.parent = QQIpcWrapper.CreateQQIpcParentWrapper();
            bool success = QQIpcWrapper.QQIpcParentWrapper_InitEnv(this.parent, Application.StartupPath + "parent-ipc-core-x64.dll");
            if (!success)
            {
                IntPtr ptr = QQIpcWrapper.QQIpcParentWrapper_GetLastErrStr(this.parent);
                string? msg = Marshal.PtrToStringAnsi(ptr);
                MessageBox.Show(msg, "启动错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                QQIpcWrapper.DeleteQQIpcChildWrapper(this.parent);

                Environment.Exit(0);
            }
            //QQIpcWrapper.QQIpcParentWrapper_SetLogLevel(this.parent, 0);
            QQIpcWrapper.QQIpcParentWrapper_InitLog(this.parent, 0, IntPtr.Zero);
            QQIpcWrapper.QQIpcParentWrapper_InitParentIpc(this.parent);
            this.pid = QQIpcWrapper.QQIpcParentWrapper_LaunchChildProcess(this.parent, this.config.QQScreenShot, callbackIpc, IntPtr.Zero, [], 0);
            QQIpcWrapper.QQIpcParentWrapper_ConnectedToChildProcess(this.parent, this.pid);

            if (this.config.EnableHotKey == "true")
            {
                string[] hotKey = this.config.HotKey.Split('+');
                Keys vk = (Keys)Enum.Parse(typeof(Keys), hotKey[2]);
                success = HotKey.RegisterHotKey(this.Handle, ID_SCREENSHOTHOTKEY, KeyModifiers.Ctrl | KeyModifiers.Alt, vk);
                if (!success)
                {
                    int error = Marshal.GetLastWin32Error();
                    if (error == 1409)
                    {
                        MessageBox.Show("热键被占用！", "热键提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("注册热键失败！错误代码：" + error, "热键提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            notifyIcon1.ShowBalloonTip(3000, "信息", "NTLauncher启动成功！", ToolTipIcon.Info);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (this.parent != IntPtr.Zero)
            {
                HotKey.UnregisterHotKey(this.Handle, ID_SCREENSHOTHOTKEY);
                if (pid > 0)
                {
                    QQIpcWrapper.QQIpcParentWrapper_TerminateChildProcess(this.parent, this.pid, 0, true);
                }
                QQIpcWrapper.DeleteQQIpcParentWrapper(this.parent);
            }

            if (this.config.AutoExitClear == "true")
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

            Application.Exit();
        }

        private Form2? form2 = null;

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.form2 == null || this.form2.IsDisposed)
            {
                this.form2 = new Form2(this.config);
                this.form2.FormClosed += (s, _) =>
                {
                    this.form2?.Dispose(); // 显式释放资源
                    this.form2 = null;     // 强制置空
                };
                if (this.form2.ShowDialog() == DialogResult.OK)
                {
                    this.handler.Write(this.config);
                }
            }
            else
            {
                this.form2.Activate();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.config.EnableScreenShot == "true")
            {
                QQIpcWrapper.QQIpcParentWrapper_SendIpcMessage(this.parent, this.pid, "screenShot", "", 0);
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case HotKey.WM_HOTKEY:
                    if (m.WParam.ToInt32() == ID_SCREENSHOTHOTKEY && this.config.EnableScreenShot == "true")
                    {
                        QQIpcWrapper.QQIpcParentWrapper_SendIpcMessage(this.parent, this.pid, "screenShot", "", 0);
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}

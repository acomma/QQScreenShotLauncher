using System.Runtime.InteropServices;

namespace NTLauncher
{
    public partial class Form1 : Form
    {
        private ConfigHandler handler;
        private Config config;
        private IntPtr parent;
        private int pid;

        private QQIpcWrapper.CallbackIpc callbackIpc = (IntPtr pArg, string msg, int arg3, string addition_msg, int addition_msg_size) =>
        {
            //string message = $"������Ϣ��{msg}����С��{arg3}\n������Ϣ��{addition_msg}����С��{addition_msg_size}";
            //MessageBox.Show(message, "�ص���ʾ");
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
                MessageBox.Show(msg, "��������", MessageBoxButtons.OK, MessageBoxIcon.Error);

                QQIpcWrapper.DeleteQQIpcChildWrapper(this.parent);

                Environment.Exit(0);
            }
            //QQIpcWrapper.QQIpcParentWrapper_SetLogLevel(this.parent, 0);
            QQIpcWrapper.QQIpcParentWrapper_InitLog(this.parent, 0, IntPtr.Zero);
            QQIpcWrapper.QQIpcParentWrapper_InitParentIpc(this.parent);
            this.pid = QQIpcWrapper.QQIpcParentWrapper_LaunchChildProcess(this.parent, this.config.QQScreenShot, callbackIpc, IntPtr.Zero, [], 0);
            QQIpcWrapper.QQIpcParentWrapper_ConnectedToChildProcess(this.parent, this.pid);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (this.parent != IntPtr.Zero)
            {
                if (pid > 0)
                {
                    QQIpcWrapper.QQIpcParentWrapper_TerminateChildProcess(this.parent, this.pid, 0, true);
                }
                QQIpcWrapper.DeleteQQIpcParentWrapper(this.parent);
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
                    this.form2?.Dispose(); // ��ʽ�ͷ���Դ
                    this.form2 = null;     // ǿ���ÿ�
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
    }
}

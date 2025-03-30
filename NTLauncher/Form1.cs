namespace NTLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Form2? form2 = null;

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (form2 == null || form2.IsDisposed)
            {
                form2 = new Form2();
                form2.FormClosed += (s, _) =>
                {
                    form2?.Dispose(); // 显式释放资源
                    form2 = null;     // 强制置空
                };
                form2.ShowDialog();
            }
            else
            {
                form2.Activate();
            }
        }
    }
}

namespace NTLauncher
{
    public partial class Form1 : Form
    {
        private ConfigHandler handler;
        private Config config;

        public Form1()
        {
            InitializeComponent();

            this.handler = new ConfigHandler(Application.StartupPath + "config.ini");
            this.config = this.handler.Read();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
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
    }
}

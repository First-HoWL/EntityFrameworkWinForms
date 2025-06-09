namespace EntityFrameworkWinForms
{
    public partial class Form1 : Form
    {
        static int clicks = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Text = $"{++clicks}";
            MessageBox.Show("Hello!", "Hi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not good!", "Oups!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Don\'t do this!", "Oups!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }
}

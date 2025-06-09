using EntityFrameworkWinForms.Models;

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Student> students = new List<Student>
            {
                new Student{ Name = "HoWL", Id = 1 },
                new Student{ Name = "HoWL1", Id = 2 },
                new Student{ Name = "HoWL2", Id = 3 }

            };
            dataGridView1.DataSource = students;
        }
    }
}

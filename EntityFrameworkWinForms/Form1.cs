using EntityFrameworkWinForms.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkWinForms
{
    public partial class Form1 : Form
    {
        static int clicks = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
                MessageBox.Show("Exeption!", "DON\'T DO THAT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                //MessageBox.Show(textBox1.Text, "Hello there!");
                using (var context = new UniversityContext())
                {
                    context.Database.EnsureCreated();
                    context.Notes.Add(new Note { Name = textBox1.Text, Description = textBox2.Text });

                    context.SaveChanges();
                }
            UpdateNotesGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        static Random rnd = new Random();

        /*public static Student GenerateStudent(UniversityContext context)
        {
            Student student = new Student();
            var names = new List<string>() { "HoWl", "Дмитро", "Ігор", "Микита", "Aboba", "Dram", "1holl", "None" };
            student.Name = names[rnd.Next(0, names.Count)];
            var a = rnd.Next(1, 5);
            student.groupe = context.Groups.Where(s => s.Id == a).First();
            student.Avg = RandomAvg();
            return student;
        }*/

        public static double RandomAvg()
        {
            return Math.Round(rnd.Next(1, 11) + rnd.NextDouble(), 2);
        }

        private void UpdateNotesGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var notes = context.Notes.ToList();
                dataGridView1.DataSource = notes;




                context.SaveChanges();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateNotesGrid();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

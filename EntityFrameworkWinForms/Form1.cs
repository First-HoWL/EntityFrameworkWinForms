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

        private void Form1_Load(object sender, EventArgs e)
        {
            /*using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                //for (int i = 0; i < 10; i++)
                //    context.Add(GenerateStudent(context));
                //context.Groups.Add(new Group { Name = "P33", Curator = new Teacher { Name = "HoWL", SecondName = "Abobov" } });
                //context.Groups.Add(new Group { Name = "P34", Curator = new Teacher { Name = "Dram", SecondName = "Dramov" } });
                //context.Groups.Add(new Group { Name = "P35", Curator = new Teacher { Name = "1holl", SecondName = "BezVideoCardovich" } });
                //context.Groups.Add(new Group { Name = "P55", Curator = new Teacher { Name = "Shex", SecondName = "Shrecsik" } });
                //context.Groups.Add(new Group { Name = "P007", Curator = new Teacher { Name = "none", SecondName = "none" } });
                context.SaveChanges();
                dataGridView1.DataSource = context.Students.Include(s => s.groupe).OrderBy(s => s.Id).ToList();
            }*/
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

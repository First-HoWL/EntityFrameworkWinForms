using EntityFrameworkWinForms.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Text;

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
                MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                //MessageBox.Show(textBox1.Text, "Hello there!");
                using (var context = new UniversityContext())
                {
                    context.Database.EnsureCreated();
                    context.students.Add(new Student { Name = textBox1.Text, Avg = Convert.ToDouble(textBox2.Text), groupe = context.groups.Where(g => g.Id == Convert.ToInt32(textBox3.Text)).First() });


                    context.SaveChanges();
                }

            UpdateStudentsGrid();

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
                MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                using (var context = new UniversityContext())
                {
                    int studId = Convert.ToInt32(textBox4.Text);
                    if (studId == null)
                        return;
                    context.Database.EnsureCreated();

                    
                    Student student = context.students.Find(studId);
                    student.Name = textBox1.Text;
                    student.Avg = Convert.ToDouble(textBox2.Text);


                    context.SaveChanges();
                }
            UpdateStudentsGrid();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new UniversityContext())
            {
                int studId = Convert.ToInt32(textBox4.Text);
                if (studId == null)
                    return;
                context.Database.EnsureCreated();


                var a = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo);
                if (a == DialogResult.Yes)
                {
                    context.students.Remove(context.students.Find(studId));
                }
                context.SaveChanges();
            }
            UpdateStudentsGrid();
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

        private void UpdateStudentsGrid()
        {
            using (var context = new UniversityContext())
            {
                Group? group = dataGridView2.CurrentRow.DataBoundItem as Group;
                if (group == null) group = new Group { Id = 0 };
                textBox3.Text = Convert.ToString(group.Id);
                context.Database.EnsureCreated();
                var students = context.students.Include(s => s.groupe).OrderBy(s => s.Id).Where(s => s.groupe.Id == group.Id).ToList();
                dataGridView1.DataSource = students;

                context.SaveChanges();
            }
        }
        private void UpdateGroupsGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var Groups = context.groups.Include(s => s.Curator).ToList();
                dataGridView2.DataSource = Groups;

                context.SaveChanges();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            /*using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();

                *//*context.groups.Add(
                    new Group { Name = "P47", Curator = new Teacher { Name = "Menya", SecondName = "Net" } }
                );*/
            /*context.groups.AddRange(
                new Group { Name = "P23", Curator = new Teacher { Name = "HoWL", SecondName = "Csharpowich" } },
                new Group { Name = "P78", Curator = new Teacher { Name = "none", SecondName = "none" } },
                new Group { Name = "P10", Curator = new Teacher { Name = "jsonReader", SecondName = "notJsonReader" } },
                new Group { Name = "P55", Curator = new Teacher { Name = "Aboba", SecondName = "Abobowna" } }
                );*//*
            context.SaveChanges();
            context.Database.EnsureCreated();

            for (int i = 0; i < 10; i++)
            {
                context.students.Add(GenerateStudent(context));
            }

            context.SaveChanges();

        };*/




            UpdateGroupsGrid();
            UpdateStudentsGrid();

        }

        public static Student GenerateStudent(UniversityContext context)
        {
            Student student = new Student();
            var names = new List<string>() { "HoWl", "Aboba", "Dram", "1holl", "None", "Misha", "Super Star" };
            student.Name = names[rnd.Next(0, names.Count)];
            var a = rnd.Next(1, 5);
            student.groupe = context.groups.Where(s => s.Id == a).First();
            student.Avg = RandomAvg();
            return student;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Student? CurrentStudent = dataGridView1.CurrentRow.DataBoundItem as Student;
            if (CurrentStudent == null)
                return;
            textBox1.Text = CurrentStudent.Name;
            textBox2.Text = $"{CurrentStudent.Avg}";
            textBox4.Text = Convert.ToString(CurrentStudent.Id);


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            UpdateStudentsGrid();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

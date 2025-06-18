using EntityFrameworkWinForms.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Text;

namespace EntityFrameworkWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
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
            textBox2.Text = string.Empty;*/


            Form2 form2 = new Form2();
            form2.ShowDialog();

            UpdateGrids();

        }

        public void UpdateGrids()
        {
            UpdateClientsGrid();
            UpdateOrderDetailsGrid();
            UpdateOrdersGrid();
            UpdatePaymentsGrid();
            UpdateProductsGrid();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            /*if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
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


*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*using (var context = new UniversityContext())
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
            UpdateStudentsGrid();*/
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

        private void UpdateProductsGrid()
        {
            using (var context = new UniversityContext())
            {
                /*Group? group = dataGridView2.CurrentRow.DataBoundItem as Group;
                if (group == null) group = new Group { Id = 0 };
                textBox3.Text = Convert.ToString(group.Id);
                */
                context.Database.EnsureCreated();
                var Products = context.Products.OrderBy(s => s.Id).ToList();
                dataGridView1.DataSource = Products;

                context.SaveChanges();
            }
        }
        private void UpdateClientsGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var Clients = context.Clients.ToList();
                dataGridView2.DataSource = Clients;

                context.SaveChanges();
            }
        }
        private void UpdateOrdersGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var Orders = context.Orders.Include(s => s.Client).ToList();
                dataGridView3.DataSource = Orders;

                context.SaveChanges();
            }
        }
        private void UpdateOrderDetailsGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var OrderDetails = context.OrderDetails.Include(s => s.Product).Include(s => s.Order).ToList();
                dataGridView4.DataSource = OrderDetails;

                context.SaveChanges();
            }
        }
        private void UpdatePaymentsGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var Payments = context.Payments.Include(s => s.Order).ToList();
                dataGridView5.DataSource = Payments;

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
            UpdateGrids();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {/*
            Student? CurrentStudent = dataGridView1.CurrentRow.DataBoundItem as Student;
            if (CurrentStudent == null)
                return;
            textBox1.Text = CurrentStudent.Name;
            textBox2.Text = $"{CurrentStudent.Avg}";
            textBox4.Text = Convert.ToString(CurrentStudent.Id);

        */
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

        }


    }
}

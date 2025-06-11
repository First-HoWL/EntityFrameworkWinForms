using EntityFrameworkWinForms.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

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
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || comboBox2.Text == string.Empty)
                MessageBox.Show("Exeption!", "DON\'T DO THAT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                //MessageBox.Show(textBox1.Text, "Hello there!");
                using (var context = new UniversityContext())
                {
                    context.Database.EnsureCreated();
                    context.Notes.Add(new Note { Name = textBox1.Text, Description = textBox2.Text, Status = comboBox2.Text });





                    context.SaveChanges();
                }
            UpdateNotesGrid();



            /*textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;*/
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || comboBox2.Text == string.Empty)
                MessageBox.Show("Exeption!", "DON\'T DO THAT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                //MessageBox.Show(textBox1.Text, "Hello there!");
                using (var context = new UniversityContext())
                {
                    int noteId = Convert.ToInt32(textBox3.Text);
                    if (noteId == null)
                        return;
                    context.Database.EnsureCreated();

                    Note note = context.Notes.Find(noteId);
                    note.Name = textBox1.Text;
                    note.Description = textBox2.Text;
                    note.Status = comboBox2.Text;



                    context.SaveChanges();
                }
            UpdateNotesGrid();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || comboBox2.Text == string.Empty)
                MessageBox.Show("Exeption!", "DON\'T DO THAT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                //MessageBox.Show(textBox1.Text, "Hello there!");
                using (var context = new UniversityContext())
                {
                    int noteId = Convert.ToInt32(textBox3.Text);
                    if (noteId == null)
                        return;
                    context.Database.EnsureCreated();

                    
                    var a = MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo);
                    if (a == DialogResult.Yes)
                    {
                        context.Notes.Remove(context.Notes.Find(noteId));
                    }


                    context.SaveChanges();
                }
            UpdateNotesGrid();
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



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Note? CurrentNote = dataGridView1.CurrentRow.DataBoundItem as Note;
            if (CurrentNote == null)
                return;
            textBox1.Text = CurrentNote.Name;
            textBox2.Text = CurrentNote.Description;
            comboBox2.Text = CurrentNote.Status;
            textBox3.Text = Convert.ToString(CurrentNote.Id);
        }

        
    }
}

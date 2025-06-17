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


        private void UpdateSpecializationGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var Specializations = context.Specializations.ToList();
                dataGridView2.DataSource = Specializations;

                context.SaveChanges();
            }
        }
        private void UpdateDoctorsGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var Doctors = context.Doctors.Include(s => s.specialization).ToList();
                dataGridView3.DataSource = Doctors;

                context.SaveChanges();
            }
        }
        private void UpdatePatientsGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var Patients = context.Patients.Include(s => s.Doctor).ToList();
                dataGridView1.DataSource = Patients;

                context.SaveChanges();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateDoctorsGrid();
            UpdatePatientsGrid();
            UpdateSpecializationGrid();

        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
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

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddDoctorToPatientButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

            UpdatePatientsGrid();
        }
    }
}

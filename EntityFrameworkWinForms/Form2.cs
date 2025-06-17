using EntityFrameworkWinForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkWinForms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (comboDoctorBox.Text == string.Empty || comboPatientBox.Text == string.Empty)
                MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                using (var context = new UniversityContext())
                {
                    var Doctor = comboDoctorBox.SelectedItem as Doctor;
                    var Patient = comboPatientBox.SelectedItem as Patient;
                    context.Database.EnsureCreated();
                    context.Patients.Where(s => s.Id == Patient.Id).First().Doctor = Doctor;
                    context.SaveChanges();
                }
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboPatientBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboDoctorBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            using (var context = new UniversityContext())
            {
                var Doctors = context.Doctors.ToArray();
                var Patients = context.Patients.ToArray();
                if (Doctors == null || Patients == null) { return; }

                comboDoctorBox.Items.AddRange(Doctors);
                comboPatientBox.Items.AddRange(Patients);

            }

        }
    }
}

using EntityFrameworkWinForms.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using EntityFrameworkWinForms.Models;

namespace EntityFrameworkWinForms
{
    public partial class Form2 : Form
    {

        public Group? startGroup { get; set; } = null;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            using (var context = new UniversityContext())
            {
                var groups = context.groups.ToArray();
                if (groups == null) { return; }

                comboGroupBox.Items.AddRange(groups);

                if (startGroup != null)
                {
                    comboGroupBox.SelectedIndex = groups.ToList().FindIndex(g => g.Id == startGroup.Id);
                }
            }
            comboGroupBox.SelectedItem = startGroup;
            
           
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            if (NameBox.Text == string.Empty || comboGroupBox.Text == string.Empty)
                MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                using (var context = new UniversityContext())
                {
                    var group = comboGroupBox.SelectedItem as Group;
                    context.Database.EnsureCreated();
                    context.students.Add(new Student { Name = NameBox.Text, groupe = context.groups.Find(group.Id) });
                    context.SaveChanges();
                }
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

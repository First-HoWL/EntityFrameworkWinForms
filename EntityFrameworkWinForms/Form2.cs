using EntityFrameworkWinForms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using EntityFrameworkWinForms.Models;

namespace EntityFrameworkWinForms
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[]{
                "Products",
                "Clients",
                "Orders",
                "OrderDetails",
                "Payments"
            });

            /*
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
            comboGroupBox.SelectedItem = startGroup;*/


        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();

                switch (comboBox1.Text)
                {
                    case "Products":
                        {
                            if (TextBox1.Text == string.Empty || TextBox2.Text == string.Empty || TextBox3.Text == string.Empty || TextBox4.Text == string.Empty)
                                MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                context.Database.EnsureCreated();
                                context.Products.Add(new Product { Name = TextBox1.Text, Price = Convert.ToDouble(TextBox2.Text), Category = TextBox3.Text, InStock = Convert.ToInt32(TextBox4.Text) });
                                context.SaveChanges();
                                UpdateProductsGrid();
                            }
                            break;
                        }
                    case "Clients":
                        {
                            if (TextBox1.Text == string.Empty || TextBox2.Text == string.Empty)
                                MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                context.Database.EnsureCreated();
                                context.Clients.Add(new Client { Name = TextBox1.Text, Phone = TextBox2.Text });
                                context.SaveChanges();
                                UpdateClientsGrid();
                            }



                            break;
                        }
                    case "Orders":
                        {
                            if (TextBox1.Text == string.Empty || comboBox2.Text == string.Empty || dateTimePicker1.Text == string.Empty)
                                MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                context.Database.EnsureCreated();
                                var client = context.Clients.ToList();
                                context.Orders.Add(new Order { OrderDate = Convert.ToDateTime(dateTimePicker1.Text), Status = TextBox1.Text, Client = context.Clients.Find(client[comboBox2.SelectedIndex].Id) });
                                context.SaveChanges();
                                UpdateOrdersGrid();
                            }
                            break;
                        }
                    case "OrderDetails":
                        {
                            if (TextBox1.Text == string.Empty || comboBox2.Text == string.Empty || comboBox3.Text == string.Empty)
                                MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                context.Database.EnsureCreated();
                                var Orders = context.Orders.ToList();
                                var Products = context.Products.ToList();
                                context.OrderDetails.Add(new OrderDetails { Quanity = Convert.ToInt32(TextBox1.Text), Product = context.Products.Find(Products[comboBox2.SelectedIndex].Id), Order = context.Orders.Find(Orders[comboBox3.SelectedIndex].Id) });
                                context.SaveChanges();
                                UpdateOrderDetailsGrid();
                            }
                            break;
                        }
                    case "Payments":
                        {
                            if (TextBox1.Text == string.Empty || TextBox2.Text == string.Empty || comboBox2.Text == string.Empty || dateTimePicker1.Text == string.Empty)
                                MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                context.Database.EnsureCreated();
                                var Orders = context.Orders.ToList();
                                context.Payments.Add(new Payment { Date = Convert.ToDateTime(dateTimePicker1.Text), Amount = Convert.ToInt32(TextBox1.Text), Order = context.Orders.Find(Orders[comboBox2.SelectedIndex].Id), PaymentMethod = TextBox2.Text });
                                context.SaveChanges();
                                UpdatePaymentsGrid();
                            }
                            break;
                        }

                }

                context.SaveChanges();
            }



            /*
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
                        this.Close();*/
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
                dataGridView1.DataSource = Clients;

                context.SaveChanges();
            }
        }
        private void UpdateOrdersGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var Orders = context.Orders.Include(s => s.Client).ToList();
                dataGridView1.DataSource = Orders;

                context.SaveChanges();
            }
        }
        private void UpdateOrderDetailsGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var OrderDetails = context.OrderDetails.Include(s => s.Product).Include(s => s.Order).ToList();
                dataGridView1.DataSource = OrderDetails;

                context.SaveChanges();
            }
        }
        private void UpdatePaymentsGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var Payments = context.Payments.Include(s => s.Order).ToList();
                dataGridView1.DataSource = Payments;

                context.SaveChanges();
            }
        }



        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();

                switch (comboBox1.Text)
                {
                    case "Products":
                        {
                            var Products = context.Products.OrderBy(s => s.Id).ToList();
                            dataGridView1.DataSource = Products;
                            TextLabel1.Text = "Name";
                            TextLabel2.Text = "Price";
                            TextLabel3.Text = "Category";
                            TextLabel4.Text = "InStock";

                            TextLabel1.Visible = true;
                            TextLabel2.Visible = true;
                            TextLabel3.Visible = true;
                            TextLabel4.Visible = true;

                            TextBox1.Visible = true;
                            TextBox2.Visible = true;
                            TextBox3.Visible = true;
                            TextBox4.Visible = true;

                            comboBox2.Visible = false;
                            comboBox3.Visible = false;
                            ComboLabel1.Visible = false;
                            ComboLabel2.Visible = false;
                            DateLabel.Visible = false;
                            dateTimePicker1.Visible = false;
                            SicretTextBox.Text = string.Empty;


                            break;
                        }
                    case "Clients":
                        {
                            var Clients = context.Clients.ToList();
                            dataGridView1.DataSource = Clients;

                            TextLabel1.Text = "Name";
                            TextLabel2.Text = "Phone";

                            TextLabel1.Visible = true;
                            TextLabel2.Visible = true;

                            TextBox1.Visible = true;
                            TextBox2.Visible = true;

                            TextLabel3.Visible = false;
                            TextLabel4.Visible = false;

                            TextBox3.Visible = false;
                            TextBox4.Visible = false;

                            comboBox2.Visible = false;
                            comboBox3.Visible = false;
                            ComboLabel1.Visible = false;
                            ComboLabel2.Visible = false;
                            DateLabel.Visible = false;
                            dateTimePicker1.Visible = false;
                            comboBox2.Items.Clear();
                            comboBox3.Items.Clear();
                            SicretTextBox.Text = string.Empty;

                            break;
                        }
                    case "Orders":
                        {
                            var Orders = context.Orders.Include(s => s.Client).ToList();
                            dataGridView1.DataSource = Orders;

                            DateLabel.Text = "Date";
                            TextLabel1.Text = "Status";
                            ComboLabel1.Text = "Client";

                            TextBox1.Visible = true;
                            TextLabel1.Visible = true;
                            DateLabel.Visible = true;
                            dateTimePicker1.Visible = true;
                            comboBox2.Visible = true;
                            ComboLabel1.Visible = true;

                            TextLabel2.Visible = false;
                            TextLabel3.Visible = false;
                            TextLabel4.Visible = false;

                            TextBox2.Visible = false;
                            TextBox3.Visible = false;
                            TextBox4.Visible = false;

                            comboBox3.Visible = false;
                            ComboLabel2.Visible = false;
                            comboBox2.Items.Clear();
                            comboBox3.Items.Clear();
                            SicretTextBox.Text = string.Empty;


                            var cl = context.Clients.ToList();
                            object[] strings = new object[cl.Count];
                            int i = 0;
                            foreach (var item in cl)
                            {
                                strings[i++] = (item.ToString());
                            }

                            comboBox2.Items.AddRange(strings);

                            break;
                        }
                    case "OrderDetails":
                        {
                            TextLabel1.Text = "Quanity";
                            ComboLabel1.Text = "Product";
                            ComboLabel2.Text = "Order";

                            TextLabel1.Visible = true;
                            TextBox1.Visible = true;
                            comboBox2.Visible = true;
                            ComboLabel1.Visible = true;
                            ComboLabel2.Visible = true;
                            comboBox3.Visible = true;

                            TextLabel2.Visible = false;
                            TextLabel3.Visible = false;
                            TextLabel4.Visible = false;

                            TextBox2.Visible = false;
                            TextBox3.Visible = false;
                            TextBox4.Visible = false;

                            DateLabel.Visible = false;
                            dateTimePicker1.Visible = false;
                            comboBox2.Items.Clear();
                            comboBox3.Items.Clear();
                            SicretTextBox.Text = string.Empty;


                            var products = context.Products.ToList();
                            object[] strings = new object[products.Count];
                            int i = 0;
                            foreach (var item in products)
                            {
                                strings[i++] = (item.ToString());
                            }

                            comboBox2.Items.AddRange(strings);


                            var Orders = context.Orders.ToList();
                            object[] strings2 = new object[Orders.Count];
                            int j = 0;
                            foreach (var item in Orders)
                            {
                                strings2[j++] = (item.ToString());
                            }

                            comboBox3.Items.AddRange(strings2);


                            var OrderDetails = context.OrderDetails.Include(s => s.Product).Include(p => p.Order).ToList();
                            dataGridView1.DataSource = OrderDetails;

                            break;
                        }
                    case "Payments":
                        {
                            DateLabel.Text = "Date";
                            TextLabel1.Text = "Amount";
                            TextLabel2.Text = "PaymentMethod";
                            ComboLabel1.Text = "Order";

                            DateLabel.Visible = true;
                            dateTimePicker1.Visible = true;
                            TextLabel1.Visible = true;
                            TextLabel2.Visible = true;
                            ComboLabel1.Visible = true;
                            TextBox1.Visible = true;
                            TextBox2.Visible = true;
                            comboBox2.Visible = true;

                            TextLabel3.Visible = false;
                            TextLabel4.Visible = false;

                            TextBox3.Visible = false;
                            TextBox4.Visible = false;

                            comboBox3.Visible = false;
                            ComboLabel2.Visible = false;
                            comboBox2.Items.Clear();
                            comboBox3.Items.Clear();
                            SicretTextBox.Text = string.Empty;

                            var Orders = context.Orders.ToList();
                            object[] strings2 = new object[Orders.Count];
                            int i = 0;
                            foreach (var item in Orders)
                            {
                                strings2[i++] = (item.ToString());
                            }

                            comboBox2.Items.AddRange(strings2);


                            var Payments = context.Payments.Include(s => s.Order).ToList();
                            dataGridView1.DataSource = Payments;
                            break;
                        }

                }

                context.SaveChanges();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();

                switch (comboBox1.Text)
                {
                    case "Products":
                        {
                            if (TextBox1.Text == string.Empty || TextBox2.Text == string.Empty || TextBox3.Text == string.Empty || TextBox4.Text == string.Empty)
                                MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                context.Database.EnsureCreated();
                                context.Products.Add(new Product { Name = TextBox1.Text, Price = Convert.ToDouble(TextBox2.Text), Category = TextBox3.Text, InStock = Convert.ToInt32(TextBox4.Text) });
                                context.SaveChanges();
                                UpdateProductsGrid();
                            }
                            break;
                        }
                    case "Clients":
                        {
                            if (TextBox1.Text == string.Empty || TextBox2.Text == string.Empty)
                                MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                context.Database.EnsureCreated();
                                context.Clients.Add(new Client { Name = TextBox1.Text, Phone = TextBox2.Text });
                                context.SaveChanges();
                                UpdateClientsGrid();
                            }



                            break;
                        }
                    case "Orders":
                        {
                            if (TextBox1.Text == string.Empty || comboBox2.Text == string.Empty || dateTimePicker1.Text == string.Empty)
                                MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                context.Database.EnsureCreated();
                                var client = context.Clients.ToList();
                                context.Orders.Add(new Order { OrderDate = Convert.ToDateTime(dateTimePicker1.Text), Status = TextBox1.Text, Client = context.Clients.Find(client[comboBox2.SelectedIndex].Id) });
                                context.SaveChanges();
                                UpdateOrdersGrid();
                            }
                            break;
                        }
                    case "OrderDetails":
                        {
                            if (TextBox1.Text == string.Empty || comboBox2.Text == string.Empty || comboBox3.Text == string.Empty)
                                MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                context.Database.EnsureCreated();
                                var Orders = context.Orders.ToList();
                                var Products = context.Products.ToList();
                                context.OrderDetails.Add(new OrderDetails { Quanity = Convert.ToInt32(TextBox1.Text), Product = context.Products.Find(Products[comboBox2.SelectedIndex].Id), Order = context.Orders.Find(Orders[comboBox3.SelectedIndex].Id) });
                                context.SaveChanges();
                                UpdateOrderDetailsGrid();
                            }
                            break;
                        }
                    case "Payments":
                        {
                            if (TextBox1.Text == string.Empty || TextBox2.Text == string.Empty || comboBox2.Text == string.Empty || dateTimePicker1.Text == string.Empty)
                                MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                context.Database.EnsureCreated();
                                var Orders = context.Orders.ToList();
                                context.Payments.Add(new Payment { Date = Convert.ToDateTime(dateTimePicker1.Text), Amount = Convert.ToInt32(TextBox1.Text), Order = context.Orders.Find(Orders[comboBox2.SelectedIndex].Id), PaymentMethod = TextBox2.Text });
                                context.SaveChanges();
                                UpdatePaymentsGrid();
                            }
                            break;
                        }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();

                switch (comboBox1.Text)
                {
                    case "Products":
                        {
                            int ProductId = Convert.ToInt32(SicretTextBox.Text);
                            if (ProductId == null)
                                return;
                            context.Database.EnsureCreated();


                            var a = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo);
                            if (a == DialogResult.Yes)
                            {
                                context.Products.Remove(context.Products.Find(ProductId));
                            }
                            context.SaveChanges();

                            UpdateProductsGrid();
                            break;
                        }
                    case "Clients":
                        {
                            int Id = Convert.ToInt32(SicretTextBox.Text);
                            if (Id == null)
                                return;
                            context.Database.EnsureCreated();


                            var a = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo);
                            if (a == DialogResult.Yes)
                            {
                                context.Clients.Remove(context.Clients.Find(Id));
                            }
                            context.SaveChanges();

                            UpdateClientsGrid();



                            break;
                        }
                    case "Orders":
                        {
                            int Id = Convert.ToInt32(SicretTextBox.Text);
                            if (Id == null)
                                return;
                            context.Database.EnsureCreated();


                            var a = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo);
                            if (a == DialogResult.Yes)
                            {
                                context.Orders.Remove(context.Orders.Find(Id));
                            }
                            context.SaveChanges();

                            UpdateOrdersGrid();
                            break;
                        }
                    case "OrderDetails":
                        {
                            int Id = Convert.ToInt32(SicretTextBox.Text);
                            if (Id == null)
                                return;
                            context.Database.EnsureCreated();


                            var a = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo);
                            if (a == DialogResult.Yes)
                            {
                                context.OrderDetails.Remove(context.OrderDetails.Find(Id));
                            }
                            context.SaveChanges();

                            UpdateOrderDetailsGrid();
                            break;
                        }
                    case "Payments":
                        {
                            int Id = Convert.ToInt32(SicretTextBox.Text);
                            if (Id == null)
                                return;
                            context.Database.EnsureCreated();


                            var a = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo);
                            if (a == DialogResult.Yes)
                            {
                                context.Payments.Remove(context.Payments.Find(Id));
                            }
                            context.SaveChanges();

                            UpdatePaymentsGrid();
                            break;
                        }

                }




            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Products":
                    {
                        Product? CurrentItem = dataGridView1.CurrentRow.DataBoundItem as Product;
                        if (CurrentItem == null)
                            return;
                        TextBox1.Text = CurrentItem.Name;
                        TextBox2.Text = CurrentItem.Price.ToString();
                        TextBox3.Text = CurrentItem.Category;
                        TextBox4.Text = CurrentItem.InStock.ToString();
                        SicretTextBox.Text = Convert.ToString(CurrentItem.Id);
                        break;
                    }
                case "Clients":
                    {
                        int Id = Convert.ToInt32(SicretTextBox.Text);
                        if (Id == null)
                            return;
                        context.Database.EnsureCreated();


                        var a = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo);
                        if (a == DialogResult.Yes)
                        {
                            context.Clients.Remove(context.Clients.Find(Id));
                        }
                        context.SaveChanges();

                        UpdateClientsGrid();



                        break;
                    }
                case "Orders":
                    {
                        int Id = Convert.ToInt32(SicretTextBox.Text);
                        if (Id == null)
                            return;
                        context.Database.EnsureCreated();


                        var a = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo);
                        if (a == DialogResult.Yes)
                        {
                            context.Orders.Remove(context.Orders.Find(Id));
                        }
                        context.SaveChanges();

                        UpdateOrdersGrid();
                        break;
                    }
                case "OrderDetails":
                    {
                        int Id = Convert.ToInt32(SicretTextBox.Text);
                        if (Id == null)
                            return;
                        context.Database.EnsureCreated();


                        var a = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo);
                        if (a == DialogResult.Yes)
                        {
                            context.OrderDetails.Remove(context.OrderDetails.Find(Id));
                        }
                        context.SaveChanges();

                        UpdateOrderDetailsGrid();
                        break;
                    }
                case "Payments":
                    {
                        int Id = Convert.ToInt32(SicretTextBox.Text);
                        if (Id == null)
                            return;
                        context.Database.EnsureCreated();


                        var a = MessageBox.Show("Are you sure?", "Question", MessageBoxButtons.YesNo);
                        if (a == DialogResult.Yes)
                        {
                            context.Payments.Remove(context.Payments.Find(Id));
                        }
                        context.SaveChanges();

                        UpdatePaymentsGrid();
                        break;
                    }

            }

        }
    }
}

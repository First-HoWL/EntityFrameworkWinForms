using EntityFrameworkWinForms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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



        private void UpdateProductsGrid()
        {
            using (var context = new UniversityContext())
            {
                try
                {
                    List<Product> Products = new List<Product>();
                    Func<Product, bool> func;
                    context.Database.EnsureCreated();
                    if (comboBox1.Text != "Products")
                        Products = context.Products.OrderBy(s => s.Id).ToList();
                    else
                    {

                        ParameterExpression param = Expression.Parameter(typeof(Product), "s");
                        MemberExpression prop = Expression.Property(param, comboBox2.Text);
                        ConstantExpression val = Expression.Constant(comboBox2.Text == "Id" || comboBox2.Text == "InStock" ?
                            Convert.ToInt32(textBox1.Text) : comboBox2.Text == "Price" ?
                            Convert.ToDouble(textBox1.Text) : textBox1.Text);

                        Expression body;

                        switch (comboBox4.Text)
                        {
                            case ">":
                                body = Expression.GreaterThan(prop, val);
                                break;
                            case "<":
                                body = Expression.LessThan(prop, val);
                                break;
                            default:
                                body = Expression.Equal(prop, val);
                                break;
                        }

                        var lambda = Expression.Lambda<Func<Product, bool>>(body, param);


                        Products = context.Products.Where(lambda).OrderBy(s => s.Id).ToList();
                    }
                    dataGridView1.DataSource = Products;

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                }
            }
        }
        private void UpdateClientsGrid()
        {
            using (var context = new UniversityContext())
            {
                try
                {
                    context.Database.EnsureCreated();
                    List<Client> Clients = new List<Client>();
                    Func<Client, bool> func;
                    if (comboBox1.Text != "Clients")
                        Clients = context.Clients.OrderBy(s => s.Id).ToList();
                    else
                    {
                        ParameterExpression param = Expression.Parameter(typeof(Client), "s");
                        MemberExpression prop = Expression.Property(param, comboBox2.Text);
                        ConstantExpression val = Expression.Constant(comboBox2.Text == "Id" ?
                            Convert.ToInt32(textBox1.Text) : textBox1.Text);

                        Expression body;

                        switch (comboBox4.Text)
                        {
                            case ">":
                                body = Expression.GreaterThan(prop, val);
                                break;
                            case "<":
                                body = Expression.LessThan(prop, val);
                                break;
                            default:
                                body = Expression.Equal(prop, val);
                                break;
                        }

                        var lambda = Expression.Lambda<Func<Client, bool>>(body, param);


                        Clients = context.Clients.Where(lambda).OrderBy(s => s.Id).ToList();
                    }

                    dataGridView2.DataSource = Clients;

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                }
            }
        }
        private void UpdateOrdersGrid()
        {
            using (var context = new UniversityContext())
            {

                List<Order> Orders = new List<Order>();
                Func<Order, bool> func;
                if (comboBox1.Text != "Orders")
                    Orders = context.Orders.Include(s => s.Client).OrderBy(s => s.Id).ToList();
                else
                {
                    try
                    {
                        var client = context.Clients.ToList();
                        ParameterExpression param = Expression.Parameter(typeof(Order), "s");
                        MemberExpression prop = Expression.Property(param, comboBox2.Text);
                        ConstantExpression val = Expression.Constant(comboBox2.Text == "Id" ?
                            Convert.ToInt32(textBox1.Text) : comboBox2.Text == "OrderDate" ?
                            Convert.ToDateTime(dateTimePicker1.Text).Date : comboBox2.Text == "Client" ?
                            context.Clients.Find(client[comboBox3.SelectedIndex].Id) : textBox1.Text
                            );

                        Expression body;

                        switch (comboBox4.Text)
                        {
                            case ">":
                                body = Expression.GreaterThan(prop, val);
                                break;
                            case "<":
                                body = Expression.LessThan(prop, val);
                                break;
                            default:
                                body = Expression.Equal(prop, val);
                                break;
                        }

                        var lambda = Expression.Lambda<Func<Order, bool>>(body, param);


                        Orders = context.Orders.Where(lambda).Include(s => s.Client).OrderBy(s => s.Id).ToList();
                    }
                    catch (Exception ex)
                    {

                    }
                }



                context.Database.EnsureCreated();
                dataGridView3.DataSource = Orders;

                context.SaveChanges();
            }
        }
        private void UpdateOrderDetailsGrid()
        {

            using (var context = new UniversityContext())
            {

                List<OrderDetails> OrderDetails = new List<OrderDetails>();
                Func<OrderDetails, bool> func;
                if (comboBox1.Text != "OrderDetails")
                    OrderDetails = context.OrderDetails.Include(s => s.Order).Include(s => s.Product).OrderBy(s => s.Id).ToList();
                else
                {
                    try
                    {
                        var Orders = context.Orders.ToList();
                        var Products = context.Products.ToList();
                        ParameterExpression param = Expression.Parameter(typeof(OrderDetails), "s");
                        MemberExpression prop = Expression.Property(param, comboBox2.Text);
                        ConstantExpression val = Expression.Constant(comboBox2.Text == "Id" || comboBox2.Text == "Quanity" ?
                            Convert.ToInt32(textBox1.Text) : comboBox2.Text == "Order" ?
                            context.Orders.Find(Orders[comboBox3.SelectedIndex].Id) :
                            context.Products.Find(Products[comboBox3.SelectedIndex].Id)
                            );

                        Expression body;

                        switch (comboBox4.Text)
                        {
                            case ">":
                                body = Expression.GreaterThan(prop, val);
                                break;
                            case "<":
                                body = Expression.LessThan(prop, val);
                                break;
                            default:
                                body = Expression.Equal(prop, val);
                                break;
                        }

                        var lambda = Expression.Lambda<Func<OrderDetails, bool>>(body, param);


                        OrderDetails = context.OrderDetails.Where(lambda).Include(s => s.Order).Include(s => s.Product).OrderBy(s => s.Id).ToList();
                    }
                    catch (Exception ex)
                    {

                    }
                }



                context.Database.EnsureCreated();
                dataGridView4.DataSource = OrderDetails;

                context.SaveChanges();
            }

        }
        private void UpdatePaymentsGrid()
        {

            using (var context = new UniversityContext())
            {

                List<Payment> Payments = new List<Payment>();
                Func<Payment, bool> func;
                if (comboBox1.Text != "Payments")
                    Payments = context.Payments.Include(s => s.Order).OrderBy(s => s.Id).ToList();
                else
                {
                    try
                    {
                        var Orders = context.Orders.ToList();
                        ParameterExpression param = Expression.Parameter(typeof(Payment), "s");
                        MemberExpression prop = Expression.Property(param, comboBox2.Text);
                        ConstantExpression val = Expression.Constant(comboBox2.Text == "Id" ?
                            Convert.ToInt32(textBox1.Text) : comboBox2.Text == "Amount" ?
                            Convert.ToDouble(textBox1.Text) : comboBox2.Text == "Date" ?
                            Convert.ToDateTime(dateTimePicker1.Text).Date : comboBox2.Text == "Order" ?
                            context.Orders.Find(Orders[comboBox3.SelectedIndex].Id) : textBox1.Text
                            );

                        Expression body;

                        switch (comboBox4.Text)
                        {
                            case ">":
                                body = Expression.GreaterThan(prop, val);
                                break;
                            case "<":
                                body = Expression.LessThan(prop, val);
                                break;
                            default:
                                body = Expression.Equal(prop, val);
                                break;
                        }

                        var lambda = Expression.Lambda<Func<Payment, bool>>(body, param);


                        Payments = context.Payments.Include(s => s.Order).Where(lambda).OrderBy(s => s.Id).ToList();
                    }
                    catch (Exception ex)
                    {
                    }
                }
                context.Database.EnsureCreated();
                dataGridView5.DataSource = Payments;

                context.SaveChanges();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[]{
                "Products",
                "Clients",
                "Orders",
                "OrderDetails",
                "Payments"
            });
            comboBox4.Items.AddRange(new string[]{
                ">",
                "<",
                "=="
            });

            UpdateGrids();

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new UniversityContext())
            {
                comboBox2.Visible = true;
                textBox1.Visible = true;
                button1.Visible = true;
                comboBox4.Visible = true;

                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.SelectedIndex = -1;
                dateTimePicker1.Text = DateTime.Now.Date.ToString();
                textBox1.Text = string.Empty;


                switch (comboBox1.Text)
                {
                    case "Products":
                        {
                            comboBox2.Items.AddRange(new string[]{
                                "Id",
                                "Name",
                                "Price",
                                "Category",
                                "InStock"
                            });


                            break;
                        }
                    case "Clients":
                        {
                            comboBox2.Items.AddRange(new string[]{
                                "Id",
                                "Name",
                                "Phone"
                            });

                            break;
                        }
                    case "Orders":
                        {
                            comboBox2.Items.AddRange(new string[]{
                                "Id",
                                "Client",
                                "OrderDate",
                                "Status"
                            });
                            break;
                        }
                    case "OrderDetails":
                        {
                            comboBox2.Items.AddRange(new string[]{
                                "Id",
                                "Order",
                                "Product",
                                "Quanity"
                            });
                            break;
                        }
                    case "Payments":
                        {
                            comboBox2.Items.AddRange(new string[]{
                                "Id",
                                "Amount",
                                "PaymentMethod",
                                "Date",
                                "Order"
                            });
                            break;
                        }
                }
            }
        }

        public void changeComboBox4(string[] strings)
        {
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(strings);
            comboBox4.SelectedIndex = -1;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Products":
                    {
                        comboBox3.Visible = false;
                        textBox1.Visible = true;
                        dateTimePicker1.Visible = false;

                        switch (comboBox2.Text)
                        {
                            case "Id":
                                {
                                    changeComboBox4(new string[] { ">", "<", "==" });
                                    break;
                                }
                            case "Name":
                                {
                                    changeComboBox4(new string[] { "==" });
                                    break;
                                }
                            case "Price":
                                {
                                    changeComboBox4(new string[] { ">", "<", "==" });
                                    break;
                                }
                            case "Category":
                                {
                                    changeComboBox4(new string[] { "==" });
                                    break;
                                }
                            case "InStock":
                                {
                                    changeComboBox4(new string[] { ">", "<", "==" });
                                    break;
                                }

                        }


                        break;
                    }
                case "Clients":
                    {
                        comboBox3.Visible = false;
                        textBox1.Visible = true;
                        dateTimePicker1.Visible = false;

                        switch (comboBox2.Text)
                        {
                            case "Id":
                                {
                                    changeComboBox4(new string[] { ">", "<", "==" });
                                    break;
                                }
                            case "Name":
                                {
                                    changeComboBox4(new string[] { "==" });
                                    break;
                                }
                            case "Phone":
                                {
                                    changeComboBox4(new string[] { "==" });
                                    break;
                                }

                        }

                        break;
                    }
                case "Orders":
                    {
                        dateTimePicker1.Visible = false;
                        switch (comboBox2.Text)
                        {
                            case "Id":
                                {
                                    changeComboBox4(new string[] { ">", "<", "==" });
                                    comboBox3.Visible = false;
                                    textBox1.Visible = true;
                                    break;
                                }
                            case "Client":
                                {
                                    changeComboBox4(new string[] { "==" });
                                    comboBox3.Visible = true;
                                    textBox1.Visible = false;
                                    break;
                                }
                            case "OrderDate":
                                {
                                    changeComboBox4(new string[] { ">", "<", "==" });
                                    comboBox3.Visible = false;
                                    textBox1.Visible = true;
                                    break;
                                }
                            case "Status":
                                {
                                    changeComboBox4(new string[] { "==" });
                                    comboBox3.Visible = false;
                                    textBox1.Visible = true;
                                    break;
                                }

                        }
                        break;
                    }
                case "OrderDetails":
                    {
                        dateTimePicker1.Visible = false;
                        switch (comboBox2.Text)
                        {
                            case "Id":
                                {
                                    changeComboBox4(new string[] { ">", "<", "==" });
                                    comboBox3.Visible = false;
                                    textBox1.Visible = true;
                                    break;
                                }
                            case "Order":
                                {
                                    changeComboBox4(new string[] { "==" });
                                    comboBox3.Visible = true;
                                    textBox1.Visible = false;
                                    break;
                                }
                            case "Product":
                                {
                                    changeComboBox4(new string[] { "==" });
                                    comboBox3.Visible = true;
                                    textBox1.Visible = false;
                                    break;
                                }
                            case "Quanity":
                                {
                                    changeComboBox4(new string[] { ">", "<", "==" });
                                    comboBox3.Visible = false;
                                    textBox1.Visible = true;
                                    break;
                                }

                        }
                        break;
                    }
                case "Payments":
                    {
                        switch (comboBox2.Text)
                        {
                            case "Id":
                                {
                                    changeComboBox4(new string[] { ">", "<", "==" });
                                    dateTimePicker1.Visible = false;
                                    comboBox3.Visible = false;
                                    textBox1.Visible = true;
                                    break;
                                }
                            case "Amount":
                                {
                                    changeComboBox4(new string[] { ">", "<", "==" });
                                    dateTimePicker1.Visible = false;
                                    comboBox3.Visible = false;
                                    textBox1.Visible = true;
                                    break;
                                }
                            case "PaymentMethod":
                                {
                                    changeComboBox4(new string[] { "==" });
                                    dateTimePicker1.Visible = false;
                                    comboBox3.Visible = false;
                                    textBox1.Visible = true;
                                    break;
                                }
                            case "Order":
                                {
                                    changeComboBox4(new string[] { "==" });
                                    dateTimePicker1.Visible = false;
                                    comboBox3.Visible = true;
                                    textBox1.Visible = false;
                                    break;
                                }
                            case "Date":
                                {
                                    changeComboBox4(new string[] { ">", "<", "==" });
                                    dateTimePicker1.Visible = true;
                                    comboBox3.Visible = false;
                                    textBox1.Visible = false;
                                    break;
                                }

                        }

                        break;
                    }
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Products":
                    {
                        if (textBox1.Text == string.Empty || comboBox2.Text == string.Empty)
                            MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            UpdateProductsGrid();
                        }


                        break;
                    }
                case "Clients":
                    {
                        if (textBox1.Text == string.Empty || comboBox2.Text == string.Empty)
                            MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            UpdateClientsGrid();
                        }

                        break;
                    }
                case "Orders":
                    {
                        switch (comboBox2.Text)
                        {
                            case "Id":
                                {
                                    if (textBox1.Text == string.Empty || comboBox2.Text == string.Empty)
                                        MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        UpdateOrdersGrid();
                                    }
                                    break;
                                }
                            case "Client":
                                {
                                    if (comboBox3.Text == string.Empty || comboBox2.Text == string.Empty)
                                        MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        UpdateOrdersGrid();
                                    }
                                    break;
                                }
                            case "OrderDate":
                                {
                                    if (dateTimePicker1.Text == string.Empty || comboBox2.Text == string.Empty)
                                        MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        UpdateOrdersGrid();
                                    }
                                    break;
                                }
                            case "Status":
                                {
                                    if (textBox1.Text == string.Empty || comboBox2.Text == string.Empty)
                                        MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        UpdateOrdersGrid();
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "OrderDetails":
                    {
                        switch (comboBox2.Text)
                        {
                            case "Id":
                                {
                                    if (textBox1.Text == string.Empty || comboBox2.Text == string.Empty)
                                        MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        UpdateOrderDetailsGrid();
                                    }
                                    break;
                                }
                            case "Order":
                                {
                                    if (comboBox3.Text == string.Empty || comboBox2.Text == string.Empty)
                                        MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        UpdateOrderDetailsGrid();
                                    }
                                    break;
                                }
                            case "Product":
                                {
                                    if (comboBox3.Text == string.Empty || comboBox2.Text == string.Empty)
                                        MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        UpdateOrderDetailsGrid();
                                    }
                                    break;
                                }
                            case "Quanity":
                                {
                                    if (textBox1.Text == string.Empty || comboBox2.Text == string.Empty)
                                        MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        UpdateOrderDetailsGrid();
                                    }
                                    break;
                                }

                        }
                        break;
                    }
                case "Payments":
                    {
                        switch (comboBox2.Text)
                        {
                            case "Id":
                                {
                                    if (textBox1.Text == string.Empty || comboBox2.Text == string.Empty)
                                        MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        UpdatePaymentsGrid();
                                    }
                                    break;
                                }
                            case "Amount":
                                {
                                    if (textBox1.Text == string.Empty || comboBox2.Text == string.Empty)
                                        MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        UpdatePaymentsGrid();
                                    }
                                    break;
                                }
                            case "PaymentMethod":
                                {
                                    if (textBox1.Text == string.Empty || comboBox2.Text == string.Empty)
                                        MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        UpdatePaymentsGrid();
                                    }
                                    break;
                                }
                            case "Order":
                                {
                                    if (comboBox3.Text == string.Empty || comboBox2.Text == string.Empty)
                                        MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        UpdatePaymentsGrid();
                                    }
                                    break;
                                }
                            case "Date":
                                {
                                    if (dateTimePicker1.Text == string.Empty || comboBox2.Text == string.Empty)
                                        MessageBox.Show("DON\'T DO THAT!", "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    else
                                    {
                                        UpdatePaymentsGrid();
                                    }
                                    break;
                                }

                        }
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}

using EntityFrameworkWinForms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace EntityFrameworkWinForms
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new UniversityContext())
            {
                switch (comboBox1.Text)
                {
                    case "1. Товари > 500 грн":
                        {
                            var text = context.Products.Where(s => s.Price >= 500).OrderBy(s => s.Id).ToList();

                            dataGridView1.DataSource = text;

                            break;
                        }
                    case "2. Загальна сума замовлень клієнтів":
                        {
                            var result = context.Payments.Include(p => p.Order).ThenInclude(p => p.Client)
                                .GroupBy(p => p.Order.Client)
                                .Select(g => new
                                {
                                    Client = g.Key.Name,
                                    TotalSum = g.Sum(p => p.Amount)
                                }).ToList();
                            dataGridView1.DataSource = result;

                            break;
                        }
                    case "3. Товари < 5 шт.":
                        {
                            var text = context.Products.Where(s => s.InStock < 5).OrderBy(s => s.Id).ToList();

                            dataGridView1.DataSource = text;

                            break;
                        }
                    case "4. Найпопулярніший товар":
                        {
                            var text = context.OrderDetails
                                .Include(od => od.Product)
                                .Where(od => od.Product != null)
                                .GroupBy(od => od.Product.Name)
                                .Select(g => new ProductSaleInfo
                                {
                                    ProductName = g.Key,
                                    TotalSold = g.Sum(od => od.Quanity)
                                })
                                .OrderByDescending(g => g.TotalSold).FirstOrDefault();

                            dataGridView1.DataSource = new List<ProductSaleInfo> { text };

                            break;
                        }
                    case "5. Клієнти з ≥3 замовленнями":
                        {
                            var text = context.Payments
                                .Include(p => p.Order)
                                .ThenInclude(o => o.Client)
                                .GroupBy(p => p.Order.Id)
                                .Where(g => g.Count() >= 3)
                                .Select(g => new
                                {
                                    OrderId = g.Key,
                                    ClientName = g.First().Order.Client.Name,
                                    PaymentsCount = g.Count()
                                })
                                .ToList();

                            dataGridView1.DataSource = text;
                            break;
                        }
                    case "6. Замовлення + товари":
                        {
                            var text = context.OrderDetails
                                .Include(od => od.Order)
                                .Include(od => od.Product)
                                .OrderBy(od => od.Order.Id)
                                .Select(od => new
                                {
                                    OrderId = od.Order.Id,
                                    ProductInfo = od.Product.Name + " x" + od.Quanity
                                })
                                .ToList();


                            dataGridView1.DataSource = text;

                            break;
                        }
                    case "7. Оплати за місяць":
                        {
                            var text = context.Payments
                                .Where(p => p.Date >= DateTime.Now.AddMonths(-1))
                                .Include(p => p.Order)
                                .ToList();



                            dataGridView1.DataSource = text;
                            break;
                        }
                    case "8. Середня вартість замовлень":
                        {
                            var text = context.Payments
                                .GroupBy(p => p.Order.Id)
                                .Select(g => new
                                {
                                    OrderID = g.Key,
                                    Average = g.Sum(p => p.Amount) / g.Count()
                                }).ToList();


                            dataGridView1.DataSource = text;
                            break;
                        }
                    case "9. Клієнти без замовлень":
                        {
                            var text = context.Clients
                                .Where(c => !context.Orders.Any(o => o.Client.Id == c.Id))
                                .Select(c => new
                                {
                                    Name = c.Name,
                                    c.Phone
                                }).ToList();


                            dataGridView1.DataSource = text;
                            break;
                        }
                    case "10. Недоставлені замовлення":
                        {
                            var text = context.Orders
                                .Where(o => o.Status != "Delivered")
                                .Include(o => o.Client)
                                .Select(o => new
                                {
                                    OrderID = o.Id,
                                    Client = o.Client.Name,
                                    Status = o.Status,
                                    Date = o.OrderDate
                                }).ToList();

                            dataGridView1.DataSource = text;
                            break;
                        }
                }
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[] {
                "1. Товари > 500 грн",
                "2. Загальна сума замовлень клієнтів",
                "3. Товари < 5 шт.",
                "4. Найпопулярніший товар",
                "5. Клієнти з ≥3 замовленнями",
                "6. Замовлення + товари",
                "7. Оплати за місяць",
                "8. Середня вартість замовлень",
                "9. Клієнти без замовлень",
                "10. Недоставлені замовлення"
            });
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

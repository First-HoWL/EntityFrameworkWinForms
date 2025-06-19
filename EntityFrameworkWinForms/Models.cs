using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EntityFrameworkWinForms.Models
{
    public class ProductSaleInfo
    {
        public string ProductName { get; set; }
        public int TotalSold { get; set; }
    }


    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public int InStock { get; set; }

        public override string ToString()
        {
            return $"{Id,5} | {Name,20} | {Price , 8} | {Category, 20} | {InStock, 9}";
        }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Id, 5} | {Name, 20} | {Phone, 12}";
        }

    }

    public class Order
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public override string ToString()
        {
            return $"{Id,5} | {Status, 15}| {OrderDate} | {Client} ";
        }

    }

    public class OrderDetails
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quanity { get; set; }
        public override string ToString()
        {
            return $"{Id,5} | {Quanity, 8}| {Product} | {Order.Id + " | " + Order.Client} ";
        }

    }

    public class Payment
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime Date { get; set; }
        public Order Order { get; set; }

        public override string ToString()
        {
            return $"{Id,5} | {Amount ,8}| {Date} | {PaymentMethod} | {Order}";
        }
    }

    public class UniversityContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;database=shop;user=root;password=";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}

using System;
using System.Collections.Generic;

namespace DBWebMvcApp.Models
{
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrderDetail")]
    public class Order
    {
        [Column("OrderNo")]
        public int Id { get; set; }

        [Display(Name = "Order Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Customer ID")]
        public string CustomerId { get; set; }

        [ScaffoldColumn(false)]
        [Column("ProductNo")]
        public int ProductId { get; set; }

        public int Quantity { get; set; }   
    }

    [Table("Product")]
    public class Product
    {
        [Display(Name = "Product No")]
        [Column("ProductNo")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name = "Unit Price")]
        public decimal Price { get; set; }

        [Display(Name = "Current Stock")]
        [Range(5, 50)]
        public int Stock { get; set; }

        //navigation property
        public ICollection<Order> Orders { get; set; }  
    }

    public class Counter
    {
        public string Id { get; set; }

        public int CurrentValue { get; set; }   
    }

    public class ShopEntities : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Counter> Counters { get; set; }

        public ShopEntities() : base(Properties.Settings.Default.ShopConnectionString)
        {

        } 
    }
}
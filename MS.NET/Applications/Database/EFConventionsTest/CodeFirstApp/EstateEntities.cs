namespace CodeFirstApp
{
    using System.Data.Entity;

    public abstract class House
    {
        public int Id { get; set; }

        public float Area { get; set; } 
    }

    public class Apartment : House
    {
        public int Floor { get; set; }  
    }

    public class Bungalow : House
    {
        public int Floors { get; set; } 
    }

    public class EstateEntities : DbContext
    {
        public DbSet<House> Houses { get; set; }    
    }
}

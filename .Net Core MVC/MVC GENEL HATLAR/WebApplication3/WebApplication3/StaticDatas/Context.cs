using WebApplication3.Models;

namespace WebApplication3.StaticDatas
{
    public static class Context
    {
        public static List<Product> Products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Telefon", UnitStock = 100 },
            new Product { ProductId = 2, ProductName = "Bilgisayar", UnitStock = 68 },
            new Product { ProductId = 3, ProductName = "Klima", UnitStock = 10 }
        };
    }
}

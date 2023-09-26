using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string[] Colors { get; set; }
        public int Brand { get; set; }
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            Id = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }
        public override string ToString()
            => $"{Id,3}{Name,12}{Price,5}{Brand,2}{string.Join(",", Colors)}";
    }
    public class Brand
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }

    class Program_Ex3
    {
        static void Main(string[] args)
        {
            var brands = new List<Brand>() {
                new Brand{ID = 1, Name = "Công Ty AAA"},
                new Brand{ID = 2, Name = "Công Ty BBB"},
                new Brand{ID = 4, Name = "Công Ty CCC"},
            };

            var products = new List<Product>()
            {
                new Product(1,"Ban Tra"         , 400, new string[] {"Xam", "Xanh"},         2),
                new Product(2,"Tranh Treo"      , 400, new string[] {"Vang", "Xanh"},        1),
                new Product(3,"Đen Trum"        , 500, new string[] {"Trang"},               3),
                new Product(4,"Ban Hoc"         , 200, new string[] {"Trang", "Xanh"},       1),
                new Product(5,"Tui Da"          , 300, new string[] {"Do", "Den", "Vang"},   2),
                new Product(6,"Giuong Ngu"      , 500, new string[] {"Trang"},               2),
                new Product(7,"Tu Ao"           , 600, new string[] {"Trang"},               3),
            };

            /*
            a.Filter out products with a price of 400.
            */
            Console.WriteLine("****************************************\n");
            Console.WriteLine(" Cau A: \n");
            List<Product> filteredProductsByPrice = products.Where(product => product.Price == 400).ToList();

            foreach (var item in filteredProductsByPrice)
            {
                Console.WriteLine($"{item.Name,10} {item.Price,4} {item.Brand,12} \n");
            }
            Console.WriteLine("****************************************\n");

            /*
               b.	Each product name has an array of colors.       
              Filter out products that contain the color yellow.
            */

            Console.WriteLine(" Cau B: \n");
            List<Product> filteredProductsByColors = products.Where(product => product.Colors.Contains("Vang")).ToList();
            
            foreach (var item in filteredProductsByColors)
            {
                Console.WriteLine($"Name: {item.Name},  Price: {item.Price},  Colors: {string.Join(", ", item.Colors)}\n");
                
            }
            Console.WriteLine("****************************************\n");

            /*
            c.Display the list of products in descending order of price. 
            */

            Console.WriteLine(" Cau C: \n");

            List<Product> sortedProducts = products.OrderByDescending(product => product.Price).ToList();

            foreach (Product product in sortedProducts)
            {
                Console.WriteLine($"Name: {product.Name},\t\t Price: {product.Price}");
            }
            Console.WriteLine("****************************************\n");




            var ketqua = from product in products
                         join brand in brands on product.Brand equals brand.ID into t
                         from brand in t.DefaultIfEmpty()
                         select new
                         {
                             name = product.Name,
                             brand = (brand == null) ? "NO-BRAND" : brand.Name,
                             price = product.Price
                         };
            foreach (var item in ketqua)
            {
                Console.WriteLine($"{item.name,10} {item.price,4} {item.brand,12}");
            }
        }
    }
}

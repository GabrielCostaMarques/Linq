using LinqClass.DemoLinq.Entities;

namespace LinqClass.DemoLinq
{
    class AlternativeSintaxe
    {
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);

            foreach (T item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
        public void AlternativeSintaxeShow()
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

            List<Product> products = new() {
            new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 },
            new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
            new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3 },
            new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 },
            new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
            new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 },
            new Product() { Id = 7, Name = "Printer", Price = 350.0, Category = c3 },
            new Product() { Id = 8, Name = "MacBook", Price = 1800.0, Category = c2 },
            new Product() { Id = 9, Name = "SoundBar", Price = 700.0, Category = c3},
            new Product() { Id = 10, Name = "Level", Price = 70.0, Category = c1 },
            new Product() { Id = 11, Name = "Camera", Price = 700.0, Category = c3 } };


            //sintaxe alternativa
            var r1 =
                from p in products
                where p.Category.Tier == 1 && p.Price < 900.0
                select p;

            var r2 =
                from p in products
                where p.Category.Name == "Tools"
                select p.Name;

            var r3 =
                from p in products
                where p.Name[0] == 'C'
                select new
                {
                    p.Name,
                    p.Price,
                    CategoryName = p.Category.Name
                };

            var r4 =
                from p in products
                where p.Category.Tier == 1
                //nessa sintaxe precisa colocar a order invertida do filtro
                orderby p.Name
                orderby p.Price
                select p;

            var r5 =
                (from p in products
                 select p).Skip(2).Take(4);

            var r6 = (from p in products select p).FirstOrDefault();

            var r7 = (from p in products
                      where p.Price>3000.00
                      select p).FirstOrDefault();

            var r8 = from p in products
                     group p by p.Category;

            Print("Tier 1 and Price < 900: ", r1);
            Print("Category Tools only names ", r2);
            Print("Products started C ", r3);
            Print("Order by prince and name", r4);
            Print("Skip and Take", r5);
            Console.WriteLine("First or Default function: "+ r6);
            Console.WriteLine("Products < 3000: "+ r7);

            foreach (var p in r8)
            {
                Console.WriteLine("Category: "+ p.Key.Name);
                foreach(Product p2 in p)
                {
                    Console.WriteLine(p2);
                }
                Console.WriteLine();
            }



        }
    }
}

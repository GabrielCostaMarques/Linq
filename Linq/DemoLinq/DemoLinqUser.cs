using LinqClass.DemoLinq.Entities;

namespace LinqClass.DemoLinq
{
    class DemoLinqUser
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
        public void DemoLinqShow()
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

            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);

            var r2 = products.Where(p => p.Category.Name == "Tools").Select(n => n.Name);


            //Mapeando produtos que começam com C porém limitando o que vai ser impresso, nesse caso Nome, Preço e nome da categoria, o compilador nao aceita o obj com o mesmo nome, entao tem que dar um "apelido" para ele, no caso foi o "CategoryName, também foi criado um obj anônimo (n=> new{})
            var r3 = products
                .Where(p => p.Name.Contains("C"))
                .Select(n => new
                { n.Name, n.Price, CategoryName = n.Category.Name });


            var r4 = products
                .Where(p => p.Category.Tier == 1)
                .OrderBy(o => o.Price)
                .ThenBy(o => o.Name);

            //pula dois e pega os 4 da lista
            var r5 = r4.Skip(2).Take(4);


            //pega o primeiro elemento e se a lista vier vazia, ele retorna null e ñão uma exceção
            var r6 = products
                .Where(p => p.Price > 3000)
                .Select(p => p.Name).SingleOrDefault();



            //Pega o unico elemento da lista, se for false, retorna null
            var r8 = products
                .Where(p => p.Id == 3)
                .SingleOrDefault();


            var r9 = products
                .Where(p => p.Id == 30)
                .SingleOrDefault();


            // Agrupa as categoria, seleciona o name da categoria, o key ele serve para pegar o nome da categoria e o produto
            var r10 = products
                .GroupBy(p => p.Category)
                .Select(o =>
                new
                {
                    CategoryName = o.Key.Name,
                    Count = o.Count()
                });



            //soma todos os produtos com a categoria computers
            var r11 = products
                .Where(p => p.Category.Name == "Computers")
                .Sum(p=>p.Price);
            

            //media de todos os produtos de uma categoria
            var r12 = products
                .Where(p => p.Category.Name == "Computers")
                .Average(p=>p.Price);

            //pegando menor e maior valor
            string r13 = $"Menor preço: ${products.Min(p => p.Price)}, Maior preço: ${products.Max(p => p.Price)}";

            //todos os preços somados
            var r14 = products
                .Select(p => p.Price)
                .Aggregate((acummulator, currentValue) => acummulator + currentValue);



            Print("Tier 1 and Price <900: ", r1);
            Print("Name tools catergory: ", r2);
            Print("Name products start c: ", r3);
            Print("tier 1 and order by Price then name: ", r4);
            Print("tier 1 and order by Price then name Skip 2 take 4: ", r5);
            Console.WriteLine("First teste 1: " + r6);
            Console.WriteLine("Single or Default: " + r8);
            Console.WriteLine("Single or Default: " + r9);
            foreach (var item in r10)
            {
                Console.WriteLine($"Categoria: {item.CategoryName}, Quantidade: {item.Count}");
            }

            Console.WriteLine(r11);
            Console.WriteLine(r12);
            Console.WriteLine(r13);
            Console.WriteLine("all products Agregrate sum: "+r14);


        }
    }
}

using System.Transactions;
using System.IO;
using LinqClass.Exercicie.Entities;
using System.Globalization;

namespace LinqClass.Exercicie
{
    class ExercicieLinq
    {
        public void ExercicieLinqShow()
        {
            List<Product> list = [];

            Console.WriteLine("Enter full file path: ");
            string path = Console.ReadLine();

            using (StreamReader reader =File.OpenText(path))
            {
                while (!reader.EndOfStream)
                {
                    string[] prod = reader.ReadLine().Split(',');
                    string name = prod[0];
                    double price = double.Parse(prod[1],CultureInfo.InvariantCulture);

                    list.Add(new Product(name, price));
                }
            }

            var avg = list.Select(p=>p.Price).DefaultIfEmpty(0.0).Average();

            Console.WriteLine("Avarage Price: " + avg.ToString("F2", CultureInfo.InvariantCulture));

            var result = list.Where(p => p.Price < avg).OrderByDescending(p =>p.Name).Select(p=>p.Name);

            foreach (string item in result)
            {
                Console.WriteLine(item);
            }



        }
    }
}

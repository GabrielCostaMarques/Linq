namespace LinqClass.Word
{
    internal class WordUser
    {
        public void WordShow()
        {
            List<string> list = new() { "Feijão", "Batata", "aaaaaaaaaaaa", "amendoim", "cloro" };


            int count = 0;


            //jeito com linq
            int count1 = list.Sum(c => c.Count(letra => letra == 'a'));

            Console.WriteLine(count1);



            //jeito sem linq
            foreach (var item in list)
            {
                foreach (char letra in item)
                {
                    if (letra=='a')
                    {
                        count += 1;

                    }
                }
            }
            Console.WriteLine(count);

        }
    }
}

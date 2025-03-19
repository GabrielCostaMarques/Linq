using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Intro
{
    class IntroUser
    {
        public void IntroShow()
        {
            //especificando o dado
            int[] numbers = new int[] { 2, 3, 4, 5 };

            //definir a expressão de consulta
            //definindo a consulta, ela procura os numero pares e "select" eles multiplicando por 10
            var result = numbers
                .Where(n => n % 2 == 0)
                .Select(n => n * 10);

            //executando a consulta
            foreach (int item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}

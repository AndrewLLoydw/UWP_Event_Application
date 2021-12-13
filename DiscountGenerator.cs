using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp
{
    public class DiscountGenerator
    {
        public int GenerateCode()
        {
            var randomNumber = new Random();

            for (int i = 0; i < 10; i++)
                Console.Write(randomNumber.Next(10, 100));

            return randomNumber.Next(10, 100);

        }
    }
}

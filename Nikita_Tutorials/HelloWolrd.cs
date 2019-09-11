using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            byte number = 2;
            int count = 10;
            float totalPrice = 20.95f;
            char character = 'A';
            string firstName = "Nikita";
            bool isWorking = false;

            var number1 = 2;
            var count1 = 10;
            var totalPrice1 = 20.95f;
            var character1 = 'A';
            var firstName1 = "Nikita";
            var isWorking1 = false;

            //different formats
            Console.WriteLine("Hello World!");
            Console.WriteLine(count);
            Console.WriteLine(totalPrice);
            Console.WriteLine(number);
            Console.WriteLine(character);
            Console.WriteLine(firstName); 
            Console.WriteLine(isWorking);

            Console.WriteLine(count1);
            Console.WriteLine(totalPrice1);
            Console.WriteLine(number1);
            Console.WriteLine(character1);
            Console.WriteLine(firstName1);
            Console.WriteLine(isWorking1);

            Console.WriteLine("{0} {1}", byte.MinValue, byte.MaxValue);
            Console.WriteLine("{0} {1}", float.MinValue, float.MaxValue);

            try
            {
                string str = "true";
                bool w = Convert.ToBoolean(str);
                Console.WriteLine(w);
            }
            catch (Exception)
            {
                Console.WriteLine("number could not be converted to byte");

            }


            //compare
            var a = 10;
            var b = 4;
            
            Console.WriteLine((float)a/(float)b);

            var c = 1;
            var d = 2;
            var e = 3;
            Console.WriteLine((c + d) * e);
            Console.WriteLine(e > d && e == c);
            Console.WriteLine(e > d || e == c);
            Console.WriteLine(!(e > d || e == c));

            var f = 5;
            var g = 6;

            Console.WriteLine(!(f !=g));
         
        }
    }
}
using System;
using System.Text;
using System.Diagnostics;

namespace SpeedTest
{
    public class RandomGenerator
    {
        // Instantiate random number generator.  
        // It is better to keep a single Random instance 
        // and keep using Next on the same instance.  
        private readonly Random _random = new Random();
        
        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        
        // Generates a random string with a given size.    
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):   
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
        
        public string RandomPasswordShort()
        {
            var passwordBuilder = new StringBuilder();

            // 4-Letters lower case   
            passwordBuilder.Append(RandomString(10, true));

            // 4-Digits between 1000 and 9999  
            //passwordBuilder.Append(RandomNumber(1000, 9999));

            // 2-Letters upper case  
            //passwordBuilder.Append(RandomString(2));
            return passwordBuilder.ToString();
        }
        public string RandomPasswordLong()
        {
            var passwordBuilder = new StringBuilder();

            // 4-Letters lower case   
            passwordBuilder.Append(RandomString(100, true));

            // 4-Digits between 1000 and 9999  
            //passwordBuilder.Append(RandomNumber(1000, 9999));

            // 2-Letters upper case  
            //passwordBuilder.Append(RandomString(2));
            return passwordBuilder.ToString();
        }
    }

    class Program
    {
        enum Mode : byte
        {
            STRING_SHORT,
            STRING_LONG
        }

        static RandomGenerator rg = new RandomGenerator();

        static bool StringShort(string value)
        {
            return (value == "1234567890") ? true : false;
        }
        static bool StringLong(string value)
        {
            return (value == "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890") ? true : false;
        }

        static bool Testing(Mode mode)
        {
            return
                (mode == Mode.STRING_SHORT) ? StringShort(rg.RandomPasswordShort()) :
                (mode == Mode.STRING_LONG) ? StringLong(rg.RandomPasswordLong()) : false;
        }
        static long Test(Mode mode)
        {
            //создаем объект
            Stopwatch stopwatch = new Stopwatch();
            //засекаем время начала операции
            stopwatch.Start();
            //выполняем какую-либо операцию
            for (int i = 0; i < 5000000; i++)
                    Testing(mode);
            //останавливаем счётчик
            stopwatch.Stop();
            //смотрим сколько миллисекунд было затрачено на выполнение
            Console.WriteLine("mode:[{0}], \tmsec:[{1}], \ttime:[{2}]", mode.ToString(), stopwatch.ElapsedMilliseconds, Time(stopwatch));
            return (stopwatch.ElapsedMilliseconds);
        }
        static string Time(Stopwatch stopwatch)
        {
            //получаем объект TimeSpan
            TimeSpan ts = stopwatch.Elapsed;
            // Создаем строку, содержащую время выполнения операции.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            return elapsedTime;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("mode:[{0}], \texample:[{1}]", Mode.STRING_SHORT, rg.RandomPasswordShort());
            Console.WriteLine("mode:[{0}], \texample:[{1}]", Mode.STRING_LONG, rg.RandomPasswordLong());
            Test(Mode.STRING_SHORT);
            Test(Mode.STRING_LONG);

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();

            Console.WriteLine("Terminating the application...");
        }
    }
}
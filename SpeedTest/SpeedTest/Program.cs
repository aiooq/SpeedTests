using System;
using System.Text;
using System.Diagnostics;

namespace SpeedTest
{
    class Program
    {
        enum Mode : byte
        {
            SWITCH_NUMBER,
            IF_V1_NUMBER,
            IF_V2_NUMBER,
            IF_V3_NUMBER,
            SWITCH_STRING,
            IF_V1_STRING,
            IF_V2_STRING,
            IF_V3_STRING
        }
        enum Method : byte
        {
            OPTIONS,
            GET,
            HEAD,
            POST,
            PUT,
            PATCH,
            DELETE,
            TRACE
        }


        static Method[] methods_numbers = { Method.OPTIONS, Method.GET, Method.HEAD, Method.POST, Method.PUT, Method.PATCH, Method.DELETE, Method.TRACE };
        static string[] methods_string = { "OPTIONS", "GET", "HEAD", "POST", "PUT", "PATCH", "DELETE", "TRACE" };


        static bool Switch(Method method)
        {
            switch (method)
            {
                case Method.OPTIONS:
                    return true;
                case Method.GET:
                    return true;
                case Method.HEAD:
                    return true;
                case Method.POST:
                    return true;
                case Method.PUT:
                    return true;
                case Method.PATCH:
                    return true;
                case Method.DELETE:
                    return true;
                case Method.TRACE:
                    return true;
                default:
                    return false;
            }
        }
        static bool IfV1(Method method)
        {
            if (method == Method.OPTIONS)
                return true;
            if (method == Method.GET)
                return true;
            if (method == Method.HEAD)
                return true;
            if (method == Method.POST)
                return true;
            if (method == Method.PUT)
                return true;
            if (method == Method.PATCH)
                return true;
            if (method == Method.DELETE)
                return true;
            if (method == Method.TRACE)
                return true;
            return false;
        }
        static bool IfV2(Method method)
        {
            if (method == Method.OPTIONS)
                return true;
            else if (method == Method.GET)
                return true;
            else if (method == Method.HEAD)
                return true;
            else if (method == Method.POST)
                return true;
            else if (method == Method.PUT)
                return true;
            else if (method == Method.PATCH)
                return true;
            else if (method == Method.DELETE)
                return true;
            else if (method == Method.TRACE)
                return true;
            return false;
        }
        static bool IfV3(Method method)
        {
            return
                (method == Method.OPTIONS) ? true :
                (method == Method.GET) ? true :
                (method == Method.HEAD) ? true :
                (method == Method.POST) ? true :
                (method == Method.PUT) ? true :
                (method == Method.PATCH) ? true :
                (method == Method.DELETE) ? true :
                (method == Method.TRACE) ? true : false;
        }

        static bool Switch(string value)
        {
            switch (value)
            {
                case "OPTIONS":
                    return true;
                case "GET":
                    return true;
                case "HEAD":
                    return true;
                case "POST":
                    return true;
                case "PUT":
                    return true;
                case "PATCH":
                    return true;
                case "DELETE":
                    return true;
                case "TRACE":
                    return true;
                default:
                    return true;
            }
        }
        static bool IfV1(string value)
        {
            if (value == "OPTIONS")
                return true;
            if (value == "GET")
                return true;
            if (value == "HEAD")
                return true;
            if (value == "POST")
                return true;
            if (value == "PUT")
                return true;
            if (value == "PATCH")
                return true;
            if (value == "DELETE")
                return true;
            if (value == "TRACE")
                return true;
            return false;
        }
        static bool IfV2(string value)
        {
            if (value == "OPTIONS")
                return true;
            else if (value == "GET")
                return true;
            else if (value == "HEAD")
                return true;
            else if (value == "POST")
                return true;
            else if (value == "PUT")
                return true;
            else if (value == "PATCH")
                return true;
            else if (value == "DELETE")
                return true;
            else if (value == "TRACE")
                return true;
            return false;
        }
        static bool IfV3(string value)
        {
            return
                (value == "OPTIONS") ? true :
                (value == "GET") ? true :
                (value == "HEAD") ? true :
                (value == "POST") ? true :
                (value == "PUT") ? true :
                (value == "PATCH") ? true :
                (value == "DELETE") ? true :
                (value == "TRACE") ? true : false;
        }

        static bool Testing(Mode mode, int i)
        {
            return
                (mode == Mode.SWITCH_NUMBER) ? Switch(methods_numbers[i]) :
                (mode == Mode.IF_V1_NUMBER) ? IfV1(methods_numbers[i]) :
                (mode == Mode.IF_V2_NUMBER) ? IfV2(methods_numbers[i]) :
                (mode == Mode.IF_V3_NUMBER) ? IfV3(methods_numbers[i]) :
                (mode == Mode.SWITCH_STRING) ? Switch(methods_string[i]) :
                (mode == Mode.IF_V1_STRING) ? IfV1(methods_string[i]) :
                (mode == Mode.IF_V2_STRING) ? IfV2(methods_string[i]) :
                (mode == Mode.IF_V3_STRING) ? IfV3(methods_string[i]) : false;
        }
        static long Test(Mode mode)
        {
            //создаем объект
            Stopwatch stopwatch = new Stopwatch();
            //засекаем время начала операции
            stopwatch.Start();
            //выполняем какую-либо операцию
            for (int i = 0; i < 20000000; i++)
                for (int j = 0; j < methods_numbers.Length; j++)
                    Testing(mode, j);
            //останавливаем счётчик
            stopwatch.Stop();
            //смотрим сколько миллисекунд было затрачено на выполнение
            Console.WriteLine("mode:[{1}], \tmsec:[{0}], \ttime:[{2}]", stopwatch.ElapsedMilliseconds, mode.ToString(), Time(stopwatch));
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
            Test(Mode.IF_V1_NUMBER);
            Test(Mode.IF_V2_NUMBER);
            Test(Mode.SWITCH_NUMBER);
            Test(Mode.IF_V3_NUMBER);

            Test(Mode.IF_V1_STRING);
            Test(Mode.IF_V2_STRING);
            Test(Mode.SWITCH_STRING);
            Test(Mode.IF_V3_STRING);

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();

            Console.WriteLine("Terminating the application...");
        }
    }
}
using System;
using LogConvert.Cli.Helper;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LogConvert.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Command" );

            var path = args.AsQueryable().FirstOrDefault();

            path = Console.ReadLine();

            var defaultPath = CommonClass.GetOutputPath();

            var fullErrorLogPath = $"{defaultPath}error.log";

            var outputCmd = path.Contains("-o");

            var convertCmd = path.Contains("-t");

            var helperCmd = path.Contains("-h");

            var jsonFormat = path.Contains("json");

            if (path == null && !outputCmd)
            {
                Console.WriteLine("Please set directory file log");
            }
            else if (convertCmd && jsonFormat)
            {
                Console.WriteLine("Convert ToJson");
                if (File.Exists(fullErrorLogPath))
                {
                    var bin = File.ReadAllBytes(fullErrorLogPath);
                    if (outputCmd)
                    {
                        Parse(args[2], bin);
                    }
                    else
                    {
                        Parse($"{defaultPath}/error{DateTime.Now.ToString("ddMMyyyHHmm")}.json", bin);
                    }
                }
                else
                {
                    Console.WriteLine("File error not found");
                }
            }
            else if (helperCmd)
            {
                PrintHelper();
            }
            else
            {
                Console.WriteLine("Convert Text");
                if (File.Exists(fullErrorLogPath))
                {
                    var bin = File.ReadAllBytes(fullErrorLogPath);
                    if (outputCmd)
                    {
                        Parse(args[2], bin);
                    }
                    else
                    {
                        Parse($"{defaultPath}/error{DateTime.Now.ToString("ddMMyyyHHmm")}.txt", bin);
                    }
                }
                else
                {
                    Console.WriteLine("File error not found");
                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void Parse(string outputpath, byte[] data)
        {
            File.WriteAllBytes(outputpath, data);
        }

        static void PrintHelper()
        {
            Console.WriteLine(@"-Mengkonversi menjadi file json");

            Console.WriteLine(@"$LogConvert.Cli /var/log/nginx/error.log -t json");
                               
            Console.WriteLine(@"-Mengkonversi menjadi file text");

            Console.WriteLine(@"$LogConvert.Cli /var/log/nginx/error.log -t text");                 
        }
    }
}

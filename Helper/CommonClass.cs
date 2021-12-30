using System;
using System.Configuration;

namespace LogConvert.Cli.Helper
{
    public class CommonClass
    {
        public static string GetOutputPath()
        {
            return ConfigurationManager.AppSettings["OutputDefault"];
        }
    }
}

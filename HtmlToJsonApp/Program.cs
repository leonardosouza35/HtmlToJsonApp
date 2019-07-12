using HtmlAgilityPack;
using HtmlToJsonApp.Report;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HtmlToJsonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var report = new DailyBusinessReport();
            report.CreateReport();
        }
    }
}

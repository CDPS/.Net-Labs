using DesingPatterns.Builder.Builder.Director;
using DesingPatterns.Builder.Builders.ReportBuilders;
using DesingPatterns.Builder.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPatterns.Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var items = new List<Item>
            {
                new Item("Sectional Couch", 55.5, 22.4, 78.6, 35.0),
                new Item("Nightstand", 25.0, 12.4, 20.0, 10.0),
                new Item("Dining Table", 105.0, 35.4, 100.6, 55.5),
            };

            //var inventoryBuilder = new PDFReportBuilder(items: items, headerName: "Daily Report");
            //var director = new ItemsBuildDirector(inventoryBuilder);

            //director.BuildCompleteReport();
            //var directorReport = inventoryBuilder.GetReport();
            //Console.WriteLine(directorReport.Debug());

            var inventoryBuilder = new ExcelReportBuilder(items: items, headerName: "Daily Report");
            var director = new ItemsBuildDirector(inventoryBuilder);

            director.BuildCompleteReport();
            var directorReport = inventoryBuilder.GetReport();
            Console.WriteLine(directorReport.Debug());
        }

    }
}

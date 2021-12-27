using DessingPatterns.Bridge.Business.Discounts;
using DessingPatterns.Bridge.Business.Licenses;
using System;

namespace DessingPatterns.Bridge
{
    internal class Program
    {
        public static void Main()
        {
            DateTime now = DateTime.Now;

            var license1 = new TwoDaysLicense("Secret Life of Pets", now, new NoDiscount());
            var license2 = new LifeLongLicense("Matrix", now, new NoDiscount());

            PrintLicenseDetails(license1);
            PrintLicenseDetails(license2);


            var license3 = new TwoDaysLicense("Secret Life of Pets", now, new MilitaryDiscount());
            var license4 = new LifeLongLicense("Matrix", now, new SeniorDiscount());

            PrintLicenseDetails(license3);
            PrintLicenseDetails(license4);

            Console.ReadKey();
        }

        private static void PrintLicenseDetails(MovieLicense license)
        {
            Console.WriteLine($"Movie: {license.Movie}");
            Console.WriteLine($"Price: {GetPrice(license)}");
            Console.WriteLine($"Valid for: {GetValidFor(license)}");

            Console.WriteLine();
        }

        private static string GetPrice(MovieLicense license)
        {
            return $"${license.GetPrice():0.00}";
        }

        private static string GetValidFor(MovieLicense license)
        {
            DateTime? expirationDate = license.GetExpirationDate();

            if (expirationDate == null)
                return "Forever";

            TimeSpan timeSpan = expirationDate.Value - DateTime.Now;

            return $"{timeSpan.Days}d {timeSpan.Hours}h {timeSpan.Minutes}m";
        }
    }
}

using DesingPatterns.Builder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesingPatterns.Builder.Builders.ReportBuilders
{
    public class PDFReportBuilder : IReportBuilder
    {
        private Report _report;
        private IEnumerable<Item> _items;
        private string _headerName;
        public PDFReportBuilder( IEnumerable<Item> items, string headerName)
        {
            Reset();
            _items = items;
            _headerName = headerName;
        }

        public void setContent()
        {
            _report.Content = string.Join(Environment.NewLine, _items.Select(product =>
                                    $"Product: {product.Name} \nPrice: {product.Price} \n" +
                                    $"Height: {product.Height} x Width: {product.Width} -> Weight: {product.Weight} lbs \n"));
        }

        public void setFooter()
        {
            _report.Footer = $"------- Report generated on {DateTime.Now} -------\n\n";
        }

        public void setHeader()
        {
            _report.Header = $"------- {_headerName} -------\n\n";            
        }

        public void setType()
        {
            _report.Type = $"------- PDF REPORT -------\n\n";
        }

        private void Reset()
        {
            _report = new Report();
        }

        public Report GetReport()
        {
            Report finishedReport = _report;
            Reset();

            return finishedReport;
        }
    }
}



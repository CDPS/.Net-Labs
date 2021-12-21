using System.Text;

namespace DesingPatterns.Builder.Model
{
    public  class Report
    {
        public string Type { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string Footer { get; set; }

        public string Debug()
        {
            return new StringBuilder()
                .AppendLine(this.Type)
                .AppendLine(Header)
                .AppendLine(Content)
                .AppendLine(Footer)
                .ToString();
        }
    }
}

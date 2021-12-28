

namespace DesingPatterns.Builder.Builders.ReportBuilders
{
    public interface IReportBuilder
    {
        void setHeader();
        void setFooter();
        void setType();
        void setContent();
    }
}

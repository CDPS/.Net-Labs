using DesingPatterns.Builder.Builders.ReportBuilders;

namespace DesingPatterns.Builder.Builder.Director
{
    public class ItemsBuildDirector
    {
        private IReportBuilder _builder;

        public ItemsBuildDirector(IReportBuilder concreteBuilder)
        {
            _builder = concreteBuilder;
        }

        public void BuildCompleteReport()
        {
            _builder.setType();
            _builder.setHeader();
            _builder.setContent();
            _builder.setFooter();
        }
    }
}

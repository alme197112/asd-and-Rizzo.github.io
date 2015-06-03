using System;
using TechTalk.SpecFlow;


namespace AcceptanceTests.Helpers
{
    public class DefaultPathGenerator : PathGenerator
    {
        protected override string GetFeatureTitle()
        {
            var feature = FeatureContext.Current.FeatureInfo.Title;
            return feature;
        }

        protected override string GetScenarioTitle()
        {
            var scenario = ScenarioContext.Current.ScenarioInfo.Title;
            return scenario;
        }

        public override string GetTestsOutputFolder()
        {
            return Environment.CurrentDirectory;
        }

    }
}

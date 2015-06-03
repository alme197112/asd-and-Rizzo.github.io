using Microsoft.Practices.Unity;

namespace AcceptanceTests.Helpers
{
    public class StepsBase:ScenarioBase
    {
        public IUnityContainer Container
        {
            get
            {
                return Get<IUnityContainer>();
            }
        }
 
    }
}

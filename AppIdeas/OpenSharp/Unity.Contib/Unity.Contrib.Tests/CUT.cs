using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unity.Contrib.Tests
{
    public interface IDependencyThatNeedsExplicitMocking
    {
        string MyMethod(int value);
    }

    public class ServiceWithThreeDependencies 
    {
        public ServiceWithThreeDependencies(IDependencyThatNeedsExplicitMocking dependency1, object a, object b) { }


        public string DoSomething()
        {
            return "I didn't have to mock the other 2 dependencies!";  
        }
    }

    public interface IDependency1 { }

    public interface IDependency2 { }
    /// <summary>
    /// Used in tests of containers.
    /// </summary>
    public class ServiceWithTwoDependencies
    {
        public IDependency1 Dependency1 { get; set; }
        public IDependency2 Dependency2 { get; set; }

        public ServiceWithTwoDependencies(IDependency1 dependency1, IDependency2 dependency2)
        {
            Dependency1 = dependency1;
            Dependency2 = dependency2;
        }

        public void DoSomething()
        {
        }
    }


}

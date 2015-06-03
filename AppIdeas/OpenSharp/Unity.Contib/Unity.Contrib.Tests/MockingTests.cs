using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Rhino;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Mocks;

namespace Unity.Contrib.Tests
{
    public class MockingTests
    {
        private IUnityContainer container;
        [SetUp]
        public void SetUp()
        {
            container = new UnityContainer()
                .AddNewExtension<MockingContainerExtension>();
        }

        [Test]
        public void Should_be_really_easy_to_test()
        {
            container
                .RegisterMock<IDependencyThatNeedsExplicitMocking>()
                .Stub(d => d.MyMethod(Rhino.Mocks.Arg<int>.Is.Anything))
                .Return("I want to specify the return value");
       
            var service = container.Resolve<ServiceWithThreeDependencies>();
            var result = service.DoSomething();
                
            Assert.That(result, Is.EqualTo("I didn't have to mock the other 2 dependencies!"));
        }

        [Test]
        public void ServiceWithTwoDependencies_resolveItAndActNotRegisteringDependencies_allOk()
        {
            var container = new UnityContainer()
                .AddNewExtension<MockingContainerExtension>()
                .RegisterType<ServiceWithTwoDependencies>();

            var service = container.Resolve<ServiceWithTwoDependencies>();
            service.DoSomething();

            Assert.IsNotNull(service.Dependency1);
            Assert.IsNotNull(service.Dependency2);
        }
    }
}

using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.ObjectBuilder;
using Moq;

namespace Microsoft.Practices.Unity.Moq
{
    //http://www.agileatwork.com/auto-mocking-unity-container-extension/
    public class MockingContainerExtension : UnityContainerExtension
    {
        public static IUnityContainer CreateContainer()
        {
            var cont = new UnityContainer();
            cont.AddExtension(new MockingContainerExtension());
            return cont;
        }

        protected override void Initialize()
        {
            var strategy = new AutoMockingBuilderStrategy(Container);

            Context.Strategies.Add(strategy, UnityBuildStage.PreCreation);
        }

        class AutoMockingBuilderStrategy : BuilderStrategy
        {
            private readonly IUnityContainer container;

            public AutoMockingBuilderStrategy(IUnityContainer container)
            {
                this.container = container;
            }

            public override void PreBuildUp(IBuilderContext context)
            {
                var key = context.OriginalBuildKey;

                if (key.Type.IsInterface && !container.IsRegistered(key.Type))
                {
                    context.Existing = CreateDynamicMock(key.Type);
                }
            }

            private static object CreateDynamicMock(Type type)
            {
                var genericMockType = typeof(Mock<>).MakeGenericType(type);
                var mock = (Mock)Activator.CreateInstance(genericMockType);
                return mock.Object;
            }
        }
    }

    public static class MoqExtensions
    {
        public static Mock<T> RegisterMock<T>(this IUnityContainer container) where T : class
        {
            var mock = new Mock<T>();

            container.RegisterInstance<Mock<T>>(mock);
            container.RegisterInstance<T>(mock.Object);

            return mock;
        }

        /// <summary>
        /// Use this to add additional setups for a mock that is already registered
        /// </summary>
        public static Mock<T> ConfigureMockFor<T>(this IUnityContainer container) where T : class
        {
            return container.Resolve<Mock<T>>();
        }

        public static void VerifyMockFor<T>(this IUnityContainer container) where T : class
        {
            container.Resolve<Mock<T>>().VerifyAll();
        }
    }

}
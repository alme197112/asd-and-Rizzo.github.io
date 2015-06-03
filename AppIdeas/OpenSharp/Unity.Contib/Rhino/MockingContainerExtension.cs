using System;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.ObjectBuilder;
using Rhino.Mocks;

namespace Microsoft.Practices.Unity.Rhino
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
                return MockRepository.GenerateMock(type,null);
			}
		}


   
	}

    public static class RhinoMocksExtensions
    {
        public static T RegisterMock<T>(this IUnityContainer container) where T : class
        {
            var mock = MockRepository.GenerateMock<T>();

            container.RegisterInstance<T>(mock);

            return mock;
        }
    }
}
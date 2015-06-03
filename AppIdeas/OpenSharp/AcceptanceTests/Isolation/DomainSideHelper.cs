using NUnit.Core;
using System;

namespace AcceptanceTests.Helpers
{
    public abstract class DomainSideHelper<TClient, THost> : MarshalByRefObject
    {
        public override object InitializeLifetimeService() { return null; }

        private string[] _probingPaths;

        private AssemblyResolver _assemblyResolver;

        public void Initialize(params string[] probingPaths)
        {

            if (probingPaths == null)
            {
                throw new ArgumentNullException("probingPaths");
            }
            _probingPaths = probingPaths;
            _assemblyResolver = new AssemblyResolver();
            foreach (var path in _probingPaths)
                _assemblyResolver.AddDirectory(path);
		 
	 
            
            }

        public abstract TClient Load(THost host);
    }
}
using System;
using CSScriptLibrary;//TODO: Replace with Roslyn


namespace AcceptanceTests.Helpers
{
    public class CSScriptCrossDomainHelper : MarshalByRefObject
    {
        public I Compile<I>(string code, string[] assemblies,string typeName) where I : class
        {
            CSScript.GlobalSettings.SearchDirs = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            return CSScript
                  .LoadCode(code, assemblies)
                  .CreateInstance(typeName)
                  .AlignToInterface<I>();
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}
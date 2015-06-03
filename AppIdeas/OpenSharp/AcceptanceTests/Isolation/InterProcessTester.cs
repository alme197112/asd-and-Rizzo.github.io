using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSScriptLibrary;//TODO: Replace with Roslyn


namespace AcceptanceTests.Helpers
{
    public class InterProcessTester
    {
        public WaitHandle CompileAndRun(string code, int numberOfProcesses, string args)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.IsDynamic).Select(x => x.Location).ToArray();
            CSScript.GlobalSettings.SearchDirs = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            //TODO: fix to use separate process
            Parallel.For(0, numberOfProcesses, i =>
                                                   {
                                                       string asmFile = CSScript.CompileCode(code, assemblies);
                                                       using (AsmHelper helper = new AsmHelper(asmFile, "TestDomain " + i, true))
                                                       {
                                                           helper.ScriptExecutionDomain.SetupInformation.
                                                               ConfigurationFile =
                                                               AppDomain.CurrentDomain.SetupInformation.
                                                                   ConfigurationFile;

                                                           helper.ScriptExecutionDomain.SetupInformation.
                                                               ApplicationBase =
                                                               AppDomain.CurrentDomain.SetupInformation.
                                                                   ApplicationBase;

                                                           var instance = helper.CreateObject("*");
                                                           helper.InvokeInst(instance,"Main");
                                                       }

                                                   });
            var waitHandle = new AutoResetEvent(false);
            Task.Factory.StartNew(() =>
                                      {
                                          Thread.Sleep(TimeSpan.FromSeconds(4));
                                          waitHandle.Set();
                                      });
            return waitHandle;
        }
    }
}
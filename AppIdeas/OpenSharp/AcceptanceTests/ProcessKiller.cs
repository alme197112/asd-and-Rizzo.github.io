using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using System;
namespace AcceptanceTests.Helpers
{
    /// <summary>
    /// Used to kill processes.
    /// </summary>
    public class ProcessKiller
    {
        /// <summary>
        /// Kills all precess by names with retries. Ignores exceptions.
        /// </summary>
        /// <param name="processNames"></param>
        public void Kill(params string[] processNames)
        {
            Contract.Requires(processNames != null);
            var retry = new RetryPolicy(RetryPolicy.DefaultFixed.ErrorDetectionStrategy, 3, TimeSpan.FromSeconds(10));
            retry.ExecuteAction(() => KillInternal(processNames));
        }

        private void KillInternal(params string[] processNames)
        {
            List<Process> processes =
                (from p in Process.GetProcesses()
                 where processNames.Contains(p.ProcessName)
                 select p)
                    .ToList();
            foreach (Process process in processes)
            {
                process.Kill();
            }
        }



    }
}

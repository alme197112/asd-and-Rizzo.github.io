using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace Microsoft.Practices.Unity
{
    public class UnityContainerChecker
    {
        /// <summary>
        /// Used during debugging to prevent duplicated registrations.
    	/// Duplicated registration leads lead to subtle errors of different resolutions for different class instead single.		
        /// Checking duplicated registrations during runtime has performance impact.
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <param name="container"></param>
        /// <param name="typeToCheck"></param>
		///<remarks>
		/// Examples:
        /// First registration resolved with some side effect, then second registration done, then second used with repeats action not expected to be repeated.
		///</remarks>
        [DebuggerStepThrough]
        [DebuggerStepperBoundary]
        [Conditional("DEBUG")]
        public static void ThrowExceptionIfRegistered<TFrom>(IUnityContainer container, Type typeToCheck, string nameToCheck = null)
        {
            //see details in https://unity.codeplex.com/discussions/268223
            ContainerRegistration[] registrations = null;
            while (registrations == null)
            {
                try
                {
                    registrations = container.Registrations.ToArray();
                }
                catch (InvalidOperationException) //"Collection was modified; enumeration operation may not execute."
                {
                    // good enough for DEBUG
                    // happens when collection changed during resolving, all registrations are on locks already
                    // avoids adding locks for resolving into RELEASE code
                }
            }

            var registered = registrations.SingleOrDefault(x => x.RegisteredType == typeof(TFrom) && x.Name == nameToCheck);
            if (registered != null)
            {
                var same = typeToCheck == registered.MappedToType ? " (same)" : " (different)";
                throw new InvalidOperationException(typeof(TFrom) + " was registered and implemented by " + registered + same + ".");
            }
        }


    }
}

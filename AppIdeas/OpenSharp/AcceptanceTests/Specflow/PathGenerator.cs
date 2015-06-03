using System;
using System.IO;
using System.Linq;

namespace AcceptanceTests.Helpers
{
    /// <summary>
    /// Creates unique path for each document created during test.
    /// </summary>
    public abstract class PathGenerator
    {
		
		// limit because saving some in some programs(like MS Office) files seems works badly with long names
        protected int maxLenght = 50;
		
        protected abstract string GetFeatureTitle();

        protected abstract string GetScenarioTitle();

        public abstract string GetTestsOutputFolder();

        public string GetNamedTestsOutputFolder()
        {
            var f = StringExtensions.ToIdentifier(GetFeatureTitle());
            var s = StringExtensions.ToIdentifier(GetScenarioTitle());
            var dir = Path.Combine(GetTestsOutputFolder(), f, s);
              
            if (dir.Length > 230) // to long file path - when saved more then 260 then fails
            {
                dir = Path.Combine(GetTestsOutputFolder(), f, s.Substring(0, 20));
            }
            EnsureDirectory(dir);
            return dir;
        }

        public string ToFile(string extension)
        {
            EnsureFeatureFolderExists();
            return Path.Combine(GetPathToDirectory(), GetUniqueName()) + "."+extension;
        }

        private string GetUniqueName()
        {

            var scenario = StringExtensions.ToIdentifier(GetScenarioTitle());
            string name = scenario;
            string partialName = name.Substring(0, name.Length > maxLenght ? maxLenght : name.Length - 1);
            string uniquePartialName = partialName + "_" + DateTime.Now.Ticks;
            return uniquePartialName;
        }

        private void EnsureFeatureFolderExists()
        {
            string pathToDirectory = GetPathToDirectory();
            EnsureDirectory(pathToDirectory);
        }

        private static void EnsureDirectory(string pathToDirectory)
        {
            if (!Directory.Exists(pathToDirectory))
            {
                Directory.CreateDirectory(pathToDirectory);
            }
        }

        private string GetPathToDirectory()
        {
            return Path.Combine(GetTestsOutputFolder(), GetFeatureTitle().ToIdentifier());
        }
    }
}

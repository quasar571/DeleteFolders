using System.IO;
using System.Reflection;

namespace DeleteFolders
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            if (args.Length > 0)
            {
                path = args[0];
            }
            else
            {
                path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            }
            DeleteDirectoryRecursive(path);
        }

        static void DeleteDirectoryRecursive(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (var dir in di.GetDirectories())
            {
                if (dir.Name == "bin" || dir.Name == "obj")
                {
                    dir.Delete(true);
                }
                else
                {
                    DeleteDirectoryRecursive(dir.FullName);
                }
            }
        }
    }
}

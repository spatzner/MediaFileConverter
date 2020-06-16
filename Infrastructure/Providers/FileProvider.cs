using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Providers
{
    public class FileSystemProvider : IFileSystemProvider
    {
        public void CreateDirectory(string directory)
        {
            Directory.CreateDirectory(directory);
        }

        public string GetFileNameWithoutExtension(string file)
        {
            return Path.GetFileNameWithoutExtension(file);
        }
    }
}

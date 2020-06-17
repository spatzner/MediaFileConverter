using System.IO;
using Illustrator;
using Infrastructure.Providers;
using Utilities;

namespace Domain.Converters
{
    public class AIConverter : IAIConverter
    {
        private readonly IIllustratorProvider illustratorProvider;
        private readonly IFileSystemProvider fileSystemProvider;

        public AIConverter(IIllustratorProvider illustratorProvider, IFileSystemProvider fileSystemProvider)
        {
            this.illustratorProvider = illustratorProvider;
            this.fileSystemProvider = fileSystemProvider;

            CheckIfArgument.IsNull(nameof(this.illustratorProvider), this.illustratorProvider);
            CheckIfArgument.IsNull(nameof(this.fileSystemProvider), this.fileSystemProvider);
        }

        public string ConvertToSVG(string file, string saveDirectory)
        {
            return illustratorProvider.ExportToSVG(file, saveDirectory);
        }
    }
}

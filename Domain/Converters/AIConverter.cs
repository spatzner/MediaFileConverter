using System;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Illustrator;
using Infrastructure.Factories;
using Infrastructure.Providers;
using Utilities;

namespace Domain.Converters
{
    public class AIConverter : IAIConverter
    {
        private readonly IIllustratorProviderFactory illustratorProviderFactory;
        private readonly IFileSystemProvider fileSystemProvider;

        public AIConverter(IIllustratorProviderFactory illustratorProviderFactory, IFileSystemProvider fileSystemProvider)
        {
            this.illustratorProviderFactory = illustratorProviderFactory;
            this.fileSystemProvider = fileSystemProvider;

            CheckIfArgument.IsNull(nameof(this.illustratorProviderFactory), this.illustratorProviderFactory);
            CheckIfArgument.IsNull(nameof(this.fileSystemProvider), this.fileSystemProvider);
        }


        public string ConvertToSVG(string file, string saveDirectory)
        {
            string fileName = fileSystemProvider.GetFileNameWithoutExtension(file);

            using (var illustrator = illustratorProviderFactory.Create())
            {

                fileSystemProvider.CreateDirectory(saveDirectory);

                illustrator.Open(file);

                Document doc = illustrator.Open(file);

                Artboard artBoard = illustrator.GetArtBoards().First();
                artBoard.Name = fileName;

                doc.ExportForScreens(saveDirectory, AiExportForScreensType.aiSE_SVG);
                doc.Close(AiSaveOptions.aiDoNotSaveChanges);
            }

            return Path.Combine(saveDirectory, "SVG", $"{fileName}.svg");
        }
    }
}

using System;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Illustrator;

namespace Domain.Converters
{
    public class AIConverter : IAIConverter
    {
        public string ConvertToSVG(string file, string saveDirectory)
        {
            var illustrator = new Application();

            Directory.CreateDirectory(saveDirectory);

            illustrator.Open(file);

            string fileName = Path.GetFileNameWithoutExtension(file);

            Document doc = illustrator.Open(file);

            var artBoards = illustrator.ActiveDocument.Artboards.GetEnumerator();
            artBoards.MoveNext();

            Artboard artBoard = artBoards.Current as Artboard;
            artBoard.Name = fileName;

            doc.ExportForScreens(saveDirectory, AiExportForScreensType.aiSE_SVG);
            doc.Close(AiSaveOptions.aiDoNotSaveChanges);
            doc = null;

            illustrator.Quit();
            illustrator = null;

            return Path.Combine(saveDirectory, "SVG", $"{fileName}.svg");
        }
    }
}

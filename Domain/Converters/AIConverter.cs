using System;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Illustrator;

namespace Domain.Converters
{
    public class AIConverter : IAIConverter, IDisposable
    {
        private Application _illustrator;

        public AIConverter()
        {
            _illustrator = new Application();
        }

        public void ConvertToSVG(string file, string saveDirectory)
        {

            _illustrator.Open(file);

            string fileName = Path.GetFileNameWithoutExtension(file);

            Document doc = _illustrator.Open(file);

            var artBoards = _illustrator.ActiveDocument.Artboards.GetEnumerator();
            artBoards.MoveNext();

            Artboard artBoard = artBoards.Current as Artboard;
            artBoard.Name = fileName;

            doc.ExportForScreens(saveDirectory, AiExportForScreensType.aiSE_SVG);
            doc.Close(AiSaveOptions.aiDoNotSaveChanges);
            doc = null;
        }

        public void Dispose()
        {
            _illustrator.Quit();
            _illustrator = null;
        }
    }
}

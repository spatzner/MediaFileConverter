using System.IO;

namespace Illustrator
{
    public class IllustratorProvider : IIllustratorProvider
    {
        public string ExportToSVG(string file, string saveDirectory)
        {
            Application illustrator = new Application();

            Document doc = illustrator.Open(file);

            var artBoards = illustrator.ActiveDocument.Artboards.GetEnumerator();
            artBoards.MoveNext();

            if (!(artBoards.Current is Artboard artBoard))
                return null;

            string fileName = Path.GetFileNameWithoutExtension(file);
            artBoard.Name = fileName;

            doc.ExportForScreens(saveDirectory, AiExportForScreensType.aiSE_SVG);
            doc.Close(AiSaveOptions.aiDoNotSaveChanges);

            return Path.Combine(saveDirectory, "SVG", $"{fileName}.svg");
        }
    }
}

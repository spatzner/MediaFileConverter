using System.IO;

namespace Illustrator
{
    public class IllustratorProvider : IIllustratorProvider
    {
        public string ExportToSVG(string file, string saveDirectory)
        {
            string fileName = Path.GetFileNameWithoutExtension(file);

            return Path.Combine(saveDirectory, "SVG", $"{fileName}.svg");
        }
    }
}

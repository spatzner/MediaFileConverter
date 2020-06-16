using System.Collections;
using System.Collections.Generic;
using Illustrator;

namespace Infrastructure.Wrappers
{
    public class IllustratorWrapper : IIllustratorWrapper
    {
        private Application illustrator;

        public IllustratorWrapper()
        {
            illustrator = new Application();
        }

        public Document Open(string file)
        {
            return illustrator.Open(file);
        }
        
        public IReadOnlyCollection<Artboard> GetArtBoards()
        {
            List<Artboard> artBoards = new List<Artboard>();

            IEnumerator enumerator = illustrator.ActiveDocument.Artboards.GetEnumerator();
            while (enumerator.MoveNext())
            {
                artBoards.Add((Artboard) enumerator.Current);
            }

            return artBoards.AsReadOnly();
        }

        public void Dispose()
        {
            illustrator?.Quit();
            illustrator = null;
        }
    }
}

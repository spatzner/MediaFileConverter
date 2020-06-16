using System;
using System.Collections.Generic;
using Illustrator;

namespace Infrastructure.Wrappers
{
    public interface IIllustratorWrapper : IDisposable
    {
        Document Open(string file);
        IReadOnlyCollection<Artboard> GetArtBoards();
    }
}
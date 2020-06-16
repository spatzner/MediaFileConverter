using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svg;

namespace Infrastructure
{
    public class SVGProvider : ISVGProvider
    {
        public SvgDocument GetDocument(string fileLocation)
        {
            return SvgDocument.Open(fileLocation);
        }
    }
}

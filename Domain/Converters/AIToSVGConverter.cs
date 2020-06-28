using Core;
using Illustrator;

namespace Domain
{
    public class AIToSVGConverter : IImageConverter
    {
        private readonly IIllustratorProvider illustratorProvider;

        public AIToSVGConverter(IIllustratorProvider illustratorProvider)
        {
            AssertArgument.IsNotNull(nameof(illustratorProvider), illustratorProvider);

            this.illustratorProvider = illustratorProvider;
        }

        public string Convert(string file, ImageSize size, string saveDirectory)
        {
            return illustratorProvider.ExportToSVG(file, saveDirectory);
        }
    }
}

﻿using Core;
using Illustrator;

namespace Domain
{
    public class AIConverter : IAIConverter
    {
        private readonly IIllustratorProvider illustratorProvider;

        public AIConverter(IIllustratorProvider illustratorProvider)
        {
            AssertArgument.IsNotNull(nameof(illustratorProvider), illustratorProvider);

            this.illustratorProvider = illustratorProvider;
        }

        public string ConvertToSVG(string file, string saveDirectory)
        {
            return illustratorProvider.ExportToSVG(file, saveDirectory);
        }
    }
}

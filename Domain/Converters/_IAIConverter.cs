namespace Domain.Converters
{
    public interface IAIConverter
    {
        void ConvertToSVG(string file, string saveDirectory);
        void Dispose();
    }
}
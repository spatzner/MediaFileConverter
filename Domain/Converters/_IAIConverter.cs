namespace Domain.Converters
{
    public interface IAIConverter
    {
        string ConvertToSVG(string file, string saveDirectory);
    }
}
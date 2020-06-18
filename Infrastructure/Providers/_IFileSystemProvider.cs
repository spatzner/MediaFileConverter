namespace Infrastructure.Providers
{
    public interface IFileSystemProvider
    {
        void CreateDirectory(string directory);
        string GetFileNameWithoutExtension(string file);
        string GetDirectoryName(string path);
    }
}
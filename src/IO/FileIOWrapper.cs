using System.IO;

using System.Threading.Tasks;

namespace PayboxHelper.IO
{
    /// <summary>
    /// File Wrapper is necesseray to allow unit testing methods without mocking File.IO
    /// </summary>
    public class FileIOWrapper : IFileIOWrapper
    {
        /// <summary>
        /// Returns if a file exists
        /// </summary>
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Returns all text content of the specified file.
        /// </summary>
        public async Task<string> ReadAllTextAsync(string path)
        {
            return await File.ReadAllTextAsync(path);
        }
    }

}
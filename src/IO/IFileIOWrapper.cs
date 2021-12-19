using System.Threading.Tasks;

namespace PayboxHelper.IO
{

    /// <summary>
    /// File Wrapper is necesseray to allow unit testing methods without mocking File.IO
    /// </summary>
    public interface IFileIOWrapper
    {
        /// <summary>
        /// Returns if a file exists
        /// </summary>
        bool Exists(string path);

        /// <summary>
        /// Returns all text content of the specified file.
        /// </summary>
        Task<string> ReadAllTextAsync(string path);
    }

}
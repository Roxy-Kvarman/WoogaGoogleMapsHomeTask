using Newtonsoft.Json;
using System.Reflection;

namespace WoogaGoogleMapsHomeTask.Utilities
{
    /// <summary>
    /// This class provides utility methods for handling file operations
    /// </summary>
    public class FileHandler
    {
        /// <summary>
        /// This method reads data from a specified JSON file located in a specified folder 
        /// and deserializes it into an object of type <typeparamref name="T"/>.
        /// </summary>
        public static T GetFileData<T>(string folderName, string fileName)where T: class
        {
            var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (directoryName == null)
                throw new Exception("Failed to get assembly directory!");

            var path = Path.Combine(directoryName, folderName, $"{fileName}.json");
            var json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}

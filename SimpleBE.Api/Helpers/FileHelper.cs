using System.Collections.Generic;
using System.IO;

using SimpleBE.Api.Dtos;

namespace SimpleBE.Api.Helpers
{
    public static class FileHelper
    {
        private static string _userPath = $"{Directory.GetCurrentDirectory()}/users.json";

        public static void SerializeUsersToFile(UserDTO dto)
        {
            var users = new List<UserDTO>() { dto };

            if (File.Exists(_userPath))
            {
                var userDTOs = DeserializeUsersFromFile();
                
                if (userDTOs != null)
                {
                    users.InsertRange(0, userDTOs);
                }
            }

            // Serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(_userPath))
            {
                var serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(file, users);
            }
        }

        public static List<UserDTO> DeserializeUsersFromFile()
        {
            if (File.Exists(_userPath))
            {
                // Deserialize JSON directly from a file
                using (StreamReader file = File.OpenText(_userPath))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    var userDTOs = (List<UserDTO>)serializer.Deserialize(file, typeof(List<UserDTO>));

                    return userDTOs;
                }
            }

            return null;
        }
    }
}
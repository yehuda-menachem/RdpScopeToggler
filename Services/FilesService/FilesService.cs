using RdpScopeToggler.Enums;
using RdpScopeToggler.Models;
using RdpScopeToggler.Stores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RdpScopeToggler.Services.FilesService
{
    public class FilesService : IFilesService
    {
        #region Public Methodes

        #region WhiteList

        public List<Client> GetWhiteList()
        {
            EnsureListFileExists("WhiteList.json");
            return ReadList("WhiteList.json");
        }

        public void AddToWhiteList(string ip, string name = "Unnamed")
        {
            EnsureListFileExists("WhiteList.json");
            WriteToList(ip, name, true, "WhiteList.json");
        }

        public void CleanWhiteList()
        {
            const string filePath = @"C:\ProgramData\RdpScopeToggler\WhiteList.json";
            List<string> whiteList = new List<string>();
            string updatedJson = JsonSerializer.Serialize(whiteList, new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            });
            File.WriteAllText(filePath, updatedJson);
        }

        #endregion

        #region AlwaysOnList

        public List<Client> GetAlwaysOnList()
        {
            EnsureListFileExists("AlwaysOnList.json");
            return ReadList("AlwaysOnList.json");
        }

        public void AddToAlwaysOnList(string ip, bool isOpen, string name = "Unnamed")
        {
            EnsureListFileExists("AlwaysOnList.json");
            WriteToList(ip, name, isOpen, "AlwaysOnList.json");
        }

        public void CleanAlwaysOnList()
        {
            const string filePath = @"C:\ProgramData\RdpScopeToggler\AlwaysOnList.json";
            List<string> whiteList = new List<string>();
            string updatedJson = JsonSerializer.Serialize(whiteList, new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            });
            File.WriteAllText(filePath, updatedJson);
        }

        #endregion

        #region Language

        public string GetLanguageFromSettings()
        {
            try
            {
                EnsureSettingsFileExists();

                const string pathToSettingsFile = @"C:\ProgramData\RdpScopeToggler\Settings.json";
                var json = File.ReadAllText(pathToSettingsFile);
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter() }
                };

                var settings = JsonSerializer.Deserialize<Settings>(json, options);

                return string.IsNullOrWhiteSpace(settings?.Language) ? "en" : settings.Language;
            }
            catch (Exception)
            {
                // ייתכן לוג או טיפול אחר
                return "en";
            }
        }


        public void WriteLanguageToSettings(string language)
        {
            const string pathToSettingsFile = @"C:\ProgramData\RdpScopeToggler\Settings.json";

            Settings settings;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };
            // אם הקובץ קיים – נקרא אותו, כדי לא לאבד נתונים נוספים
            if (File.Exists(pathToSettingsFile))
            {
                var json = File.ReadAllText(pathToSettingsFile);



                settings = JsonSerializer.Deserialize<Settings>(json, options) ?? new Settings();
            }
            else
            {
                settings = new Settings();
            }


            // עדכון השפה
            settings.Language = language;

            var updatedJson = JsonSerializer.Serialize(settings, options);

            File.WriteAllText(pathToSettingsFile, updatedJson);
        }

        #endregion

        #region DefaultState

        public ActionsEnum GetDefaultStateFromSettings()
        {
            EnsureSettingsFileExists();

            const string pathToSettingsFile = @"C:\ProgramData\RdpScopeToggler\Settings.json";
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };
            try
            {
                var json = File.ReadAllText(pathToSettingsFile);
                var settings = JsonSerializer.Deserialize<Settings>(json, options);

                if (settings == null)
                    return ActionsEnum.CloseRdp; // ברירת מחדל אם יש שגיאה

                return settings.DefaultState;
            }
            catch
            {
                return ActionsEnum.CloseRdp; // במקרה של בעיה בקריאה
            }
        }

        public void WriteDefaultStateToSettings(ActionsEnum defaultState)
        {
            const string pathToSettingsFile = @"C:\ProgramData\RdpScopeToggler\Settings.json";

            Settings settings;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };
            try
            {
                // אם הקובץ קיים – נקרא אותו כדי לא לאבד נתונים אחרים
                if (File.Exists(pathToSettingsFile))
                {
                    var json = File.ReadAllText(pathToSettingsFile);
                    settings = JsonSerializer.Deserialize<Settings>(json, options) ?? new Settings();
                }
                else
                {
                    settings = new Settings();
                }

                // עדכון המצב
                settings.DefaultState = defaultState;

                var updatedJson = JsonSerializer.Serialize(settings, options);

                File.WriteAllText(pathToSettingsFile, updatedJson);
            }
            catch (Exception ex)
            {
                // אופציונלי: אפשר להוסיף לוג או הודעת שגיאה למשתמש
                Debug.WriteLine($"Failed to write default state: {ex.Message}");
            }
        }

        #endregion

        #region Authentication

        public bool IsUserLoggedIn()
        {
            try
            {
                EnsureSettingsFileExists();
                const string pathToSettingsFile = @"C:\ProgramData\RdpScopeToggler\Settings.json";
                var json = File.ReadAllText(pathToSettingsFile);
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                };
                var settings = JsonSerializer.Deserialize<Settings>(json, options);
                // Return false if settings is null, or if IsLoggedIn is not set (null) or false
                if (settings == null)
                    return false;

                return settings.IsLoggedIn;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error checking login status: {ex.Message}");
                return false;
            }
        }

        public void SaveCredentials(string username, string passwordHash)
        {
            const string pathToSettingsFile = @"C:\ProgramData\RdpScopeToggler\Settings.json";
            Settings settings;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };

            if (File.Exists(pathToSettingsFile))
            {
                var json = File.ReadAllText(pathToSettingsFile);
                settings = JsonSerializer.Deserialize<Settings>(json, options) ?? new Settings();
            }
            else
            {
                settings = new Settings();
            }

            settings.Username = username;
            settings.PasswordHash = passwordHash;
            settings.IsLoggedIn = true;

            var updatedJson = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(pathToSettingsFile, updatedJson);
        }

        public string GetSavedUsername()
        {
            try
            {
                EnsureSettingsFileExists();
                const string pathToSettingsFile = @"C:\ProgramData\RdpScopeToggler\Settings.json";
                var json = File.ReadAllText(pathToSettingsFile);
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter() }
                };
                var settings = JsonSerializer.Deserialize<Settings>(json, options);
                return settings?.Username ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public string GetSavedPasswordHash()
        {
            try
            {
                EnsureSettingsFileExists();
                const string pathToSettingsFile = @"C:\ProgramData\RdpScopeToggler\Settings.json";
                var json = File.ReadAllText(pathToSettingsFile);
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter() }
                };
                var settings = JsonSerializer.Deserialize<Settings>(json, options);
                return settings?.PasswordHash ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void ClearCredentials()
        {
            const string pathToSettingsFile = @"C:\ProgramData\RdpScopeToggler\Settings.json";
            Settings settings;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            };

            if (File.Exists(pathToSettingsFile))
            {
                var json = File.ReadAllText(pathToSettingsFile);
                settings = JsonSerializer.Deserialize<Settings>(json, options) ?? new Settings();
            }
            else
            {
                settings = new Settings();
            }

            settings.Username = null;
            settings.PasswordHash = null;
            settings.IsLoggedIn = false;

            var updatedJson = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(pathToSettingsFile, updatedJson);
        }

        #endregion

        #endregion


        #region Private Methodes
        private void WriteToList(string ip, string name, bool isOpen = true, string fileName = "WhiteList.json")
        {
            name = name.Trim();
            ip = ip.Trim();
            string filePath = $"C:\\ProgramData\\RdpScopeToggler\\{fileName}";
            List<Client> list;

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                try
                {
                    list = JsonSerializer.Deserialize<List<Client>>(json) ?? new List<Client>();
                }
                catch
                {
                    list = new List<Client>();
                }
            }
            else
            {
                list = new List<Client>();
            }

            if (list.Any(entry => entry.Address == ip && !entry.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase)))
            {
                var entryToUpdate = list.First(e => e.Address == ip);
                entryToUpdate.Name = name;
                entryToUpdate.IsOpen = isOpen;

                string updatedJson = JsonSerializer.Serialize(list, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter() }
                });

                File.WriteAllText(filePath, updatedJson);
            }
            else if (!list.Any(entry => entry.Address == ip && entry.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase)))
            {
                list.Add(new Client { Address = ip, Name = name, IsOpen = isOpen });

                string updatedJson = JsonSerializer.Serialize(list, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter() }
                });

                File.WriteAllText(filePath, updatedJson);
            }
        }


        private List<Client> ReadList(string fileName = "WhiteList.json")
        {
            string filePath = $"C:\\ProgramData\\RdpScopeToggler\\{fileName}";

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"{fileName} file not found.", filePath);
            }

            string jsonContent = File.ReadAllText(filePath);

            try
            {
                var list = JsonSerializer.Deserialize<List<Client>>(jsonContent);
                return list ?? new List<Client>();
            }
            catch (JsonException)
            {
                return new List<Client>();
            }
        }

        private void EnsureListFileExists(string fileName = "WhiteList.json")
        {
            string folderPath = @"C:\ProgramData\RdpScopeToggler";
            string filePath = Path.Combine(folderPath, fileName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!File.Exists(filePath))
            {
                var defaultList = new List<Client>();

                string json = JsonSerializer.Serialize(defaultList, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter() }
                });

                File.WriteAllText(filePath, json);
            }
        }

        private void EnsureSettingsFileExists(string fileName = "Settings.json")
        {
            string folderPath = @"C:\ProgramData\RdpScopeToggler";
            string filePath = Path.Combine(folderPath, fileName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!File.Exists(filePath))
            {
                var defaultSettings = new RdpScopeToggler.Models.Settings
                {
                    Language = "en",
                    DefaultState = Enums.ActionsEnum.CloseRdp,
                    IsLoggedIn = false
                };

                string json = JsonSerializer.Serialize(defaultSettings, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter() }
                });

                File.WriteAllText(filePath, json);
            }
        }

        #endregion
    }
}

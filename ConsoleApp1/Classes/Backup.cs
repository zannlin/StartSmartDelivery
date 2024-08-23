using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1.Classes
{
    // Leave this for last, along with long-term datastorage. Existing code is due to research

    internal class Backup
    {
        private string _BackupPath;

        public Backup()
        {
            _BackupPath = GetBackupPathFromConfig();

            if (string.IsNullOrWhiteSpace(_BackupPath) || !File.Exists(_BackupPath))
            {
                Console.WriteLine("Invalid or empty backup path. Setting default path.");

                // Get the user's Documents directory
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Define the backup directory and ensure it exists
                string backupDirectory = Path.Combine(documentsPath, "StartSmartBackup");
                if (!Directory.Exists(backupDirectory))
                {
                    Directory.CreateDirectory(backupDirectory);
                }

                // Define the backup file path
                _BackupPath = Path.Combine(backupDirectory, "");

                // Update the app.config with the new backup path
                SetBackupPathInConfig(_BackupPath);
            }

            Console.WriteLine("Backup location set to: " + _BackupPath);
        }

        internal void SetBackupPathInConfig(string path)
        {
            // Open the app.config file
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            config.AppSettings.Settings["BackupPath"].Value = path;
          
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            _BackupPath = path;
            Console.WriteLine("Backup path in app.config updated to: " + _BackupPath);
        }

        internal string GetBackupPathFromConfig()
        {
            // Retrieve the backup path from appSettings
            string path = ConfigurationManager.AppSettings["BackupPath"];
            return path;
        }
        internal void RunSetBackupLocation() {
            Console.WriteLine("Backup location set");
         }

         internal void RunPerformBackup()
         { 
             Console.WriteLine("Backup performed.");
         }

         internal void RunRestoreBackup()
         {  
             Console.WriteLine("Backup restored.");
         }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace QSF.Common
{
    public class LoggerService
    {
        private static readonly LoggerService Instance = new LoggerService();
        private static StorageFile LogFile;
        private static string LogFileName = "QSF.log";

        public static readonly string LogFilePath;

        public static async void LogAsync(string textToLog, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            StorageFile logFile = await GetLogFile();
            if (logFile != null)
            {
                if (string.IsNullOrEmpty(textToLog))
                {
                    textToLog = "string.empty";
                }
                string completeText = string.Format("[{0}][{1}:{2} {3}] : \"{4}\"{5}", 
                                                    DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"), 
                                                    sourceFilePath, sourceLineNumber, memberName, 
                                                    textToLog, Environment.NewLine);
                var suppressedAsyncWrite = Windows.Storage.FileIO.AppendTextAsync(logFile, completeText);
            }
        }

        private static async Task<StorageFile> GetLogFile()
        {
            if (LogFile != null)
            {
                return LogFile;
            }

            StorageFile logFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(LogFileName, CreationCollisionOption.OpenIfExists);
            LogFile = logFile;
            return logFile;
        }
    }
}

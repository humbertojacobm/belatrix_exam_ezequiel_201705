using Belatrix.BusinessEntities;
using Belatrix.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.BusinessLayer
{
    public class JobLogger
    {

        private bool _logToFile;
        private bool _logToConsole;
        private bool _logMessage;
        private bool _logWarning;
        private bool _logError;
        private bool LogToDatabase;

        public JobLogger(bool logToFile, bool logToConsole, bool logToDatabase, bool logMessage, bool logWarning, bool logError)
        {
            _logError = logError;
            _logMessage = logMessage;
            _logWarning = logWarning;

            LogToDatabase = logToDatabase;
            _logToFile = logToFile;
            _logToConsole = logToConsole;
        }

        public Result LogMessage(string message, bool ValueMessage, bool warning, bool error)
        {

            Result _Result = new Result();
            _Result.Code = (int)Enumerates.Result.Success; //success by default.
            _Result.ErrorMessage = ResourceMessage.SuccessMessage;

            message.Trim();

            if (message == null || message.Length == 0)
            {
                _Result.Code = (int)Enumerates.Result.Error;
                _Result.ErrorMessage = ResourceMessage.MensajeVacio;

                return _Result;
            }

            if (!_logToConsole && !_logToFile && !LogToDatabase)
            {
                _Result.Code = (int)Enumerates.Result.Error;
                _Result.ErrorMessage = ResourceMessage.InvalidConfiguration;

                return _Result;

            }

            if ((!_logError && !_logMessage && !_logWarning) || (!ValueMessage && !warning && !error))
            {
                _Result.Code = (int)Enumerates.Result.Error;
                _Result.ErrorMessage = ResourceMessage.ErrorIsntIdentified;

                return _Result;

            }

            int t = 0;

            if (ValueMessage && _logMessage)
            {
                t = 1;
                message += ". typeError: " + ResourceMessage.TypeMensaje;
            }

            if (error && _logError)
            {
                t = 2;
                message += ". typeError: " + ResourceMessage.TypeError;
            }

            if (warning && _logWarning)
            {
                t = 3;
                message += ". typeError: " + ResourceMessage.TypeWarning;
            }

            if (LogToDatabase)
            {
                t = (int)Enumerates.LogType.Message;
                _Result = new DALLog().CreateLog(new Log() { CodeT = t.ToString(), Message = message });

                if (_Result.Code != (int)Enumerates.Result.Success)
                {
                    return _Result;
                }

            }

            if (_logToFile)
            {

                string l = "";

                if (System.IO.File.Exists(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" +  ".txt"))
                {
                    l = System.IO.File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + ".txt");
                }

                l = l + Environment.NewLine + DateTime.Now.ToShortDateString() + " " + message;

                System.IO.File.WriteAllText(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" +  ".txt", l);

            }

            if (_logToConsole)
            {

                if (error && _logError)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if (warning && _logWarning)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (ValueMessage && _logMessage)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine(DateTime.Now.ToShortDateString() + " " + message);

            }

            return _Result;

        }
    }
}

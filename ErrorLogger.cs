using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Logger
{
    public class ErrorLogger : IErrorLogger
    {

        public void ErrorLogWrite(Exception ex)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "------------------------------------------------------------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "------------------------------------------------------------------------------------------------------------";
            message += Environment.NewLine;

            string path = AppDomain.CurrentDomain.BaseDirectory + "ErrorLog";

            if (pathExist(path, true))
            {
                if (CreateFile(path, "ErrorLog.txt"))
                {
                    path = path + "\\ErrorLog.txt";

                    using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                    {
                        using (StreamWriter StreamWriter = new StreamWriter(fs))
                        {
                            StreamWriter.WriteLine(message);
                            StreamWriter.Close();
                        }
                    }
                }

            }

            /*********************************************
       errorLogWrite(Exception ex)
       writing error log

           *************************************************/

        }
        private bool CreateFile(string path, string fileName)
        {
            path = String.Format("{0}\\{1}", path, fileName);
            if (!File.Exists(path))
            {

                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {

                }
            }

            return File.Exists(path);
            /***********************************************************************************
        private bool createFile(string path, string fileName)

            if the required file is not found in the path, create the file
            and return bool about file existence.
        
            **************************************************************************************/
        }
        private bool PathExist(string path)
        {
            return Directory.Exists(path);
        }
        private bool pathExist(string path, bool yes)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return Directory.Exists(path);

            /*****************************************************************************************
        private bool pathExist(string path, bool yes)

            Check whether the directory path exists, if not exists create the directory
            ******************************************************************************************/
        }


    }
}

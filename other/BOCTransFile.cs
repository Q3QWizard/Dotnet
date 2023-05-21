using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace ProductClass.API
{
    public class BOCTransFile
    {
        private string _TxtFileName;

        public BOCTransFile(string textFileName)
        {
            this._TxtFileName = textFileName;
            this.BOCTranserEmployeeRecList = new List<BOCTansEmpRec>();
        }

        public List<BOCTansEmpRec> BOCTranserEmployeeRecList { get; set; }

        public bool GenerateTranserFile(string path, out string hashValue)
        {

            bool flag = false;
            hashValue = "";

            if (BOCTranserEmployeeRecList != null && BOCTranserEmployeeRecList.Count > 0)
            {
                string textFilePath = path + "\\" + this._TxtFileName;

                if (File.Exists(textFilePath))
                {
                    File.Delete(textFilePath);
                }

                foreach (BOCTansEmpRec b in BOCTranserEmployeeRecList)
                {
                    ErrorLogWrite(b.ToString(), path);
                }

                if (File.Exists(textFilePath))
                {
                    hashValue = GenerateHashForTextFile(textFilePath);
                }

                flag = true;
            }
            else
            {
                return flag;
            }

            return flag;
        }

        private string GenerateHashForTextFile(string filePath)
        {
            FileStream filestream;
            SHA256 mySHA256 = SHA256Managed.Create();

            filestream = new FileStream(filePath, FileMode.Open);

            filestream.Position = 0;

            byte[] hashValue = mySHA256.ComputeHash(filestream);

            string stttt = BitConverter.ToString(hashValue).Replace("-", String.Empty);

            filestream.Close();

            return stttt;
        }

        public void ErrorLogWrite(string customeException, string textFilePath)
        {
            string path = textFilePath; //+ "\\" + "BankText";
            string message = customeException;

            if (pathExist(path, true))
            {
                if (CreateFile(path, this._TxtFileName))
                {
                    path = path + "\\" + this._TxtFileName;

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

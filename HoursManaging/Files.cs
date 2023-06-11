using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursManaging
{
    internal class Files
    {
        internal static string VerifyReadFromFileName(string FilePath)
        {
            if (!File.Exists(FilePath))
            {
                throw new FileNotFoundException("ReadFromFileException: FilePath (" + FilePath + ") does not exist");
            }

            return FilePath;
        }

        internal static string VerifyWriteToFileName(string FilePath)
        {
            string text = Path.GetDirectoryName(FilePath);
            if (text == "")
            {
                text = ".\\";
                FilePath = text + FilePath;
            }

            if (!Directory.Exists(text))
            {
                throw new Exception("SaveToFileException: FilePath (" + FilePath + ") does not exist");
            }

            if (File.Exists(FilePath) && (File.GetAttributes(FilePath) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                throw new Exception("SaveToFileException:  FilePath(" + FilePath + ") is read only");
            }

            return FilePath;
        }
    }
}

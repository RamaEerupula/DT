using System;
using System.IO;


namespace DataStructures.Helpers
{
    public static class  FileReader
    {
        ///<summary>
        ///Gets the content of the file
        ///</summary>
        ///<param name>
        ///</paramname>
        
        public static string GetFileContent(string fileName)
        {
            Guard.ArgumentNotNullorEmpty(fileName, "fileName");

            string fileContent = string.Empty;
            if(File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    fileContent = sr.ReadToEnd();
                }
            }
            else
            {
                throw new FileNotFoundException("File could not be loaded from the path ",fileName);
            }
            return fileContent;
        }

      
    }
}

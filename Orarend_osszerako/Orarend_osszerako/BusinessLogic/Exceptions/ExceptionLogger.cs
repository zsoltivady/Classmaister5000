using System;
using System.IO;

namespace Orarend_osszerako.BusinessLogic.Exceptions
{
    public class ExceptionLogger
    {
        public ExceptionLogger()
        {

        }
        public static void LogException(Exception ex)
        {
            
            string filePath = @"/Orarend_osszerako/BusinessLogic/Error.txt";

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine("Date : " + DateTime.Now.ToString());
                writer.WriteLine();

                while (ex != null)
                {
                    writer.WriteLine(ex.GetType().FullName);
                    writer.WriteLine("Message : " + ex.Message);
                    writer.WriteLine("StackTrace : " + ex.StackTrace);

                    ex = ex.InnerException;
                }
            }
        }
    }
}

using System.IO;

namespace loggerLib
{
public class Filelogger:ILogger
{
    private StreamWriter sw=null;
    public void Log(string message)
    {
        //use file I/O APIs here
        //check if file named log.txt exists in a folder named logs
        // DirectoryInfo d = new DirectoryInfo("c:\\logs");

        //     if(!d.Exists)

        //     {

        //         d.Create();

        //         Console.WriteLine("Directory created for logs");

        //     }

        //     else

        //     {

        //         Console.WriteLine("Directory already exists for logs");

        //     }

        if(! Directory.Exists("c:\\logs"))

            {

                Directory.CreateDirectory("c:\\logs");

                Console.WriteLine("Directory created for logs");

            }

            else

            {

                Console.WriteLine("Directory already exists for logs");

            }
            //check if a file named logs.txt exists in the c:\logs folder

            FileInfo fi = new FileInfo("c:\\logs\\log.txt");

            if(! fi.Exists)

            {

                fi.Create();

                Console.WriteLine("File created for writing logs");

            }

            else

            {

                Console.WriteLine("File already exists for writing logs");

            }
            //open the file in append mode
            sw = new StreamWriter("c:\\logs\\log.txt", true);
            //write the log into the file
            sw.WriteLine("{0} written at {1}", message, DateTime.Now.ToLongTimeString());
    }

    public void Dispose()
    {
        //here write code to close the file

            if(this.sw != null)

            {

                sw.Close();

                Console.WriteLine("Log file closed in Dispose()");

            }
    }
}
}

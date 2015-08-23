using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPictureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                PrintHelp();
                return;
            }

            string mode = args[0];

            if(mode == "img")
            {
                string sourcePathOrString = args[1];
                string outputPath = args[4];

                Encoding textEncoding = Encoding.GetEncoding(args[2]);

                BitmapTextConverter.GenerateTextBitmapFromFile(sourcePathOrString, textEncoding, outputPath);
            }
            else if(mode == "text")
            {
                string sourcePathOrString = args[1];
                string outputPath = args[3];

                throw new NotImplementedException("Functionality not available yet");
            }
            else
            {
                Console.WriteLine("Unknown mode");
                return;
            }

            //Bitmap pic = new Bitmap(350, 350);

            //var picBytes = pic.ToByteArray(ImageFormat.Bmp);

            //Console.WriteLine(picBytes.Length);

            Console.WriteLine("Image generation finished");

            Console.Read();
        }

        static void PrintHelp()
        {
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName + " [mode|source path (encoding)|-o|ouput path]");
            Console.WriteLine("e.g.");
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName + @" img C:\tmp\hamlet.txt ascii -o C:\tmp\example.bmp");
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName + @" text C:\tmp\example.bmp -o C:\tmp\hamlet.txt");
        }
    }
}

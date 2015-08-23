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
    public class BitmapTextConverter
    {
        public const int BITMAP_DATA_OFFSET = 54;
        private const int BMP_WIDTH = 350;
        private const int BMP_HEIGHT = 350;

        private static byte[] GetNewBitmapBytes()
        {
            Bitmap pic = new Bitmap(BMP_WIDTH, BMP_HEIGHT);
            using(Graphics gr = Graphics.FromImage(pic))
            {
                Rectangle imgBgr = new Rectangle(0, 0, BMP_WIDTH, BMP_HEIGHT);
                gr.FillRectangle(Brushes.White, imgBgr);
            }

            var picBytes = pic.ToByteArray(ImageFormat.Bmp);

            return picBytes;
        }

        public static void GenerateTextBitmap(string text, Encoding encoding, string outputPath)
        {
            byte[] bytesToReplace = encoding.GetBytes(text);

            byte[] bitmapBytes = GetNewBitmapBytes();
            if (bytesToReplace.LongLength > (bitmapBytes.LongLength - BITMAP_DATA_OFFSET - 1))
                throw new ArgumentException("Text too big");            

            for (long i = 0; i < bytesToReplace.LongLength; i++)
            {
                bitmapBytes[i + BITMAP_DATA_OFFSET] = bytesToReplace[i];
            }

            File.WriteAllBytes(outputPath, bitmapBytes);
        }

        public static void GenerateTextBitmapFromFile(string path, Encoding encoding, string outputPath)
        {
            string text = File.ReadAllText(path);

            GenerateTextBitmap(text, encoding, outputPath);
        }
    }
}

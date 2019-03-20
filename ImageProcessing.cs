using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Steganography
{
    class ImageProcessing
    {    
        public static string LoadMessage(Bitmap image)
        {
            Color color = image.GetPixel(0, 0);

            int xStep = color.R;
            int yStep = color.G;
            int count = color.B;
            int index = 0;

            List<byte> data = new List<byte>();

            int x = xStep;
            int y = yStep;
            while(index < count)
            {
                Color pixelData = image.GetPixel(x, y);
                x += xStep;
                y += yStep;
                if (x >= image.Width)
                    x = x - image.Width;
                if (y >= image.Height)
                    y = y - image.Height;
                data.Add(pixelData.R);
                if(index+1 <count)
                data.Add(pixelData.G);
                if(index+2 < count)
                data.Add(pixelData.B);
                index+=3;
            }
            return (Encoding.ASCII.GetString(data.ToArray()));
        }
        public static Bitmap SaveMessage(Bitmap Image,string Message)
        {
            Bitmap image = (Bitmap)Image.Clone();

            byte[] data = Encoding.ASCII.GetBytes(Message);

            int xStep = image.Width / 3;
            if (xStep > 255)
                xStep = 255;
            int yStep = image.Height / data.Length;
            if (yStep > 255)
                yStep = 255;

            image.SetPixel(0, 0, Color.FromArgb(xStep, yStep, data.Length));

            int index = 0;
            int x = xStep;
            int y = yStep;
            while(index < data.Length)
            {
                if(index +2 < data.Length)
                image.SetPixel(x, y, Color.FromArgb(data[index], data[index + 1], data[index + 2]));
                else if (index+1<data.Length)
                    image.SetPixel(x, y, Color.FromArgb(data[index], data[index + 1], 255));
                else
                    image.SetPixel(x, y, Color.FromArgb(data[index], 255, 255));

                x += xStep;
                y += yStep;
                if (x >= image.Width)
                    x = x - image.Width;
                if (y >= image.Height)
                    y = y - image.Height;
                index += 3;
            }
            return (image);
        }
    }
}

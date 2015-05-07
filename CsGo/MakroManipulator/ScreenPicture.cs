using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakroManipulator
{
    public class ScreenPicture
    {

        public Point Location { get; set; }
        public Size Size { get; set; }
        public Image Image { get; set; }

        public ScreenPicture()
        {

        }

        public ScreenPicture(Point aiLocation, Size aiSize, Image aiImg)
        {
            Location = aiLocation;
            Size = aiSize;
            Image = aiImg;
        }

        /// <summary>
        /// This function checks if two pictures the same.
        /// </summary>
        /// <param name="aiPic1">Picture 1 which shall be compared with the second one.</param>
        /// <param name="aiPic2">Picture 2 which shall be compared with the first one.</param>
        /// <param name="aiTolerance">Value of tolerance.</param>
        /// <returns></returns>
        public static bool CompareScreenPictures(ScreenPicture aiPic1, ScreenPicture aiPic2, int aiTolerance)
        {
            if (!(aiPic1.Size == aiPic2.Size || aiPic1.Location == aiPic2.Location))
                return false;

            Bitmap img1 = new Bitmap(aiPic1.Image);
            Bitmap img2 = new Bitmap(aiPic2.Image);

            Color colorValue1 = GetColorValue(img1);
            Color colorValue2 = GetColorValue(img2);

            if (!CheckColorValues(colorValue1, colorValue2, aiTolerance))
            {
                Trace.WriteLine("Image has Changed");
                return false;
            }

            Trace.WriteLine("Image is nearly the same");
            return true;
        }

        public static ScreenPicture Take(Point aiLocation, Size aiSize)
        {
            var screenshot = new ScreenCapture();
            var img = screenshot.CaptureScreenAt(aiLocation,aiSize);

            ScreenPicture pic = new ScreenPicture(aiLocation,aiSize, img);

            return pic;
        }

        private static bool CheckColorValues(Color c, Color c2, int tolerance)
        {
            if (Math.Abs(c.A - c2.A) <= tolerance &&
                Math.Abs(c.R - c2.R) <= tolerance &&
                Math.Abs(c.G - c2.G) <= tolerance &&
                Math.Abs(c.B - c2.B) <= tolerance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static Color GetColorValue(Bitmap aiBitmap)
        {
            Color ergColor = new Color();

            int count = 0;
            int a = 0;
            int r = 0;
            int g = 0;
            int b = 0;

            for(int x = 0;x<aiBitmap.Width;x++)
            {
                for (int y = 0; y < aiBitmap.Height; y++)
                {
                    a += aiBitmap.GetPixel(x, y).A;
                    r += aiBitmap.GetPixel(x, y).R;
                    g += aiBitmap.GetPixel(x, y).G;
                    b += aiBitmap.GetPixel(x, y).B;
                    count++;
                }
            }

            a = a / count;
            r = r / count;
            g = g / count;
            b = b / count;

            ergColor = Color.FromArgb(a,r,g,b);

            return ergColor;
        }



        internal void Save(string aiPath)
        {
            this.Image.Save(aiPath);
        }
    }
}

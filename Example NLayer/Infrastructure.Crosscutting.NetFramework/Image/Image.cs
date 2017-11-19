using Infrastructure.Crosscutting.Image;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text.RegularExpressions;

namespace Infrastructure.Crosscutting.NetFramework.Imaging
{
    public class Image : IImage
    {
        public string CreateFilename(string fileName)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));

            return r.Replace(fileName, "_").Replace(' ', '_');
        }
        public Bitmap CreateImageInDirectory(string path, string filename, Stream stream, int width, int height, bool watermark, string copyright)
        {
            Bitmap original = Bitmap.FromStream(stream) as Bitmap;
            var StreamLength = stream.Length;

            // imagenes giradas
            foreach (var prop in original.PropertyItems)
            {
                if ((prop.Id == 0x0112 || prop.Id == 5029 || prop.Id == 274))
                {
                    var value = (int)prop.Value[0];
                    if (value == 6)
                    {
                        original.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    }
                    else if (value == 8)
                    {
                        original.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    }
                    else if (value == 3)
                    {
                        original.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    }
                }
            }

            if (original != null)
            {
                if ((width == 0 && height == 0) || original.Width < width)
                {//Tamaño original o imagen pequeña
                    width = original.Width;
                    height = original.Height;
                }

                if (StreamLength > 100000 || width == 240)// imagen que pesa poco o es para miniatura
                {
                    original = CreateImage(original, width, height);
                }

                var fn = path + filename + ".png";
                if (watermark)
                    original = Watermark(original, copyright);
                original.Save(fn, System.Drawing.Imaging.ImageFormat.Jpeg);

                return original;
            }

            return null;
        }
        public bool CreateMiniatureInDirectory(string path, string filename, Bitmap original, int width, int height)
        {
            if (original != null)
            {
                original = CreateImage(original, width, height);

                var fn = path + filename + ".png";

                original.Save(fn, System.Drawing.Imaging.ImageFormat.Jpeg);
                original.Dispose();

                return true;
            }

            return false;
        }
        Bitmap CreateImage(Bitmap original, int width, int height)
        {
            var ratioX = (double)width / original.Width;
            var ratioY = (double)height / original.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(original.Width * ratio);
            var newHeight = (int)(original.Height * ratio);

            var img = new Bitmap(newWidth, newHeight);

            using (var g = Graphics.FromImage(img))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(original, 0, 0, newWidth, newHeight);
            }

            return img;
        }
        Bitmap Watermark(Bitmap bitmapimage, string copyright)
        {
            int phWidth = bitmapimage.Width;
            int phHeight = bitmapimage.Height;
            using (var grPhoto = Graphics.FromImage(bitmapimage))
            {
                grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
                grPhoto.DrawImage(
                    bitmapimage,
                    new Rectangle(0, 0, phWidth, phHeight),
                    0,
                    0,
                    phWidth,
                    phHeight,
                    GraphicsUnit.Pixel);

                int[] sizes = new int[] { 16, 14, 12, 10, 8, 6, 4 };
                Font crFont = null;
                SizeF crSize = new SizeF();
                for (int i = 0; i < 7; i++)
                {
                    crFont = new Font("arial", sizes[i], FontStyle.Bold);
                    crSize = grPhoto.MeasureString(copyright, crFont);

                    if ((ushort)crSize.Width < (ushort)phWidth)
                        break;
                }

                int yPixlesFromBottom = (int)(phHeight * .05);
                float yPosFromBottom = ((phHeight - yPixlesFromBottom) - (crSize.Height / 2));
                float xCenterOfImg = (phWidth / 2);

                StringFormat StrFormat = new StringFormat();
                StrFormat.Alignment = StringAlignment.Center;

                SolidBrush semiTransBrush2 = new SolidBrush(Color.FromArgb(153, 0, 0, 0));

                grPhoto.DrawString(copyright,
                    crFont,
                    semiTransBrush2,
                    new PointF(xCenterOfImg + 1, yPosFromBottom + 1),
                    StrFormat);

                SolidBrush semiTransBrush = new SolidBrush(
                             Color.FromArgb(153, 255, 255, 255));

                grPhoto.DrawString(copyright,
                    crFont,
                    semiTransBrush,
                    new PointF(xCenterOfImg, yPosFromBottom),
                    StrFormat);
            }

            return bitmapimage;
        }
    }
}
using System;
using System.Drawing;

namespace Miniaturisation
{
    public static class ImageExtension
    {
        public static Image ScaleImage(this Image image, int maxWidth, int maxHeight)
        {
            var originalWidth = image.Width;
            var originalHeight = image.Height;
            var ratioX = (double)maxWidth / originalWidth;
            var ratioY = (double)maxHeight / originalHeight;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(maxWidth, maxHeight);
            int posX = Convert.ToInt32((maxWidth - (originalWidth * ratio)) / 2);
            int posY = Convert.ToInt32((maxHeight - (originalHeight * ratio)) / 2);
            
            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.Clear(Color.Transparent);
                graphics.DrawImage(image, posX, posY, newWidth, newHeight);
            }

            return newImage;
        }
    }
}

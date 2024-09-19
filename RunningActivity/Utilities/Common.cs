using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace RunningActivity.Utilities
{
    public static class Common
    {
        public static void ResizeImage(Image image, int targetWidth, int targetHeight)
        {
            var scale = Math.Max((double)targetWidth / image.Width, (double)targetHeight / image.Height);
            var newWidth = (int)Math.Round(image.Width * scale);
            var newHeight = (int)Math.Round(image.Height * scale);
            var cropX = (newWidth - targetWidth) / 2;
            var cropY = (newHeight - targetHeight) / 2;
            image.Mutate(x => x.Resize(newWidth, newHeight).Crop(new(cropX, cropY, targetWidth, targetHeight)));
        }
    }
}

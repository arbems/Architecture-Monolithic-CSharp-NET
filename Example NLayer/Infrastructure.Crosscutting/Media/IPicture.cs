using System.Drawing;
using System.IO;

namespace Infrastructure.Crosscutting.Media
{
    public interface IPicture
    {
        string CreateFilename(string fileName);
        Bitmap CreateImageInDirectory(string path, string filename, Stream inputStream, int width, int height, bool watermark, string copyright);
        bool CreateMiniatureInDirectory(string path, string filename, Bitmap original, int width, int height);
    }
}

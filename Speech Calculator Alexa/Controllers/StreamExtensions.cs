using System;
using System.IO;

namespace Speech_Calculator.Controllers
{
    public static class StreamExtensions
    {
        public static byte[] ReadAll(this Stream stream)
        {
            const int bufSize = 1024 * 1024;
            using (var ms = new MemoryStream())
            {
                int count;
                do
                {
                    var buf = new Byte[bufSize];
                    count = stream.Read(buf, 0, bufSize);
                    ms.Write(buf, 0, count);
                } while (count > 0);
                return ms.ToArray();
            }
        }
    }
}
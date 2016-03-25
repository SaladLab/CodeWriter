using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeWriter
{
    public static class CodeWriterExtensions
    {
        public static void _(this CodeWriter w, string str)
        {
            w.Write(str);
        }

        public static void _(this CodeWriter w, params string[] strs)
        {
            w.Write(strs);
        }

        public static UsingHandle B(this CodeWriter w, string str = null)
        {
            return w.OpenBlock(str);
        }
    }
}

namespace CodeWriter
{
    public static class CodeWriterExtensions
    {
#pragma warning disable SA1300 // Element must begin with upper-case letter
        public static void _(this CodeWriter w, string str = null)
        {
            w.Write(str);
        }

        public static void _(this CodeWriter w, string str, params string[] strs)
        {
            w.Write(str, strs);
        }

        public static UsingHandle b(this CodeWriter w, string str = null)
        {
            return w.OpenBlock(str, newLineAfterBlockEnd: false);
        }

        public static UsingHandle B(this CodeWriter w, string str = null)
        {
            return w.OpenBlock(str, newLineAfterBlockEnd: true);
        }
#pragma warning restore SA1300 // Element must begin with upper-case letter
    }
}

using System;
using CodeWriter;

namespace Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new CodeWriterSettings(CodeWriterSettings.CSharpDefault);
            s.BlockNewLine = false;
            s.TranslationMapping["`"] = "\"";

            var w = new CodeWriter.CodeWriter(s);
            
            using (w.B("class Test"))
            {
                using (w.B("public int Sum(int a, int b)"))
                {
                    w._($"var r = a + b;",
                        $"return r;");
                }
                using (w.B("public int Mul(int a, int b)"))
                {
                    w._($"var r = `a * b`;",
                        $"return r;");
                }
            }
            w.HeadLines = new[]
            {
                "// COMMENT1",
                "// COMMENT2",
                "",
                "using System;",
                "",
            };

            Console.Write(w.ToString());
        }
    }
}

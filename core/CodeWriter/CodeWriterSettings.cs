using System;
using System.Collections.Generic;

namespace CodeWriter
{
    public class CodeWriterSettings
    {
        public string Indent;
        public bool BlockNewLine;
        public string BlockBegin;
        public string BlockEnd;
        public string NewLine;
        public Dictionary<string, string> TranslationMapping = new Dictionary<string, string>();

        public CodeWriterSettings()
        {
        }

        public CodeWriterSettings(CodeWriterSettings o)
        {
            Indent = o.Indent;
            BlockNewLine = o.BlockNewLine;
            BlockBegin = o.BlockBegin;
            BlockEnd = o.BlockEnd;
            NewLine = o.NewLine;
            TranslationMapping = new Dictionary<string, string>(o.TranslationMapping);
        }

        public static CodeWriterSettings CSharpDefault = new CodeWriterSettings
        {
            Indent = "    ",
            BlockNewLine = true,
            BlockBegin = "{",
            BlockEnd = "}",
            NewLine = Environment.NewLine
        };
    }
}

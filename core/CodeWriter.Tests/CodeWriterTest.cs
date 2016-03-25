using Xunit;

namespace CodeWriter.Tests
{
    public class CodeWriterTest
    {
        [Fact]
        private void Test_Block_NewLineBeforeBlockBegin_False()
        {
            var w = CreateTestWriter();
            w.Settings.NewLineBeforeBlockBegin = false;

            using (w.B("Block"))
            {
                using (w.b("SubBlock1"))
                {
                    w._("Line1");
                }
                using (w.b("SubBlock2"))
                {
                    w._("Line2");
                }
            }

            AssertEqualLines(
                w,
                "Block {",
                "  SubBlock1 {",
                "    Line1",
                "  }",
                "  SubBlock2 {",
                "    Line2",
                "  }",
                "}");
        }

        [Fact]
        private void Test_Block_NewLineBeforeBlockBegin_True()
        {
            var w = CreateTestWriter();
            w.Settings.NewLineBeforeBlockBegin = true;

            using (w.B("Block"))
            {
                using (w.b("SubBlock1"))
                {
                    w._("Line1");
                }
                using (w.b("SubBlock2"))
                {
                    w._("Line2");
                }
            }

            AssertEqualLines(
                w,
                "Block",
                "{",
                "  SubBlock1",
                "  {",
                "    Line1",
                "  }",
                "  SubBlock2",
                "  {",
                "    Line2",
                "  }",
                "}");
        }

        [Fact]
        private void Test_Block_NewLineAfterBlockEnd_True()
        {
            var w = CreateTestWriter();

            using (w.B("Block"))
            {
                using (w.B("SubBlock1"))
                {
                    w._("Line1");
                }
                using (w.B("SubBlock2"))
                {
                    w._("Line2");
                }
                w._("Line");
                using (w.B("SubBlock3"))
                {
                    w._("Line3");
                }
            }

            AssertEqualLines(
                w,
                "Block {",
                "  SubBlock1 {",
                "    Line1",
                "  }",
                "",
                "  SubBlock2 {",
                "    Line2",
                "  }",
                "",
                "  Line",
                "  SubBlock3 {",
                "    Line3",
                "  }",
                "}");
        }

        [Fact]
        private void Test_HeadLines()
        {
            var w = CreateTestWriter();

            w.HeadLines = new[]
            {
                "HeadLine1",
                "HeadLine2",
            };
            w.Write("Line1");

            AssertEqualLines(
                w,
                "HeadLine1",
                "HeadLine2",
                "Line1");
        }

        [Fact]
        private void Test_TranslationMapping()
        {
            var w = CreateTestWriter();
            w.Settings.TranslationMapping["`"] = "\"";
            w.Settings.TranslationMapping["'"] = "*";

            w.HeadLines = new[]
            {
                "Head`Line1`",
                "Head'Line2'",
            };
            w.Write("`Line1'");

            AssertEqualLines(
                w,
                "Head\"Line1\"",
                "Head*Line2*",
                "\"Line1*");
        }

        private void AssertEqualLines(CodeWriter w, params string[] lines)
        {
            var ls = w.ToString().TrimEnd().Replace("\r", "").Split('\n');
            Assert.Equal(lines, ls);
        }

        private CodeWriter CreateTestWriter()
        {
            var settings = new CodeWriterSettings(CodeWriterSettings.CSharpDefault);
            settings.Indent = "  ";
            settings.NewLineBeforeBlockBegin = false;
            return new CodeWriter(settings);
        }
    }
}

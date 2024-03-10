using Microsoft.CodeAnalysis.CSharp;

namespace Roslyn.CodeAnalysis.Lightup.CSharp
{
    public class LanguageVersionEx
    {
        public const LanguageVersion CSharp1 = (LanguageVersion)1;
        public const LanguageVersion CSharp2 = (LanguageVersion)2;
        public const LanguageVersion CSharp3 = (LanguageVersion)3;
        public const LanguageVersion CSharp4 = (LanguageVersion)4;
        public const LanguageVersion CSharp5 = (LanguageVersion)5;
        public const LanguageVersion CSharp6 = (LanguageVersion)6;
        public const LanguageVersion CSharp7 = (LanguageVersion)7;
        public const LanguageVersion CSharp7_1 = (LanguageVersion)701;
        public const LanguageVersion CSharp7_2 = (LanguageVersion)702;
        public const LanguageVersion CSharp7_3 = (LanguageVersion)703;
        public const LanguageVersion CSharp8 = (LanguageVersion)800;
        public const LanguageVersion CSharp9 = (LanguageVersion)900;
        public const LanguageVersion CSharp10 = (LanguageVersion)1000;
        public const LanguageVersion CSharp11 = (LanguageVersion)1100;
        public const LanguageVersion CSharp12 = (LanguageVersion)1200;
        public const LanguageVersion LatestMajor = (LanguageVersion)2147483645;
        public const LanguageVersion Preview = (LanguageVersion)2147483646;
        public const LanguageVersion Latest = (LanguageVersion)2147483647;
        public const LanguageVersion Default = (LanguageVersion)0;
    }
}

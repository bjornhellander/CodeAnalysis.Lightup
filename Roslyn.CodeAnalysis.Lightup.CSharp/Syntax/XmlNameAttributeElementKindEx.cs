using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Roslyn.CodeAnalysis.Lightup.CSharp.Syntax
{
    public class XmlNameAttributeElementKindEx
    {
        public const XmlNameAttributeElementKind Parameter = (XmlNameAttributeElementKind)0;
        public const XmlNameAttributeElementKind ParameterReference = (XmlNameAttributeElementKind)1;
        public const XmlNameAttributeElementKind TypeParameter = (XmlNameAttributeElementKind)2;
        public const XmlNameAttributeElementKind TypeParameterReference = (XmlNameAttributeElementKind)3;
    }
}
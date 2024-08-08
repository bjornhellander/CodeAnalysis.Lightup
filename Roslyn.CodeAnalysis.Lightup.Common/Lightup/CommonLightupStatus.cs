namespace Microsoft.CodeAnalysis.Lightup
{
    using System;
    using Microsoft.CodeAnalysis;

    public class CommonLightupStatus
    {
        static CommonLightupStatus()
        {
            CodeAnalysisVersion = typeof(OperationKind).Assembly.GetName().Version;
        }

        public static Version CodeAnalysisVersion { get; }
    }
}

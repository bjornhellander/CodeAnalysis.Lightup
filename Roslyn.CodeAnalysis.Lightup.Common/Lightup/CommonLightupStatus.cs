// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

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

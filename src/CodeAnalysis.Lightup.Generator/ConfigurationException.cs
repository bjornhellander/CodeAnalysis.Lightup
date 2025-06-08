// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

namespace CodeAnalysis.Lightup.Generator;

[Serializable]
internal class ConfigurationException : Exception
{
    public ConfigurationException(string message)
        : base(message)
    {
    }
}

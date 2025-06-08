// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

#pragma warning disable SA1200 // Using directives should be placed correctly
global using System;
global using System.Collections.Immutable;
global using System.Linq;
global using System.Reflection;
global using CodeAnalysis.Lightup.Test.V1_3_2.CSharp;
global using Microsoft.CodeAnalysis;
global using Microsoft.CodeAnalysis.CSharp;
global using Microsoft.CodeAnalysis.CSharp.Syntax;
global using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
global using Microsoft.CodeAnalysis.Diagnostics;
global using Microsoft.CodeAnalysis.Lightup;
global using Microsoft.CodeAnalysis.Operations;
global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using Moq;

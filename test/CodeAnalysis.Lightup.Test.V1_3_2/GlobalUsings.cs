// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

#pragma warning disable SA1200 // Using directives should be placed correctly
global using System;
global using System.Collections.Generic;
global using System.Collections.Immutable;
global using System.Diagnostics.CodeAnalysis;
global using System.Linq;
global using System.Threading;
global using System.Threading.Tasks;
global using CodeAnalysis.Lightup.Example.Analyzers;
global using Microsoft.CodeAnalysis;
global using Microsoft.CodeAnalysis.CodeActions.Lightup;
global using Microsoft.CodeAnalysis.CodeFixes;
global using Microsoft.CodeAnalysis.CodeFixes.Lightup;
global using Microsoft.CodeAnalysis.CSharp;
global using Microsoft.CodeAnalysis.CSharp.Lightup;
global using Microsoft.CodeAnalysis.CSharp.Syntax;
global using Microsoft.CodeAnalysis.CSharp.Syntax.Lightup;
global using Microsoft.CodeAnalysis.Lightup;
global using Microsoft.CodeAnalysis.Testing;
global using Microsoft.CodeAnalysis.Text;
global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using Moq;

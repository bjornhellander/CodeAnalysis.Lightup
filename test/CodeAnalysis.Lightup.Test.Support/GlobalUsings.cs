// Copyright © Björn Hellander 2024
// Licensed under the MIT License. See LICENSE.txt in the repository root for license information.

global using System;
global using System.Collections.Immutable;
global using System.Threading;
global using System.Threading.Tasks;
global using Microsoft.CodeAnalysis;
global using Microsoft.CodeAnalysis.CodeFixes;
global using Microsoft.CodeAnalysis.CodeRefactorings;
global using Microsoft.CodeAnalysis.CSharp;
global using Microsoft.CodeAnalysis.CSharp.Testing;
global using Microsoft.CodeAnalysis.Diagnostics;
global using Microsoft.CodeAnalysis.Testing;
global using Microsoft.CodeAnalysis.VisualBasic.Testing;
global using Microsoft.VisualStudio.TestTools.UnitTesting;

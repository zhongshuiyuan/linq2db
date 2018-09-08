using System;
using FastExpressionCompiler;
using NUnit.Framework;

using Tests;

/// <summary>
/// 1. Don't add namespace to this class! It's intentional
/// 2. This class implements test assembly setup/teardown methods.
/// </summary>
[SetUpFixture]
public class TestsInitialization
{
	[OneTimeSetUp]
	public void TestAssemblySetup()
	{
		// register test provider
		TestNoopProvider.Init();
#if !NETSTANDARD1_6
		LinqToDB.Common.Compilation.SetExpressionCompiler(
			_ => ExpressionCompiler.CompileFast(_, true));
#endif
	}

	[OneTimeTearDown]
	public void TestAssemblyTeardown()
	{
	}
}

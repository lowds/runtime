// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit.Abstractions;

#nullable enable

namespace Wasm.Build.Tests;

public class BlazorWasmProjectProvider : WasmSdkBasedProjectProvider
{
    public BlazorWasmProjectProvider(ITestOutputHelper _testOutput, string? _projectDir = null)
            : base(_testOutput, _projectDir)
    {}

    public void AssertBundle(BlazorBuildOptions options)
        => AssertBundle(new AssertWasmSdkBundleOptions(
                Config: options.Config,
                IsPublish: options.IsPublish,
                TargetFramework: options.TargetFramework,
                BinFrameworkDir: FindBinFrameworkDir(options.Config, options.IsPublish, options.TargetFramework),
                GlobalizationMode: GlobalizationMode.Sharded,
                PredefinedIcudt: null,
                ExpectFingerprintOnDotnetJs: options.ExpectFingerprintOnDotnetJs,
                ExpectedFileType: options.ExpectedFileType,
                RuntimeType: options.RuntimeType,
                AssertIcuAssets: false, // FIXME: this is broken right now
                AssertSymbolsFile: false // FIXME: not supported yet
            ));
}

// Copyright (c) Wojciech Figat. All rights reserved.

using System.IO;
using Flax.Build;
using Flax.Build.NativeCpp;

/// <summary>
/// https://github.com/Chlumsky/msdfgen
/// </summary>
public class msdfgen : DepsModule
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        LicenseType = LicenseTypes.MIT;
        LicenseFilePath = "LICENSE.TXT";

        // Merge third-party modules into engine binary
        BinaryModuleName = "FlaxEngine";
    }

    /// <inheritdoc />
    public override void Setup(BuildOptions options)
    {
        base.Setup(options);

        var depsRoot = options.DepsFolder;
        switch (options.Platform.Target)
        {
        case TargetPlatform.Windows:
            options.OutputFiles.Add(Path.Combine(depsRoot, "msdfgen-core.lib"));
            break;
        case TargetPlatform.Linux:
        case TargetPlatform.Mac:
            // todo
            //options.OutputFiles.Add(Path.Combine(depsRoot, "msdfgen-core.a"));
            break;
        default: throw new InvalidPlatformException(options.Platform.Target);
        }

        options.PublicIncludePaths.Add(Path.Combine(Globals.EngineRoot, @"Source\ThirdParty\msdfgen"));
    }
}

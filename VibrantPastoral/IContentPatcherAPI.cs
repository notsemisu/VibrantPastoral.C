#nullable enable
using StardewModdingAPI;
using System;
using System.Collections.Generic;

namespace ContentPatcher
{
    public interface IContentPatcherAPI
    {
        bool IsConditionsApiReady { get; }

        void RegisterToken(IManifest mod, string name, Func<IEnumerable<string>?> getValue);
    }
}
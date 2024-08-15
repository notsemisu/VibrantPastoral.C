#nullable enable
using ContentPatcher;
using GenericModConfigMenu;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace VibrantPastoral
{
    internal class ModEntry : Mod
    {
        private ModConfig Config;

        public override void Entry(IModHelper helper)
        {
            this.Helper.Events.GameLoop.GameLaunched += this.OnGameLaunched;

            Config = this.Helper.ReadConfig<ModConfig>();
        }
        void OnGameLaunched(object? sender, GameLaunchedEventArgs e)
        {
            //CP Token
            if (this.Helper.ModRegistry.GetApi<IContentPatcherAPI>("Pathoschild.ContentPatcher") is not IContentPatcherAPI api)
            {
                return;
            }

            api.RegisterToken(this.ModManifest, "GreenFall", () =>
                {
                    if (Context.IsWorldReady || SaveGame.loaded is not null)
                    {
                        return new[] { this.Config.GreenFall.ToString() };
                    }
                    return null;
                });
            api.RegisterToken(this.ModManifest, "PetBowlShadow", () =>
            {
                if (Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.PetBowlShadow };
                }
                return null;
            });
            api.RegisterToken(this.ModManifest, "Furniture", () =>
            {
                if (Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.Furniture.ToString() };
                }
                return null;
            });
            api.RegisterToken(this.ModManifest, "Interiors", () =>
            {
                if (Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.Interiors.ToString() };
                }
                return null;
            });
            api.RegisterToken(this.ModManifest, "Vegetation", () =>
            {
                if (Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.Vegetation.ToString() };
                }
                return null;
            });
            api.RegisterToken(this.ModManifest, "SnOverlay", () =>
            {
                if (Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.SnOverlay.ToString() };
                }
                return null;
            });
            //Expanded Config
            api.RegisterToken(this.ModManifest, "Extras", () =>
            {
                if (Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.Extras.ToString() };
                }
                return null;
            });
            api.RegisterToken(this.ModManifest, "IridiumOasis", () =>
            {
                if (Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.IridiumOasis.ToString() };
                }
                return null;
            });
            //??? Config
            api.RegisterToken(this.ModManifest, "EdNygma", () =>
            {
                if (Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.EdNygma.ToString() };
                }
                return null;
            });

            //GMCM
            if (this.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu") is not IGenericModConfigMenuApi configMenu)
            {
                return;
            }

            configMenu.Register(
                mod: this.ModManifest,
                reset: () => this.Config = new ModConfig(),
                save: () => this.Helper.WriteConfig(this.Config)
                );

            configMenu.AddSectionTitle(
                mod: this.ModManifest,
                text: () => "World Map"
                );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                name: () => "Green Fall",
                tooltip: () => "Change terrain colour from orange to green during fall.",
                getValue: () => this.Config.GreenFall,
                setValue: value => this.Config.GreenFall = value
                );

            configMenu.AddSectionTitle(
                mod: this.ModManifest,
                text: () => "Custom Farm"
                );

            configMenu.AddTextOption(
                 mod: this.ModManifest,
                 name: () => "Pet Bowl Shadow",
                 tooltip: () => "Manually set the pet bowl shadow for custom farms.",
                 getValue: () => this.Config.PetBowlShadow,
                 setValue: value => this.Config.PetBowlShadow = value,
                 allowedValues: new string[] { "", "Beach", "Standard" }
                 );

            configMenu.AddSectionTitle(
                mod: this.ModManifest,
                text: () => "Misc"
                );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                name: () => "Furniture",
                tooltip: () => "Toggle changes to furniture.",
                getValue: () => this.Config.Furniture,
                setValue: value => this.Config.Furniture = value
                );
            configMenu.AddBoolOption(
                mod: this.ModManifest,
                name: () => "Interiors",
                tooltip: () => "Toggle changes to interiors.",
                getValue: () => this.Config.Interiors,
                setValue: value => this.Config.Interiors = value
                );
            configMenu.AddBoolOption(
                mod: this.ModManifest,
                name: () => "Vegetation",
                tooltip: () => "Toggle changes to outdoors vegetation. No effect if Simple Foliage loaded.",
                getValue: () => this.Config.Vegetation,
                setValue: value => this.Config.Vegetation = value
                );
            configMenu.AddBoolOption(
                mod: this.ModManifest,
                name: () => "SnOverlay",
                tooltip: () => "Toggle snow covered rooves and other exposed surfaces during winter; no effect on disabled buildings.",
                getValue: () => this.Config.SnOverlay,
                setValue: value => this.Config.SnOverlay = value
                );

            //Expanded Config
            if (Helper.ModRegistry.IsLoaded("VibrantPastoral.Expanded"))
            {
                configMenu.AddSectionTitle(
                    mod: this.ModManifest,
                    text: () => "Extras"
                    );

                configMenu.AddBoolOption(
                    mod: this.ModManifest,
                    name: () => "Extras",
                    tooltip: () => "Toggle changes to z_extras.",
                    getValue: () => this.Config.Extras,
                    setValue: value => this.Config.Extras = value
                    );
                configMenu.AddBoolOption(
                     mod: this.ModManifest,
                     name: () => "Iridium Oasis",
                     tooltip: () => "Enable if Oasis chosen to be made of iridium in VPR.",
                     getValue: () => this.Config.IridiumOasis,
                     setValue: value => this.Config.IridiumOasis = value
                     );
            }

            //??? Config
            configMenu.AddSectionTitle(
                mod: this.ModManifest,
                text: () => "???"
                );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                name: () => "Ed Nygma",
                tooltip: () => "???",
                getValue: () => this.Config.EdNygma,
                setValue: value => this.Config.EdNygma = value
                );
        }
    }
}
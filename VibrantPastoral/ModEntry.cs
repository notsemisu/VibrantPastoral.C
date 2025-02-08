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
                if (Context.IsGameLaunched || Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.GreenFall.ToString() };
                }
                return null;
            });
            api.RegisterToken(this.ModManifest, "PetBowlShadow", () =>
            {
                if (Context.IsGameLaunched || Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.PetBowlShadow };
                }
                return null;
            });
            api.RegisterToken(this.ModManifest, "Furniture", () =>
            {
                if (Context.IsGameLaunched || Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.Furniture.ToString() };
                }
                return null;
            });
            api.RegisterToken(this.ModManifest, "Interiors", () =>
            {
                if (Context.IsGameLaunched || Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.Interiors.ToString() };
                }
                return null;
            });
            api.RegisterToken(this.ModManifest, "Vegetation", () =>
            {
                if (Context.IsGameLaunched || Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.Vegetation.ToString() };
                }
                return null;
            });
            api.RegisterToken(this.ModManifest, "SnOverlay", () =>
            {
                if (Context.IsGameLaunched || Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.SnOverlay.ToString() };
                }
                return null;
            });
            api.RegisterToken(this.ModManifest, "Water", () =>
            {
                if (Context.IsGameLaunched || Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.Water };
                }
                return null;
            });
            api.RegisterToken(this.ModManifest, "IridiumOasis", () =>
            {
                if (Context.IsGameLaunched || Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.IridiumOasis.ToString() };
                }
                return null;
            });
            //??? Config
            api.RegisterToken(this.ModManifest, "EdNygma", () =>
            {
                if (Context.IsGameLaunched || Context.IsWorldReady || SaveGame.loaded is not null)
                {
                    return new[] { this.Config.EdNygma.ToString() };
                }
                return null;
            });

            //GMCM
            var i18n = Helper.Translation;

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
                text: () => i18n.Get("config.section.WorldMap.name")
                );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                name: () => i18n.Get("config.GreenFall.name"),
                tooltip: () => i18n.Get("config.GreenFall.description"),
                getValue: () => this.Config.GreenFall,
                setValue: value => this.Config.GreenFall = value
                );

            configMenu.AddSectionTitle(
                mod: this.ModManifest,
                text: () => i18n.Get("config.section.CustomFarm.name")
                );

            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => i18n.Get("config.PetBowlShadow.name"),
                tooltip: () => i18n.Get("config.PetBowlShadow.description"),
                getValue: () => this.Config.PetBowlShadow,
                setValue: value => this.Config.PetBowlShadow = value,
                allowedValues: new string[] { "", "beach", "standard" },
                formatAllowedValue: value => i18n.Get($"config.PetBowlShadow.values.{value}").UsePlaceholder(false) ?? ""
                );

            configMenu.AddSectionTitle(
                mod: this.ModManifest,
                text: () => i18n.Get("config.section.misc.name")
                );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                name: () => i18n.Get("config.Furniture.name"),
                tooltip: () => i18n.Get("config.Furniture.description"),
                getValue: () => this.Config.Furniture,
                setValue: value => this.Config.Furniture = value
                );
            configMenu.AddBoolOption(
                mod: this.ModManifest,
                name: () => i18n.Get("config.Interiors.name"),
                tooltip: () => i18n.Get("config.Interiors.description"),
                getValue: () => this.Config.Interiors,
                setValue: value => this.Config.Interiors = value
                );
            configMenu.AddBoolOption(
                mod: this.ModManifest,
                name: () => i18n.Get("config.Vegetation.name"),
                tooltip: () => i18n.Get("config.Vegetation.description"),
                getValue: () => this.Config.Vegetation,
                setValue: value => this.Config.Vegetation = value
                );
            configMenu.AddBoolOption(
                mod: this.ModManifest,
                name: () => i18n.Get("config.SnOverlay.name"),
                tooltip: () => i18n.Get("config.SnOverlay.description"),
                getValue: () => this.Config.SnOverlay,
                setValue: value => this.Config.SnOverlay = value
                );
            configMenu.AddTextOption(
                mod: this.ModManifest,
                name: () => i18n.Get("config.Water.name"),
                tooltip: () => i18n.Get("config.Water.description"),
                getValue: () => this.Config.Water,
                setValue: value => this.Config.Water = value,
                allowedValues: new string[] { "transparent", "semi", "opaque" },
                formatAllowedValue: value => i18n.Get($"config.Water.values.{value}").UsePlaceholder(false) ?? ""
                );
            configMenu.AddBoolOption(
                mod: this.ModManifest,
                name: () => i18n.Get("config.IridiumOasis.name"),
                tooltip: () => i18n.Get("config.IridiumOasis.description"),
                getValue: () => this.Config.IridiumOasis,
                setValue: value => this.Config.IridiumOasis = value
                );

            //Expanded Config
            if (Helper.ModRegistry.IsLoaded("VibrantPastoral.Expanded"))
            {
            }

            //??? Config
            configMenu.AddSectionTitle(
                mod: this.ModManifest,
                text: () => i18n.Get("config.section.???.name")
                );

            configMenu.AddBoolOption(
                mod: this.ModManifest,
                name: () => i18n.Get("config.EdNygma.name"),
                tooltip: () => i18n.Get("config.EdNygma.description"),
                getValue: () => this.Config.EdNygma,
                setValue: value => this.Config.EdNygma = value
                );
        }
    }
}
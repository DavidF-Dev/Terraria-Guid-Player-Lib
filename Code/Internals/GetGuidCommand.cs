using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace GuidPlayerLib.Code.Internals;

// ReSharper disable once UnusedType.Global
internal sealed class GetGuidCommand : ModCommand
{
    #region Properties

    public override string Command => "get-guid";

    public override string Usage => $"{Command} <get|list>";

    public override CommandType Type => CommandType.Chat | CommandType.Console;

    #endregion

    #region Methods

    public override void Action(CommandCaller caller, string input, string[] args)
    {
        if (args.Length < 1)
        {
            caller.Reply($"Invalid usage: {Usage}");
            return;
        }

        if (args[0] == "get")
        {
            if (args.Length < 2 || !int.TryParse(args[1], out var whoAmI) || whoAmI < 0 || whoAmI >= Main.maxPlayers)
            {
                caller.Reply($"Invalid usage: {Command} get <whoAmI>", Color.Red);
                return;
            }

            var player = Main.player[whoAmI];
            if (!player.active)
            {
                caller.Reply($"Cannot get guid of inactive player: {whoAmI}.", Color.Red);
                return;
            }

            caller.Reply($"[{whoAmI}] {player.name}: {player.GetGuid()}");
        }
        else if (args[0] == "list")
        {
            foreach (var player in Main.ActivePlayers)
            {
                caller.Reply($"[{player.whoAmI}] {player.name}: {player.GetGuid()}");
            }
        }
        else
        {
            caller.Reply($"Invalid usage: {Usage}", Color.Red);
        }
    }

    public override bool IsLoadingEnabled(Mod mod)
    {
#if DEBUG
        return true;
#else
        return false;
#endif
    }

    #endregion
}
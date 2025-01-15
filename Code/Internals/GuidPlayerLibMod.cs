/*
 *  GuidPlayerLibMod.cs
 *  DavidFDev
 */

using System;
using Terraria;
using Terraria.ModLoader;

namespace GuidPlayerLib.Code.Internals;

// ReSharper disable once ClassNeverInstantiated.Global
internal sealed class GuidPlayerLibMod : Mod
{
    #region Methods

    public override object Call(params object[] args)
    {
        if (args.Length < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(args));
        }

        if (args[0] is not string callName)
        {
            throw new ArgumentException($"Invalid argument 0: '{args[0]?.GetType().Name}'. Expected: '{nameof(String)}'.", nameof(args));
        }

        // Usage: Guid result = mod.Call("GetGuid", player);
        if (callName == "GetGuid")
        {
            if (args.Length < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(args));
            }

            if (args[1] is not Player player)
            {
                throw new ArgumentException($"Invalid argument 1: '{args[1]?.GetType().Name}'. Expected: '{nameof(Player)}'.", nameof(args));
            }

            return player.GetGuid();
        }

        throw new ArgumentException($"Invalid mod call: '{callName}'.", nameof(args));
    }

    #endregion
}
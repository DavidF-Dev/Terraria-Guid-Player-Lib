/*
 *  GuidPlayerExtensions.cs
 *  DavidFDev
 */

using System;
using GuidPlayerLib.Code.Internals;
using Terraria;

namespace GuidPlayerLib.Code;

/// <summary>
///     Extension methods for retrieving player's guids.
/// </summary>
public static class GuidPlayerExtensions
{
    #region Static Methods

    /// <summary>
    ///     Retrieve a player's unique guid.
    /// </summary>
    public static Guid GetGuid(this Player player)
    {
        return player.GetModPlayer<GuidPlayer>().Guid;
    }

    #endregion
}
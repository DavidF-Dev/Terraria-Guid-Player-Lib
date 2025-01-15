/*
 *  GuidPlayer.cs
 *  DavidFDev
 */

using System;
using System.IO;
using EasyPacketsLib;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace GuidPlayerLib.Code.Internals;

// ReSharper disable once ClassNeverInstantiated.Global
internal sealed class GuidPlayer : ModPlayer
{
    #region Properties

    public Guid Guid { get; private set; }

    #endregion

    #region Methods

    public override void Initialize()
    {
        Guid = Guid.NewGuid();
    }

    public override void SaveData(TagCompound tag)
    {
        tag.Add("Guid", Guid.ToByteArray());
    }

    public override void LoadData(TagCompound tag)
    {
        if (tag.ContainsKey("Guid"))
        {
            Guid = new Guid(tag.GetByteArray("Guid"));
        }
    }

    public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
    {
        Mod.SendPacket(new SyncPacket((byte)Player.whoAmI, Guid), toWho, fromWho);
    }

    public override void CopyClientState(ModPlayer targetCopy)
    {
        // TODO: Allocates
        // - Is CopyClientState/SendClientChanges necessary?
        // - Can we fill a byte array to avoid allocations?
        ((GuidPlayer)targetCopy).Guid = Guid;
    }

    public override void SendClientChanges(ModPlayer clientPlayer)
    {
        if (Guid != ((GuidPlayer)clientPlayer).Guid)
        {
            Mod.SendPacket(new SyncPacket((byte)Player.whoAmI, Guid), forward: true);
        }
    }

    #endregion

    #region Nested Types

    private readonly struct SyncPacket(byte whoAmI, Guid guid) : IEasyPacket<SyncPacket>, IEasyPacketHandler<SyncPacket>
    {
        #region Fields

        private readonly byte _whoAmI = whoAmI;
        private readonly Guid _guid = guid;

        #endregion

        #region Methods

        void IEasyPacket<SyncPacket>.Serialise(BinaryWriter writer)
        {
            var guidBytes = _guid.ToByteArray();
            writer.Write(_whoAmI);
            writer.Write(guidBytes.Length);
            writer.Write(guidBytes);
        }

        SyncPacket IEasyPacket<SyncPacket>.Deserialise(BinaryReader reader, in SenderInfo sender)
        {
            return new SyncPacket(reader.ReadByte(), new Guid(reader.ReadBytes(reader.ReadInt32())));
        }

        void IEasyPacketHandler<SyncPacket>.Receive(in SyncPacket packet, in SenderInfo sender, ref bool handled)
        {
            Main.player[packet._whoAmI].GetModPlayer<GuidPlayer>().Guid = packet._guid;
            handled = true;
        }

        #endregion
    }

    #endregion
}
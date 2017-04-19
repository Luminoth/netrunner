namespace EnergonSoftware.Netrunner.Core.SocketIO.Packets
{
    public sealed class BinaryEvent : Packet
    {
        public override Type PacketType => Type.BinaryEvent;

        public int Id { get; set; }

        public string Data { get; set; }
    }
}

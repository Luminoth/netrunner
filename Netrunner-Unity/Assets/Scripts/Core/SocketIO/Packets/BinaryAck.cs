namespace EnergonSoftware.Netrunner.Core.SocketIO.Packets
{
    public sealed class BinaryAck : Packet
    {
        public override Type PacketType => Type.BinaryAck;

        public int Id { get; set; }

        public string Data { get; set; }
    }
}

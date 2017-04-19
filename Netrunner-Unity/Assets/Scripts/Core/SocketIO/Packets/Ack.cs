namespace EnergonSoftware.Netrunner.Core.SocketIO.Packets
{
    public sealed class Ack : Packet
    {
        public override Type PacketType => Type.Ack;

        public int Id { get; set; }

        public string Data { get; set; }
    }
}

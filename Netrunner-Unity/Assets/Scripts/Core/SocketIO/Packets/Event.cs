namespace EnergonSoftware.Netrunner.Core.SocketIO.Packets
{
    public sealed class Event : Packet
    {
        public override Type PacketType => Type.Event;

        public int Id { get; set; }

        public string Data { get; set; }
    }
}

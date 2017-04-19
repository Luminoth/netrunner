namespace EnergonSoftware.Netrunner.Core.SocketIO.Packets
{
    public sealed class Error : Packet
    {
        public override Type PacketType => Type.Error;

        public string Data { get; set; }
    }
}

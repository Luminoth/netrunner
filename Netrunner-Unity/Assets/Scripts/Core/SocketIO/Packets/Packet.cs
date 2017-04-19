namespace EnergonSoftware.Netrunner.Core.SocketIO.Packets
{
    public abstract class Packet
    {
        public enum Type
        {
            Connect,
            Disconnect,
            Event,
            Ack,
            Error,
            BinaryEvent,
            BinaryAck
        }

        public abstract Type PacketType { get; }
    }
}

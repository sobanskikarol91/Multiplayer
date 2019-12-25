public enum ServerPackets
{
    SWelcomeMessage = 1
}

public class DataSender  
{
    public static void SendWelcomeMessage(int connectionID)
    {
        ByteBuffer buffer = new ByteBuffer();
        buffer.WriteInteger((int)ServerPackets.SWelcomeMessage);
        ClientManager.SendDataTo(connectionID, buffer.ToArray());
        buffer.Dispose();
    }
}
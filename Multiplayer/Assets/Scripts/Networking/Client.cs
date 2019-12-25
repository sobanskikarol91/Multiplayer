using System;
using System.Net.Sockets;

public class Client  
{
    public int connectionID;
    public TcpClient socket;
    public NetworkStream stream;
    private byte[] reciveBuffer;
    public ByteBuffer buffer;

    private int bufferSize = 4096;

    public void Start()
    {
        socket.SendBufferSize = bufferSize;
        socket.ReceiveBufferSize = bufferSize;
        stream = socket.GetStream();
        stream.BeginRead(reciveBuffer, 0, socket.ReceiveBufferSize, OnReceiveData, null);
        Console.WriteLine($"Incoming connection from {socket.Client.RemoteEndPoint.ToString()}");

    }

    private void OnReceiveData(IAsyncResult result)
    {
        try
        {
            int length = stream.EndRead(result);

            if (length <=0)
            {
                CloseConnection();
                return;
            }

            byte[] newBytes = new byte[length];
            Array.Copy(reciveBuffer, newBytes, length);
            ServerHandleData.HandleDate(connectionID, newBytes);
            stream.BeginRead(reciveBuffer, 0, socket.ReceiveBufferSize, OnReceiveData, null);
        }
        catch (Exception)
        {
            CloseConnection();
            return;
        }
    }

    private void CloseConnection()
    {
        Console.WriteLine($"Connection from {socket.Client.RemoteEndPoint.ToString()} has been terminated");
        socket.Close();
    }
}
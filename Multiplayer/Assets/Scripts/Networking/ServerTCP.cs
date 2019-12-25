using System;
using System.Net;
using System.Net.Sockets;


public class ServerTCP 
{
    static TcpListener serverSocket = new TcpListener(IPAddress.Any, 5557);

    public static void InitializeNetwork()
    {
        Console.WriteLine("Initializin Packets...");
        ServerHandleData.InitializePackets();
        serverSocket.Start();
        serverSocket.BeginAcceptSocket(new AsyncCallback(OnClientConnect), null);
    }

    private static void OnClientConnect(IAsyncResult result)
    {
        TcpClient client = serverSocket.EndAcceptTcpClient(result);
        serverSocket.BeginAcceptSocket(new AsyncCallback(OnClientConnect), null);
        ClientManager.CreateNewConnection(client);
    }
}
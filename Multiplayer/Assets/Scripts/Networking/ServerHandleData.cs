using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

static class ServerHandleData
{
    public delegate void Packet(int connectionId, byte[] data);
    public static Dictionary<int, Packet> packets = new Dictionary<int, Packet>();

    public static void InitializePackets()
    {
        packets.Add((int)ClientPackets.CHelloServer, DataReceiver.HandleHelloServer);
    }

    public static void HandleDate(int connectionID, byte[] data)
    {
        byte[] buffer = (byte[])data.Clone();
        int packetLength = 0;

        ByteBuffer clientBuffer = ClientManager.client[connectionID].buffer;

        if (clientBuffer == null)
            clientBuffer = new ByteBuffer();

        clientBuffer.WriteBytes(buffer);

        if (clientBuffer.IsEmpty)
        {
            clientBuffer.Clear();
            return;
        }

        if (clientBuffer.Length >= 4)
        {
            packetLength = clientBuffer.ReadInteger(false);

            if(packetLength <=0)
            {
                clientBuffer.Clear();
                return;
            }
        }

        while (packetLength > 0 & packetLength <= buffer.Length - 4)
        {
            clientBuffer.ReadInteger();
            data = clientBuffer.ReadBytes(packetLength);
            HandleDataPackets(connectionID, data);

            packetLength = 0;

            if (clientBuffer.Length >= 4)
            {
                packetLength = clientBuffer.ReadInteger(false);

                if (packetLength <= 0)
                {
                    clientBuffer.Clear();
                    return;
                }
            }
        }

        if(packetLength <= 1)
        {
            clientBuffer.Clear();
        }
    }

    private static void HandleDataPackets(int connectionID, byte[] data)
    {
        ByteBuffer buffer = new ByteBuffer();
        buffer.WriteBytes(data);
        int packetID = buffer.ReadInteger();
        buffer.Dispose();

        if(packets.TryGetValue(packetID, out Packet packet))
        {
            packet.Invoke(connectionID, data);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum ClientPackets
{
    CHelloServer = 1,
}

public class DataReceiver : MonoBehaviour
{
    public static void HandleHelloServer(int connectionID, byte[] data)
    {
        ByteBuffer buffer = new ByteBuffer();
        buffer.WriteBytes(data);
        int packetI = buffer.ReadInteger();
        string msg = buffer.ReadString();
        buffer.Dispose();
        Console.WriteLine(msg);
    }
}
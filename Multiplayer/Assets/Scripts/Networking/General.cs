using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class General : MonoBehaviour 
{
    public static void InitializeServer()
    {
        ServerTCP.InitializeNetwork();
        Console.WriteLine("Server has been started");
    }
}
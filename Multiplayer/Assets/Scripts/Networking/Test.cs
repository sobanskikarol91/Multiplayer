using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Test : MonoBehaviour
{
    void Awake()
    {
        General.InitializeServer();
        Console.WriteLine();
    }
}
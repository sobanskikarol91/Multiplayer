using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameSetupController : MonoBehaviour 
{
    public static GameSetupController instance;

    public Transform[] spawnPoints;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
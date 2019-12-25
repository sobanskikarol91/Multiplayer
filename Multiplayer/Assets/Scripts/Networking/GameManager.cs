using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Photon.Pun;
using System.IO;

public class GameManager : MonoBehaviour 
{
    private void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Debug.Log("Create Player");
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "PhotonNetworkPlayer"), Vector3.zero, Quaternion.identity);
    }
}
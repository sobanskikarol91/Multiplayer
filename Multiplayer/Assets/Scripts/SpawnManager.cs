using UnityEngine;
using Photon.Pun;
using System.IO;


public class SpawnManager : MonoBehaviour 
{
    public Transform[] spawnPoints;


    public void CreatePlayer()
    {
        Debug.Log("Create Player");
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "PhotonNetworkPlayer"), Vector3.zero, Quaternion.identity);
    }
}
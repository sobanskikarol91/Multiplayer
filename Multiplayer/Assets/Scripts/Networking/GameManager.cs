using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;

    public Transform[] spawnPoints;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

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
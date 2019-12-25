using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameSetupController : MonoBehaviour 
{
    private void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Debug.Log("Create Player");
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player"), Vector3.zero, Quaternion.identity);
    }
}
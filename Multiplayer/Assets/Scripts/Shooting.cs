using UnityEngine;
using Photon.Pun;
using System.IO;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] PhotonView view;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (view.IsMine && Input.GetMouseButtonDown(0))
        {
            PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Rocket"), spawnPoint.position, Quaternion.identity);
        }
    }
}
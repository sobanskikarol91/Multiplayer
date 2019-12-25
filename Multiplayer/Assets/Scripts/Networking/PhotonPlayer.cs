using UnityEngine;
using Photon.Pun;
using System.IO;

public class PhotonPlayer : MonoBehaviour
{
    public GameObject myAvatar;

    private PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        int spawnPicker = Random.Range(0, GameSetupController.instance.spawnPoints.Length);

        Vector2 position = GameSetupController.instance.spawnPoints[spawnPicker].position;

        if (view.IsMine)
        {
            Debug.Log("Spawn");
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player"), position, Quaternion.identity);
        }
    }
}
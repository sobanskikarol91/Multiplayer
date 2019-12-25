using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] Button startButton;

    [SerializeField] Button cancelButton;
    [SerializeField] byte roomSize = 2;

    private int createdRoomsNr = 0;


    private void Awake()
    {
        startButton.onClick.AddListener(QuickStart);
        cancelButton.onClick.AddListener(QuickCancel);
    }

    private void QuickStart()
    {
        startButton.gameObject.SetActive(false);
        cancelButton.gameObject.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    private void QuickCancel()
    {
        cancelButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        startButton.gameObject.SetActive(true);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a room");
        CreateRoom();
    }

    private void CreateRoom()
    {
        Debug.Log("Creating new room");
        RoomOptions options = new RoomOptions() {IsVisible = true, IsOpen = true, MaxPlayers = roomSize};
        PhotonNetwork.CreateRoom("Room" + createdRoomsNr);
        createdRoomsNr++; 

    }
}
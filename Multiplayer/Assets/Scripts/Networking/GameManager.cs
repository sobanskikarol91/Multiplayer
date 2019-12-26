using UnityEngine;


public class GameManager : MonoBehaviour 
{
    public static GameManager instance;

    public Transform[] spawnPoints;

    SpawnManager spawnManager;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        spawnManager = GetComponent<SpawnManager>();
    }

    private void Start()
    {
        spawnManager.CreatePlayer();
    }
}
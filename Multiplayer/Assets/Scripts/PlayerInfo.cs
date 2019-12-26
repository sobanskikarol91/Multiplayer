using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;
    public int selectedCharacter;
    public GameObject[] allCharacters;

    private string myCharacterName = "MyCharacter";
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(myCharacterName))
        {
            selectedCharacter = PlayerPrefs.GetInt(myCharacterName);
        }
        else
        {
            selectedCharacter = 0;
            PlayerPrefs.SetInt(myCharacterName, selectedCharacter);
        }
    }
}
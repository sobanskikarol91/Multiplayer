using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MenuController : MonoBehaviour
{
    public void OnClickCharacterPick(int whichCharacter)
    {
        if(PlayerInfo.instance != null)
        {
            PlayerInfo.instance.selectedCharacter = whichCharacter;
            PlayerPrefs.SetInt("MyCharacter", whichCharacter);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChatBox : MonoBehaviour
{
    public GameObject[] prefabsChatBox;
    public GameObject conatinerChatBox;

    public void OnGenerateChatBox(string speakerName)
    {
        //check if dialogue is player use prefabs[0]
        if (speakerName == "player")
        {

        }
        //if not player use prefabs[1]
        else
        {

        }
    }
}

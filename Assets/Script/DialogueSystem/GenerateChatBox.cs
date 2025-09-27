using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenerateChatBox : MonoBehaviour
{
    public GameObject[] prefabsChatBox;
    public Transform conatinerChatBox;

    public void OnGenerateChatBox(string speakerName, string dialogue)
    {
        //check if dialogueLine is player or not
        GameObject preafabtoSpawn = (speakerName == "Player") ?
            prefabsChatBox[0] : prefabsChatBox[1];
       
       //Spawn chatbox in area
       GameObject newChatBox = Instantiate(preafabtoSpawn, conatinerChatBox);

        // (Optional) If you have a name field in the prefab, set it too
        ChatBoxUI chatUI = newChatBox.GetComponent<ChatBoxUI>();
        if (chatUI != null)
        {
            chatUI.SetChatBox(dialogue);
        }
    }
}

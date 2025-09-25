using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public static ChatManager instance;

    [Header("Status MassagerApplication")]
    [SerializeField] private bool isOpenChat;
    [SerializeField] private string currentContactID;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetOpenChat(string contactID)
    {
        if (!isOpenChat)
        {
            currentContactID = contactID;
        }

    }

    public void SetCloseChat()
    {
        if (isOpenChat)
        {
            if (currentContactID != null)
            {

            }
            isOpenChat = false;
        }
            
    }
}

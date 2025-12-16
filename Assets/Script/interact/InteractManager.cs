using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    [Header("Area Interact")]
    [SerializeField] private GameObject bathRoom;
    [SerializeField] private GameObject makeUp;

    public static InteractManager instance;

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

    public void ActiveInteract()
    {
        Debug.Log("Get Called");
        string name = QuestManager.instance.GetCurrentQuest().questID.Split('-')[0].ToLower();

        switch (name)
        {
            case "amu":
                makeUp.SetActive(true);
                break;

            case "btr":
                bathRoom.SetActive(true);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    public QuestSO quest;

    public void interact()
    {
        QuestManager.instance.GetCheckQuest(quest.questID, true);
        Debug.Log($"there to use {gameObject.name}");
    }
}

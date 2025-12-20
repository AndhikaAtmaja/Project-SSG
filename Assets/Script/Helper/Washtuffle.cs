using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washtuffle : MonoBehaviour, IInteractable
{
    public void interact()
    {
       ToothBurshManager.instance.ActivedMiniGame();
    }
}

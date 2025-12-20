using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToothBrush : MonoBehaviour
{
    public void OnClick()
    {
        ToothBurshManager.instance.DeactiveMiniGame();
    }
}

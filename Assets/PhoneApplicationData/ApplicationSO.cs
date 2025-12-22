using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = ("ApplicationSO"), fileName = "NewApplicationData")]
public class ApplicationSO : ScriptableObject
{
    public Sprite ApplicationIcon;
    public string ApplicationName;
}

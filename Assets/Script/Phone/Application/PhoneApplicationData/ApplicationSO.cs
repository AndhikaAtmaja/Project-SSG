using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = ("ApplicationSO"), fileName = "NewApplicationData")]
public class ApplicationSO : ScriptableObject
{
    public Image ApplicationIcon;
    public string ApplicationName;
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommentUI : MonoBehaviour
{
    [SerializeField] private Image photoProfile;
    [SerializeField] private TextMeshProUGUI nameProfileUI;
    [SerializeField] private TextMeshProUGUI commentProfileUI;


    public void SetComment(string nameProfile, string comment)
    {
        nameProfileUI.text = nameProfile;
        commentProfileUI.text = comment;
    }
}

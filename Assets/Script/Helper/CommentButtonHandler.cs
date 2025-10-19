using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject commentSection;
   public void OnOpenCommentSection()
    {
        commentSection.SetActive(CommentManager.Instance.OpeningCommentSection());
    }
}

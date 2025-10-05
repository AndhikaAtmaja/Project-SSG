using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject commentSection;
    [SerializeField] private ScrollRect mainScroll;
    private bool isCommentOpen;

    public void OnToggleComment()
    {
        isCommentOpen = !isCommentOpen;

        if (mainScroll != null)
            mainScroll.enabled = isCommentOpen;

        if (commentSection != null)
            commentSection.SetActive(isCommentOpen);
    }

}

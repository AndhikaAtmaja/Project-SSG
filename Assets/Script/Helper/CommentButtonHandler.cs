using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject commentSection;
    [SerializeField] private ScrollRect mainScroll;
    [SerializeField] private bool isCommentOpen;

    private void Start()
    {
        if (mainScroll == null)
        {
            mainScroll = GameObject.FindWithTag("MainScroll").GetComponent<ScrollRect>();
        }
    }

    public void OnToggleComment()
    {
        isCommentOpen = !isCommentOpen;

        if (mainScroll != null)
            mainScroll.enabled = !isCommentOpen;

        if (commentSection != null)
            commentSection.SetActive(isCommentOpen);
    }

}

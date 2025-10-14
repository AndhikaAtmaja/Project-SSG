using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentButtonHandler : MonoBehaviour
{
   public void OnOpenCommentSection()
    {
        CommentManager.Instance.OpeningCommentSection();
    }
}

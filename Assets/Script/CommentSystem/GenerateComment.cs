using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateComment : MonoBehaviour
{
    [SerializeField] private GameObject _prefabsComment;
    [SerializeField] private Transform _commentContainer;
/*
    public void onPlayerGenerateComment(string commentLine)
    {
        GameObject newComment = Instantiate(_prefabsComment, _commentContainer);

        if (newComment != null)
        {
            CommentUI commentProfileUI = newComment.GetComponent<CommentUI>();
            if (commentProfileUI != null)
            {
                commentProfileUI.SetComment();
            }
        }
    }
*/
    public void OnRandomPeapolGenerateComment(string name, string comment)
    {
        GameObject newComment = Instantiate(_prefabsComment, _commentContainer);

        if (newComment != null)
        {
            CommentUI commentUI = newComment.GetComponent<CommentUI>();
            if (commentUI != null)
            {
                commentUI.SetComment(name, comment);
            }
        }
    }
}

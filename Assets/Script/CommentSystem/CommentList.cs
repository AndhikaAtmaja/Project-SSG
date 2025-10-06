using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CommentList : MonoBehaviour
{
    [SerializeField] private List<CommentSO> comments = new List<CommentSO>();
    [SerializeField] private string DataComment;

    private void Start()
    {
        ReadCommentData();
    }

    public void ReadCommentData()
    {
         string dataCommentPath = "DataComments";

        CommentSO[] loadedComments = Resources.LoadAll<CommentSO>(dataCommentPath);

        comments.Clear();
        comments.AddRange(loadedComments);

        Debug.Log($"Loaded {comments.Count} comments!");
        /*foreach (CommentSO comment in loadedComments)
        {
            Debug.Log($"{comment.nameCommenter}: {comment.commentLine}"); 
        }*/

    }

    public List<CommentSO> GetCommentDatas()
    {
        return comments;
    }
}

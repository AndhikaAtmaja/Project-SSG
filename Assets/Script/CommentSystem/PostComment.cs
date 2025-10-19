using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostComment : MonoBehaviour
{
    [SerializeField] private GenerateComment _generateComment;

    [Header("Config comment amount in the post")]
    [SerializeField] private int minComments = 1;
    [SerializeField] private int maxComments = 4;

    [SerializeField] private List<CommentSO> myComments = new List<CommentSO>();

    // Start is called before the first frame update
    void Start()
    {
        CommentManager.Instance.GenerateCommentsForPost(this);
    }

    public void SetComments(List<CommentSO> comments)
    {
        myComments = comments;
        foreach (var comment in myComments)
        {
            {
                _generateComment.OnRandomPeapolGenerateComment(comment.nameCommenter, comment.NeutralComment);
            }
        }
    }

    public (int, int) GetCommentRange()
    {
        return (minComments, maxComments);
    }
}

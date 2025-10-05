using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CommentManager : MonoBehaviour
{
    public static CommentManager Instance;

    [SerializeField] private CommentList _commentList;
    [SerializeField] private GenerateComment _generateComment;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGenerateComment()
    {
        List<CommentSO> comments = _commentList.GetCommentDatas();

        for (int i = 0; i < comments.Count; i++)
        {
            _generateComment.OnRandomPeapolGenerateComment(comments[i].nameCommenter, comments[i].commentLine);
        }
    }
}

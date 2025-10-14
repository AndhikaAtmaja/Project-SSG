using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CommentManager : MonoBehaviour
{
    public static CommentManager Instance;

    [Header("Status")]
    [SerializeField] private bool isCommentSectionOpen;

    [Header("Refencese")]
    [SerializeField] private GameObject commentSection;
    [SerializeField] private CommentList _commentList;
    [SerializeField] private List<GenerateComment> _generateComment;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public void OpeningCommentSection()
    {
        isCommentSectionOpen = !isCommentSectionOpen;

        commentSection.SetActive(isCommentSectionOpen);
    }

    public void GenerateCommentsForPost(PostComment post)
    {
        List<CommentSO> AllComments = _commentList.GetCommentDatas();

        if (AllComments.Count == 0)
        {
            Debug.LogWarning("WARNING There are no AllComments loaded!");
            return; 
        }

        (int min, int max) = post.GetCommentRange();
        int commentCount = Random.Range(min, max);

        List<CommentSO> shuffled = new List<CommentSO>(AllComments);
        for (int i = 0; i < shuffled.Count; i++)
        {
            CommentSO tempComment = shuffled[i];
            int randomIndex = Random.Range(i, shuffled.Count);
            shuffled[i] = shuffled[randomIndex];
            shuffled[randomIndex] = tempComment;
        }

        // Take only some
        List<CommentSO> selected = shuffled.GetRange(0, Mathf.Min(commentCount, shuffled.Count));

        // Send to the post
        post.SetComments(selected);
    }
}

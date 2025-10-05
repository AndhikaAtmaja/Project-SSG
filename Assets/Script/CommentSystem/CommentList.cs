using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
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
        string gameFolder = Application.dataPath + "/Script/AI";
        string commentFolderPath = Path.Combine(gameFolder, DataComment);

        if (!Directory.Exists(commentFolderPath)){
            Debug.LogWarning("Folder does not exist: " + commentFolderPath);
            return;
        }

        CommentSO[] loadedComments = Resources.LoadAll<CommentSO>(commentFolderPath);

        if (loadedComments.Length == 0)
        {
            Debug.Log("No screenshots found!");
            return;
        }

        comments.Clear();
        comments.AddRange(loadedComments);
    }

    public List<CommentSO> GetCommentDatas()
    {
        return comments;
    }
}

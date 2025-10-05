using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CommentSO")]
public class CommentSO : ScriptableObject
{
    public string nameCommenter;
    [TextArea(5, 10)] public string commentLine;
}

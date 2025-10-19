using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeGeneration
{
    Human,
    AI
}

[CreateAssetMenu(menuName = "CommentSO")]
public class CommentSO : ScriptableObject
{
    public string nameCommenter;
    public TypeGeneration typeGenerate;

    [TextArea(5, 10)] public string PostiveComment;

    [TextArea(5, 10)] public string NeutralComment;

    [TextArea(5, 10)] public string NegativeComment;

}

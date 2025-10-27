using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharacterEmotion : MonoBehaviour
{
    [SerializeField] private Image emotionImage;
    [SerializeField] private emotionSO[] emotions;
    [SerializeField] private float timerToShowEmotion;

    [SerializeField] private bool isEmotioning;

    private void Start()
    {
        HideEmotion();
    }

    public void ShowEmotion(string emotion)
    {
        if (emotionImage == null)
            return;

        for (int i = 0; i < emotions.Length; i++)
        {
            if (emotions[i].emotionName == emotion)
            {
                isEmotioning = !isEmotioning;
                gameObject.SetActive(isEmotioning);
                emotionImage.sprite = emotions[i].emotionSprite;
                StartCoroutine(TimmerToHideEmotion());
            }
                
            else
            {
                Debug.Log($"there are no emotions with that name '{emotion}' in the game data!");
                break;
            }
        }
    }

    public void HideEmotion()
    {
        isEmotioning = false;
        gameObject.SetActive(false);
    }

    IEnumerator TimmerToHideEmotion()
    {
        yield return new WaitForSeconds(timerToShowEmotion);
        HideEmotion();
    }
}

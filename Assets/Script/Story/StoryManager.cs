using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager instance;

    [Header("Story Progress")]
    [SerializeField] private List<StoryChapterSO> allChapters;
    [SerializeField] private StoryChapterSO currStoryChapter;
    private int ChapterIndex;
    private int StepIndex;

    [Header("Refences")]
    [SerializeField] private QuestList _questList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //start from chpater 0 or from save file
    public void StartChapter()
    {

    }

    public StoryStep currentStep => allChapters[ChapterIndex].chapterSteps[StepIndex];

    public void SelectedChapter(string chapterName)
    {
        currStoryChapter = allChapters[ChapterIndex];

        if (allChapters == null || allChapters.Count == 0)
        {
            Debug.LogWarning("No allChapters assigned!");
            return;
        }

        if (ChapterIndex < 0)
        {
            Debug.LogError("Chapter not found: " + chapterName);
            return;
        }

        StepIndex = 0;
        LoadCurrentStep();
    }

    private void LoadCurrentStep()
    {
        StoryStep step = currentStep;

        //Debug.Log($"Total Step is {allChapters[ChapterIndex].chapterSteps.Count}");
        //Debug.Log($"Total Quest of {step.nameStep} is {step.quests.Count}");

        if (currentStep.quests.Count > 0)
            QuestManager.instance.FillQuest(step.quests);

        if (currentStep.dialogues.Count > 0)
            DialogueManager.instance.ChangeCurrentDialogue(step.dialogues[0]);
    }

    public void CheckChapter()
    {
        if (currStoryChapter != null)
        {
            StoryStep step = currentStep;

            step.QuestChecker();
            step.DialogueChecker();

            if (step.GetAllQuestDone() && step.GetAllDialogueDone())
            {
                NextStep();
            }
        }
    }

    private void NextStep()
    {
        Debug.Log($"Proceed to next step");

        StoryChapterSO chapter = allChapters[ChapterIndex];

        StepIndex++;
        //Debug.Log($"name step {allChapters[ChapterIndex].chapterSteps[StepIndex].nameStep}");
        
        // If still inside this chapter
        if (StepIndex < chapter.chapterSteps.Count)
        {
            LoadCurrentStep();
            return;
        }

        // If last step, move chapter
        //NextChapter();
    }

/*    private void NextChapter()
    {
        Debug.Log("Proceed to next NextChapter");

        ChapterIndex++;

        if (ChapterIndex >= allChapters.Count)
        {
            Debug.Log("All Chapters Complete! Story Finished.");
            return;
        }

        StepIndex = 0;
        LoadCurrentStep();
    }*/
}

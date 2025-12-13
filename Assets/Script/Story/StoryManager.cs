using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager instance;

    [Header("Story Progress")]
    [SerializeField] private List<StoryChapterSO> allChapters;
    [SerializeField] private StoryChapterSO currStoryChapter;
    [SerializeField] private int ChapterIndex;
    [SerializeField] private int StepIndex;
    private bool isTransitioning;

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

   
    public void StartChapter()
    {
        //start from chpater 0 or from save file
        ChapterIndex = 0;
        StepIndex = 0;
        currStoryChapter = allChapters[ChapterIndex];
        LoadCurrentStep();
    }

    public StoryStep currentStep => allChapters[ChapterIndex].chapterSteps[StepIndex];

    public void SelectedChapter(string chapterName)
    {
        if (allChapters == null || allChapters.Count == 0)
        {
            Debug.LogWarning("No allChapters assigned!");
            return;
        }

        string find = chapterName.ToLower();
        currStoryChapter = null;

        for (int i = 0; i < allChapters.Count; i++)
        {
            if (allChapters[i].nameChapter.ToLower() == find)
            {
                ChapterIndex = i;
                currStoryChapter = allChapters[ChapterIndex];
                break;    // STOP searching when found
            }
        }

        if (currStoryChapter == null)
        {
            Debug.LogError("Chapter not found: " + chapterName);
            return;
        }

        // Success load step 0
        StepIndex = 0;
        LoadCurrentStep();
    }

    private void LoadCurrentStep()
    {
        StoryStep step = currentStep;

        Debug.Log($"current Step is {currentStep.nameStep}");
        //Debug.Log($"Total Quest of {step.nameStep} is {step.quests.Count}");

        if (currentStep.dialogues.Count > 0)
        {
            //Debug.Log("Get Called");
            DialogueManager.instance.ChangeCurrentDialogue(step.dialogues[0]);
        }
        else
        {
            Debug.Log("No dialogues in step!");
        }

        if (currentStep.quests.Count > 0)
        {
            //Debug.Log("Get Called");
            QuestManager.instance.FillQuest(step.quests);
        }
    }

    public void CheckChapter()
    {
        if (isTransitioning) return;
        if (currStoryChapter == null) return;

        StoryStep step = currentStep;
        if (step == null) return;

        step.QuestChecker();
        step.DialogueChecker();

        if (step.GetAllQuestDone() && step.GetAllDialogueDone())
        {
            NextStep();
        }
    }

    private void NextStep()
    {
        //Debug.Log($"Proceed to next step");
        if (isTransitioning) return;

        StoryChapterSO chapter = allChapters[ChapterIndex];
        StepIndex++;

        //Debug.Log($"name step {allChapters[ChapterIndex].chapterSteps[StepIndex].nameStep}");
        
        // If still inside this chapter
        if (StepIndex >= chapter.chapterSteps.Count)
        {
            Debug.Log("Chapter finished!");
            return;
        }

        LoadCurrentStep();
        // If last step, move chapter
        //NextChapter();
    }

    public void LockStory()
    {
        isTransitioning = true;
    }

    private void OnEnable()
    {
        DialogueManager.OnDialogueFinished += OnDialogueFinished;
    }

    private void OnDisable()
    {
        DialogueManager.OnDialogueFinished -= OnDialogueFinished;
    }

    private void OnDialogueFinished()
    {
        if (isTransitioning) return;
        if (currentStep.autoStartDialogueAfterScene)
            CheckChapter();
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

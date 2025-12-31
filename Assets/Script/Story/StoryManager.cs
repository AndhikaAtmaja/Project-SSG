using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StoryGameSaveData
{
    public int chapterIndex;
    public int stepID;
}

public class StoryManager : MonoBehaviour
{
    public static StoryManager instance;

    [Header("Story Progress")]
    [SerializeField] private List<StoryChapterSO> allChapters;
    [SerializeField] private StoryChapterSO _currentStoryChapter;
    [SerializeField] private int _chapterIndex;
    [SerializeField] private int _stepIndex;
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

    private void Start()
    {
        StartChapter();
    }

    public void StartChapter()
    {
        //start from chpater 0 or from save file
        _chapterIndex = 0;
        _stepIndex = 0;
        _currentStoryChapter = allChapters[_chapterIndex];
        LoadCurrentStep();
    }

    public void Save(ref StoryGameSaveData data)
    {
        data.chapterIndex = _chapterIndex;
        data.stepID       = _stepIndex;
    }

    public void Load(StoryGameSaveData data)
    {
        Debug.Log("Get called!");
        if (data.chapterIndex < 0)
        {
            StartChapter();
        }
        else if (data.chapterIndex >= 0)
        {
            _chapterIndex = data.chapterIndex;
            _stepIndex = data.stepID;

            LoadCurrentStep();
        }
    }

    public StoryStep currentStep => allChapters[_chapterIndex].chapterSteps[_stepIndex];

    public void SelectedChapter(string chapterName)
    {
        if (allChapters == null || allChapters.Count == 0)
        {
            Debug.LogWarning("No allChapters assigned!");
            return;
        }

        string find = chapterName.ToLower();
        _currentStoryChapter = null;

        for (int i = 0; i < allChapters.Count; i++)
        {
            if (allChapters[i].nameChapter.ToLower() == find)
            {
                _chapterIndex = i;
                _currentStoryChapter = allChapters[_chapterIndex];
                break;    // STOP searching when found
            }
        }

        if (_currentStoryChapter == null)
        {
            Debug.LogError("Chapter not found: " + chapterName);
            return;
        }

        // Success load step 0
        _stepIndex = 0;
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

        if (currentStep.quests.Count > 0)
        {
            //Debug.Log("Get Called");
            QuestManager.instance.FillQuest(step.quests);
        }

        if (currentStep.nextChapter != null)
        {
            NextChapter();
        }

        if (currentStep.musicTrack != null)
        {
            PlayMusic();
        }

        if (currentStep.soundEffect != null)
        {
            PlaySound();
        }

        if (currentStep.nextSceneName != null)
        {
            ChangeScene();
        }

        //QuestManager.instance.HighlightArea();
    }

    public void CheckChapter()
    {
        if (isTransitioning) return;
        if (_currentStoryChapter == null) return;

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

        StoryChapterSO chapter = allChapters[_chapterIndex];
        _stepIndex++;

        //Debug.Log($"name step {allChapters[_chapterIndex].chapterSteps[_stepIndex].nameStep}");

        if (_stepIndex >= chapter.chapterSteps.Count)
        {
            chapter.isChapterDone = true;
        }

        // If still inside this chapter
        if (_stepIndex >= chapter.chapterSteps.Count)
        {
            Debug.Log("Chapter finished!");
            chapter.isChapterDone = true;
            //return;
        }

        LoadCurrentStep();
        // If last step, move chapter
        //NextChapter();
    }

    private void NextChapter()
    {
        Debug.Log("get Called");

        if (currentStep.nextChapter != null)
        {
            //find chapter in the data 
            bool found = false;

            if (found == false)
            {
                for (int i = 0; i < allChapters.Count; i++)
                {
                    if (allChapters[i].nameChapter.ToLower() == currentStep.nextChapter.nameChapter.ToLower())
                    {
                        //set the chapter with this
                        _currentStoryChapter = allChapters[i];
                        _chapterIndex = i;
                        _stepIndex = 0;
                        LoadCurrentStep();
                    }
                }
            }

        }
    }

    public void LockStory()
    {
        isTransitioning = true;
    }

    private void PlaySound()
    {
        string soundFX = currentStep.soundEffect;

        if (string.IsNullOrEmpty(soundFX))
            return;

        SoundManager.instance.PlaySoundFXOneClip(soundFX);
    }

    private void PlayMusic()
    {
        string musicTrack = currentStep.musicTrack;

        if (string.IsNullOrEmpty(musicTrack))
            return;

        MusicManager.instance.PlayMusic(musicTrack);
    }

    private void ChangeScene()
    {
        string scene = currentStep.nextSceneName;

        if (string.IsNullOrEmpty(scene))
            return;

        SceneManagement.instance.OnChangeScene(currentStep.nextSceneName, "");
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
        CheckChapter();
    }
}

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

    [Header("Config ")]
    public bool isAutoStartPlayEnable;

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
        if (isAutoStartPlayEnable)
        {
            ResetAllStoryProgress();
            StartChapter();
        }
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
        //Debug.Log("Get called!");
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
        Debug.Log($"current Step is {currentStep.nameStep}");
        //Debug.Log($"Total Quest of {step.nameStep} is {step.quests.Count}");

        if (currentStep.nameStep.ToLower() == "ending")
            EndStory();

        if (currentStep.dialogues.Count > 0)
        {
            //Debug.Log("Get Called");
            DialogueManager.instance.ChangeCurrentDialogue(currentStep.dialogues[0]);
        }

        if (currentStep.quests.Count > 0)
        {
            //Debug.Log("Get Called");
            QuestManager.instance.FillQuest(currentStep.quests);
        }

        if (currentStep.musicTrack != null)
        {
            PlayMusic();
        }

        if (currentStep.soundEffect != null)
        {
            PlaySound();
        }

        if (currentStep.nextChapter != null)
        {
            ChangeChapterbyStep();
        }

        if (currentStep.nextSceneName != null)
        {
            ChangeScene();
        }

        if (PhoneManager.Instance != null)
        {
            PhoneManager.Instance.UpdateListChapter();
            PhoneManager.Instance.UpdateContactMassage();
        }

        QuestManager.instance.ShowQuets();
    }

    private void EndStory()
    {
        FinishChapter();
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
        StoryChapterSO chapter = allChapters[_chapterIndex];
        _stepIndex++;

        // If still inside this chapter
        if (_stepIndex >= _currentStoryChapter.chapterSteps.Count)
        {
            FinishChapter();
            return;
        }
 
        LoadCurrentStep();
    }

    private void ChangeChapterbyStep()
    {
        Debug.Log("get Called");
        if (currentStep.nextChapter != null)
        {
            for (int i = 0; i < allChapters.Count; i++)
            {
                if (currentStep.nextChapter.name.ToLower() == allChapters[i].name.ToLower())
                {
                    //set the chapter with this
                    _currentStoryChapter = allChapters[i];
                    _chapterIndex = i;
                    _stepIndex = 0;
                    GameManager.instance.ResetAllGameStatus();
                    LoadCurrentStep();
                }
            }
        }
    }

    private void FinishChapter()
    {
        StoryChapterSO chapter = allChapters[_chapterIndex];
        Debug.Log("Chapter finished!");

        StoryStep step = currentStep;
        if (step == null) return;

        step.QuestChecker();
        step.DialogueChecker();

        chapter.isChapterDone = true;
    }

    public void ResetAllStoryProgress()
    {
        _chapterIndex = -1;
        _stepIndex = -1;
        foreach(StoryChapterSO chapter in allChapters)
        {
            for(int i = 0; i < chapter.chapterSteps.Count; i++)
            {
                chapter.chapterSteps[i].ResetStoryProgress();
            }
            chapter.isChapterDone = false;
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

        if (currentStep.isSoundEffectLoop)
        {
            Debug.Log("Sound Effect Loop Get Called");
            SoundManager.instance.PlayLoopSoundEffect(soundFX);
        }
        else
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
        string transition = currentStep.transition;

        if (string.IsNullOrEmpty(scene))
            return;

        SceneManagement.instance.OnChangeScene(currentStep.nextSceneName, "", transition);
    }

    public StoryChapterSO GetCurrentStroy()
    {
        return _currentStoryChapter;
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

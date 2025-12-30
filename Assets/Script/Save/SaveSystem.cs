using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    private static GameSaveData _saveData = new GameSaveData();

    [System.Serializable]
    public struct GameSaveData
    {
        //last scene
        public SceneGameSaveData sceneData;

        //Story chapter (Last chpater name, chapterID, ChapterStepID)
        public StoryGameSaveData storyData;

        //Game Status
    }  

    public static string SaveFileName()
    {
        string saveFile = Application.persistentDataPath + "/GameData" + ".save";
        Debug.Log("Name file" + saveFile);
        return saveFile;
    }

    public static void Save()
    {
        HandelSaveData();

        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_saveData, true));
    }

    public static void HandelSaveData()
    {
        SceneManagement.instance.Save(ref _saveData.sceneData);
        StoryManager.instance.Save(ref _saveData.storyData);
    }

    public static void Load()
    {
        string saveData = File.ReadAllText(SaveFileName());
        _saveData = JsonUtility.FromJson<GameSaveData>(saveData);
        HandelLoadData();
    }

    public static void HandelLoadData()
    {
        SceneManagement.instance.Load(_saveData.sceneData);
        StoryManager.instance.Load(_saveData.storyData);
    }
}

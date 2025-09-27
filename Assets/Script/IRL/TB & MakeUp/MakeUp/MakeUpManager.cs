using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MakeUpManager : MonoBehaviour
{
    public static MakeUpManager instance;

    [SerializeField] private List<GameObject> MakeUpTools;
    [SerializeField] private int applyPlayer;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        Debug.Log($"{applyPlayer}/{MakeUpTools.Count}");

        if (applyPlayer >= MakeUpTools.Count)
        {
            DoneMakeUp();
        }
    }

    public void StartMakeUpMG()
    {
        Debug.Log($"Apply all make up to char");
        Debug.Log($"There {MakeUpTools.Count} need apply too the char");
    }
    
    public void DoneMakeUp()
    {
        SceneManagement.instance.OnChangeScene("Bedroom-2", "MakeUp");
        Cursor.visible = false;
    }

    public void AddApplyPlayer()
    {
        applyPlayer++;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLoadedScene;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLoadedScene;
    }

    private void OnLoadedScene(Scene scene, LoadSceneMode mode)
    {
        if (MakeUpTools == null)
            MakeUpTools = new List<GameObject>();

        MakeUpTools.Clear();

        GameObject[] tools = GameObject.FindGameObjectsWithTag("MakeUpTool");
        MakeUpTools.AddRange(tools);
        StartMakeUpMG();
    }
}

using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class PhoneData : MonoBehaviour
{
    [SerializeField] private string FolderPathCapture;
    [SerializeField] private GeneratePhotoBox generatePhotoBox;

    [SerializeField] private string screenshotFolder;

    private HashSet<string> loadedFiles = new HashSet<string>();

    private void Start()
    {
        screenshotFolder = Path.Combine(Application.dataPath, "Capture", FolderPathCapture);
        StartCoroutine(RefreshScreenshots());
    }

    public IEnumerator RefreshScreenshots()
    {
        if (!Directory.Exists(screenshotFolder))
        {
            Debug.LogWarning("Folder does not exist: " + screenshotFolder);
            yield break;
        }

        string[] files = Directory.GetFiles(screenshotFolder, "*.png");

        if (files.Length == 0)
        {
            Debug.Log("No screenshots found!");
            yield break;
        }

        foreach (string file in files)
        {
            //  Skip files that are already loaded
            if (loadedFiles.Contains(file))
                continue;

            bool loaded = false;

            for (int i = 0; i < 10 && !loaded; i++)
            {
                bool ioError = false;

                try
                {
                    byte[] imageData = File.ReadAllBytes(file);
                    Texture2D tex = new Texture2D(2, 2);
                    tex.LoadImage(imageData);
                    Sprite sprite = Sprite.Create(
                        tex,
                        new Rect(0, 0, tex.width, tex.height),
                        new Vector2(0.5f, 0.5f)
                    );

                    //  Pass the full file path
                    generatePhotoBox.OnGeneratePhotoBox(sprite, file);
                    //Debug.Log($"Loaded new screenshot: {file}");

                    //  Mark this file as loaded
                    loadedFiles.Add(file);
                    loaded = true;
                }
                catch (IOException)
                {
                    ioError = true;
                    Debug.LogWarning($"Retrying to read {Path.GetFileName(file)}...");
                }

                if (ioError)
                    yield return new WaitForSeconds(0.2f);
            }
        }
    }

    public void ReloadScreenshots()
    {
        StopAllCoroutines();
        StartCoroutine(RefreshScreenshots());
    }
}
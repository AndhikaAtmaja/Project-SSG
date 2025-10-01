using UnityEngine;
using System.IO;

public class PhoneData : MonoBehaviour
{
    [SerializeField] private string FilePathCapture;
    [SerializeField] private GeneratePhotoBox generatePhotoBox;

    public void GetCaputeData()
    {
        string gameFolder = Application.dataPath + "/Capture";
        string screenshotFolder = Path.Combine(gameFolder, FilePathCapture);

        //Read File
        if (!Directory.Exists(screenshotFolder))
        {
            Debug.LogWarning("Folder does not exist: " + screenshotFolder);
            return;
        }

        // get all PNG files in the folder
        string[] files = Directory.GetFiles(screenshotFolder, "*.png");

        if (files.Length == 0)
        {
            Debug.Log("No screenshots found!");
            return;
        }

        // loop through files
        foreach (string file in files)
        {
            Debug.Log("Found screenshot: " + file);

            byte[] imageData = File.ReadAllBytes(file);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(imageData);

            // Convert Texture2D -> Sprite
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));

            // Pass sprite to GeneratePhotoBox
            generatePhotoBox.OnGeneratePhotoBox(sprite);
        }
    }
}

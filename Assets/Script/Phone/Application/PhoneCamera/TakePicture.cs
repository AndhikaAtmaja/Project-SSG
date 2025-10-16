using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TakePicture : MonoBehaviour
{
    [SerializeField] private RectTransform captureArea;
    [SerializeField] private PhoneData _phoneData;
    public void OnTakePicture()
    {
        //Take screenshot inside Capture Area
        //The Save Picture
        StartCoroutine(CaptureScreenshot());
    }

    IEnumerator CaptureScreenshot()
    {
        yield return new WaitForEndOfFrame();

        // Get world corners of UI element
        Vector3[] worldCorners = new Vector3[4];
        captureArea.GetWorldCorners(worldCorners);

        // Convert to screen space
        Vector2 bottomLeft = RectTransformUtility.WorldToScreenPoint(Camera.main, worldCorners[0]);
        Vector2 topRight = RectTransformUtility.WorldToScreenPoint(Camera.main, worldCorners[2]);

        float x = bottomLeft.x;
        float y = bottomLeft.y;
        float width = topRight.x - bottomLeft.x;
        float height = topRight.y - bottomLeft.y;

        // Create texture & read pixels
        Texture2D tex = new Texture2D((int)width, (int)height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(x, y, width, height), 0, 0);
        tex.Apply();

        // Save to custom path
        string gameFolder = Application.dataPath + "/Capture";
        string screenshotFolder = Path.Combine(gameFolder, "Screenshots");

        // make sure folder exists
        if (!Directory.Exists(screenshotFolder))
            Directory.CreateDirectory(screenshotFolder);

        string path = Path.Combine(screenshotFolder, $"screenshot_{System.DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png");
        File.WriteAllBytes(path, tex.EncodeToPNG());

        Debug.Log("Saved screenshot to: " + path);
        Destroy(tex);
        Debug.Log("Succes Taking picture");

        _phoneData.ReloadScreenshots();
    }
}

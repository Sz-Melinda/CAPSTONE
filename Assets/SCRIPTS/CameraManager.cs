using UnityEngine;
using System.IO;
using System.Collections;

public class CameraMode : MonoBehaviour
{
    public GameObject cameraUI;       
    public GameObject gameUI;         
    public KeyCode toggleKey = KeyCode.C;
    public KeyCode photoKey = KeyCode.Space;
    public string screenshotFolder = "Screenshots";

    private bool cameraActive = false;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            cameraActive = !cameraActive;

            cameraUI.SetActive(cameraActive);
            gameUI.SetActive(!cameraActive);
        }

        if (cameraActive && Input.GetKeyDown(photoKey))
            StartCoroutine(TakePhoto());
    }

    IEnumerator TakePhoto()
    {
        cameraUI.SetActive(false);
        gameUI.SetActive(false);

        yield return new WaitForEndOfFrame(); 

        string folderPath = Path.Combine(Application.persistentDataPath, screenshotFolder);
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        string path = Path.Combine(folderPath,
            $"photo_{System.DateTime.Now:yyyyMMdd_HHmmss}.png");

        ScreenCapture.CaptureScreenshot(path);
        Debug.Log("Saved photo: " + path);

        yield return null; 

        if (cameraActive)
            cameraUI.SetActive(true);
        else
            gameUI.SetActive(true);
    }
}

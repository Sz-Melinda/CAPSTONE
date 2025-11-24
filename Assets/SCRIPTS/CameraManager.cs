using UnityEngine;
using System.IO;
using System.Collections;

public class CameraMode : MonoBehaviour
{
    public GameObject cameraUI;       
    public GameObject gameUI;         
    public KeyCode toggleKey = KeyCode.C;
    public KeyCode photoKey = KeyCode.Space;
    public string screenshotsFolder = "Screenshots";

    public AudioSource shutterSound;  

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
        if (shutterSound != null)
            shutterSound.Play();

        cameraUI.SetActive(false);
        gameUI.SetActive(false);

        string folderPath = Path.Combine(Application.persistentDataPath, screenshotsFolder);
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        string fileName = $"photo_{System.DateTime.Now:yyyyMMdd_HHmmss}.png";
        string path = Path.Combine(folderPath, fileName);

        ScreenCapture.CaptureScreenshot(path);
        Debug.Log("Saved photo: " + path);

        while (!File.Exists(path))
            yield return null;

        FindObjectOfType<NotebookGallery>()?.Refresh();

        yield return null; 

        if (cameraActive)
            cameraUI.SetActive(true);
        else
            gameUI.SetActive(true);
    }

    public bool CameraIsActive()
    {
        return cameraActive;
    }
}

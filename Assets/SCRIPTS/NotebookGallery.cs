using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NotebookGallery : MonoBehaviour
{
    public Transform container;          // MUST be assigned
    public GameObject imagePrefab;       // MUST have RawImage
    public string screenshotsFolder = "Screenshots";
    public float refreshDelay = 0.2f;

    string folderPath;

    void OnEnable()
    {
        folderPath = Path.Combine(Application.persistentDataPath, screenshotsFolder);
        StartCoroutine(RefreshDelayRoutine());
    }

    IEnumerator RefreshDelayRoutine()
    {
        yield return new WaitForSeconds(refreshDelay);
        Refresh();
    }

    public void Refresh()
    {
        if (container == null)
        {
            Debug.LogError("NotebookGallery: container is NOT assigned.");
            return;
        }

        if (imagePrefab == null)
        {
            Debug.LogError("NotebookGallery: imagePrefab is NOT assigned.");
            return;
        }

        ClearContainer();

        if (!Directory.Exists(folderPath))
            return;

        string[] files = Directory
            .GetFiles(folderPath, "*.png")
            .OrderByDescending(f => File.GetLastWriteTime(f))
            .ToArray();

        foreach (string file in files)
        {
            byte[] bytes = File.ReadAllBytes(file);
            if (bytes == null || bytes.Length == 0)
                continue;

            Texture2D tex = new Texture2D(2, 2);
            bool loaded = tex.LoadImage(bytes);
            if (!loaded)
            {
                Debug.LogWarning("Failed to load texture: " + file);
                Destroy(tex);
                continue;
            }

            GameObject entry = Instantiate(imagePrefab, container);

            RawImage img = entry.GetComponentInChildren<RawImage>();
            if (img == null)
            {
                Debug.LogError("imagePrefab is missing a RawImage component.");
                Destroy(entry);
                Destroy(tex);
                return;
            }

            img.texture = tex;
        }
    }

    void ClearContainer()
    {
        List<GameObject> toDestroy = new List<GameObject>();

        foreach (Transform child in container)
            toDestroy.Add(child.gameObject);

        foreach (GameObject go in toDestroy)
            Destroy(go);
    }
}

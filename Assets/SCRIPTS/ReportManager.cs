using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ReportManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject reportPanel;          
    public TMP_Dropdown caseTypeDropdown;   
    public GameObject correctPanel;         
    public GameObject incorrectPanel;       

    [Header("File Settings")]
    public string screenshotsFolder = "Screenshots";
    public string notesFileName = "player_notes.txt";

    public void OpenReport()
    {
        reportPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SubmitReport()
    {
        reportPanel.SetActive(false);

        string selected = caseTypeDropdown.options[caseTypeDropdown.value].text.ToLower();

        if (selected == "homocide")
        {
            correctPanel.SetActive(true);
        }
        else
        {
            incorrectPanel.SetActive(true);
        }

        Invoke(nameof(CleanUpAndReturn), 3f);
    }

    private void CleanUpAndReturn()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, screenshotsFolder);
        if (Directory.Exists(folderPath))
        {
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            foreach (FileInfo file in dir.GetFiles("*.png"))
                file.Delete();
        }

        string notesPath = Path.Combine(Application.persistentDataPath, notesFileName);
        if (File.Exists(notesPath))
            File.Delete(notesPath);

        SceneManager.LoadScene("MainMenu");
    }
}

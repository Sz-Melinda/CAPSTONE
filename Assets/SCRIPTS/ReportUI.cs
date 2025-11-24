using UnityEngine;

public class ReportUI : MonoBehaviour
{
    public GameObject promptText; 
    public GameObject reportPanel; 
    public KeyCode openKey = KeyCode.R;

    bool canOpen = false;

    void Update()
    {
        if (canOpen && Input.GetKeyDown(openKey))
        {
            OpenReport();
        }
    }

    public void ShowPrompt()
    {
        canOpen = true;
        promptText.SetActive(true);
    }

    public void HidePrompt()
    {
        canOpen = false;
        promptText.SetActive(false);
    }

    void OpenReport()
    {   
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;


        reportPanel.SetActive(true);
        HidePrompt();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

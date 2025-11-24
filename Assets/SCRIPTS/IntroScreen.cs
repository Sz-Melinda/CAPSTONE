using UnityEngine;

public class IntroPanel : MonoBehaviour
{
    public GameObject introUI;    

    void Start()
    {
        introUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseIntro()
    {
        introUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ButtonProceed()
    {
        CloseIntro(); 
    }
}

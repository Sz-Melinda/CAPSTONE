using UnityEngine;

public class NotebookToggle : MonoBehaviour
{
    public GameObject notebookUI;
    public KeyCode toggleKey = KeyCode.Tab;

    void Start()
    {
        notebookUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            bool nowActive = !notebookUI.activeSelf;
            notebookUI.SetActive(nowActive);

            if (nowActive)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public bool NotebookIsOpen()
    {
        return notebookUI.activeSelf;
    }
}

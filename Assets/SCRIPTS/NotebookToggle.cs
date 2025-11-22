using System.Collections;
using UnityEngine;

public class NotebookToggle : MonoBehaviour
{
    public GameObject notebookUI;
    public KeyCode toggleKey = KeyCode.N;
    public NotebookGallery gallery; 

    private Coroutine autoRefreshCoroutine;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            bool isActive = !notebookUI.activeSelf;
            notebookUI.SetActive(isActive);

            if (isActive && gallery != null)
            {
                gallery.Refresh(); 
                autoRefreshCoroutine = StartCoroutine(AutoRefreshGallery());
            }
            else
            {
                if (autoRefreshCoroutine != null)
                {
                    StopCoroutine(autoRefreshCoroutine);
                    autoRefreshCoroutine = null;
                }
            }
        }
    }

    public bool NotebookIsOpen()
    {
        return notebookUI.activeSelf;
    }

    private IEnumerator AutoRefreshGallery()
    {
        while (notebookUI.activeSelf)
        {
            gallery.Refresh();
            yield return new WaitForSeconds(1f); 
        }
    }
}

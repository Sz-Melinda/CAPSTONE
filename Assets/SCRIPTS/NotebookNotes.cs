using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.EventSystems;
using System.Collections;

public class NotebookNotes : MonoBehaviour
{
    public TMP_InputField notesField;
    string filePath;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "player_notes.txt");
        LoadNotes();
    }

    void OnEnable()
    {
        StartCoroutine(FocusNotesField());
    }

    IEnumerator ActivateTMPInput()
    {
        yield return new WaitForEndOfFrame();

        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null); 
            notesField.ActivateInputField();                  
            notesField.Select();
        }
    }

    public void SaveNotes()
    {
        File.WriteAllText(filePath, notesField.text);
    }

    void LoadNotes()
    {
        if (File.Exists(filePath))
            notesField.text = File.ReadAllText(filePath);
    }

    IEnumerator FocusNotesField()
    {
        yield return new WaitForEndOfFrame();
        notesField.ActivateInputField();
        notesField.Select();
    }
}

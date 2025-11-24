using UnityEngine;

public class ReportTrigger : MonoBehaviour
{
    public ReportUI reportUI;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            reportUI.ShowPrompt();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            reportUI.HidePrompt();
    }
}

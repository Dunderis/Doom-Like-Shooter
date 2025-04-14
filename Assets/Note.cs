using System.Collections;
using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    public GameObject NotePanel;

    public void Interact()
    {
        NotePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        StartCoroutine(WaitForInteraction());
    }

    private IEnumerator WaitForInteraction()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        while (NotePanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                NotePanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f;
                Destroy(gameObject);
                break;
            }
            yield return null;
        }
    }
}
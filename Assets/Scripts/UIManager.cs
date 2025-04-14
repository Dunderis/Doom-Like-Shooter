using System;
using UnityEngine;
using TMPro; // If you're using TextMeshPro for text

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;  // Singleton pattern to access UIManager easily
    public GameObject notePanel;  // Panel that holds the note UI
    public TextMeshProUGUI noteText;  // TextMeshPro component to display the note's text

    void Awake()
    {
        // Singleton setup
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        HideNote();  // Hide note UI by default
    }

    public void ShowNote(string text)
    {
        noteText.text = text;  // Set the text to display the note
        notePanel.SetActive(true);  // Show the note panel
        Time.timeScale = 0f;  // Pause the game while reading the note (optional)
    }

    public void HideNote()
    {
        notePanel.SetActive(false);  // Hide the note panel
        Time.timeScale = 1f;  // Resume the game
    }
    private void CloseNote()
    {
        HideNote();  // Hide the note when the close button is clicked
    }

    private void Update()
    {
        if (notePanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            HideNote();
        }
    }
}
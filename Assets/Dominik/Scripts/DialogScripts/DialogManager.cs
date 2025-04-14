using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    public GameObject dialogUI;
    public TMP_Text nameText;
    public TMP_Text dialogText;
    public Image speakerImage;
    public float lettersPerSec = 40;
    public KeyCode DialogSkipButton = KeyCode.G;

    private Queue<DialogLine> dialogLines = new Queue<DialogLine>();
    private bool freezePlayer = false;
    private bool typing = false;
    private DialogLine line;
    private int letterIndex = 0;
    private float timer;
    private void Start()
    {
        Instance = this;
    }
    private void Update()
    {
        if (dialogUI.activeSelf && Input.GetKeyDown(DialogSkipButton))
        {
            DisplayNextLine();
        }
        if(typing && timer>=1/lettersPerSec)
        {
            timer = 0;
            dialogText.text += line.sentence[letterIndex];
            letterIndex++;
            if (letterIndex == line.sentence.Length) typing = false;
        }
        timer += Time.deltaTime;
    }
    public void StartDialog(Dialog dialog)
    {
        dialogUI.SetActive(true);
        dialogLines.Clear();
        freezePlayer = dialog.freezePlayer;
        dialogText.text = "";
        //if (freezePlayer) PlayerMovement.Instance.canMove = false;(if needed)
        foreach (var line in dialog.lines)
        {
            dialogLines.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (dialogLines.Count == 0)
        {
            EndDialog();
            return;
        }
        letterIndex = 0;
        timer = 0;
        dialogText.text = "";
        typing = true;
        line = dialogLines.Dequeue();
        nameText.text = line.speakerName;
        speakerImage.sprite = line.speakerImage;
    }

    void EndDialog()
    {
        dialogUI.SetActive(false);
        //if (freezePlayer) PlayerMovement.Instance.canMove = true;
    }

}
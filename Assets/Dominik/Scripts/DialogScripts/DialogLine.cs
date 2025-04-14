using UnityEngine;

[System.Serializable]
public class DialogLine
{
    public string speakerName;
    public Sprite speakerImage;
    [TextArea(2, 2)]
    public string sentence;
}
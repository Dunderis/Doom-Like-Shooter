using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog/DialogData")]
public class Dialog : ScriptableObject
{
    public DialogLine[] lines;
    public bool freezePlayer;
}
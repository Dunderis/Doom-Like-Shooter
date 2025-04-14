using System.Threading;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialogData;
    public bool canMultiple = false;
    private int times = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (canMultiple ||(!canMultiple&&times==0)) && !DialogManager.Instance.dialogUI.activeSelf)
        {
            times++;
            FindObjectOfType<DialogManager>().StartDialog(dialogData);
        }
    }
}   
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool isOpen = false;
    private bool isRotating = false;

    public float rotationAmount = 90f;
    public float rotationSpeed = 200f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private void Start()
    {
        closedRotation = transform.rotation;

        openRotation = Quaternion.Euler(0f, transform.eulerAngles.y + rotationAmount, 0f);
    }

    public void Interact()
    {
        if (!isRotating)
        {
            isOpen = !isOpen;

            StopAllCoroutines();
            StartCoroutine(RotateDoor(isOpen ? openRotation : closedRotation));
        }
    }

    private IEnumerator RotateDoor(Quaternion targetRotation)
    {
        isRotating = true;

        Vector3 originalPos = transform.position; 

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.position = originalPos; 
            yield return null;
        }
        
        transform.rotation = targetRotation; 
        transform.position = originalPos;    
        isRotating = false;
    }
}
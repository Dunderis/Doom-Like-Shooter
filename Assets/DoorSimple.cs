using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSimple : MonoBehaviour
{
    public Material unlockedDoorMaterial;

    public void UnlockDoor()
    {
        GetComponent<MeshRenderer>().material = unlockedDoorMaterial;
        Destroy(GetComponent<BoxCollider>());
        Destroy(this);
    }
}

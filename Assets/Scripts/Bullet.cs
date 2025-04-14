using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        var health = other.gameObject.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }
}

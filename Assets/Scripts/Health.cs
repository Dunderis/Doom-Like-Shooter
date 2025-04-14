using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public bool destroyOnDeath = false;
    public UnityEvent onDeath;
    public UnityEvent onDamage;
    
    
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            
            onDeath.Invoke();
            if(destroyOnDeath) Destroy(gameObject);
        }
        
        onDamage.Invoke();
    }
}

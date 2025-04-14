using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour // Implemented already
{
    [Header("Game objects")]
    public Image fillImage;
    public RectTransform fillTransform;
    public TMP_Text healthText;
    [Header("Colors")]
    public Color color1;
    public Color color2;
    [Header("Bar properties")]
    public int maxHealth = 100;
    public string valueType = "HEALTH";

    private float currentHealth;
    private float startX;
    private float startY;

    private Vector2 originalSize;

    private void Start()
    {
        currentHealth = maxHealth;
        originalSize = fillTransform.sizeDelta;
        startX = fillTransform.localPosition.x;
        startY = fillTransform.localPosition.y;
        UpdateHealthBar();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float fillPercent = currentHealth / maxHealth;
        fillTransform.sizeDelta = new Vector2(originalSize.x * fillPercent, originalSize.y);
        fillTransform.localPosition = new Vector2(startX-originalSize.x/2*(1-fillPercent),startY);
        fillImage.color = Color.Lerp(color1, color2, fillPercent);
        healthText.text = currentHealth+"%\n"+valueType;
    }
}
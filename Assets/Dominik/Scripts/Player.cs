using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour // put "Player" tag on a player object
{
    public static Player Instance;

    [Header("Player Settings")]
    public int maxHp = 100;
    public int maxArmor = 100;
    public int hp;
    public int armor;
    [Header("Screen Flash Settings (for hp gain and loss effects)")]
    public Color hpGainColor = new Color(0.31f,1,0,0.31f);
    public Color hpLossColor = new Color(1, 0, 0, 0.31f);
    public float flashDuration = 1f;
    public Image flashImage;
    [Header("Other objects")]
    public GameObject gameOverScreen;

    private bool isFlashing = false;
    private bool isHealing = false;
    private float flashTimer = 0;
    void Start()
    {
        Instance = this;
        flashImage.color = new Color(0, 0, 0, 0);
        hp = maxHp;
        armor = maxArmor;
    }
    void Update()
    {
        //test purposes
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(15);
        }
        //
        if (isFlashing)
        {
            flashTimer += Time.deltaTime;
            float normalizedTime = flashTimer / flashDuration;
            Color color = isHealing?hpGainColor:hpLossColor;
            flashImage.color = Color.Lerp(color, new Color(0,0,0,0), normalizedTime);
            if (flashTimer >= flashDuration)
            {
                isFlashing = false;
                flashImage.color = new Color(0, 0, 0, 0);
            }
        }
    }
    public void TakeDamage(int damage)
    {
        if(armor>=damage)
        {
            armor -= damage;
            InventorySystem.Instance.armorBar.TakeDamage(damage);
        }
        else if (armor>0)
        {
            int left = damage - armor;
            armor = 0;
            hp -= left;
            InventorySystem.Instance.armorBar.TakeDamage(damage);
            InventorySystem.Instance.hpBar.TakeDamage(left);
        }
        else
        {
            hp -= damage;
            InventorySystem.Instance.hpBar.TakeDamage(damage);
            if (hp<=0)
            {
                GameOver();
            }
        }
        flashTimer = 0f;
        isFlashing = true;
        isHealing = false;
        flashImage.color = hpLossColor;
    }
    public void HealHp(int amount)
    {
        hp = Mathf.Clamp(hp+amount,0,maxHp);
        flashTimer = 0f;
        isFlashing = true;
        isHealing = true;
        flashImage.color = hpGainColor;
    }
    public void HealArmor(int amount)
    {
        armor = Mathf.Clamp(armor + amount, 0, maxArmor);
        flashTimer = 0f;
        isFlashing = true;
        isHealing = true;
        flashImage.color = hpGainColor;
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        //PlayerMovement.Instance.canMove = false;
    }
    public void Restart()
    {
        //SceneManager.LoadScene("name");
    }
}

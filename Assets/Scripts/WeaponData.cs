using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Weapon Identification")]
    public string weaponName = "Default Weapon";
    public int weaponID = 0;
    public Sprite weaponIcon;
    
    [Header("Weapon Stats")]
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 0.5f;
    public int maxAmmo = 30;
    public bool isAutomatic = false;
    
    [Header("Effects")]
    public AudioClip fireSound;
    public AudioClip emptySound;
    public AudioClip reloadSound;
    public GameObject muzzleFlash;
    public GameObject impactEffect;
    
    [Header("Gameplay")]
    [Tooltip("Set the weight of the weapon for player movement (bigger is slower)")]
    public float weight = 1f;
    public float reloadTime = 1.5f;
}
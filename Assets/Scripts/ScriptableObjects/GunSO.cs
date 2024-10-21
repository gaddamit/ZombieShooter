using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Scriptable Objects/Gun")]
public class GunSO : ScriptableObject
{
    public string gunName;
    public string description;
    [Range(0, 5)]
    public float fireRate;
    [Range(0, 50)]
    public float range;
    [Range(-1, 100)]
    public int maxAmmo;
    public float recoil;
    public bool spread;
    public GameObject bulletPrefab;
    public Sprite levelSprite;
    public Sprite uiSprite;
}

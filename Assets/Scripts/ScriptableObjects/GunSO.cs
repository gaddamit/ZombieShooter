using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Scriptable Objects/Gun")]
public class GunSO : ScriptableObject
{
    public string gunName;
    public string description;
    public float fireRate;
    public float range;
    public int maxAmmo;
    public float recoil;
    public bool spread;
    public float bulletSpeed;
    public float bulletLifeTime;
    public GameObject bulletPrefab;
    public Sprite levelSprite;
    public Sprite uiSprite;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Scriptable Objects/Bullet")]
public class BulletSO : ScriptableObject
{
    public string bulletName;
    public int damage;
    [Range(0.01f, 10)]
    public float travelTime;
    [Range(0, 10)]
    public float lifeTime;
    public float size;
    
    public Sprite bulletSprite;
    public GameObject hitEffect;
    public GameObject trailEffect;
    public AudioClip hitSound;
    public AudioClip shootSound;
}

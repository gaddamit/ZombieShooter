using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Scriptable Objects/Bullet")]
public class BulletSO : ScriptableObject
{
    public string bulletName;
    public int damage;
    public float speed;
    public float lifeTime;
    public float size;
    // public float knockback;
    public Sprite bulletSprite;
    public ParticleSystem hitEffect;
    public ParticleSystem trailEffect;
    public AudioClip hitSound;
    public AudioClip shootSound;
}

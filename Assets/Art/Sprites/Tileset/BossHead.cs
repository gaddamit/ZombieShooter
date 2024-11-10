using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHead : MonoBehaviour
{
    [SerializeField] private BossScript parent_script;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
            {
            Debug.Log("bullet hit");
            parent_script.Hit();
            }
    }
}

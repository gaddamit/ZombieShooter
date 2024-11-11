using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBomb : MonoBehaviour
{
    //we could have this kill the player or we could have it push the player away - I think just pushing them away plays into the core gameplay better
    public float explosion_radius = 10f;
    public float explosion_force = 50f;
    [SerializeField] private GameObject explosion;
    private Vector2 explode_here;

    public void SetExplosionTarget(Vector2 target)
    {
        explode_here = target;
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, explode_here) <= .2)
        {
            Explode();
        }
    }

    void Explode()
    {
        // Apply explosion force and damage to nearby rigidbody object
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosion_radius);
        foreach (Collider2D hit in colliders)
        {
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Debug.Log(rb);
                Vector2 explosion_pos = transform.position;
                Vector2 hit_pos = hit.transform.position;
                Vector2 explosion_dir = (hit_pos - explosion_pos).normalized;
                float explosion_distance = Vector2.Distance(explosion_pos, hit_pos);
                if (explosion_distance == 0)
                {
                    explosion_distance = .1f;
                }
                // Apply force away from the explosion center
                rb.AddForce(explosion_dir * explosion_force / explosion_distance, ForceMode2D.Impulse);
            }

        }

        // Destroy the projectile when we're done
        GameObject explosion_instance = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

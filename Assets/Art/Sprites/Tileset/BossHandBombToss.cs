using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandBombToss : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] float throw_force = 15f;
    [SerializeField] float targetting_radius = 12f;
    [SerializeField] float throw_timer;
    [SerializeField] float explosion_force = 3f;
    [SerializeField] float explosion_radius = 3f;
    [SerializeField] float bomb_duration_minimum = 1f;
    [SerializeField] float bomb_duration_maximum = 3f;
    private GameObject player;
    public bool active = true;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBomb()
    {
        if (player != null & bomb != null)
        {
            //where is the player
            Vector2 player_position = player.transform.position;
            //create
            GameObject projectile = Instantiate(bomb, transform.position, Quaternion.identity);
            //find the direction to our target with a randomized offset
            Vector2 random_offset = Random.insideUnitCircle * targetting_radius;
            Vector2 target_positon = player_position + random_offset;
            Vector2 direction = (target_positon - (Vector2)transform.position).normalized;
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            //tossit
            if (rb != null)
            {
                rb.AddForce(direction * throw_force, ForceMode2D.Impulse);
            }
            BossBomb bomb_script = projectile.GetComponent<BossBomb>();
            if (bomb_script != null)
            {
                bomb_script.SetExplosionDelay(Random.Range(bomb_duration_minimum, bomb_duration_maximum));
            }
        }
    }
}

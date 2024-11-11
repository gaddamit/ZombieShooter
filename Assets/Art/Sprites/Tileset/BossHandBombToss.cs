using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandBombToss : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] float throw_force = 5f;
    [SerializeField] float targetting_radius = 1.5f;
    [SerializeField] float throw_timer = 5f;
    private GameObject player;
    public bool active = true;
    private float next_spawn_time;
    private Animator anim;
    private float throw_anim_timer = .65f;
    private float throw_anim_timer_end = .3f;
    private bool is_throwing = false;
    private bool is_dying = false;

    public void IsDying()
    {
        is_dying = true;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("hand idle");
        player = GameObject.FindWithTag("Player");
        Debug.Log(player);
        next_spawn_time = Time.time + throw_timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_dying)
        {
            anim.Play("hand die");
        }
        else if (Time.time >= next_spawn_time & !is_throwing)
        {
            is_throwing = true;
            StartCoroutine(ThrowAnimation());
            next_spawn_time = Time.time + throw_timer;
        }
    }

    IEnumerator ThrowAnimation()
    {
        anim.Play("hand attack");
        yield return new WaitForSeconds(throw_anim_timer);
        SpawnBomb();
        yield return new WaitForSeconds(throw_anim_timer_end);
        is_throwing = false;
        anim.Play("hand idle");
    }

    void SpawnBomb()
    {
        if (player != null & bomb != null)
        {
            Debug.Log("spawning a bomb");
            //where is the player
            Vector2 player_position = player.transform.localPosition;
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
                Debug.Log("setting bomb target");
                bomb_script.SetExplosionTarget(target_positon);
            }
        }
    }
}

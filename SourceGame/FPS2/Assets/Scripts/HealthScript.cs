using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float max_health = 100f;
    public float cur_health = 0f;
    [SerializeField] public Transform player;
    [SerializeField] public Transform respawnPoint;
    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        cur_health = max_health; // Cur health is set to 100
    }

    public void TakeDamage(float amount)
    {
        if (!alive)  // if alive is true
        {
            return;
        }

        if (cur_health <= 0)
        {
            cur_health = 0;
            alive = false;
            Respawn();
            //gameObject.setActive(false); // Disable player
        }
        cur_health -= amount;
    }

    public void Respawn ()
    {
        player.transform.position = respawnPoint.transform.position;
        alive = true;
        cur_health = max_health;
    }
    }
// Ignore Spelling: spd dmg

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1.0f;
    public float damage = 1.0f;
    public Vector2 direction = Vector2.up;
    public float lifeSpan = 5.0f;

    Rigidbody2D rb;
    float lifeTimer = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//needs to be before stuff

        rb.velocity = direction.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer > lifeSpan)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitObj = collision.gameObject;
        if (hitObj.layer != LayerMask.NameToLayer("Enemy")) return;

        EvtSystem.EventDispatcher.Raise(new GameEvents.EnemyHit() { enemy = hitObj });

        hitObj.GetComponent<EnemyHealth>().ApplyDamage(damage);
        Destroy(gameObject);
    }
}

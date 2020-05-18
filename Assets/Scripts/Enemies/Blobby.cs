using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blobby : Enemy {
    Transform player;
    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;
        player = FindObjectOfType<Player>().transform;
    }

    public new float CollisionDamage
    {
        get
        {
            return 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyIfOffScreen();
    }

    protected override void Move()
    {
        Vector3 targetVector = (player.position - transform.position);
        targetVector.Normalize();

        transform.position += Vector3.right * targetVector.x * moveSpeed * Time.deltaTime;
        transform.position += Vector3.down * Time.deltaTime * moveSpeed * 1.5f;
    }

    public override void TakeHit(float damage, string tag)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }
}

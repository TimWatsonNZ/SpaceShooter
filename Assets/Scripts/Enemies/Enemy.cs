using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable {
    protected float moveSpeed = 3;
    public float startingHealth = 2;
    protected float currentHealth;
    protected bool alive = true;
    public string behaviour;

    public System.Action OnDeath;

    public float CollisionDamage
    {
        get
        {
            return 1;
        }
    }

    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        DestroyIfOffScreen();
    }

    protected virtual void Move()
    {
        Vector2 position = transform.position;

        position.y -= Time.deltaTime * moveSpeed;

        transform.position = position;
    }

    protected void DestroyIfOffScreen()
    {
        if (transform.position.y < -Utility.GetScreenHeight())
        {
            Kill();
        }
    }

    public void Kill()
    {
        alive = false;

        if(OnDeath != null)
        {
            OnDeath();
        }
        Destroy(gameObject);
    }

    public virtual void TakeHit(float damage, string tag)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public float startingHealth = 10;
    public float startingShield = 10;
    public Weapon weaponPrefab;
    public float moveSpeed = 10f;
    public Hud hudPrefab;
    
    float shieldRechargeDelay = 2f;
    float shieldRechargeRate = 2f;
    float shieldRechargeStart;

    Weapon weaponInstance;
    public System.Action OnDeath;
    protected float currentHealth;
    protected float currentShield;
    Hud hudInstance;

    float damageByCollision = 1f;
    bool dead = false;
    bool firing = false;

    public float CollisionDamage
    {
        get
        {
            return 1;
        }
    }

    void Start()
    {
        currentHealth = startingHealth;
        currentShield = startingShield;
        weaponInstance = Instantiate(weaponPrefab, transform);
        weaponInstance.target = Vector2.up;
        weaponInstance.tag = "Player";

        hudInstance = Instantiate(hudPrefab, transform);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalalMove = Input.GetAxisRaw("Vertical");
        transform.position += Vector3.right * horizontalMove * moveSpeed * Time.deltaTime;
        transform.position += Vector3.up * verticalalMove * moveSpeed * Time.deltaTime;
        
        KeepOnscreen();
        Shoot();
        RechargeShield();
        hudInstance.UpdateHud(currentHealth / startingHealth, currentShield/startingShield);
    }

    void RechargeShield()
    {
        if (Time.time > shieldRechargeStart)
        {
            currentShield += startingShield / shieldRechargeRate * Time.deltaTime;
            currentShield = currentShield > startingShield ? startingShield : currentShield;
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            firing = true;
        }
        if (firing)
        { 
            Vector3 prefabPosition = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2, transform.position.z);
            weaponInstance.Shoot(prefabPosition, Vector2.one);
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            firing = false;
        }
    }

    void KeepOnscreen()
    {
        float halfPlayerWidth = transform.localScale.x / 2;
        float halfPlayerHeight = transform.localScale.y / 2;

        float screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
        float screenHalfHeightInWorldUnits = Camera.main.orthographicSize - halfPlayerHeight;

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

        if (transform.position.y < -screenHalfHeightInWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, -screenHalfHeightInWorldUnits);
        }
        if (transform.position.y > screenHalfHeightInWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, screenHalfHeightInWorldUnits);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeHit(damageByCollision, tag);
            TakeHit(damageable.CollisionDamage, tag);
        }
    }

    public void TakeHit(float damage, string tag)
    {
        currentShield -= damage;
        shieldRechargeStart = Time.time + shieldRechargeDelay;
        if (currentShield < 0)
        {
            currentHealth += currentShield;
            currentShield = 0;
        }

        if (currentHealth <= 0 && !dead)
        {
            dead = true;
            OnDeath();
        }
    }
}

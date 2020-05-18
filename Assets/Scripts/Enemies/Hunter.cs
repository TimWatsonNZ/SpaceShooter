using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : Enemy {

    public Weapon weaponPrefab;
    Weapon weaponInstance;
    // Use this for initialization
    void Start () {
        weaponInstance = Instantiate(weaponPrefab, transform);
        weaponInstance.tag = "Enemy";
        weaponInstance.target = Vector2.down;
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 position = transform.position;
        position.y -= moveSpeed * Time.deltaTime;
        transform.position = position;
        Shoot();
    }

    void Shoot()
    {
        Vector3 prefabPosition = new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z);
        weaponInstance.Shoot(prefabPosition, Vector2.one * -1);
    }
}

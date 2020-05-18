using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShotInitializer
{
    public Vector2 StartPoint;
    public Vector2 Orientation;
}

public class Weapon : MonoBehaviour {
    
    public Bullet bulletPrefab;
    public Vector2 target;
    private Cooldown cooldown;
    public float cooldownDuration;
    public float scale = 1;
    public float damage;
    public ShotInitializer[] shotInitializers;
    public bool isHoming = false;
    public bool isAutotargeted = false;
    
    void Start ()
    {
        cooldown = new Cooldown(cooldownDuration);
    }

    public void Shoot(Vector2 parentPosition, Vector2 orientationChange)
    {
        if (cooldown.Ready)
        {
            foreach(var init in shotInitializers)
            {
                Bullet bullet = Instantiate(bulletPrefab, parentPosition + init.StartPoint, Quaternion.identity);
                bullet.tag = tag;
                if (isAutotargeted)
                {
                    var player = FindObjectOfType<Player>();
                    var targetVector = (player.transform.position - bullet.transform.position);
                    targetVector.Normalize();
                    bullet.moveVector = targetVector;
                } else
                {
                    bullet.moveVector = init.Orientation * orientationChange;
                }
                
                bullet.transform.localScale = Vector3.one * scale;
                bullet.damage = damage;
                cooldown.Update(Time.deltaTime, true);

                if (isHoming)
                {
                    if (tag == "Player")
                    {
                        var enemies = FindObjectsOfType<Enemy>();
                        if (enemies.Length > 0)
                        {
                            bullet.target = enemies[0].transform;
                        }
                    }
                }
            }
        }
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        cooldown.Update(Time.deltaTime, false);
    }
}

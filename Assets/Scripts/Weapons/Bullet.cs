using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float moveSpeed = 10;
    public float damage = 1f;
    public Transform target;
    public float rotateSpeed = 1f;

    public Vector2 moveVector;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 position = transform.position;
        Vector2 targetOrientation = moveVector;
        if (target != null)
        {
            targetOrientation = (target.position - transform.position).normalized;
        }

        float angle = Mathf.Atan2(targetOrientation.y, targetOrientation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward) ;
        position += targetOrientation * moveSpeed * Time.deltaTime;

        transform.position = position;
        DestroyIfOffScreen();
	}

    void DestroyIfOffScreen()
    {
        float screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        float screenHalfHeightInWorldUnits = Camera.main.orthographicSize;

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -screenHalfHeightInWorldUnits)
        {
            Destroy(gameObject);

        }
        if (transform.position.y > screenHalfHeightInWorldUnits)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null && other.tag != tag)
        {
            damageable.TakeHit(damage, tag);
            Destroy(gameObject);
        }
    }
}

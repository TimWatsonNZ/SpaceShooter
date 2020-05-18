using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy {
    enum MoveState
    {
        Start,
        Down,
        Up
    }

    public Blobby blobbyPrefab;
    public Healthbar healthbar;
    MoveState moveState = MoveState.Start;
    float currentMovementDuration = 0;
    float moveStartDuration = 4f;
    float moveDownDuration = 2f;
    float moveUpDuration = 2f;
    bool behaviourStarted = false;
    Cooldown cooldown = new Cooldown(4);

    // Use this for initialization
    void Start ()
    {
        moveSpeed = 1.5f;
        healthbar = Instantiate(healthbar, new Vector2(0, 0), Quaternion.identity);
        currentHealth = startingHealth;
        healthbar.transform.SetParent(transform);
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        if (cooldown.Ready)
        {
            Vector2 v1 = transform.position;
            v1.x -= 2;
            var blobby1 = Instantiate(blobbyPrefab, v1, Quaternion.identity);
            blobby1.OnDeath += OnChildDied;

            Vector2 v2 = transform.position;
            v2.x -= 2;
            v2.y -= 1;
            var blobby2 = Instantiate(blobbyPrefab, v2, Quaternion.identity);
            blobby2.OnDeath += OnChildDied;

            Vector2 v3 = transform.position;
            v3.x -= 2;
            v3.y += 1;
            var blobby3 = Instantiate(blobbyPrefab, v3, Quaternion.identity);
            blobby3.OnDeath += OnChildDied;

            Vector2 v4 = transform.position;
            v4.x -= .5f;
            v4.y += 1f;
            var blobby4 = Instantiate(blobbyPrefab, v4, Quaternion.identity);
            blobby4.OnDeath += OnChildDied;

            Vector2 v5 = transform.position;
            v5.y += 1f;
            var blobby5 = Instantiate(blobbyPrefab, v5, Quaternion.identity);
            blobby5.OnDeath += OnChildDied;

            Vector2 v6 = transform.position;
            v6.x += .5f;
            v6.y += 1f;
            var blobby6 = Instantiate(blobbyPrefab, v6, Quaternion.identity);
            blobby6.OnDeath += OnChildDied;

            Vector2 v7 = transform.position;
            v7.x += 2;
            v7.y += 2;
            var blobby7 = Instantiate(blobbyPrefab, v7, Quaternion.identity);
            blobby7.OnDeath += OnChildDied;

            Vector2 v8 = transform.position;
            v8.x += 2;
            var blobby8 = Instantiate(blobbyPrefab, v8, Quaternion.identity);
            blobby8.OnDeath += OnChildDied;

            Vector2 v9 = transform.position;
            v9.x += 2;
            v9.y -= 2;
            var blobby9 = Instantiate(blobbyPrefab, v9, Quaternion.identity);
            blobby8.OnDeath += OnChildDied;

            cooldown.Update(Time.deltaTime, true);
        } else
        {
            cooldown.Update(Time.deltaTime, false);
        }
	}

    void OnChildDied()
    {

    }

    protected override void Move()
    {
        if (!behaviourStarted)
        {
            StartCoroutine(Behaviour());
            behaviourStarted = true;
        }
    }

    IEnumerator Behaviour()
    {
        while(true)
        {
            Vector2 position = transform.position;
            if (moveState == MoveState.Start)
            {
                position.y -= moveSpeed * Time.deltaTime;
                transform.position = position;
                currentMovementDuration += Time.deltaTime;

                if (currentMovementDuration > moveStartDuration)
                {
                    moveState = MoveState.Up;
                    currentMovementDuration = 0;
                    yield return null;
                }
                yield return null;
            }

            if (moveState == MoveState.Up)
            {
                position.y += moveSpeed * Time.deltaTime;
                transform.position = position;
                currentMovementDuration += Time.deltaTime;
                if (currentMovementDuration > moveUpDuration)
                {
                    moveState = MoveState.Down;
                    currentMovementDuration = 0;
                    yield return null;
                }
                yield return null;
            }

            if (moveState == MoveState.Down)
            {
                position.y -= moveSpeed * Time.deltaTime;
                transform.position = position;
                currentMovementDuration += Time.deltaTime;
                if (currentMovementDuration > moveDownDuration)
                {
                    moveState = MoveState.Up;
                    currentMovementDuration = 0;
                    yield return null;
                }
                yield return null;
            }
        }
    }


    public override void TakeHit(float damage, string tag)
    {
        base.TakeHit(damage, tag);
        if (!alive)
        {
            Destroy(healthbar);
        } else
        {
            healthbar.SetPercentage(currentHealth / startingHealth);
        }
    }
}

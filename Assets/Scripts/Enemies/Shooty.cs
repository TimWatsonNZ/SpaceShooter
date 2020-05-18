using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooty : Enemy {

    enum MoveState {
        Idle,
        FirstDown,
        DownBeforeLeft,
        DownBeforeRight,
        ShortLeft,
        Left,
        Right,
    }

    MoveState moveState = MoveState.Idle;

    public Weapon weaponPrefab;
    Weapon weaponInstance;

    bool behaviourStarted = false;

    void Start()
    {
        weaponInstance = Instantiate(weaponPrefab, transform);
        weaponInstance.tag = "Enemy";
        weaponInstance.target = Vector2.down;
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyIfOffScreen();
        Shoot();
    }

    protected override void Move()
    {
        if (behaviour == "Zigzag")
        {
            if (!behaviourStarted)
            {
                StartCoroutine(ZigzagBehaviour());
                behaviourStarted = true;
            }
        } 
        if (behaviour == "Down")
        {

            Vector2 position = transform.position;
            position.y -= moveSpeed * Time.deltaTime;
            transform.position = position;
        }
    }

    IEnumerator ZigzagBehaviour()
    {
        float currentMovementDuration = 0f;
        float moveDownDuration = 1f;
        float shortLeftDuration = 1f;
        float moveLeftDuration = 3f;
        float moveRightDuration = 3f;

        Vector2 position = transform.position;

        while(true)
        {
            if (moveState == MoveState.Idle)
            {
                moveState = MoveState.FirstDown;
                currentMovementDuration = 0;
                yield return null;
            }

            if (moveState == MoveState.FirstDown)
            {
                if (currentMovementDuration < moveDownDuration)
                {
                    position.y -= moveSpeed * Time.deltaTime;
                    currentMovementDuration += Time.deltaTime;
                    transform.position = position;
                    yield return null;
                } else
                {
                    moveState = MoveState.ShortLeft;
                    currentMovementDuration = 0;
                    yield return null;
                }
            }

            if (moveState == MoveState.ShortLeft)
            {
                if (currentMovementDuration < shortLeftDuration)
                {
                    position.x -= moveSpeed * Time.deltaTime;
                    currentMovementDuration += Time.deltaTime;
                    transform.position = position;
                    yield return null;
                }
                else
                {
                    moveState = MoveState.DownBeforeRight;
                    currentMovementDuration = 0;
                    yield return null;
                }
            }

            if (moveState == MoveState.DownBeforeRight)
            {
                if (currentMovementDuration < moveDownDuration)
                {
                    position.y -= moveSpeed * Time.deltaTime;
                    currentMovementDuration += Time.deltaTime;
                    transform.position = position;
                    yield return null;
                }
                else
                {
                    moveState = MoveState.Right;
                    currentMovementDuration = 0;
                    yield return null;
                }
            }

            if (moveState == MoveState.Right)
            {
                if (currentMovementDuration < moveRightDuration)
                {
                    position.x += moveSpeed * Time.deltaTime;
                    currentMovementDuration += Time.deltaTime;
                    transform.position = position;
                    yield return null;
                }
                else
                {
                    moveState = MoveState.DownBeforeLeft;
                    currentMovementDuration = 0;
                    yield return null;
                }
            }

            if (moveState == MoveState.DownBeforeLeft)
            {
                if (currentMovementDuration < moveDownDuration)
                {
                    position.y -= moveSpeed * Time.deltaTime;
                    currentMovementDuration += Time.deltaTime;
                    transform.position = position;
                    yield return null;
                }
                else
                {
                    moveState = MoveState.Left;
                    currentMovementDuration = 0;
                    yield return null;
                }
            }

            if (moveState == MoveState.Left)
            {
                if (currentMovementDuration < moveLeftDuration)
                {
                    position.x -= moveSpeed * Time.deltaTime;
                    currentMovementDuration += Time.deltaTime;
                    transform.position = position;
                    yield return null;
                }
                else
                {
                    moveState = MoveState.DownBeforeRight;
                    currentMovementDuration = 0;
                    yield return null;
                }
            }

            yield return null;
        }
    }

    void Shoot()
    {
        Vector3 prefabPosition = new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z);
        weaponInstance.Shoot(prefabPosition, Vector2.one * -1);
    }
}

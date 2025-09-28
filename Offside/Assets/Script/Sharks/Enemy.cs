using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform startingPoint;
    public Transform finishPoint;
    [Range(0f, 1f)]
    public float progress;
    public float moveSpeed = 5f;

    private Vector3 targetPos;

    public static Enemy Instance;

    public float roundMovementMultiplier = 1f;
    public float movementMultiplier = 1f;

    public bool isFreeze = false;

    void Awake() => Instance = this;

    void Update()
    {
        progress = Mathf.Clamp01(progress);

        targetPos = Vector3.Lerp(startingPoint.position, finishPoint.position, progress);

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
    public void MoveForward(float amount)
    {
        if (isFreeze)
        {
            roundMovementMultiplier = 0f;
        }

        Move(amount * roundMovementMultiplier);

        roundMovementMultiplier = 1f;
    }

    public void Move(float amount)
    {
        if (isFreeze)
        {
            movementMultiplier = 0f;
        }

        progress = Mathf.Clamp01(progress + amount * movementMultiplier);

        movementMultiplier = 1f;
    }
}

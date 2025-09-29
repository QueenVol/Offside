using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform startingPoint;
    public Transform finishPoint;
    [Range(0f, 1f)]
    public float progress;
    public float moveSpeed = 5f;

    private Vector3 targetPos;

    public static Player Instance;

    public float movementMultiplier = 1f;

    void Awake() => Instance = this;

    void Update()
    {
        progress = Mathf.Clamp01(progress);

        progress = Mathf.Clamp01(Mathf.Round(progress * 10f) / 10f);

        targetPos = Vector3.Lerp(startingPoint.position, finishPoint.position, progress);

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (progress >= 1f)
        {
            if (GameManager.Instance != null) GameManager.Instance.CheckGameOver();
        }

        Debug.Log("player: " + progress);
    }

    public void Move(float amount)
    {
        progress = Mathf.Clamp01(progress + amount * movementMultiplier);

        movementMultiplier = 1f;
    }
}
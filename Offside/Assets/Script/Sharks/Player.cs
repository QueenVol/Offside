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

    void Awake() => Instance = this;

    void Update()
    {
        progress = Mathf.Clamp01(progress);

        targetPos = Vector3.Lerp(startingPoint.position, finishPoint.position, progress);

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
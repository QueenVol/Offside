using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    public float moveUpAmount = 0.2f;
    public float moveSpeed = 20f;

    private Vector3 originalPos;
    private Vector3 targetPos;

    private void Start()
    {
        originalPos = transform.position;
        targetPos = originalPos;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);
    }

    private void OnMouseEnter()
    {
        targetPos = originalPos + Vector3.up * moveUpAmount;
    }

    private void OnMouseExit()
    {
        targetPos = originalPos;
    }
}

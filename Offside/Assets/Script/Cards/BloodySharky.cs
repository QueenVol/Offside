using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodySharky : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    public float displacement = 0.1f;

    void OnMouseDown()
    {
        if (enemy != null)
        {
            enemy.progress = Mathf.Clamp01(enemy.progress - displacement);
        }
        Destroy(gameObject);
    }
}

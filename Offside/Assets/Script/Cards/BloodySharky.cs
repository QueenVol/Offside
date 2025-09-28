using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodySharky : MonoBehaviour
{ 
    public float displacement = 0.1f;

    void OnMouseDown()
    {
        CardRuntime runtime = GetComponent<CardRuntime>();
        if (runtime == null || runtime.IsPlayed) return;

        if (GameManager.Instance != null && GameManager.Instance.IsPlayerLocked)
        {
            return;
        }

        Enemy enemy = Enemy.Instance;
        if (enemy != null)
        {
            enemy.Move(-displacement);
        }

        runtime.MarkAsPlayed();
    }
}

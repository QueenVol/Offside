using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarySharky : MonoBehaviour
{
    public float displacement = 0.1f;

    void OnMouseDown()
    {
        Enemy enemy = Enemy.Instance;
        if (enemy != null)
        {
            enemy.progress = Mathf.Clamp01(enemy.progress + displacement);
        }
        GetComponent<CardRuntime>().Discard();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralReefs : MonoBehaviour
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

        Player player = Player.Instance;
        Enemy enemy = Enemy.Instance;
        if (player != null && enemy != null)
        {
            player.Move(-displacement);
            enemy.Move(-displacement);
        }

        runtime.MarkAsPlayed();
    }
}

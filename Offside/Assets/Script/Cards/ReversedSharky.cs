using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversedSharky : MonoBehaviour
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
        if (player != null)
        {
            player.Move(-displacement);

            player.movementMultiplier = 3f;
        }

        runtime.MarkAsPlayed();
    }
}

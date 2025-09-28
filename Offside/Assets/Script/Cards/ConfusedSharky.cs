using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfusedSharky : MonoBehaviour
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
            int randomValue = Random.Range(0, 2);
            if (randomValue == 0)
            {
                player.Move(displacement * 2);
            }
            if (randomValue == 1)
            {
                player.Move(-displacement);
            }
        }

        runtime.MarkAsPlayed();
    }
}

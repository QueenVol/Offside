using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TralaleroTralala : MonoBehaviour
{
    void OnMouseDown()
    {
        CardRuntime runtime = GetComponent<CardRuntime>();
        if (runtime == null || runtime.IsPlayed) return;

        if (GameManager.Instance != null && GameManager.Instance.IsPlayerLocked)
        {
            return;
        }

        GameManager.Instance.immuneThisTurn = true;

        runtime.MarkAsPlayed();
    }
}

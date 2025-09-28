using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversedSharky : MonoBehaviour
{
    public float displacement = 0.1f;

    void OnMouseDown()
    {
        Player player = Player.Instance;
        if (player != null)
        {
            player.progress = Mathf.Clamp01(player.progress - displacement);
        }
        GetComponent<CardRuntime>().MarkAsPlayed();
    }
}

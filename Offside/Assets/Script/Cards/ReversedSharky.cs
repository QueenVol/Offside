using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversedSharky : MonoBehaviour
{
    [SerializeField] private Player player;
    public float displacement = 0.1f;

    void OnMouseDown()
    {
        if (player != null)
        {
            player.progress = Mathf.Clamp01(player.progress - displacement);
        }
        GetComponent<CardRuntime>().Discard();
    }
}

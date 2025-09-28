using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfusedSharky : MonoBehaviour
{
    [SerializeField] private Player player;
    public float displacement = 0.1f;

    void OnMouseDown()
    {
        if (player != null)
        {
            int randomValue = Random.Range(0, 2);
            if (randomValue == 0)
            {
                player.progress = Mathf.Clamp01(player.progress + displacement);
            }
            if (randomValue == 1)
            {
                player.progress = Mathf.Clamp01(player.progress - displacement);
            }
        }
        GetComponent<CardRuntime>().Discard();
    }
}

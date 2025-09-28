using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRuntime : MonoBehaviour
{
    public CardData cardData;
    private GameManager gm;
    private bool isPlayed = false;

    private SpriteRenderer spriteRenderer;

    public void Init(CardData data, GameManager manager)
    {
        cardData = data;
        gm = manager;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void MarkAsPlayed()
    {
        if (isPlayed) return;

        isPlayed = true;
        SetTransparent(true);
    }

    public void Discard()
    {
        if (gm != null && cardData != null)
        {
            gm.AddToDiscard(cardData);
        }
        Destroy(gameObject);
    }

    private void SetTransparent(bool transparent)
    {
        if (spriteRenderer != null)
        {
            Color c = spriteRenderer.color;
            c.a = transparent ? 0.2f : 1f;
            spriteRenderer.color = c;
        }
    }
}

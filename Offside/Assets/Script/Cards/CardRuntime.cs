using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRuntime : MonoBehaviour
{
    public CardData cardData;
    private GameManager gm;

    public void Init(CardData data, GameManager manager)
    {
        cardData = data;
        gm = manager;
    }

    public void Discard()
    {
        if (gm != null && cardData != null)
        {
            gm.AddToDiscard(cardData);
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<CardData> startingDeck;
    public Transform[] handSlots;

    public Button startTurnButton;
    public Button endTurnButton;

    private List<CardData> deck = new List<CardData>();
    private List<CardData> discardPile = new List<CardData>();
    private List<GameObject> hand = new List<GameObject>();

    //private enum TurnState { WaitingToStart, InTurn, TurnEnded }
    private enum TurnState { WaitingToStart, InTurn };
    private TurnState currentState = TurnState.WaitingToStart;

    void Start()
    {
        InitDeck();
        UpdateButtonStates();
        //DrawHand(5);
    }

    void InitDeck()
    {
        deck.Clear();
        discardPile.Clear();
        hand.Clear();

        deck.AddRange(startingDeck);
        Shuffle(deck);
    }

    void Shuffle(List<CardData> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            CardData temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    CardData DrawCardData()
    {
        if (deck.Count == 0)
        {
            if (discardPile.Count == 0) return null;

            deck.AddRange(discardPile);
            discardPile.Clear();
            Shuffle(deck);
        }

        CardData data = deck[0];
        deck.RemoveAt(0);
        return data;
    }

    void ClearHand()
    {
        foreach (GameObject card in hand)
        {
            if (card != null) Destroy(card);
        }
        hand.Clear();
    }

    public void AddToDiscard(CardData card)
    {
        discardPile.Add(card);
    }

    public void AddNewCardToDeck(CardData card)
    {
        deck.Add(card);
        Shuffle(deck);
    }

    public void StartTurn()
    {
        if (currentState != TurnState.WaitingToStart) return;

        DrawHand(5);
        currentState = TurnState.InTurn;
        UpdateButtonStates();
    }

    public void EndTurn()
    {
        if (currentState != TurnState.InTurn) return;

        DiscardHand();
        //currentState = TurnState.TurnEnded;
        currentState = TurnState.WaitingToStart;
        UpdateButtonStates();
    }

    public void DrawHand(int count)
    {
        ClearHand();

        for (int i = 0; i < count && i < handSlots.Length; i++)
        {
            CardData data = DrawCardData();
            if (data != null)
            {
                GameObject cardInstance = Instantiate(data.prefab, handSlots[i].position, Quaternion.identity);
                CardRuntime runtime = cardInstance.AddComponent<CardRuntime>();
                runtime.Init(data, this);
                hand.Add(cardInstance);
            }
        }
    }

    public void DiscardHand()
    {
        foreach (GameObject card in hand)
        {
            if (card == null) continue;

            CardRuntime runtime = card.GetComponent<CardRuntime>();
            if (runtime != null)
            {
                runtime.Discard();
            }
        }
        hand.Clear();
    }

    void UpdateButtonStates()
    {
        startTurnButton.interactable = (currentState == TurnState.WaitingToStart);
        endTurnButton.interactable = (currentState == TurnState.InTurn);
    }

    public void ResetTurn()
    {
        currentState = TurnState.WaitingToStart;
        UpdateButtonStates();
    }
}

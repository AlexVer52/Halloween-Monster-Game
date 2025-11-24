using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public DeckBuilding monsterDeck;
    public List<MonsterCard> monsterOnField = new List<MonsterCard>();
    public List<Monster> monstersInGame = new List<Monster>();
    public MonsterCardView monsterCardPrefab;
    public RectTransform[] monsterSlots;
    public RectTransform deckSlot;
    public RuntimeDeck runtime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (monsterDeck == null)
        {
            Debug.LogError("Monster Deck is not assigned in the Inspector.");
            return;
        }

        runtime = new RuntimeDeck(monsterDeck);
        Debug.Log("Deck initialized with " + runtime.Count + " cards.");
        // Initiate the Monster Cards in the Slots
        for (int i = 0; i < monsterSlots.Length; i++)
        {
            MonsterCard drawnCard = runtime.Draw();
            if (drawnCard != null)
            {
                MonsterCardView cardView = Instantiate(monsterCardPrefab, monsterSlots[i]);
                cardView.cardData = drawnCard;
                cardView.isFaceUp = true;
                monsterOnField.Add(drawnCard);
                monstersInGame.Add(new Monster(drawnCard));
            }
        }

        MonsterCardView deckCardView = Instantiate(monsterCardPrefab, deckSlot);
        deckCardView.cardData = null; // Assuming the deck slot starts empty
        deckCardView.isFaceUp = false;
    }

    public void ReplaceDeadMonster(Monster deadMonster)
    {
        int index = monstersInGame.IndexOf(deadMonster);
        if (index != -1)
        {
            MonsterCardView slotView = monsterSlots[index].GetComponentInChildren<MonsterCardView>();
            if (slotView != null)
            {
                Destroy(slotView.gameObject);
            }
            MonsterCard newCard = runtime.Draw();
            if (newCard != null)
            {
                MonsterCardView newCardView = Instantiate(monsterCardPrefab, monsterSlots[index]);
                newCardView.cardData = newCard;
                newCardView.isFaceUp = true;
                monsterOnField[index] = newCard;
                monstersInGame[index] = new Monster(newCard);
                Debug.Log("Replaced dead monster with new monster: " + newCard.cardName + "new set of cards: " + monstersInGame[0].monsterCardData.cardName + ", " + monstersInGame[1].monsterCardData.cardName + ", " + monstersInGame[2].monsterCardData.cardName);
            }
            else
            {
                Debug.Log("No more cards in the deck to draw.");
            }
        }
        else
        {
            Debug.LogWarning("Dead monster not found in the current monsters in game.");
        }
    }
}

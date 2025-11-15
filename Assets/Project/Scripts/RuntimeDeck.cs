using UnityEngine;
using System.Collections.Generic;

public class RuntimeDeck
{
    public List<MonsterCard> monsterDeck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public RuntimeDeck(DeckBuilding sourceDeck)
    {
        monsterDeck = new List<MonsterCard>(sourceDeck.monsterDeck);
        Shuffle();
    }

    public void Shuffle()
    {
        for (int i = 0; i < monsterDeck.Count; i++)
        {
            MonsterCard temp = monsterDeck[i];
            int randomIndex = Random.Range(i, monsterDeck.Count);
            monsterDeck[i] = monsterDeck[randomIndex];
            monsterDeck[randomIndex] = temp;
        }
    }

    public MonsterCard Draw()
    {
        if (monsterDeck.Count == 0)
        {
            Debug.LogWarning("No more cards to draw.");
            return null;
        }

        MonsterCard drawnCard = monsterDeck[0];
        monsterDeck.RemoveAt(0);
        return drawnCard;
    }

    public int Count => monsterDeck.Count;
}

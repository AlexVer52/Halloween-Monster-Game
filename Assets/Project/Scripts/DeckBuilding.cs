using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Deck/MonsterDeck")]
public class DeckBuilding : ScriptableObject
{
    public List<MonsterCard> monsterDeck = new List<MonsterCard>();

    public DeckBuilding(List<MonsterCard> monsterDeck)
    {
        this.monsterDeck = monsterDeck;
    }
}

using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public DeckBuilding monsterDeck;
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
                cardView.isFaceUp = false;
            }
        }
        MonsterCardView deckCardView = Instantiate(monsterCardPrefab, deckSlot);
        deckCardView.cardData = null; // Assuming the deck slot starts empty
        deckCardView.isFaceUp = true;
    }
}

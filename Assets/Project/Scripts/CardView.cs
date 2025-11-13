using UnityEngine;
using TMPro;

public class CardView : MonoBehaviour
{
    [Header("Card Data")]
    public Card cardData;
    [Header("UI Elements")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI rewardText;
    public TextMeshProUGUI stuffText;
    public TextMeshProUGUI attackText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (cardData != null)
        {
            Debug.LogWarning("CardView on " + gameObject.name + " has no cardData assigned.");
            return;
        }

        // Common setup
        if (nameText != null) nameText.text = cardData.cardName;
        if (descriptionText != null) descriptionText.text = cardData.description;

        // Specific setup based on card type
        switch (cardData.cardType)
        {
            case CardType.Monster:
                MonsterCard monster = (MonsterCard)cardData;
                SetUp(monster.cardName, monster.description, monster.hp, 0);
                if (rewardText != null) rewardText.text = $"Reward VP: {monster.rewardVP}, Weapon: {monster.rewardWeapon}";
                break;
            case CardType.Player:
                PlayerCard player = (PlayerCard)cardData;
                SetUp(player.cardName, player.description, player.hp, 0);
                break;
            case CardType.Weapon:
                WeaponCard weapon = (WeaponCard)cardData;
                SetUp(weapon.cardName, weapon.description, 0, weapon.attackPower);
                break;
            default:
                Debug.LogWarning("Unhandled card type in CardView.");
                break;
        }
    }
    void SetUp(string name, string description, int hp, int attack)
    {
        if (nameText != null) nameText.text = name;
        if (descriptionText != null) descriptionText.text = description;
        if (hpText != null) hpText.text = $"HP: {hp}";
        if (attackText != null) attackText.text = $"ATK: {attack}";
    }
}

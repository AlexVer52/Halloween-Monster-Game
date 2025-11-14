using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;

public class MonsterCardView : MonoBehaviour
{
    public MonsterCard cardData;
    public Text id;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    //public Image artworkImage;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI rewardTotal;
    void Start()
    {
        if (cardData != null)
        {
            nameText.text = cardData.cardName;
            //descriptionText.text = cardData.description;
            Debug.Log("Monster HP: " + cardData.hp.ToString());
            hp.text = cardData.hp.ToString();
            Debug.Log("Reward VP: " + cardData.rewardVP.ToString());
            if (cardData.rewardVP != 0 && cardData.rewardWeapon != null)
                rewardTotal.text = cardData.rewardVP.ToString() + " Victory Points and " + cardData.rewardWeapon;
            if (cardData.rewardVP != 0 && cardData.rewardWeapon == null)
                rewardTotal.text = cardData.rewardVP.ToString() + " Victory Points ";
            if (cardData.rewardVP == 0 && cardData.rewardWeapon != null)
                rewardTotal.text = cardData.rewardWeapon;
            if (cardData.rewardVP == 0 && cardData.rewardWeapon == null)
                rewardTotal.text = "No Rewards";
            //artworkImage.sprite = cardData.artwork;
        }
    }
}

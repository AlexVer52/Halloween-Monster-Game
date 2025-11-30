using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;

public class MonsterCardView : MonoBehaviour
{
    public MonsterCard cardData;

    [Header("UI References")]
    public GameObject cardFront;
    public GameObject cardBack;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI rewardVP;
    //public TextMeshProUGUI rewardWeapon;
    public bool isFaceUp;
    public Image artworkImage;
    void Start()
    {
        if (cardData != null)
        {
            nameText.text = cardData.cardName;
            descriptionText.text = cardData.description;
            hp.text = cardData.hp.ToString();
            if (cardData.rewardVP != 0)
                rewardVP.text = cardData.rewardVP.ToString();
            else
                rewardVP.text = "0";

            //if (cardData.rewardWeapon != null)
            //    rewardWeapon.text = cardData.rewardWeapon.ToString();

            artworkImage.sprite = cardData.artwork;
        }
        UpdateCardFace();
    }

    void Update()
    {
        UpdateCardFace();
    }

    void UpdateCardFace()
    {
        if (isFaceUp)
        {
            cardFront.SetActive(true);
            cardBack.SetActive(false);
        }
        else
        {
            cardFront.SetActive(false);
            cardBack.SetActive(true);
        }
    }
}

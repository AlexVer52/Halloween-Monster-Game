using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerCardView : MonoBehaviour
{
    public PlayerCard cardData;
    public TextMeshProUGUI id;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    //public Image artworkImage;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI stuff;

    void Start()
    {
        if (cardData != null)
        {
            nameText.text = cardData.cardName;
            //descriptionText.text = cardData.description;
            hp.text = cardData.hp.ToString();
            //stuff.text = cardData.stuff;
            //artworkImage.sprite = cardData.artwork;
        }
    }
}

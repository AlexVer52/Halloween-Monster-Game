using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;

public class WeaponCardView : MonoBehaviour
{
    public WeaponCard cardData;
    public TextMeshProUGUI id;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    //public Image artworkImage;
    public TextMeshProUGUI attackPower;

    void Start()
    {
        if (cardData != null)
        {
            nameText.text = cardData.cardName;
            descriptionText.text = cardData.description;
            attackPower.text = cardData.attackPower.ToString();
            //artworkImage.sprite = cardData.artwork;
        }
    }
}

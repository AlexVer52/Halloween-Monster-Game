using UnityEngine;

public class CardBackDisplay : MonoBehaviour
{
    public GameObject cardBack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MonsterCardView.staticCardback == true)
        {
            cardBack.SetActive(false);
        }
        else
        {
            cardBack.SetActive(true);
        }
    }
}

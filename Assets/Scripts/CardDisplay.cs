using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI cardDescription;
    public Image artworkImage;
    public TextMeshProUGUI manaValue;
    public TextMeshProUGUI attackValue;
    public TextMeshProUGUI healthValue;
    public Button cardButton;

    // Start is called before the first frame update
    void Start()
    {
        cardName.text = card.cardName;
        cardDescription.text = card.description;
        artworkImage.sprite = card.artwork;
        manaValue.text = card.mana.ToString();
        attackValue.text = card.attack.ToString();
        healthValue.text = card.health.ToString();
        cardButton = card.button;     
    }
}

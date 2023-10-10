using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEditor;

public class FormManager : MonoBehaviour
{
    public TMP_InputField[] formInputs = new TMP_InputField[5];
    public TMP_Dropdown artworkDropdown;
    public TextMeshProUGUI[] cardPreviewInputs = new TextMeshProUGUI[5];
    public Image cardPreviewArtwork;
    public GameObject errorMessage;
    public void GetArtwork()
    {
        List<string> l = new List<string>();
        foreach(Sprite spr in Resources.LoadAll("Imports/Artwork", typeof(Sprite)))
        {
            l.Add(spr.name);
        }
        artworkDropdown.AddOptions(l);
        for(int i = 0; i < artworkDropdown.options.Count; i++)
        {
            //artworkDropdown.optio 
        }
    }

    public void ResetCreateForm()
    {
        for(int i = 0; i < formInputs.Length; i++)
        {
            formInputs[i].text = "";
        }
        artworkDropdown.value = 0;
        errorMessage.SetActive(false);
    }
    //ON VALUE CHANGE
    public void NameChange()
    {
        string t = formInputs[0].text; 
        cardPreviewInputs[0].text = t;
    }

    public void DescriptionChange()
    {
        string t = formInputs[1].text; 
        cardPreviewInputs[1].text = t;
    }

    public void ArtworkChange()
    {
        string str = artworkDropdown.options[artworkDropdown.value].text;
        cardPreviewArtwork.sprite = Resources.Load<Sprite>("Imports/Artwork/" + str);
    }

    public void ManaChange()
    {
        string t = formInputs[2].text;
        cardPreviewInputs[2].text = t;
    }
    public void AttackChange()
    {
        string t = formInputs[3].text; 
        cardPreviewInputs[3].text = t;
    }
    public void HealthChange()
    {
        string t = formInputs[4].text; 
        cardPreviewInputs[4].text = t;
    }
    
    public bool ValidateForm()
    {
        for(int i = 0; i < formInputs.Length; i++)
        {
            if(formInputs[i].text == "")
            {
                errorMessage.SetActive(true);
                return false;
            }            
        }
        if(artworkDropdown.value == 0)
        {
            errorMessage.SetActive(true);
            return false;
        }
        return true;
    }
    public void CreateCard()
    {
        Card c = Card.CreateInstance<Card>();
        c.cardName = formInputs[0].text;
        c.description = formInputs[1].text;
        c.mana = int.Parse(formInputs[2].text);
        c.attack = int.Parse(formInputs[3].text);
        c.health = int.Parse(formInputs[4].text);
        string str = artworkDropdown.options[artworkDropdown.value].text;
        c.artwork = Resources.Load<Sprite>("Imports/Artwork/" + str);
        AssetDatabase.CreateAsset(c, "Assets/Resources/Cards/" + c.cardName + ".asset");        
    }
    // Start is called before the first frame update
    void Start()
    {
        GetArtwork();
    }
}

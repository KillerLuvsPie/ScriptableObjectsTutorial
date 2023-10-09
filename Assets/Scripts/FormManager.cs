using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class FormManager : MonoBehaviour
{
    public TMP_InputField[] formInputs = new TMP_InputField[5];
    public TMP_Dropdown artworkDropdown;
    public TextMeshProUGUI[] cardPreviewInputs = new TextMeshProUGUI[5];
    public Image cardPreviewArtwork;
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
    
    // Start is called before the first frame update
    void Start()
    {
        GetArtwork();
    }
}

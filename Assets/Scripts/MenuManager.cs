using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    //MENU OBJECTS
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject collectionMenu;
    public GameObject cardViewMenu;
    public GameObject addCardMenu;
    public GameObject deleteConfirmation;
    //BUTTONS
    public Image deleteButtonImage;
    //MENU FUNCTIONALITY
    private bool delete = false;
    //MAIN MENU BUTTON FUNCTIONS
    public void CollectionButton()
    {
        collectionMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void OptionsButton()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    //COLLECTION BUTTONS
    public void CardButton()
    {
        if(delete == false)
        {
            cardViewMenu.SetActive(true);
            collectionMenu.SetActive(false); 
        }
        else
            deleteConfirmation.SetActive(true);
        
    }
    public void DeleteYes()
    {
        deleteConfirmation.SetActive(false);
    }
    public void DeleteNo()
    {
        deleteConfirmation.SetActive(false);
    }
    public void GoBackButton()
    {
        mainMenu.SetActive(true);
        collectionMenu.SetActive(false);
    }
    public void DeleteButton()
    {
        delete = !delete;
        if(delete == false)
        {
            deleteButtonImage.color = new Color(1,1,1,1);
        }
        else
        {
            deleteButtonImage.color = new Color(0,0.75f,1,1);
        }
    }
    //OPTIONS BUTTONS
    public void OptionsGoBack()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    void Start()
    {
        foreach(Card card in Resources.FindObjectsOfTypeAll<Card>())
        {
            CardData.cardList.Add(card);
        }
    }
}

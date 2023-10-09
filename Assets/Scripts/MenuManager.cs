using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public FormManager formManager;
    //MENU OBJECTS
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject collectionMenu;
    public GameObject cardViewMenu;
    public GameObject createCardMenu;
    public GameObject deleteConfirmation;
    //BUTTONS
    public Image deleteButtonImage;
    //COLLECTION GRID PLACEHOLDERS
    public GameObject[] placeholders = new GameObject[5];
    //MENU FUNCTIONALITY
    private bool delete = false;
    //FUNCTIONS
    //MAIN MENU BUTTONS
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
    public void GoBackButton()
    {
        mainMenu.SetActive(true);
        collectionMenu.SetActive(false);
    }
    public void DeleteYes()
    {
        deleteConfirmation.SetActive(false);
    }
    public void DeleteNo()
    {
        deleteConfirmation.SetActive(false);
    }
    public void DeleteButton()
    {
        delete = !delete;
        if(delete == false)
            deleteButtonImage.color = new Color(1,1,1,1);
        else
            deleteButtonImage.color = new Color(0,0.75f,1,1);
    }
    public void CreateCardMenuButton()
    {
        createCardMenu.SetActive(true);
        collectionMenu.SetActive(false);
    }
    //CREATE CARD BUTTONS
    public void CreateCardGoBack()
    {
        collectionMenu.SetActive(true);
        createCardMenu.SetActive(false);
        formManager.ResetCreateForm();
    }
    public void CreateCardButton()
    {
        createCardMenu.SetActive(false);
        formManager.ResetCreateForm();
    }

    //OPTIONS BUTTONS
    public void OptionsGoBack()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    
    //FEATURE FUNCTIONS
    private void LoadCardList()
    {
        foreach(Card card in Resources.LoadAll("Cards", typeof(Card)))
        {
            CardData.cardList.Add(card);
        }
    }

    //FORM FUNCTIONS
    
    

    

    void Start()
    {
        LoadCardList();
    }
}

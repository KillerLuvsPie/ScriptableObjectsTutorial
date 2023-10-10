using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Events;
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
    public Button deleteYesButton;
    //COLLECTION GRID PLACEHOLDERS
    public GameObject[] placeholders = new GameObject[5];
    public GameObject collectionViewport;
    //CARD PREFAB
    public GameObject cardPrefab;
    public CardDisplay cardView;
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
    public void CardButton(Card card)
    {
        if(delete == false)
        {
            cardView.BuildCard(card);
            cardViewMenu.SetActive(true);
            collectionMenu.SetActive(false);
        }
        else
        {
            deleteYesButton.onClick.RemoveAllListeners();
            deleteYesButton.onClick.AddListener(delegate {DeleteYes(card);});
            deleteConfirmation.SetActive(true);
        }
            
        
    }
    public void GoBackButton()
    {
        mainMenu.SetActive(true);
        collectionMenu.SetActive(false);
    }
    public void DeleteYes(Card card)
    {
        deleteConfirmation.SetActive(false);
        AssetDatabase.DeleteAsset("Assets/Resources/Cards/" + card.cardName + ".asset");
        LoadCardList();
        UpdateCardDisplay();
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
        if(formManager.ValidateForm() == true)
        {
            createCardMenu.SetActive(false);
            formManager.CreateCard();
            formManager.ResetCreateForm();
            LoadCardList();
            UpdateCardDisplay();
            collectionMenu.SetActive(true);
        }
    }
    //VIEW CARD BUTTONS
    public void CardViewGoBack()
    {
        collectionMenu.SetActive(true);
        cardViewMenu.SetActive(false);
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
        CardData.cardList.Clear();
        foreach(Card card in Resources.LoadAll("Cards", typeof(Card)))
        {
            CardData.cardList.Add(card);
            print(card);
        }
    }
    private void UpdateCardDisplay()
    {
        int d = collectionViewport.transform.childCount;
        while(d > 5)
        {
            d--;
            //print(collectionViewport.transform.GetChild(d).GameObject().name);
            if(collectionViewport.transform.GetChild(d).GameObject().name.Contains("Clone"))
                Destroy(collectionViewport.transform.GetChild(d).GameObject());
        }
        //yield return new WaitForSeconds(0.5f);
        int i = 0;
        int j = 0;
        foreach(Card card in CardData.cardList)
        {
            GameObject c = Instantiate(cardPrefab, placeholders[i].transform);
            RectTransform collectionViewportSize = collectionViewport.GetComponent<RectTransform>();
            c.transform.parent = collectionViewport.transform;
            c.transform.position = new Vector3(c.transform.position.x, c.transform.position.y + j*-325, c.transform.position.z);
            i++;
            if(i == 4)
                j += 1;
            CardDisplay cd = c.GetComponent<CardDisplay>();
            cd.BuildCard(card);
            Button b = c.GetComponentInChildren<Button>();
            b.onClick.AddListener(delegate {CardButton(card);});
        }        
    }
    void Start()
    {
        LoadCardList();
        UpdateCardDisplay();
    }
}

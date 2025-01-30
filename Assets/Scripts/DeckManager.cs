using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Inst {get;private set;}
    void Awake() => Inst = this;


    // For Card deck
    List<Item> cardList;

    [SerializeField]
    CardSO cardSO;
    [SerializeField]
    GameObject cardPrefab;


    const string URL = "https://docs.google.com/spreadsheets/d/1vTKQfIfWiSmaHZBsgp7q1rVpm4O8NUvD639-jLm60s4/export?format=tsv&range=A2:D9";

 
    private void OnDestroy() {
        cardSO.cards = null;
    }

    

  

    void GenerateCard()
    {
        float yVal = 490f;     
        
        
        foreach(var cardItem in cardList)
        {
            var cardObject = cardPrefab.transform.GetChild(0).gameObject;
            var rect = cardObject.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector3(0f,yVal,10f);
            var temp = Instantiate(cardPrefab, new Vector3(0f,yVal,0f),Quaternion.identity);
            var card = rect.GetComponent<Card>();
            card.Setup(cardItem);
            yVal -= 75f;
        }
        //Able to instantiate  card from prefab. Need to instantiate as many as the size of carlist
    }

   

    void shuffleCardDeck(List<Item> deck)
    {
        // Randomize the card order
        for(int i=0; i < deck.Count; i++)
        {
            int rand = Random.Range(i, deck.Count);
            Item temp = deck[i];
            deck[i] = deck[rand];
            deck[rand] = temp;
        }
    }

    public IEnumerator cardSetUpCo()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
            yield return www.SendWebRequest();
            string data= www.downloadHandler.text;
            SetCardDeck(data);
    }

    void SetCardDeck(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int colSize = row[0].Split('\t').Length;

        // counter value for do-while loop
        int counter =0;

        //Initialize card list with the number of cards
        cardSO.cards = new Item[rowSize];
        cardList = new List<Item>();
        for(int i =0; i <rowSize; i++)
        {
            string[] col = row[i].Split('\t');
            do{
                Item targetCard = new Item();

                // Assign name
                targetCard.name = col[counter++];

                // Assign cardType
                switch(col[counter++].ToUpper())
                {
                    case "GEM" : targetCard.eCardType = ECardType.Gem;
                    break;
                    case "RELIC" : targetCard.eCardType = ECardType.Relic;
                    break;
                    case "SPELL" : targetCard.eCardType = ECardType.Spell;
                    break;
                    default:
                    break;
                }

                // Assign cardCost
                switch(col[counter++].ToString())
                {
                    case "0": targetCard.eCarCost = ECardCost.c0;
                    break;
                    case "1": targetCard.eCarCost = ECardCost.c1;
                    break;
                    case "2": targetCard.eCarCost = ECardCost.c2;
                    break;
                    case "3": targetCard.eCarCost = ECardCost.c3;
                    break;
                    case "4": targetCard.eCarCost = ECardCost.c4;
                    break;
                    case "5": targetCard.eCarCost = ECardCost.c5;
                    break;
                    case "6": targetCard.eCarCost = ECardCost.c6;
                    break;
                    case "7": targetCard.eCarCost = ECardCost.c7;
                    break;
                    case "8": targetCard.eCarCost = ECardCost.c8;
                    break;
                    default:
                    break;
                }

                // Assign description
                targetCard.description = col[counter++];
                
                
                // Assign cardNumb
                targetCard.cardNum = 1;

                // Add to the array
                cardSO.cards[i] = targetCard;
                cardList.Add(targetCard);
            }while(counter < colSize);
            counter =0;
        }
        shuffleCardDeck(cardList);
        GenerateCard();
    }
    

    
}

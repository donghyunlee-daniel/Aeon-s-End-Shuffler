using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Inst { get; private set; }
    void Awake() => Inst = this;


    // For Card deck
    public List<Item> gemList, spellList, relicList;
    public List<Item> cardResult;

    [SerializeField]
    CardSO cardSO;
    [SerializeField]
    GameObject cardPrefab;

    [SerializeField]
    public Transform parent;

    [SerializeField]
    GameObject scrollView;


    const string URL = "https://docs.google.com/spreadsheets/d/1vTKQfIfWiSmaHZBsgp7q1rVpm4O8NUvD639-jLm60s4/export?format=tsv";

    

    private void OnDestroy()
    {
        cardSO.cards = null;
    }

    // Prompt users to choose cards each list (gems, spells, relics)
    // UI pops up and select cards
    // At the final UI, show users selected cards
    // Needed for panel. 
    
    // TabView is needed

    // Checkbox for boost mode (1.5 / 2.0)
    // Boost mode for card Cost
    // Input for the number of fixed card
    // 




    public void GenerateCard()
    {
        scrollView.SetActive(true);
        for(int i =0; i <relicList.Count; i++)
        {
            var item = Instantiate(cardPrefab);
            item.transform.Find("nameTxt").GetComponent<TMP_Text>().text = relicList[i].name;
            item.transform.Find("costTxt").GetComponent<TMP_Text>().text = relicList[i].eCarCost.ToString();
            item.transform.Find("typeTxt").GetComponent<TMP_Text>().text = relicList[i].eCardType.ToString();
            item.transform.SetParent(parent);
            item.transform.localScale = Vector2.one;
        }
        for(int i =0; i <spellList.Count; i++)
        {
            var item = Instantiate(cardPrefab);
            item.transform.Find("nameTxt").GetComponent<TMP_Text>().text = spellList[i].name;
            item.transform.Find("costTxt").GetComponent<TMP_Text>().text = spellList[i].eCarCost.ToString();
            item.transform.Find("typeTxt").GetComponent<TMP_Text>().text = spellList[i].eCardType.ToString();
            item.transform.SetParent(parent);
            item.transform.localScale = Vector2.one;
        }
        for(int i =0; i <gemList.Count; i++)
        {
            var item = Instantiate(cardPrefab);
            item.transform.Find("nameTxt").GetComponent<TMP_Text>().text = gemList[i].name;
            item.transform.Find("costTxt").GetComponent<TMP_Text>().text = gemList[i].eCarCost.ToString();
            item.transform.Find("typeTxt").GetComponent<TMP_Text>().text = gemList[i].eCardType.ToString();
            item.transform.SetParent(parent);
            item.transform.localScale = Vector2.one;
        }
        
    }

    // After use press Shuffle
    // Shuffle card deck with user input
    // SHuffleCardDeck needs boostMode, totalCard, cardCost, cardChoose

    public List<Item> shuffleCardDeck(List<Item> deck, ECardCost cardCost, int total, int choose)
    {
        // 1. get guranteed card into the list
        cardResult = new List<Item>();
        var temp = deck.FindAll(item => item.eCarCost == cardCost);
        while(choose >0 && temp.Count >0){
            int rand = Random.Range(0,temp.Count);
            string tempStr = temp[rand].name;
            cardResult.Add(temp[rand]);
            temp.RemoveAt(rand);
            deck.Remove(deck.Find(temp => temp.name == tempStr));
            choose --;
            total--;
        };

        // 2. Fill the list with the rest randomly
        while(total > 0)
        {
            int rand = Random.Range(0,deck.Count);
            string tempStr = deck[rand].name;
            cardResult.Add(deck[rand]);
            deck.Remove(deck.Find(temp => temp.name == tempStr));
            total --;
        }

       
        
        // 3. Sort the list based on cardCost order
       cardResult = cardResult.OrderBy(item => item.eCarCost).ToList();
       
       return cardResult;
    }

    public IEnumerator cardSetUpCo()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();
        string data = www.downloadHandler.text;
        SetCardDeck(data);
    }

    void SetCardDeck(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int colSize = row[0].Split('\t').Length;

        // counter value for do-while loop
        int counter = 0;

        //Initialize card list with the number of cards
        cardSO.cards = new Item[rowSize];
        gemList = new List<Item>();
        relicList = new List<Item>();
        spellList = new List<Item>();
        for (int i = 0; i < rowSize; i++)
        {
            string[] col = row[i].Split('\t');
            do
            {
                Item targetCard = new Item();

                // Assign name
                targetCard.name = col[counter++];

                // Assign cardType
                switch (col[counter++].ToUpper())
                {
                    case "GEM":
                        targetCard.eCardType = ECardType.Gem;
                        break;
                    case "RELIC":
                        targetCard.eCardType = ECardType.Relic;
                        break;
                    case "SPELL":
                        targetCard.eCardType = ECardType.Spell;
                        break;
                    default:
                        break;
                }

                // Assign cardCost
                switch (col[counter++].ToString())
                {
                    case "0":
                        targetCard.eCarCost = ECardCost.C0;
                        break;
                    case "1":
                        targetCard.eCarCost = ECardCost.C1;
                        break;
                    case "2":
                        targetCard.eCarCost = ECardCost.C2;
                        break;
                    case "3":
                        targetCard.eCarCost = ECardCost.C3;
                        break;
                    case "4":
                        targetCard.eCarCost = ECardCost.C4;
                        break;
                    case "5":
                        targetCard.eCarCost = ECardCost.C5;
                        break;
                    case "6":
                        targetCard.eCarCost = ECardCost.C6;
                        break;
                    case "7":
                        targetCard.eCarCost = ECardCost.C7;
                        break;
                    case "8":
                        targetCard.eCarCost = ECardCost.C8;
                        break;
                    default:
                        break;
                }

                // Assign description
                targetCard.description = col[counter++];


                // Add to the array
                cardSO.cards[i] = targetCard;
                switch (targetCard.eCardType.ToString())
                {
                    case "Gem":
                        gemList.Add(targetCard);
                        break;
                    case "Relic":
                        relicList.Add(targetCard);
                        break;
                    case "Spell":
                        spellList.Add(targetCard);
                        break;
                    default:
                        break;
                }
            } while (counter < colSize);
            counter = 0;
        }
    }



}

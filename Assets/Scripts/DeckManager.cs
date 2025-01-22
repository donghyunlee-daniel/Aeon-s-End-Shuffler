using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DeckManager : MonoBehaviour
{
    [SerializeField]
    CardSO cardSO;

    const string URL = "https://docs.google.com/spreadsheets/d/1vTKQfIfWiSmaHZBsgp7q1rVpm4O8NUvD639-jLm60s4/export?format=tsv&range=A2:D9";

    IEnumerator DownloadCardSO()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data= www.downloadHandler.text;

        SetCardSO(data);
        
    }

    void SetCardSO(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int colSize = row[0].Split('\t').Length;


        // counter value for do-while loop
        int counter =0;

        //Initialize card list with the number of cards
        cardSO.cards = new Card[rowSize];
        
        for(int i =0; i <rowSize; i++)
        {
            string[] col = row[i].Split('\t');

            do{
                Card targetCard = new Card();

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
                

                // Add to the array
                cardSO.cards[i] = targetCard;
            }while(counter < colSize);
            counter =0;
        }
    }
    void Start()
    {
        StartCoroutine(DownloadCardSO());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

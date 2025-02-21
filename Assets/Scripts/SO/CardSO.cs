using UnityEngine;

// Enum for CardType
public enum ECardType { Gem, Relic, Spell };

// Enum for CardCost
public enum ECardCost { RANDOM, C0, C1, C2, C3, C4, C5, C6, C7, C8 };

[System.Serializable]
public class Item
{
    // Card info (name, type, cost, description, image)
    public string name;
    public ECardType eCardType;
    public ECardCost eCarCost;
    public string description;



}


[CreateAssetMenu(fileName = "CardSO", menuName = "Scriptable Objects/CardSO")]
public class CardSO : ScriptableObject
{
    public Item[] cards;
}

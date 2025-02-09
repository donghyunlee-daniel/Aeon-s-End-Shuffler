using UnityEngine;

// Enum for CardType
public enum ECardType {Gem, Relic, Spell};

// Enum for CardCost
public enum ECardCost{c0,c1, c2, c3, c4,c5,c6,c7,c8};

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

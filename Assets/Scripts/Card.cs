using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    [SerializeField] TMP_Text nameTMP;
    [SerializeField] TMP_Text costTMP;
    [SerializeField] TMP_Text typeTMP;
    

    public Item item;

    public void Setup(Item item)
    {
        nameTMP.text = item.name;
        costTMP.text = item.eCarCost.ToString();
        typeTMP.text = item.eCardType.ToString();
    }
}

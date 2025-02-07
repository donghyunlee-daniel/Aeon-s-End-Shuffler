using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Inst{get; private set;}
    void Awake()
    {
        Inst = this;
        var bToggleGroup = tab1.transform.Find("BoostToggleGroup");
        check1 = bToggleGroup.transform.Find("1.5CheckBox").GetComponent<Toggle>();
        check2 = bToggleGroup.transform.Find("2.0CheckBox").GetComponent<Toggle>();

        slider = tab1.transform.Find("CardNumSlider").GetComponent<Slider>();
        
    }
    [SerializeField]
    GameObject tab1;

    [SerializeField]
    GameObject tab2;

    [SerializeField]
    GameObject tab3;


    // variables for Setting data
    float boost;
    ECardCost cardCost;
    int cardInput, totalCard;

    Toggle check1, check2;
    Slider slider;


    void Start(){
        check1.onValueChanged.AddListener(delegate {ToggleClick();});
        check2.onValueChanged.AddListener(delegate {ToggleClick();});
        slider.onValueChanged.AddListener(delegate {SliderChange();});
    }

    void GetCardCostVaue()
    {

        // Setting for cardCost
        int counter = 0;
        Toggle[] cToggleArray = tab1.transform.Find("CostToggleGroup").GetComponentsInChildren<Toggle>();
        foreach(Toggle toggle in cToggleArray)
        {
            if(toggle.isOn == true)
                cardCost = (ECardCost)Enum.GetValues(cardCost.GetType()).GetValue(counter);
            counter++;
        }       
    }

    public void SaveSetting()
    {
        GetCardCostVaue();
    }

    
    public void ToggleClick()
    {
        if(check1.isOn)
        {
            totalCard = 3;
            boost = 1.5f;
            totalCard = (int)(totalCard * boost);
            tab1.transform.Find("CardNumSlider").GetComponent<Slider>().maxValue = totalCard;
            tab1.transform.Find("TotalCardNum_val").GetComponent<TMP_Text>().text = totalCard.ToString();
        }
        else if(check2.isOn)
        {
            totalCard = 3;
            boost = 2.0f;
            totalCard = (int)(totalCard * boost);
            tab1.transform.Find("CardNumSlider").GetComponent<Slider>().maxValue = totalCard;
            tab1.transform.Find("TotalCardNum_val").GetComponent<TMP_Text>().text = totalCard.ToString();
        }
        else
        {
            totalCard = 3;
            boost = 1;
            tab1.transform.Find("CardNumSlider").GetComponent<Slider>().maxValue = totalCard;
            tab1.transform.Find("TotalCardNum_val").GetComponent<TMP_Text>().text = totalCard.ToString();
        }
    }

    public void SliderChange()
    {
        cardInput = (int)slider.value;
    }

}

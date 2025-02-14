using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Inst { get; private set; }

    [SerializeField]
    GameObject tab1;

    [SerializeField]
    GameObject tab2;

    [SerializeField]
    GameObject tab3;
    
    [SerializeField]
    GameObject notification;

    [SerializeField]
    Button saveBtn;

    // Awake -> instantiate each setting values
    // Start -> Add Listener


    // variables for Setting data
    float relic_boost, spell_boost, gem_boost;
    ECardCost relic_cardCost, spell_cardCost, gem_cardCost;
    int relic_cardChoose, relic_totalCard, spell_cardChoose, spell_totalCrad, gem_cardChoose, gem_totalCard;

    Toggle relic_check1, relic_check2, spell_check1, spell_check2, gem_check1, gem_check2;
    Slider relic_slider, spell_slider, gem_slider;

    void Awake()
    {
        StartSetup(tab1);
        //StartSetup(tab2);
        //StartSetup(tab3);       
    }

    void Start()
    {
        relic_check1.onValueChanged.AddListener(delegate {RelicToggleClick(); });
        relic_check2.onValueChanged.AddListener(delegate {RelicToggleClick();});
        relic_slider.onValueChanged.AddListener(delegate {RelicSliderChange();});
    }

  


    void StartSetup(GameObject tab)
    {
        if (tab.name == "Tab1_Relic")
        {
            relic_check1 = tab.transform.Find("BoostToggleGroup").transform.Find("1.5CheckBox").GetComponent<Toggle>();
            relic_check2 = tab.transform.Find("BoostToggleGroup").transform.Find("2.0CheckBox").GetComponent<Toggle>();
            relic_slider = tab.transform.Find("CardNumSlider").GetComponent<Slider>();
        }
        if (tab.name == "Tab2_Spell")
        {
            spell_check1 = tab.transform.Find("BoostToggleGroup").transform.Find("1.5CheckBox").GetComponent<Toggle>();
            spell_check2 = tab.transform.Find("BoostToggleGroup").transform.Find("2.0CheckBox").GetComponent<Toggle>();
        }
        if (tab.name == "Tab3_Gem")
        {
            gem_check1 = tab.transform.Find("BoostToggleGroup").transform.Find("1.5CheckBox").GetComponent<Toggle>();
            gem_check2 = tab.transform.Find("BoostToggleGroup").transform.Find("2.0CheckBox").GetComponent<Toggle>();
        }


    }

    public void RelicToggleClick()
    {
        if (relic_check1.isOn)
        {
            relic_totalCard = 3;
            relic_boost = 1.5f;
            relic_totalCard = (int)(relic_totalCard * relic_boost);
            relic_slider.maxValue = relic_totalCard;
            tab1.transform.Find("TotalCardNum_val").GetComponent<TMP_Text>().text = relic_totalCard.ToString();
        }
        else if (relic_check2.isOn)
        {
            relic_totalCard = 3;
            relic_boost = 2.0f;
            relic_totalCard = (int)(relic_totalCard * relic_boost);
            relic_slider.maxValue = relic_totalCard;
            tab1.transform.Find("TotalCardNum_val").GetComponent<TMP_Text>().text = relic_totalCard.ToString();
        }
        else
        {
            relic_totalCard = 3;
            relic_boost = 1;
            relic_slider.maxValue = relic_totalCard;
            tab1.transform.Find("TotalCardNum_val").GetComponent<TMP_Text>().text = relic_totalCard.ToString();
        }
    }

    public void RelicSliderChange()
    {
        relic_cardChoose = (int)relic_slider.value;
        tab1.transform.Find("CardNumVal").GetComponent<TMP_Text>().text = relic_cardChoose.ToString();

    }

    public void RelictCardCostChange()
    {

        // Setting for cardCost
        int counter = 0;
        Toggle[] cToggleArray = tab1.transform.Find("CostToggleGroup").GetComponentsInChildren<Toggle>();
        foreach(Toggle toggle in cToggleArray)
        {
            if(toggle.isOn == true)
                {
                    relic_cardCost = (ECardCost)Enum.GetValues(relic_cardCost.GetType()).GetValue(counter);
                }
            counter++;
        }
    }

      public void btnSave()
    {
        RelictCardCostChange();
        notification.transform.Find("NotificationTxt").GetComponent<TMP_Text>().text 
        = $"You will get {relic_cardChoose} {relic_cardCost} card(s) and the rest({relic_totalCard-relic_cardChoose}) will be randomly generated";
        notification.SetActive(true);
        saveBtn.gameObject.SetActive(false);
    }

    public void btnCancel()
    {
        notification.SetActive(false);
        saveBtn.gameObject.SetActive(true);
    }

    public void btnNext()
    {
        
    }


}

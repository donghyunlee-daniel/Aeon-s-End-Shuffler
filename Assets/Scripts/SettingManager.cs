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
    GameObject tabMenu;

    




    // Awake -> instantiate each setting values
    // Start -> Add Listener


    // variables for Setting data
    float relic_boost, spell_boost, gem_boost;
    ECardCost relic_cardCost, spell_cardCost, gem_cardCost;
    int relic_cardChoose, relic_totalCard, spell_cardChoose, spell_totalCard, gem_cardChoose, gem_totalCard;

    Toggle relic_check1, relic_check2, spell_check1, spell_check2, gem_check1, gem_check2;
    Slider relic_slider, spell_slider, gem_slider;

    void Awake()
    {
        StartSetup(tab1);
        StartSetup(tab2);
        StartSetup(tab3);
    }

    void Start()
    {
        relic_check1.onValueChanged.AddListener(delegate { ToggleClick(tab1); });
        relic_check2.onValueChanged.AddListener(delegate { ToggleClick(tab1); });
        relic_slider.onValueChanged.AddListener(delegate { SliderChange(tab1); });
        spell_check1.onValueChanged.AddListener(delegate { ToggleClick(tab2); });
        spell_check2.onValueChanged.AddListener(delegate { ToggleClick(tab2); });
        spell_slider.onValueChanged.AddListener(delegate { SliderChange(tab2); });
        gem_check1.onValueChanged.AddListener(delegate { ToggleClick(tab3); });
        gem_check2.onValueChanged.AddListener(delegate { ToggleClick(tab3); });
        gem_slider.onValueChanged.AddListener(delegate { SliderChange(tab3); });

    }




    void StartSetup(GameObject tab)
    {
        switch (tab.name)
        {
            case "Tab1_Relic":
                {
                    relic_check1 = tab.transform.Find("BoostToggleGroup").transform.Find("1.5CheckBox").GetComponent<Toggle>();
                    relic_check2 = tab.transform.Find("BoostToggleGroup").transform.Find("2.0CheckBox").GetComponent<Toggle>();
                    relic_slider = tab.transform.Find("CardNumSlider").GetComponent<Slider>();
                }
                break;
            case "Tab2_Spell":
                {
                    spell_check1 = tab.transform.Find("BoostToggleGroup").transform.Find("1.5CheckBox").GetComponent<Toggle>();
                    spell_check2 = tab.transform.Find("BoostToggleGroup").transform.Find("2.0CheckBox").GetComponent<Toggle>();
                    spell_slider = tab.transform.Find("CardNumSlider").GetComponent<Slider>();
                }
                break;

            case "Tab3_Gem":
                {
                    gem_check1 = tab.transform.Find("BoostToggleGroup").transform.Find("1.5CheckBox").GetComponent<Toggle>();
                    gem_check2 = tab.transform.Find("BoostToggleGroup").transform.Find("2.0CheckBox").GetComponent<Toggle>();
                    gem_slider = tab.transform.Find("CardNumSlider").GetComponent<Slider>();
                }
                break;
            default:
                break;
        }

    }

    void BoostModeOn(GameObject tab, Toggle check1, Toggle check2)
    {
        switch (tab.name)
        {
            case "Tab1_Relic":
                {
                    if (check1.isOn)
                    {
                        relic_totalCard = 2;
                        relic_boost = 1.5f;
                        relic_totalCard = (int)(relic_totalCard * relic_boost);
                        relic_slider.maxValue = relic_totalCard;
                        tab.transform.Find("TotalCardNum_val").GetComponent<TMP_Text>().text = relic_totalCard.ToString();
                    }
                    else if (check2.isOn)
                    {
                        relic_totalCard = 2;
                        relic_boost = 2.0f;
                        relic_totalCard = (int)(relic_totalCard * relic_boost);
                        relic_slider.maxValue = relic_totalCard;
                        tab.transform.Find("TotalCardNum_val").GetComponent<TMP_Text>().text = relic_totalCard.ToString();
                    }
                    else
                    {
                        relic_totalCard = 2;
                        relic_boost = 1;
                        relic_slider.maxValue = relic_totalCard;
                        tab.transform.Find("TotalCardNum_val").GetComponent<TMP_Text>().text = relic_totalCard.ToString();
                    }
                }
                break;
            case "Tab2_Spell":
                {
                    if (check1.isOn)
                    {
                        spell_totalCard = 4;
                        spell_boost = 1.5f;
                        spell_totalCard = (int)(spell_totalCard * spell_boost);
                        spell_slider.maxValue = spell_totalCard;
                        tab.transform.Find("TotalCardNum_val").GetComponent<TMP_Text>().text = spell_totalCard.ToString();
                    }
                    else if (check2.isOn)
                    {
                        spell_totalCard = 4;
                        spell_boost = 2.0f;
                        spell_totalCard = (int)(spell_totalCard * spell_boost);
                        spell_slider.maxValue = spell_totalCard;
                        tab.transform.Find("TotalCardNum_val").GetComponent<TMP_Text>().text = spell_totalCard.ToString();
                    }
                    else
                    {
                        spell_totalCard = 4;
                        spell_boost = 1;
                        spell_slider.maxValue = spell_totalCard;
                        tab.transform.Find("TotalCardNum_val").GetComponent<TMP_Text>().text = spell_totalCard.ToString();
                    }
                }
                break;

            case "Tab3_Gem":
                {
                    if (check1.isOn)
                    {
                        gem_totalCard = 3;
                        gem_boost = 1.5f;
                        gem_totalCard = (int)(gem_totalCard * gem_boost);
                        gem_slider.maxValue = gem_totalCard;
                        tab.transform.Find("TotalCardNum_val").GetComponent<TMP_Text>().text = gem_totalCard.ToString();
                    }
                    else if (check2.isOn)
                    {
                        gem_totalCard = 3;
                        gem_boost = 2.0f;
                        gem_totalCard = (int)(gem_totalCard * gem_boost);
                        gem_slider.maxValue = gem_totalCard;
                        tab.transform.Find("TotalCardNum_val").GetComponent<TMP_Text>().text = gem_totalCard.ToString();
                    }
                    else
                    {
                        gem_totalCard = 3;
                        gem_boost = 1;
                        gem_slider.maxValue = gem_totalCard;
                        tab.transform.Find("TotalCardNum_val").GetComponent<TMP_Text>().text = gem_totalCard.ToString();
                    }
                }
                break;
            default:
                break;
        }
    }
    public void ToggleClick(GameObject tab)
    {
        Toggle check1 = tab.transform.Find("BoostToggleGroup").transform.Find("1.5CheckBox").GetComponent<Toggle>();
        Toggle check2 = tab.transform.Find("BoostToggleGroup").transform.Find("2.0CheckBox").GetComponent<Toggle>();

        BoostModeOn(tab, check1, check2);


    }

    public void SliderChange(GameObject tab)
    {

        switch (tab.name)
        {
            case "Tab1_Relic":
                {
                    relic_cardChoose = (int)relic_slider.value;
                    tab.transform.Find("CardNumVal").GetComponent<TMP_Text>().text = relic_cardChoose.ToString();
                }
                break;
            case "Tab2_Spell":
                {
                    spell_cardChoose = (int)spell_slider.value;
                    tab.transform.Find("CardNumVal").GetComponent<TMP_Text>().text = spell_cardChoose.ToString();
                }
                break;

            case "Tab3_Gem":
                {
                    gem_cardChoose = (int)gem_slider.value;
                    tab.transform.Find("CardNumVal").GetComponent<TMP_Text>().text = gem_cardChoose.ToString();
                }
                break;
            default:
                break;
        }

    }

    public void CardCostChange(GameObject tab)
    {
        switch (tab.name)
        {
            case "Tab1_Relic":
                {
                    // Setting for cardCost
                    int counter = 1;
                    bool hasCostVal = false;
                    Toggle[] cToggleArray = tab.transform.Find("CostToggleGroup").GetComponentsInChildren<Toggle>();
                    foreach (Toggle toggle in cToggleArray)
                    {
                        if (toggle.isOn == true)
                        {
                            relic_cardCost = (ECardCost)Enum.GetValues(relic_cardCost.GetType()).GetValue(counter);
                            hasCostVal = true;
                        }
                        counter++;
                    }
                    if (hasCostVal == false)
                    {
                        relic_cardCost = (ECardCost)Enum.GetValues(relic_cardCost.GetType()).GetValue(0);
                    }

                }
                break;
            case "Tab2_Spell":
                {
                    // Setting for cardCost
                    int counter = 1;
                    bool hasCostVal = false;
                    Toggle[] cToggleArray = tab.transform.Find("CostToggleGroup").GetComponentsInChildren<Toggle>();
                    foreach (Toggle toggle in cToggleArray)
                    {
                        if (toggle.isOn == true)
                        {
                            spell_cardCost = (ECardCost)Enum.GetValues(spell_cardCost.GetType()).GetValue(counter);
                            hasCostVal = true;
                        }

                        counter++;
                    }
                    if (hasCostVal == false)
                    {
                        spell_cardCost = (ECardCost)Enum.GetValues(spell_cardCost.GetType()).GetValue(0);
                    }
                }
                break;

            case "Tab3_Gem":
                {
                    // Setting for cardCost
                    int counter = 1;
                    bool hasCostVal = false;
                    Toggle[] cToggleArray = tab.transform.Find("CostToggleGroup").GetComponentsInChildren<Toggle>();
                    foreach (Toggle toggle in cToggleArray)
                    {
                        if (toggle.isOn == true)
                        {
                            gem_cardCost = (ECardCost)Enum.GetValues(gem_cardCost.GetType()).GetValue(counter);
                            hasCostVal = true;
                        }

                        counter++;
                    }
                    if (hasCostVal == false)
                    {
                        gem_cardCost = (ECardCost)Enum.GetValues(gem_cardCost.GetType()).GetValue(0);
                    }
                }
                break;
            default:
                break;
        }


    }

    public void btnSave(GameObject tab)
    {
        switch (tab.name)
        {
            case "Tab1_Relic":
                {
                    CardCostChange(tab);
                    GameObject notification = tab.transform.Find("NotificationPanel").gameObject;
                    notification.transform.Find("NotificationTxt").GetComponent<TMP_Text>().text
                    = $"{relic_cardChoose} of your RELIC card(s) will be {relic_cardCost}, and the rest ({relic_totalCard - relic_cardChoose}) will be randomly generated";
                    notification.SetActive(true);
                    tab.transform.Find("SaveBtn").gameObject.SetActive(false);
                }
                break;
            case "Tab2_Spell":
                {
                    CardCostChange(tab);
                    GameObject notification = tab.transform.Find("NotificationPanel").gameObject;
                    notification.transform.Find("NotificationTxt").GetComponent<TMP_Text>().text
                    = $"{spell_cardChoose} of your SPELL card(s) will be {spell_cardCost}, and the rest ({spell_totalCard - spell_cardChoose}) will be randomly generated";
                    notification.SetActive(true);
                    tab.transform.Find("SaveBtn").gameObject.SetActive(false);
                }
                break;

            case "Tab3_Gem":
                {
                    CardCostChange(tab);
                    GameObject notification = tab.transform.Find("NotificationPanel").gameObject;
                    notification.transform.Find("NotificationTxt").GetComponent<TMP_Text>().text
                    = $"{gem_cardChoose} of your GEM card(s) will be {gem_cardCost}, and the rest ({gem_totalCard - gem_cardChoose}) will be randomly generated";
                    notification.SetActive(true);
                    tab.transform.Find("SaveBtn").gameObject.SetActive(false);
                }
                break;
            default:
                break;
        }

    }
    // Save buttons and Next buttons doesn't pop up properly in each tab
    public void btnCancel(GameObject tab)
    {
        switch (tab.name)
        {
            case "Tab1_Relic":
                {
                    GameObject notification = tab.transform.Find("NotificationPanel").gameObject;
                    notification.SetActive(false);
                    Button saveBtn = tab.transform.Find("SaveBtn").GetComponent<Button>();
                    saveBtn.gameObject.SetActive(true);
                }
                break;
            case "Tab2_Spell":
                {
                    GameObject notification = tab.transform.Find("NotificationPanel").gameObject;
                    notification.SetActive(false);
                    Button saveBtn = tab.transform.Find("SaveBtn").GetComponent<Button>();
                    saveBtn.gameObject.SetActive(true);
                }
                break;

            case "Tab3_Gem":
                {
                    GameObject notification = tab.transform.Find("NotificationPanel").gameObject;
                    notification.SetActive(false);
                    Button saveBtn = tab.transform.Find("SaveBtn").GetComponent<Button>();
                    saveBtn.gameObject.SetActive(true);
                }
                break;
            default:
                break;
        }

    }

    public void btnNext(GameObject tab)
    {
        switch (tab.name)
        {
            case "Tab1_Relic":
                {
                    TabsManager.Inst.SwitchToTab(TabsManager.Inst.currentTabID + 1);
                    GameObject notification = tab.transform.Find("NotificationPanel").gameObject;
                    notification.SetActive(false);
                }
                break;
            case "Tab2_Spell":
                {
                    TabsManager.Inst.SwitchToTab(TabsManager.Inst.currentTabID + 1);
                    GameObject notification = tab.transform.Find("NotificationPanel").gameObject;
                    notification.SetActive(false);
                }
                break;

            case "Tab3_Gem":
                {
                    GameObject notification = tab.transform.Find("NotificationPanel").gameObject;
                    notification.SetActive(false);
                    tabMenu.SetActive(false);
                    
                }
                break;
            default:
                break;
        }
    }


}

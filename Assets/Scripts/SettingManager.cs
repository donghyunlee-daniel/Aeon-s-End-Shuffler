using System;
using System.Collections.Generic;
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

    [SerializeField]
    GameObject cardPrefab;

    int relic_unselect = 0, spell_unselect = 0, gem_unselect = 0;
    int relic_maxCard = 2, spell_maxCard = 4, gem_maxCard = 3;



    // Awake -> instantiate each setting values
    // Start -> Add Listener


    // variables for Setting data
    float relic_boost, spell_boost, gem_boost;
    ECardCost relic_cardCost, spell_cardCost, gem_cardCost;
    int relic_cardChoose, relic_totalCard, spell_cardChoose, spell_totalCard, gem_cardChoose, gem_totalCard;

    Toggle relic_check1, relic_check2, spell_check1, spell_check2, gem_check1, gem_check2;
    Slider relic_slider, spell_slider, gem_slider;
    Button relicNextBtn, spellNextBtn, gemNextBtn;

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
                    relic_totalCard = 2;
                    relic_cardChoose = 0;
                    relicNextBtn = tab.transform.Find("NotificationPanel").transform.Find("NextBtn").GetComponent<Button>();
                }
                break;
            case "Tab2_Spell":
                {
                    spell_check1 = tab.transform.Find("BoostToggleGroup").transform.Find("1.5CheckBox").GetComponent<Toggle>();
                    spell_check2 = tab.transform.Find("BoostToggleGroup").transform.Find("2.0CheckBox").GetComponent<Toggle>();
                    spell_slider = tab.transform.Find("CardNumSlider").GetComponent<Slider>();
                    spell_totalCard = 4;
                    spell_cardChoose = 0;
                    spellNextBtn = tab.transform.Find("NotificationPanel").transform.Find("NextBtn").GetComponent<Button>();
                }
                break;

            case "Tab3_Gem":
                {
                    gem_check1 = tab.transform.Find("BoostToggleGroup").transform.Find("1.5CheckBox").GetComponent<Toggle>();
                    gem_check2 = tab.transform.Find("BoostToggleGroup").transform.Find("2.0CheckBox").GetComponent<Toggle>();
                    gem_slider = tab.transform.Find("CardNumSlider").GetComponent<Slider>();
                    gem_totalCard = 3;
                    gem_cardChoose = 0;
                    gemNextBtn = tab.transform.Find("NotificationPanel").transform.Find("NextBtn").GetComponent<Button>();
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
                    relicNextBtn.enabled = relic_totalCard == relic_maxCard ? true : false;
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
                    spellNextBtn.enabled = spell_totalCard == spell_maxCard ? true : false;
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
                    gemNextBtn.enabled = gem_totalCard == gem_maxCard ? true : false;
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
    public void OnMouseClick(GameObject item, GameObject tab)
    {
        Color32 redCol = new Color32(246, 78, 78, 255);
        Color32 grayCol = new Color32(180, 180, 180, 255);
        Image imageColor = item.GetComponent<Image>();

        switch (tab.name)
        {
            case "Tab1_Relic":
                if (relic_maxCard != relic_totalCard-relic_unselect)
                {
                    if (imageColor.color == redCol)
                    {
                        imageColor.color = grayCol;
                        relic_unselect--;
                    }
                    else
                    {
                        imageColor.color = redCol;
                        relic_unselect++;
                    }
                }
                else
                {
                    if (imageColor.color == redCol)
                    {
                        imageColor.color = grayCol;
                        relic_unselect--;
                    }
                }
                if (relic_maxCard == relic_totalCard - relic_unselect)
                {
                    relicNextBtn.enabled = true;
                    relicNextBtn.gameObject.GetComponent<Image>().color = new Color32(10, 36, 217, 255);
                }
                else
                {
                    relicNextBtn.enabled = false;
                    relicNextBtn.gameObject.GetComponent<Image>().color = new Color32(87, 100, 190, 255);
                }
                break;
            case "Tab2_Spell":
                if (spell_maxCard != spell_totalCard-spell_unselect)
                {
                    if (imageColor.color == redCol)
                    {
                        imageColor.color = grayCol;
                        spell_unselect--;
                    }
                    else
                    {
                        imageColor.color = redCol;
                        spell_unselect++;
                    }
                }
                else
                {
                    if (imageColor.color == redCol)
                    {
                        imageColor.color = grayCol;
                        spell_unselect--;
                    }
                }
                if (spell_maxCard == spell_totalCard - spell_unselect)
                {
                    spellNextBtn.enabled = true;
                    spellNextBtn.gameObject.GetComponent<Image>().color = new Color32(10, 36, 217, 255);
                }
                else
                {
                    spellNextBtn.enabled = false;
                    spellNextBtn.gameObject.GetComponent<Image>().color = new Color32(87, 100, 190, 255);
                }
                break;

            case "Tab3_Gem":
                if (gem_maxCard != gem_totalCard-gem_unselect)
                {
                    if (imageColor.color == redCol)
                    {
                        imageColor.color = grayCol;
                        gem_unselect--;
                    }
                    else
                    {
                        imageColor.color = redCol;
                        gem_unselect++;
                    }
                }
                else
                {
                    if (imageColor.color == redCol)
                    {
                        imageColor.color = grayCol;
                        gem_unselect--;
                    }
                }
                if (gem_maxCard == gem_totalCard - gem_unselect)
                {
                    gemNextBtn.enabled = true;
                    gemNextBtn.gameObject.GetComponent<Image>().color = new Color32(10, 36, 217, 255);
                }
                else
                {
                    gemNextBtn.enabled = false;
                    gemNextBtn.gameObject.GetComponent<Image>().color = new Color32(87, 100, 190, 255);
                }
                break;
            default:
                break;
        }


    }

    void ShowGeneratedCard(Transform parent, List<Item> deck, GameObject tab)
    {
        switch (tab.name)
        {
            case "Tab1_Relic":
                {
                    for (int i = 0; i < deck.Count; i++)
                    {
                        var item = Instantiate(cardPrefab);
                        var button = item.AddComponent<Button>();
                        item.transform.Find("nameTxt").GetComponent<TMP_Text>().text = deck[i].name;
                        item.transform.Find("costTxt").GetComponent<TMP_Text>().text = deck[i].eCarCost.ToString();
                        item.transform.Find("typeTxt").GetComponent<TMP_Text>().text = deck[i].eCardType.ToString();
                        item.transform.SetParent(parent);
                        item.transform.localScale = Vector2.one;
                        button.onClick.AddListener(() => OnMouseClick(item, tab));
                    }
                }
                break;
            case "Tab2_Spell":
                {
                    for (int i = 0; i < deck.Count; i++)
                    {
                        var item = Instantiate(cardPrefab);
                        var button = item.AddComponent<Button>();
                        item.transform.Find("nameTxt").GetComponent<TMP_Text>().text = deck[i].name;
                        item.transform.Find("costTxt").GetComponent<TMP_Text>().text = deck[i].eCarCost.ToString();
                        item.transform.Find("typeTxt").GetComponent<TMP_Text>().text = deck[i].eCardType.ToString();
                        item.transform.SetParent(parent);
                        item.transform.localScale = Vector2.one;
                        button.onClick.AddListener(() => OnMouseClick(item, tab));
                    }
                }
                break;

            case "Tab3_Gem":
                {
                    for (int i = 0; i < deck.Count; i++)
                    {
                        var item = Instantiate(cardPrefab);
                        var button = item.AddComponent<Button>();
                        item.transform.Find("nameTxt").GetComponent<TMP_Text>().text = deck[i].name;
                        item.transform.Find("costTxt").GetComponent<TMP_Text>().text = deck[i].eCarCost.ToString();
                        item.transform.Find("typeTxt").GetComponent<TMP_Text>().text = deck[i].eCardType.ToString();
                        item.transform.SetParent(parent);
                        item.transform.localScale = Vector2.one;
                        button.onClick.AddListener(() => OnMouseClick(item, tab));
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


                    DeckManager.Inst.relicList = DeckManager.Inst.shuffleCardDeck(DeckManager.Inst.relicList, relic_cardCost, relic_totalCard, relic_cardChoose);
                    GameObject scrollView = tab.transform.Find("Scroll View").gameObject;
                    Transform parent = scrollView.GetComponentInChildren<VerticalLayoutGroup>().GetComponent<Transform>();
                    ShowGeneratedCard(parent, DeckManager.Inst.relicList, tab);
                    scrollView.SetActive(true);
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
                    
                    DeckManager.Inst.spellList = DeckManager.Inst.shuffleCardDeck(DeckManager.Inst.spellList, spell_cardCost, spell_totalCard, spell_cardChoose);
                    GameObject scrollView = tab.transform.Find("Scroll View").gameObject;
                    Transform parent = scrollView.GetComponentInChildren<VerticalLayoutGroup>().GetComponent<Transform>();
                    ShowGeneratedCard(parent, DeckManager.Inst.spellList, tab);
                    scrollView.SetActive(true);
                }
                break;

            case "Tab3_Gem":
                {
                    CardCostChange(tab);
                    GameObject notification = tab.transform.Find("NotificationPanel").gameObject;
                    notification.transform.Find("NotificationTxt").GetComponent<TMP_Text>().text
                    = $"{gem_cardChoose} of your GEM card(s) will be {gem_cardCost}, and the rest ({gem_totalCard - gem_cardChoose}) will be randomly generated";
                    notification.SetActive(true);
                    notification.transform.Find("NextBtn").GetComponentInChildren<TMP_Text>().text = "Shuffle";
                    tab.transform.Find("SaveBtn").gameObject.SetActive(false);

                    DeckManager.Inst.gemList = DeckManager.Inst.shuffleCardDeck(DeckManager.Inst.gemList, gem_cardCost, gem_totalCard, gem_cardChoose);
                    GameObject scrollView = tab.transform.Find("Scroll View").gameObject;
                    Transform parent = scrollView.GetComponentInChildren<VerticalLayoutGroup>().GetComponent<Transform>();
                    ShowGeneratedCard(parent, DeckManager.Inst.gemList, tab);
                    scrollView.SetActive(true);
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
                    GameObject content = tab.transform.Find("Scroll View").GetComponentInChildren<VerticalLayoutGroup>().gameObject;
                    notification.SetActive(false);
                    Image[] imgArray = content.GetComponentsInChildren<Image>();
                    
                    foreach (var item in imgArray)
                    {
                        if (item.color == new Color32(246, 78, 78, 255))
                        {
                            string itemName = item.transform.Find("nameTxt").GetComponent<TMP_Text>().text;
                            DeckManager.Inst.relicList.Remove(DeckManager.Inst.relicList.Find(temp => temp.name == itemName));
                        }
                    }
                    
                }
                break;
            case "Tab2_Spell":
                {
                    TabsManager.Inst.SwitchToTab(TabsManager.Inst.currentTabID + 1);
                    GameObject notification = tab.transform.Find("NotificationPanel").gameObject;
                    GameObject content = tab.transform.Find("Scroll View").GetComponentInChildren<VerticalLayoutGroup>().gameObject;

                    notification.SetActive(false);
                    Image[] imgArray = content.GetComponentsInChildren<Image>();
                    
                    foreach (var item in imgArray)
                    {
                        if (item.color == new Color32(246, 78, 78, 255))
                        {
                            string itemName = item.transform.Find("nameTxt").GetComponent<TMP_Text>().text;
                            DeckManager.Inst.spellList.Remove(DeckManager.Inst.spellList.Find(temp => temp.name == itemName));
                        }
                    }
                    
                }
                break;

            case "Tab3_Gem":
                {
                    GameObject notification = tab.transform.Find("NotificationPanel").gameObject;
                    GameObject content = tab.transform.Find("Scroll View").GetComponentInChildren<VerticalLayoutGroup>().gameObject;

                    notification.SetActive(false);
                    tabMenu.SetActive(false);
                    Image[] imgArray = content.GetComponentsInChildren<Image>();
                    
                    foreach (var item in imgArray)
                    {
                        if (item.color == new Color32(246, 78, 78, 255))
                        {
                            string itemName = item.transform.Find("nameTxt").GetComponent<TMP_Text>().text;
                            DeckManager.Inst.gemList.Remove(DeckManager.Inst.gemList.Find(temp => temp.name == itemName));
                        }
                    }

                    
                    DeckManager.Inst.GenerateCard();
                }
                break;
            default:
                break;
        }

    }


}

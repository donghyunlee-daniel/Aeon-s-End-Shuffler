using UnityEngine;
using UnityEngine.UI;

public class TabsManager : MonoBehaviour
{
    public GameObject[] Tabs;
    public Image[] TabButtons;

    public Vector2 InactiveTabButtonSize, ActiveTabButtonSize;


    public void SwitchToTab(int TabID)
    {
        
        foreach (GameObject temp in Tabs)
        {
            temp.SetActive(false);
        }
        Tabs[TabID].SetActive(true);

        foreach (Image image in TabButtons)
        {
            image.transform.Find("BtnBackground").GetComponent<Image>().color = UnityEngine.Color.grey;
            image.transform.Find("BtnBackground").GetComponent<RectTransform>().sizeDelta = InactiveTabButtonSize;
        }
        TabButtons[TabID].transform.Find("BtnBackground").GetComponent<Image>().color = UnityEngine.Color.blue;
        TabButtons[TabID].transform.Find("BtnBackground").GetComponent<RectTransform>().sizeDelta = ActiveTabButtonSize;
    }
    
}

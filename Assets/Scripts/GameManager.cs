using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst{get;private set;}
    void Awake() => Inst = this;

    [SerializeField]
    Startpanel startPanel;

    void Start()
    {
        //UISetup();   
    }

    void UISetup()
    {
        //startPanel.Active(true);
    }

    public void StartGame()
    {
        StartCoroutine(DeckManager.Inst.cardSetUpCo());
    }

   
}

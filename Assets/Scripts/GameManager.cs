using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst{get;private set;}
    void Awake() => Inst = this;

    [SerializeField]
    TitlePanel titlePanel;

    void Start()
    {
        UISetup();   
    }

    void UISetup()
    {
        titlePanel.Active(true);
    }

    public void StartGame()
    {
        StartCoroutine(DeckManager.Inst.cardSetUpCo());

    }
}

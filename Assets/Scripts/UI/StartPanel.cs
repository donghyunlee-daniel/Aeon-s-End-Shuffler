using UnityEngine;

public class Startpanel : MonoBehaviour
{
    [SerializeField]
    GameObject TapMenu;
        public void StartGameClick()
    {

        GameManager.Inst.StartGame();
        gameObject.SetActive(false);
        TapMenu.SetActive(true);
        
    }

    public void Active(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
    
    
}

using UnityEngine;

public class Startpanel : MonoBehaviour
{
    public void StartGameClick()
    {
        GameManager.Inst.StartGame();
        
    }

    public void Active(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
    
    
}

using UnityEngine;

public class TitlePanel : MonoBehaviour
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

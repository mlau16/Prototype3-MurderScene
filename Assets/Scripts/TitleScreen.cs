using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] GameObject titlePanel;

    public void StartGame()
    {
        gameObject.SetActive(false); 
        GameManager.I.StartGame();   
    }

    public void ShowRules()
    {
        titlePanel.SetActive(true);
    }

    public void HideRules()
    {
        titlePanel.SetActive(false);
    }
}

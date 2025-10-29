using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public float timeLimit = 60f;
    public Text timerText, taskText, endText;

    float timeLeft;
    int stainsLeft, itemsLeft;
    bool ended = false;

    void Awake() => I = this;

    void Start()
    {
        timeLeft = timeLimit;
        var allStains = FindObjectsByType<CleaningBehavior>(FindObjectsSortMode.None);
        stainsLeft = allStains.Length;
        var allItems = FindObjectsByType<DragItems>(FindObjectsSortMode.None);
        itemsLeft = allItems.Length;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (ended) return;
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            EndGame(false);
        }
        UpdateUI();
    }

    public void OnCleaned()
    {
        stainsLeft--;
        CheckWin();
    }

    public void OnItemPlaced()
    {
        itemsLeft--;
        CheckWin();
    }

    void CheckWin()
    {
        if(itemsLeft <= 0 && stainsLeft <= 0){
            EndGame(true);
        }
    }

    void EndGame(bool win)
    {
        ended = true;
        endText.text = win ? "Scene Cleaned!" : "Time's Up";

    }

    void UpdateUI()
    {
        timerText.text = $"Time: {Mathf.CeilToInt(timeLeft)}";
        taskText.text = $"Stains: {stainsLeft} | Items: {itemsLeft}";
    }
}

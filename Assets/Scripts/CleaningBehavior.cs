using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CleaningBehavior : MonoBehaviour, IPointerDownHandler
{
    public float cleanTime = 1.5f;
    private SpriteRenderer sr;
    private bool cleaned = false;

    private Color dirtyColor;
    private Color cleanColor;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
        dirtyColor = sr.color;
        cleanColor = Color.white;
    } 

    public void OnPointerDown(PointerEventData eventData) 
    {
        if(cleaned) return;
        StartCoroutine(CleanRoutine());
    }

    private System.Collections.IEnumerator CleanRoutine()
    {
        float t = 0f;

        while(t < cleanTime)
        {
            t += Time.deltaTime;
            sr.color = Color.Lerp(dirtyColor, cleanColor, t / cleanTime);
            yield return null;
        }

        cleaned = true;
        sr.color = cleanColor;
        GameManager.I.OnCleaned(); 
    }
    
}

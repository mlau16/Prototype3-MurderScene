using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CleaningBehavior : MonoBehaviour, IPointerDownHandler
{
    public float cleaningClicks = 5;
    public float fadeSpeed = 0.2f;

    private int clicks = 0;
    private SpriteRenderer sr;
    private Color dirtyColor;
    private Color cleanColor;

    public bool cleaned { get; private set; } = false;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
        dirtyColor = sr.color;
        cleanColor = Color.white;

        var drag = GetComponent<DragItems>();
        if (drag != null)
            drag.enabled = false;       
    } 

    public void OnPointerDown(PointerEventData eventData) 
    {
        if(cleaned) return;
        
        clicks++;
        float ratio = Mathf.Clamp01((float)clicks / cleaningClicks);

        sr.color = Color.Lerp(dirtyColor, cleanColor, ratio * fadeSpeed + ratio);

        if (ratio >= 1f)
        {
            cleaned = true;
            sr.color = cleanColor;

            var drag = GetComponent<DragItems>();
            if (drag != null)
                drag.enabled = true;

            if (GameManager.I != null)
                GameManager.I.OnCleaned(); 
        }
    }
            
}
    


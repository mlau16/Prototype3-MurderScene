using UnityEngine;
using UnityEngine.EventSystems;

public class DragItems : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private bool isPlaced = false;
    private Transform correctSpot;
    public float snapDistance = 0.5f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(isPlaced) return;
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(isPlaced) return;
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(eventData.position);
        worldPoint.z = 0;
        transform.position = worldPoint;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(isPlaced) return;
        float dist = Vector2.Distance(transform.position, correctSpot.position);
        if(dist <= snapDistance)
        {
            transform.position = correctSpot.position;
            isPlaced = true;
            GameManager.I.OnItemPlaced();
        }
        else
        {
            transform.position = startPosition;
        }
    }
}

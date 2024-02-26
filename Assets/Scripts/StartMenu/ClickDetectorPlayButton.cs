using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDetectorPlayButton : MonoBehaviour, IPointerUpHandler,
    IPointerDownHandler, IPointerClickHandler,
     IPointerExitHandler, IPointerEnterHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject ScriptExecutor;

    private StartPlay startPlay;

    void Start()
    {
        startPlay = ScriptExecutor.GetComponent<StartPlay>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag Begin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag Ended");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Mouse Exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        startPlay.PlayButtonClick();
        //Debug.Log("Mouse Up");
    }
}

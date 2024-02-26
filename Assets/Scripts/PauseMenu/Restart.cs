using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Restart : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public GameObject PausePanel;
    public GameObject MainCamera;

    private RoundGenerator roundGenerator;


    void Start()
    {
        roundGenerator = MainCamera.GetComponent<RoundGenerator>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Begin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Ended");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        roundGenerator.RestartGame();
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
}
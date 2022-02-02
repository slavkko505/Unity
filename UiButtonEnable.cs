using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiButtonEnable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject buttonToInteract;
    [SerializeField] private GameObject unVisialButton;
    
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private bool canCreate = true;
    
    public Directionint typeDirection;
    
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        unVisialButton.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = .6f;
        _canvasGroup.blocksRaycasts = false;
        unVisialButton.SetActive(true);
        canCreate = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        gameObject.SetActive(false);

        if (canCreate)
        {
            Instantiate(buttonToInteract, gameObject.transform.position, Quaternion.identity);
            canCreate = false;
        }

        FindObjectOfType<playerControler>().DisebleToMove(typeDirection.ToString());
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
    
    public enum Directionint
    {
        right,
        left,
        jump
    }
    
}



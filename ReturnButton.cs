using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    [SerializeField] private Directionint _directionint;
    [SerializeField] private GameObject returnAgain;
    [SerializeField] private GameObject posToReturn;
    public void returnButton()
    {
        string buttonTocanvas = FindObjectOfType<ButtonTypePrefab>()._directionint.ToString();

        if (buttonTocanvas == _directionint.ToString())
        {
            Destroy(FindObjectOfType<ButtonTypePrefab>().gameObject);
            returnAgain.SetActive(true);
            returnAgain.gameObject.GetComponent<RectTransform>().anchoredPosition =
                posToReturn.gameObject.GetComponent<RectTransform>().anchoredPosition;

            posToReturn.SetActive(false);
            
            FindObjectOfType<playerControler>().EnableToMove(_directionint.ToString());
        }
    }
    
    
    public enum Directionint
    {
        right,
        left,
        jump
    }
}

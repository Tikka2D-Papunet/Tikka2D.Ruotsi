using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class CloseGuideScreenButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    Button button;
    [SerializeField] InputManager inputManager;
    [SerializeField] CursorController cursor;
    public GameObject closeBlackBG;
    void Start()
    {
        button = GetComponent<Button>();
        if (inputManager != null)
        {
            inputManager.GetComponent<InputManager>();
            if (inputManager.keyboardInput)
                closeBlackBG.SetActive(true);
            else
                closeBlackBG.SetActive(false);
        }
        cursor.GetComponent<CursorController>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (inputManager != null)
            inputManager.canThrow = false;
        closeBlackBG.SetActive(true);
        cursor.ChangeCursor(cursor.cursorHover);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (inputManager != null)
            inputManager.canThrow = true;
        closeBlackBG.SetActive(false);
        cursor.ChangeCursor(cursor.cursorOriginal);
    }
    public void OnSelect(BaseEventData eventData)
    {
        closeBlackBG.SetActive(true);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        closeBlackBG.SetActive(false);
    }
}
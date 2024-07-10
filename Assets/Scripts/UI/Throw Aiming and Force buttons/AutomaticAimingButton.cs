using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class AutomaticAimingButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public static bool controlMouseTargeting;
    public static bool automaticMouseTargeting = true;
    [HideInInspector] public Button button;
    [HideInInspector] public Image buttonImage;
    [HideInInspector] public Sprite originalSprite;
    public Sprite spriteClicked;
    [SerializeField] Image hoverImg;
    [SerializeField] CursorController cursor;
    void Start()
    {
        button = GetComponent<Button>();
        //hoverImg = GetComponent<Image>();
        buttonImage = button.image;
        originalSprite = buttonImage.sprite;
        if (automaticMouseTargeting)
            buttonImage.sprite = spriteClicked;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        cursor.ChangeCursor(cursor.cursorHover);
        hoverImg.enabled = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        cursor.ChangeCursor(cursor.cursorOriginal);
        hoverImg.enabled = false;
    }
    public void OnSelect(BaseEventData eventData)
    {
        hoverImg.enabled = true;
    }
    public void OnDeselect(BaseEventData eventData)
    {
        hoverImg.enabled = false;
    }
}
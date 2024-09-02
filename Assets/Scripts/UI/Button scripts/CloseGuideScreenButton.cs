using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class CloseGuideScreenButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    Button button;
    [HideInInspector] public Image buttonImage;
    [HideInInspector] public Sprite originalSprite;
    public Sprite hoverSprite;
    [HideInInspector] public float originalSpriteWidth;
    [HideInInspector] public float originalSpriteHeight;
    [HideInInspector] public float hoverSpriteWidth = 154.4963f;
    [HideInInspector] public float hoverSpriteHeight = 79.7048f;
    [SerializeField] InputManager inputManager;
    [SerializeField] CursorController cursor;
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.image;
        originalSprite = buttonImage.sprite;
        originalSpriteWidth = buttonImage.rectTransform.rect.width;
        originalSpriteHeight = buttonImage.rectTransform.rect.height;
        if (inputManager != null)
        {
            inputManager.GetComponent<InputManager>();
            if (inputManager.keyboardInput)
                SetButton(hoverSprite, hoverSpriteWidth, hoverSpriteHeight);
            else
                SetButton(originalSprite, originalSpriteWidth, originalSpriteHeight);
        }
        cursor.GetComponent<CursorController>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (inputManager != null)
            inputManager.canThrow = false;
        SetButton(hoverSprite, hoverSpriteWidth, hoverSpriteHeight);
        cursor.ChangeCursor(cursor.cursorHover);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (inputManager != null)
            inputManager.canThrow = true;
        SetButton(originalSprite, originalSpriteWidth, originalSpriteHeight);
        cursor.ChangeCursor(cursor.cursorOriginal);

    }
    public void OnSelect(BaseEventData eventData)
    {
        if (InputManager.Instance.isEndingMenuOpen)
            SetButton(hoverSprite, hoverSpriteWidth, hoverSpriteHeight);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        if (InputManager.Instance.isEndingMenuOpen)
            SetButton(originalSprite, originalSpriteWidth, originalSpriteHeight);
    }
    public void SetButton(Sprite sprite, float width, float height)
    {
        if (buttonImage != null)
        {
            buttonImage.sprite = sprite;
            RectTransform rectTransform = buttonImage.rectTransform;
            rectTransform.sizeDelta = new Vector2(width, height);
        }
    }
}
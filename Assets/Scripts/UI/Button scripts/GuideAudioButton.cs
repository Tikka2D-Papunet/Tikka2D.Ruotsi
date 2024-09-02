using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class GuideAudioButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, IPointerClickHandler, ISubmitHandler
{
    Button button;
    [HideInInspector] public Image buttonImage;
    [HideInInspector] public Sprite originalSprite;
    private float originalSpriteWidth;
    private float originalSpriteHeight;
    private float hoverSpriteWidth = 233.6725f;
    private float hoverSpriteHeight = 82.0101f;
    public Sprite listenHoverSprite;
    public Sprite stopPlaySprite;
    public Sprite stopPlaySpriteHover;
    [SerializeField] CursorController cursor;
    [SerializeField] AudioClip guideAudioClip;
    public bool guideAudioOn;
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.image;
        originalSprite = buttonImage.sprite;
        originalSpriteWidth = button.image.rectTransform.rect.width;
        originalSpriteHeight = button.image.rectTransform.rect.height;
        cursor.GetComponent<CursorController>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (InputManager.Instance != null)
            InputManager.Instance.canThrow = false;
        if (!guideAudioOn)
            SetButton(listenHoverSprite, hoverSpriteWidth, hoverSpriteHeight);
        else
        {
            SetButton(stopPlaySpriteHover, hoverSpriteWidth, hoverSpriteHeight);
        }
        cursor.ChangeCursor(cursor.cursorHover);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (buttonImage != null)
        {
            if (!guideAudioOn)
                buttonImage.sprite = listenHoverSprite;
            else
                buttonImage.sprite = stopPlaySpriteHover;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!guideAudioOn)
            SetButton(originalSprite, originalSpriteWidth, originalSpriteHeight);
        else
        {
            SetButton(stopPlaySprite, originalSpriteWidth, originalSpriteHeight);
        }
        cursor.ChangeCursor(cursor.cursorOriginal);
        if (InputManager.Instance != null)
            InputManager.Instance.canThrow = true;
    }
    public void OnSelect(BaseEventData eventData)
    {
        if(InputManager.Instance.isEndingMenuOpen)
        {
            if (!guideAudioOn)
                SetButton(listenHoverSprite, hoverSpriteWidth, hoverSpriteHeight);
            else
                SetButton(stopPlaySpriteHover, hoverSpriteWidth, hoverSpriteHeight);
        }
    }
    public void OnSubmit(BaseEventData eventData)
    {
        if (InputManager.Instance.isEndingMenuOpen)
        {
            if (buttonImage != null)
            {
                if (!guideAudioOn)
                    buttonImage.sprite = listenHoverSprite;
                else
                    buttonImage.sprite = stopPlaySpriteHover;
            }
        }
    }
    public void OnDeselect(BaseEventData eventData)
    {
        if (InputManager.Instance.isEndingMenuOpen)
        {
            if (!guideAudioOn)
                SetButton(originalSprite, originalSpriteWidth, originalSpriteHeight);
            else
                SetButton(stopPlaySprite, originalSpriteWidth, originalSpriteHeight);
        }
    }
    public void PlayAudioGuide()
    {
        if (!guideAudioOn)
        {
            guideAudioOn = true;
            SoundManager.Instance.PlaySound(guideAudioClip);
        }
        else
        {
            guideAudioOn = false;
            SoundManager.Instance.source.Stop();
        }
    }
    private void SetButton(Sprite sprite, float width, float height)
    {
        buttonImage.sprite = sprite;
        RectTransform rectTransform = buttonImage.rectTransform;
        rectTransform.sizeDelta = new Vector2(width, height);
    }
}
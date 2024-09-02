using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ListenButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, IPointerClickHandler, ISubmitHandler
{
    Button button;
    Image buttonImage;
    [SerializeField] Sprite soundOnOriginalSprite;
    [SerializeField] Sprite soundOffOriginalSprite;
    public Sprite soundOnHoverSprite;
    public GameObject soundOnSpeechBubble;
    public Sprite soundOffHoverSprite;
    public GameObject soundOffSpeechBubble;
    bool isMutedFetch;
    bool soundOn = true;
    [SerializeField] InputManager inputManager;
    [SerializeField] CursorController cursor;
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.image;
        soundOnOriginalSprite = buttonImage.sprite;
        if (SoundManager.Instance.isMuted)
            buttonImage.sprite = soundOffOriginalSprite;
        soundOnSpeechBubble.gameObject.SetActive(false);
        if (inputManager != null)
            inputManager.GetComponent<InputManager>();
        cursor.GetComponent<CursorController>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(inputManager != null)
            inputManager.canThrow = false;
        if(!SoundManager.Instance.isMuted)
        {
            buttonImage.sprite = soundOnHoverSprite;
            SoundOnSpeechBubble();
        }
        else
        {
            buttonImage.sprite = soundOffHoverSprite;
            SoundOffSpeechBubble();
        }
        cursor.ChangeCursor(cursor.cursorHover);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.Instance.isMuted = !SoundManager.Instance.isMuted;
        SoundManager.Instance.source.mute = SoundManager.Instance.isMuted;
        PlayerPrefs.SetInt("isMuted", SoundManager.Instance.isMuted ? 1 : 0);
        PlayerPrefs.Save();
        if (!SoundManager.Instance.isMuted)
        {
            buttonImage.sprite = soundOnHoverSprite;
            SoundOnSpeechBubble();
        }
        else
        {
            buttonImage.sprite = soundOffHoverSprite;
            SoundOffSpeechBubble();
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(inputManager != null)
            inputManager.canThrow = true;
        if (!SoundManager.Instance.isMuted)
            buttonImage.sprite = soundOnOriginalSprite;
        else
            buttonImage.sprite = soundOffOriginalSprite;
        cursor.ChangeCursor(cursor.cursorOriginal);
        soundOffSpeechBubble.SetActive(false);
        soundOnSpeechBubble.SetActive(false);
    }
    public void OnSelect(BaseEventData eventData)
    {
        if(InputManager.Instance.isEndingMenuOpen)
        {
            if (!SoundManager.Instance.isMuted)
            {
                buttonImage.sprite = soundOnHoverSprite;
                SoundOnSpeechBubble();
            }
            else
            {
                buttonImage.sprite = soundOffHoverSprite;
                SoundOffSpeechBubble();
            }
        }
    }
    public void OnSubmit(BaseEventData eventData)
    {
        if(InputManager.Instance.isEndingMenuOpen)
        {
            SoundManager.Instance.isMuted = !SoundManager.Instance.isMuted;
            SoundManager.Instance.source.mute = SoundManager.Instance.isMuted;
            PlayerPrefs.SetInt("isMuted", SoundManager.Instance.isMuted ? 1 : 0);
            PlayerPrefs.Save();
            if (!SoundManager.Instance.isMuted)
            {
                buttonImage.sprite = soundOnHoverSprite;
                SoundOnSpeechBubble();
            }
            else
            {
                buttonImage.sprite = soundOffHoverSprite;
                SoundOffSpeechBubble();
            }
        }
    }
    public void OnDeselect(BaseEventData eventData)
    {
        if(InputManager.Instance.isEndingMenuOpen)
        {
            if (!SoundManager.Instance.isMuted)
                buttonImage.sprite = soundOnOriginalSprite;
            else
                buttonImage.sprite = soundOffOriginalSprite;
            soundOffSpeechBubble.SetActive(false);
            soundOnSpeechBubble.SetActive(false);
        }
    }
    void SoundOnSpeechBubble()
    {
        soundOffSpeechBubble.SetActive(false);
        soundOnSpeechBubble.SetActive(true);
    }
    void SoundOffSpeechBubble()
    {
        soundOffSpeechBubble.SetActive(true);
        soundOnSpeechBubble.SetActive(false);
    }
}
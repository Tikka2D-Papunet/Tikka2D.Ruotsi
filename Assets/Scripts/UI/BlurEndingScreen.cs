using UnityEngine;
public class BlurEndingScreen : MonoBehaviour
{
    [SerializeField] MouseAndDartManager manager;
    int howManyDartsThrownFetch; // fetch from MouseAndSpawnManager -script
    [SerializeField] GameObject originalBackground;
    SpriteRenderer originalBackgroundSprite;
    [SerializeField] GameObject originalBoard;
    SpriteRenderer originalBoardSprite;
    [SerializeField] GameObject childObjectBackground;
    SpriteRenderer backgroundSprite;
    [SerializeField] GameObject childObjectBoard;
    SpriteRenderer dartboardSprite;
    private void Start()
    {
        originalBackgroundSprite = originalBackground.GetComponent<SpriteRenderer>();
        originalBoardSprite = originalBoard.GetComponent<SpriteRenderer>();
        backgroundSprite = childObjectBackground.GetComponent<SpriteRenderer>();
        dartboardSprite = childObjectBoard.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        howManyDartsThrownFetch = manager.GetComponent<MouseAndDartManager>().howManyDartsThrown;
        if (howManyDartsThrownFetch >= 5)
        {
            Invoke("ShowBlurSprites", 2);
            Invoke("HideOriginalSprites", 2);
        }
        else
        {
            originalBackgroundSprite.enabled = true;
            originalBoardSprite.enabled = true;
            backgroundSprite.enabled = false;
            dartboardSprite.enabled = false;
        }
    }
    void ShowBlurSprites()
    {
        backgroundSprite.enabled = true;
        dartboardSprite.enabled = true;
    }
    void HideOriginalSprites()
    {
        originalBackgroundSprite.enabled = false;
        originalBoardSprite.enabled = false;
    }
}
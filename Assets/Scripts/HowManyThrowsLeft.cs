using UnityEngine;
using UnityEngine.UI;
public class HowManyThrowsLeft : MonoBehaviour
{
    #region Singleton
    public static HowManyThrowsLeft Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    #endregion
    public MouseAndDartManager manager;
    int howManyDartsThrownFetch; // fetch from MouseAndSpawnManager -script
    [SerializeField] GameObject dart1;
    [SerializeField] GameObject dart2;
    [SerializeField] GameObject dart3;
    [SerializeField] GameObject dart4;
    [SerializeField] GameObject dart5;
    public void HowManyDartsThrown()
    {
        howManyDartsThrownFetch = manager.GetComponent<MouseAndDartManager>().howManyDartsThrown;
        if (howManyDartsThrownFetch == 1)
            HideImage(dart1);
        if (howManyDartsThrownFetch == 2)
            HideImage(dart2);
        if (howManyDartsThrownFetch == 3)
            HideImage(dart3);
        if (howManyDartsThrownFetch == 4)
            HideImage(dart4);
        if (howManyDartsThrownFetch == 5)
            HideImage(dart5);
    }
    void HideImage(GameObject newDart)
    {
        Image childImage = newDart.GetComponent<Image>();
        childImage.enabled = false;
    }
}
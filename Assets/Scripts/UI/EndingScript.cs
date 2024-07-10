using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class EndingScript : MonoBehaviour
{
    #region Singleton
    public static EndingScript Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }
    #endregion
    public MouseAndDartManager MaDmanager;
    public int publicScore;
    int howManyDartsThrown;
    public GameObject[] endings;
    int index;
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI scoreText3;
    public TextMeshProUGUI scoreText4;
    public Button playAgain;
    public Button backToMenu;
    float counter;
    float maxTime = 2;
    [SerializeField] InputManager inputManager;
    public void IfEndingConditionsAreMet(int throwCount, int score)
    {
        publicScore = score;
        if(throwCount >= 5)
        {
            StartCoroutine(EndGame(score));
        }
    }
    IEnumerator EndGame(int newScore)
    {
        GameObject[] darts = GameObject.FindGameObjectsWithTag("Dart");
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < darts.Length; i++)
            Destroy(darts[i]);
        playAgain.gameObject.SetActive(true);
        backToMenu.gameObject.SetActive(true);
        if (newScore < 25)
        {
            endings[0].SetActive(isActiveAndEnabled);
            scoreText1.text = "alle " + newScore + " pistettä: Hyvä alku!\nPienellä harjoittelulla kehityt varmasti vielä.";
        }
        else if (newScore >= 25 && newScore < 35)
        {
            endings[1].SetActive(isActiveAndEnabled);
            scoreText2.text = "tasan tai yli " + newScore + " pistettä: Olet selkeästi harjoitellut heittämistä!";
        }
        else if (newScore > 34 && newScore < 45)
        {
            endings[2].SetActive(isActiveAndEnabled);
            scoreText3.text = "tasan tai yli " + newScore + " pistettä: Taidat olla jo melko hyvä heittäjä?";
        }
        else if (newScore > 44)
        {
            endings[3].SetActive(isActiveAndEnabled);
            scoreText4.text = "tasan tai yli " + newScore + " pistettä: Sinähän olet varsinainen tikkamestari!";
        }
        yield return new WaitForSeconds(0.5f);
        inputManager.GetComponent<InputManager>().isEndingMenuOpen = true;
        inputManager.GetComponent<InputManager>().SelectFirstButton();
    }
}
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
    public GameObject[] endings;
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI scoreText3;
    public TextMeshProUGUI scoreText4;
    public Button playAgain;
    public Button backToMenu;
    [SerializeField] InputManager inputManager;
    [SerializeField] ScoreText scoreText;
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
        scoreText.GetComponent<ScoreText>().scoreText.enabled = false;
        for (int i = 0; i < darts.Length; i++)
            Destroy(darts[i]);
        playAgain.gameObject.SetActive(true);
        backToMenu.gameObject.SetActive(true);
        if (newScore < 25)
        {
            endings[0].SetActive(isActiveAndEnabled);
            scoreText1.text = "Du fick " + newScore + " poäng. Bra början! Med lite övning blir du bättre.";
        }
        else if (newScore >= 25 && newScore < 35)
        {
            endings[1].SetActive(isActiveAndEnabled);
            scoreText2.text = "Du fick " + newScore + " poäng. Du har helt klart tränat på att kasta.";
        }
        else if (newScore > 34 && newScore < 45)
        {
            endings[2].SetActive(isActiveAndEnabled);
            scoreText3.text = "Du fick " + newScore + " poäng. Du verkar vara ganska bra på att kasta!";
        }
        else if (newScore > 44)
        {
            endings[3].SetActive(isActiveAndEnabled);
            scoreText4.text = "Du fick " + newScore + " poäng. Du är verkligen en mästare på pilkastning!";
        }
        yield return new WaitForSeconds(0.5f);
        inputManager.GetComponent<InputManager>().isEndingMenuOpen = true;
        inputManager.GetComponent<InputManager>().SelectPlayAgainButton();
    }
}
using System.Collections;
using UnityEngine;
public class StarSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject mouseAndDartManager;
    [SerializeField] GameObject star1, star2, star3, star4, star5, star6, star7, star8, star9, star10;
    Vector3 childCastPointPositionFetch;
    public void StarSpawner(int num)
    {
        childCastPointPositionFetch = mouseAndDartManager.GetComponent<MouseAndDartManager>().childCastpointPosition;
        if (num == 10)
            StartCoroutine(SpawnStar(star10));
        if (num == 9)
            StartCoroutine(SpawnStar(star9));
        if (num == 8)
            StartCoroutine(SpawnStar(star8));
        if (num == 7)
            StartCoroutine(SpawnStar(star7));
        if (num == 6)
            StartCoroutine(SpawnStar(star6));
        if (num == 5)
            StartCoroutine(SpawnStar(star5));
        if (num == 4)
            StartCoroutine(SpawnStar(star4));
        if (num == 3)
            StartCoroutine(SpawnStar(star3));
        if (num == 2)
            StartCoroutine(SpawnStar(star2));
        if (num == 1)
            StartCoroutine(SpawnStar(star1));
    }
    void CreateAndDestroyStar(GameObject newStar)
    {
        transform.position = childCastPointPositionFetch;
        GameObject starPrefab = Instantiate(newStar, transform.position, Quaternion.identity);
        Rigidbody2D rb2d = starPrefab.GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, 2);
        Destroy(starPrefab, 1.5f);
    }
    public IEnumerator SpawnStar(GameObject star)
    {
        yield return new WaitForSeconds(0.6f);
        CreateAndDestroyStar(star);
    }
}
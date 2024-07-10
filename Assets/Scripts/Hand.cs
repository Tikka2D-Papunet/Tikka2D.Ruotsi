using System.Collections;
using UnityEngine;
public class Hand : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject manager;
    public GameObject kasiiii;
    int dartsThrown;
    IEnumerator HandDisappearAfterGame()
    {
        yield return new WaitForSeconds(0.5f);
        kasiiii.gameObject.SetActive(false);
    }
    private void Update()
    {
        dartsThrown = manager.GetComponent<MouseAndDartManager>().howManyDartsThrown;
        if (dartsThrown == 5)
            StartCoroutine(HandDisappearAfterGame());
        FollowCrosshair();
    }
    void FollowCrosshair()
    {
        transform.position = new Vector3(crosshair.transform.position.x - 2f, crosshair.transform.position.y - 3.6f,
transform.position.z);
    }
}
using UnityEngine;
public class DontDestroy : MonoBehaviour
{
    GameObject thisGameObject;
    private void Awake()
    {
        if (thisGameObject == null)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
}
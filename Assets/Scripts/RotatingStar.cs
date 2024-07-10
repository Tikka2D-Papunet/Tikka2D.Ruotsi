using UnityEngine;
public class RotatingStar : MonoBehaviour
{
    float rotateSpeed = 40;
    private void Update()
    {
        transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
    }
}
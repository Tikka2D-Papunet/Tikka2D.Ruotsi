using UnityEngine;
public class Rotate : MonoBehaviour
{
    public static bool controlMouseTargeting;
    public static bool automaticMouseTargeting = true;
    float rotateSpeed = 12; // original speed 10
    Vector3 rotateDirection = Vector3.forward;
    float rotateDirectionMaxTime;
    float rotateDirectionCounter = 0;
    public float changeRotateDirection;
    public bool checkRotateDirectionMaxTime = true;
    bool checkRotateSpeedMaxTime = true;
    float rotateSpeedMaxTime;
    float rotateSpeedCounter = 0;
    private void Update()
    {
        if(automaticMouseTargeting)
        {
            if (checkRotateDirectionMaxTime)
            {
                rotateDirectionMaxTime = Random.Range(3, 5);
                checkRotateDirectionMaxTime = false;
            }
            if (rotateDirectionMaxTime > rotateDirectionCounter)
                rotateDirectionCounter += Time.deltaTime;
            else
            {
                changeRotateDirection = Random.Range(0, 2);
                rotateDirectionCounter = 0;
                rotateDirectionMaxTime = 0;
                checkRotateDirectionMaxTime = true;
            }

            if (changeRotateDirection == 0)
                rotateDirection = Vector3.forward;
            else
                rotateDirection = Vector3.back;
            if (checkRotateSpeedMaxTime)
            {
                rotateSpeedMaxTime = Random.Range(3, 5);
                checkRotateSpeedMaxTime = false;
            }
            if(rotateSpeedMaxTime > rotateSpeedCounter)
                rotateSpeedCounter += Time.deltaTime;
            else
            {
                rotateSpeed = Random.Range(12, 16);
                rotateSpeedMaxTime = 0;
                rotateSpeedCounter = 0;
                checkRotateSpeedMaxTime = true;
            }
            transform.Rotate(rotateDirection, rotateSpeed * Time.deltaTime);
        }
    }
}
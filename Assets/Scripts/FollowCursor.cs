using UnityEngine;
public class FollowCursor : MonoBehaviour
{
    public static bool controlMouseTargeting;
    public static bool automaticMouseTargeting = true;
    Vector3 mousePosition;
    float distance; // distance to cursor
    float maxDistance = 0; // max distance to cursor
    float followSpeed = 10; // crosshair cursor follow speed
    float distanceToCursor = 4;
    int screenWidth;
    int screenHeight;
    private void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        Debug.Log("Screen resolution: " + screenWidth + "x" + screenHeight);
    }
    private void Update()
    {
        if(controlMouseTargeting)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            if (Input.touchCount > 0)
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                mousePosition.z = 0;
            }
            distance = Vector3.Distance(mousePosition, transform.position * distanceToCursor);
            if(distance > maxDistance)
                transform.position = Vector3.Lerp(transform.position, mousePosition, Time.deltaTime * followSpeed);
        }
    }
}
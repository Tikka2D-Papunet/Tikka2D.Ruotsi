using System.Collections;
using UnityEngine;
public class Crosshair : MonoBehaviour
{
    public static bool controlMouseTargeting;
    public static bool automaticMouseTargeting = true;
    SpriteRenderer sprite;
    Vector3 mousePosition; // Cursor position
    [Header("Crosshair Movement Speeds")]
    float moveSpeed = 2.2f; // Controlled crosshair speed
    float controlledMoveSpeed = 100f; // controlled aiming move speed
    float originalControlledMoveSpeed;
    float originalSpeed;
    [Header("Crosshair Distances")]
    float distance;
    float maxDistance = 4f;
    public Vector3 direction = Vector3.up; // (0, 0, 0)
    bool running = false;
    [Header("MouseAndDartManager Boolean Fetches")]
    public MouseAndDartManager manager;
    public bool mouseDown;
    bool startThrowCountFetch;
    [Header("Automatic Crosshair Parameters")]
    Vector2 startPosition;
    [Header("Controlled Mouse Targeting Parameters")]
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;
    float automaticMouseSpeed = 3;
    float originalAutomaticMouseSpeed;
    bool startSpeed = true;
    float startMaxTime = 0.000000001f;
    float startCounter = 0;
    Vector3 startPos;
    Vector3 targetPos;
    Vector3 wayPoint;
    [SerializeField] Transform followCursor;
    [SerializeField] Transform touchScreenFollow;
    float minRange = 0.5f;
    float range;
    float randomX, randomY;
    float distanceToCursor;
    private void Start()
    {
        originalSpeed = moveSpeed;
        if(automaticMouseTargeting)
            startPosition = transform.position;
        sprite = GetComponent<SpriteRenderer>();
        originalControlledMoveSpeed = controlledMoveSpeed;
        startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        originalAutomaticMouseSpeed = automaticMouseSpeed;
    }
    private void Update()
    {
        if(controlMouseTargeting)
            ControlMouseTargeting();
        if (automaticMouseTargeting)
            AutomaticMouseTargeting();
    }
    void ControlMouseTargeting()
    {
        mouseDown = manager.GetComponent<MouseAndDartManager>().mouseDown;
        startThrowCountFetch = manager.GetComponent<MouseAndDartManager>().startThrowCount;
        range = Vector2.Distance(transform.position, wayPoint);
        distanceToCursor = Vector2.Distance(transform.position, followCursor.position);
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, moveSpeed * Time.deltaTime);
        if (startThrowCountFetch)
            sprite.enabled = false;
        else
            sprite.enabled = true;
        if (mouseDown) // When mouse button is pressed down the crosshair movement slows down
            moveSpeed = 1.5f;
        else
            moveSpeed = originalSpeed;
        if (distanceToCursor > maxDistance)
            SetNewDestination();
        else
        {
            if(range < minRange)
                SetNewDestination();
        }
    }
    void SetNewDestination()
    {
        randomX = Random.Range(-maxDistance, maxDistance);
        randomY = Random.Range(-maxDistance, maxDistance);
        wayPoint = new Vector2(followCursor.position.x + randomX, followCursor.position.y + randomY);
    }
    void AutomaticMouseTargeting()
    {
        mouseDown = manager.GetComponent<MouseAndDartManager>().mouseDown;
        startThrowCountFetch = manager.GetComponent<MouseAndDartManager>().startThrowCount;
        if (startThrowCountFetch)
            sprite.enabled = false;
        else
            sprite.enabled = true;
        if (startSpeed)
        {
            automaticMouseSpeed = 27;
            if (startMaxTime > startCounter)
                startCounter += Time.deltaTime;
            else
            {
                automaticMouseSpeed = originalAutomaticMouseSpeed;
                startSpeed = false;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 1.5f)
                automaticMouseSpeed -= Time.deltaTime;
            else if (automaticMouseSpeed <= 0)
                automaticMouseSpeed = originalAutomaticMouseSpeed;
            else
                automaticMouseSpeed = originalAutomaticMouseSpeed;
        }
        if (mouseDown) // When mouse button is pressed down the crosshair movement slows down
        {
            if (distance > maxDistance) // if crosshairs distance to center of the darts board is larger than maxDistance return crosshair back to minimun distance
                transform.position = Vector3.Lerp(transform.position, transform.position, Time.deltaTime * 10f);
            moveSpeed = 0.0005f;
            if (!running) // Changes crosshairs movement direction randomly 1
                StartCoroutine(ChangeDirection());
            transform.position += direction * moveSpeed;
        }
        else
        {
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                    currentWaypointIndex = 0;
            }
            transform.position = Vector3.MoveTowards(transform.position,
                waypoints[currentWaypointIndex].transform.position, automaticMouseSpeed * Time.deltaTime);
        }
    }
    IEnumerator ChangeDirection() // Changes crosshairs movement direction randomly 2
    {
        running = true;
        yield return new WaitForSeconds(0.3f);
        direction.x = Random.Range(-1, 2);
        direction.y = Random.Range(-1, 2);
        running = false;
    }
}
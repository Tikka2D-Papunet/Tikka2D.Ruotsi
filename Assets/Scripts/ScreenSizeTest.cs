using UnityEngine;
public class ScreenSizeTest : MonoBehaviour
{
    int screenWidth;
    int screenHeight;
    SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        Debug.Log("Screen resolution: " + screenWidth + "x" + screenHeight);
        if(screenWidth <= 1600 && screenHeight <= 720)
            sprite.enabled = true;
        else
            sprite.enabled = false;
    }
}
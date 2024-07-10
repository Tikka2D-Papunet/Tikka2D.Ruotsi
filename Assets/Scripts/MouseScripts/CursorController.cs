using UnityEngine;
public class CursorController : MonoBehaviour
{
    CursorControls controls;
    Camera mainCamera;
    public Texture2D cursorOriginal;
    public Texture2D cursorHover;
    private void Awake()
    {
        controls = new CursorControls();
        ChangeCursor(cursorOriginal);
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera = Camera.main;
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    public void ChangeCursor(Texture2D cursorType)
    {
        //Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }
}
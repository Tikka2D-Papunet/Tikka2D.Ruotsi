using UnityEngine;
public class Dart : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb2d;
    public bool throwed = false;
    public Camera cam;
    public Transform castPoint;
    [HideInInspector] public GameObject crosshair;
    [SerializeField] SpriteRenderer sprite;
    public GameObject childObject;
    [HideInInspector] public SpriteRenderer childSprite;
    public GameObject childObjectAnimator;
    [HideInInspector] public Animator childAnim;
    [SerializeField] public GameObject childShadow;
    [HideInInspector] public SpriteRenderer shadowSprite;
    float timer;
    public Transform GetChildObjectTransform()
    {
        return castPoint;
    }
    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
    }
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Kinematic;
        childSprite = childObject.GetComponent<SpriteRenderer>();
        childAnim = childObjectAnimator.GetComponent<Animator>();
        shadowSprite = childShadow.GetComponent<SpriteRenderer>();
    }
}
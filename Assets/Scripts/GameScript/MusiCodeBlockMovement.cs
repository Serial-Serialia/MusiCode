using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MusiCodeBlockMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    [SerializeField] private Rigidbody2D physics;
    [SerializeField] private float objectVelocity;
    [SerializeField] private Collider2D g_collider;
    private Vector3 mousePos;
    private Vector3 originalPos;
    private Vector3 extents;
    private UIScript LogicManager;
    private UIScript.statusChoice status;
    [SerializeField] private bool isOnPlace;
    private bool isMoving;

    public void Awake()
    {
        extents = GetComponent<SpriteRenderer>().sprite.bounds.extents;
        originalPos = transform.position;
        LogicManager = GameObject.FindGameObjectWithTag("Logic_manager").GetComponent<UIScript>();
    }
    void Update()
    {
        status = LogicManager.GetStatus();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        isMoving = true;

        if (status == UIScript.statusChoice.stop)
        {
            isOnPlace = false;

        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (status == UIScript.statusChoice.stop)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            Vector3 topRight = Camera.main.ViewportToWorldPoint(Vector3.one);
            Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);

            mousePos.x = Mathf.Clamp(mousePos.x, bottomLeft.x + extents.x, topRight.x - extents.x);
            mousePos.y = Mathf.Clamp(mousePos.y, bottomLeft.y + extents.y, topRight.y - extents.y);

            transform.position = Vector2.MoveTowards(transform.position, mousePos, objectVelocity);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if ((transform.position != originalPos) && !isOnPlace && (status == UIScript.statusChoice.stop))
        {
            transform.position = originalPos;
        }

        isMoving = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isOnPlace = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && !isMoving)
        { 
            transform.position = new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isOnPlace = false;
        }
        
    }
}

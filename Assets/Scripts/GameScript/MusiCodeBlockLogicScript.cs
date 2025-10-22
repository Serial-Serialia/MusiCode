using UnityEngine;

public class MusiCodeBlockLogicScript : MonoBehaviour
{
    [SerializeField] private Collider2D g_collider;
    [SerializeField] private string tagOfCorrectPlace;
    [SerializeField] private int listPosition;
    private Vector2 OriginalSize;
    private SpriteRenderer sprite;
    private UIScript LogicManager;
    private UIScript.statusChoice status;
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        OriginalSize = sprite.size;
        LogicManager = GameObject.FindGameObjectWithTag("Logic_manager").GetComponent<UIScript>();
    }

    void Update()
    {
        status = LogicManager.GetStatus();
    }

    void OTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.layer == 8) && (status == UIScript.statusChoice.stop))
        {
            LogicManager.SetIsOnRightPlace(listPosition, collision.gameObject.CompareTag(tagOfCorrectPlace));
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.layer == 8) && (status == UIScript.statusChoice.stop))
        {
            LogicManager.SetIsOnRightPlace(listPosition, collision.gameObject.CompareTag(tagOfCorrectPlace));
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.layer == 8) && (status == UIScript.statusChoice.stop))
        {
            sprite.size = OriginalSize;
            LogicManager.SetIsOnRightPlace(listPosition, false);
        }
        
    }
}

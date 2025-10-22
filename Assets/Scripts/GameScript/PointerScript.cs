using UnityEngine;

public class MusiCodeBlock : MonoBehaviour
{
    private UIScript LogicManager;
    private UIScript.statusChoice status;
    private Vector3 originalPos;
    [SerializeField] private Rigidbody2D rb2;
    [SerializeField] private Collider2D cl2;

    void Start()
    {
        LogicManager = GameObject.FindGameObjectWithTag("Logic_manager").GetComponent<UIScript>();
        originalPos = transform.position;
    }

    void Update()
    {
        status = LogicManager.GetStatus();
        switch (status)
        {
            case UIScript.statusChoice.stop:
                rb2.constraints = RigidbodyConstraints2D.FreezePositionY;
                rb2.linearVelocityY = 0.0f;
                transform.position = originalPos;
                break;
            case UIScript.statusChoice.play:
                rb2.constraints = RigidbodyConstraints2D.None;
                rb2.linearVelocityY = -0.5f;
                break;
            case UIScript.statusChoice.paused:
                rb2.constraints = RigidbodyConstraints2D.FreezePositionY;
                rb2.linearVelocityY = 0.0f;
                break;
            default:
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            LogicManager.Pause();
            LogicManager.InGameChecker();
        }
    }
}

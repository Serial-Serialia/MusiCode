using UnityEngine;
using UnityEngine.EventSystems;

public class NoteScript : MonoBehaviour, IPointerClickHandler
{
    private AudioSource audioSource;
    private UIScript LogicManager;
    private UIScript.statusChoice status;
    [SerializeField] Collider2D collision;
    private Vector3 extents;
    private Vector3 center;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        LogicManager = GameObject.FindGameObjectWithTag("Logic_manager").GetComponent<UIScript>();
        extents = transform.parent.GetComponentInParent<SpriteRenderer>(true).bounds.extents;
        center = transform.localPosition;
        Vector3 offset = new(-extents.x -0.5f, center.y, transform.position.z);
        transform.localPosition = offset;
    }

    void Update()
    {
        status = LogicManager.GetStatus();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.layer == 6) && (status == UIScript.statusChoice.play))
        {
            audioSource.Play();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.Play();
    }
}

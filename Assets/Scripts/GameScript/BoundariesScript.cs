using UnityEngine;
using UnityEngine.EventSystems;

public class BoundariesScript : MonoBehaviour, IDropHandler
{
    [SerializeField] private Collision2D collision2D;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("ondrop");
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField, Space]
    private RectTransform Background;

    [SerializeField, Space]
    private RectTransform Handle;

    [SerializeField, Space, Range(0, 2f)]
    private float HandleLimit = 1f;

    private Vector2 input = Vector2.zero;
    public float Vertical => input.y;
    public float Horizontal => input.x;

    private Vector2 playerRotation;
    public float RotationVertical => playerRotation.y;
    public float RotationHorizontal => playerRotation.x;

    private bool canRotate;
    public bool CanRotate { get { return canRotate; } set { canRotate = value; } }

    private Vector2 JoyPosition = Vector2.zero;

    public void OnPointerDown(PointerEventData eventdata)
    {
        Background.gameObject.SetActive(true);
        OnDrag(eventdata);
        JoyPosition = eventdata.position;
        Background.position = eventdata.position;
        Handle.anchoredPosition = Vector2.zero;
        input = Vector2.zero;
        canRotate = false;
    }

    public void OnDrag(PointerEventData eventdata)
    {
        Vector2 JoyDriection = eventdata.position - JoyPosition;
        input = (JoyDriection.magnitude > Background.sizeDelta.x / 2f) ? JoyDriection.normalized : JoyDriection / (Background.sizeDelta.x / 2f);
        Handle.anchoredPosition = (input * Background.sizeDelta.x / 2f) * HandleLimit;
        playerRotation = (JoyDriection.magnitude > Background.sizeDelta.x / 2f) ? JoyDriection.normalized : JoyDriection / (Background.sizeDelta.x / 2f);
        canRotate = true;
    }

    public void OnPointerUp(PointerEventData eventdata)
    {
        Background.gameObject.SetActive(false);
        input = Vector2.zero;
        Handle.anchoredPosition = Vector2.zero;
        canRotate = false;
    }
}

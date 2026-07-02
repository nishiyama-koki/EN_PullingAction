using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
    private Image arrowImage;
    InputAction clickAction_;
    private Vector2 clickPosition_;
    private bool isDrag_ = false;
    void Start()
    {
        InputActionAsset inputActions = InputSystem.actions;
        clickAction_ = inputActions.FindAction("Player/LeftClick");
        clickAction_.performed += OnClick;
        clickAction_.canceled += OnRelease;

        arrowImage.enabled = false;

    }

    void Update()
    {
        if (isDrag_)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector2 dist = clickPosition_ - mousePosition;
            float size = dist.magnitude;
            float angleRad = Mathf.Atan2(dist.y, dist.x);
            arrowImage.rectTransform.position = clickPosition_;
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);

        }
    }

    void OnClick(InputAction.CallbackContext context)
    {
        if (isDrag_ == false)
        {
            clickPosition_ = Mouse.current.position.ReadValue();
            isDrag_ = true;
            arrowImage.enabled = true;
        }
    }

    /// <summary>
    /// name= "context";
    /// </summary>
    /// <param name="context"></param>

    void OnRelease(InputAction.CallbackContext context)
    {
        isDrag_ = false;
        arrowImage.enabled = false;
    }



}

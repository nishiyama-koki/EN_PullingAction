using UnityEngine;
using UnityEngine.InputSystem;

public class PullingJump : MonoBehaviour
{
    [SerializeField]private float jumpPower_=10.0f;
    private float maxSpeed_ = 10;

    private Rigidbody rigidbody_;
    //クリック座標
    private Vector2 clickPosition_=Vector2.zero;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //重力いじるとき,変えたら戻すのにもう一度
        //Physics.gravity=new Vector3(0,0,0);

        rigidbody_ = GetComponent<Rigidbody>();
        InputActionAsset inputActions = InputSystem.actions;
        InputAction leftClickAction=inputActions.FindAction("Player/LeftClick");
        leftClickAction.performed += OnClick;
        leftClickAction.canceled += OnRelease;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 linearVelocity = rigidbody_.linearVelocity;
        if(linearVelocity.sqrMagnitude>maxSpeed_*maxSpeed_)
        {
            rigidbody_.linearVelocity=linearVelocity.normalized*maxSpeed_;
        }
    }

    void OnClick(InputAction.CallbackContext context)
    {
        Physics.gravity = new Vector3(0, 0, 0);
        clickPosition_ =Mouse.current.position.ReadValue();
        rigidbody_.linearVelocity=new Vector3 (0,0,0);

    }

    void OnRelease(InputAction.CallbackContext context)
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);
        Vector2 dist=clickPosition_-Mouse.current.position.ReadValue();
        if (dist.sqrMagnitude <= 0.0f) { return; }
        rigidbody_.linearVelocity=dist.normalized*jumpPower_;
    }

}

using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    //外部から値を受けつけるprivate変数
    [SerializeField]TMP_Text text_;

    //public TMP_Text text;

    InputAction leftClickAction;

    void Start()
    {
        //InputActionAssetの取得
        InputActionAsset inputActions = InputSystem.actions;
        //InputActionの取得,アセット名とアクション名で検索する
        leftClickAction = inputActions.FindAction("Player/LeftClick");
        //実行するメソッドを登録
        leftClickAction.performed += OnLeftClick;
     
    }

    private void Update()
    {
        text_.text=Time.time.ToString("f4");
    }


    private void OnLeftClick(InputAction.CallbackContext context)
    {
        Vector2 cursorPosition = Mouse.current.position.ReadValue();
        Debug.Log("Left Click : " + cursorPosition);
    }

}

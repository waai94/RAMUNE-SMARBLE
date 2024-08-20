using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


// 移動のスティック入力
public class LeftMove : MonoBehaviour
{
    public static Vector2 axis = Vector2.zero;
    Vector2 vec = Vector2.zero;

    public void OnLeftMove(InputAction.CallbackContext value)
    {
        // MoveActionの入力値を取得
        vec = value.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        axis = vec;
    }
}
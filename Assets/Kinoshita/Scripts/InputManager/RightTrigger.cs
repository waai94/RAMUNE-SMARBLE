using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightTrigger : MonoBehaviour
{
    public static Vector2 axis = Vector2.zero;
    float val = 0f;

    public void OnRightTrigger(InputAction.CallbackContext value)
    {
        // TriggerActionの入力値を取得
        val = value.ReadValue<float>();
        //Debug.Log(val);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
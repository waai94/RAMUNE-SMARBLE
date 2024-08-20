using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftTrigger : MonoBehaviour
{

    public static Vector2 axis = Vector2.zero;
    float val = 0f;

    public void OnLeftTrigger(InputAction.CallbackContext value)
    {
        // TriggerAction‚Ì“ü—Í’l‚ðŽæ“¾
        val = value.ReadValue<float>();
        Debug.Log(val);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftTrigger : MonoBehaviour
{

    public static float val;

    private void Start()
    {
        val = 0;
    }

    public void OnLeftTrigger(InputAction.CallbackContext value)
    {
        // TriggerAction‚Ì“ü—Í’l‚ðŽæ“¾
        val = value.ReadValue<float>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


// �ړ��̃X�e�B�b�N����
public class RightMove : MonoBehaviour
{
    public static Vector2 axis = Vector2.zero;
    Vector2 vec = Vector2.zero;

    public void OnRightMove(InputAction.CallbackContext value)
    {
        // MoveAction�̓��͒l���擾
        vec = value.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        axis = vec;
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class CursorManager : MonoBehaviour
{
    [SerializeField] VirtualMouseInput mouseInput;

    // Start is called before the first frame update
    void Start()
    {
        mouseInput.enabled = true;
    }
}

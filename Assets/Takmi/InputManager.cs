using UnityEngine;
using UnityEngine.InputSystem;
public class CurrentInputTest : MonoBehaviour
{
    void Update()
    {
        print(Input.GetAxis("Horizontal2"));
    }
}
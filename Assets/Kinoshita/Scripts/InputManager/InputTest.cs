using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    Transform TF;
    // Start is called before the first frame update
    void Start()
    {
        TF = transform;
    }

    // Update is called once per frame
    void Update()
    {
        var leftMove = LeftMove.axis; // �E�X�e�B�b�N����(Vector2)
        var rightMove = RightMove.axis; // ���X�e�B�b�N����(Vector2)
        var rightTrigger = RightTrigger.val; // �E�g���K�[����(float) 0�`1
        var leftTrigger = LeftTrigger.val; // ���g���K�[����(float) 0�`1

        TF.position += new Vector3(LeftMove.axis.x, LeftMove.axis.y, 0) * Time.deltaTime;


        Debug.Log(rightTrigger);
    }
}

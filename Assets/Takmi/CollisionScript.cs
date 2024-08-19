using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] GameObject myParent;
    CurrentInputTest myParentScript;
    // Start is called before the first frame update
    void Start()
    {
        myParentScript = myParent.GetComponent<CurrentInputTest>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // �q�I�u�W�F�N�g�̌��݂̃��[���h��]���擾
        Quaternion targetRotation = Quaternion.identity; // ���[���h��Ԃł̉�]�̓[��

        // �q�I�u�W�F�N�g�̌��݂̃��[�J����]
        Quaternion localRotation = transform.localRotation;

        // �e�I�u�W�F�N�g�̉�]���l�����āA�q�I�u�W�F�N�g�̃��[�J����]���v�Z
        Quaternion adjustedLocalRotation = Quaternion.Inverse(transform.parent.rotation) * targetRotation;

        // �q�I�u�W�F�N�g�̃��[�J����]��ݒ�
        transform.localRotation = adjustedLocalRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("glass"))
        {
            myParentScript.isHitToGlass = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("glass"))
        {
            myParentScript.isHitToGlass = false;
        }
    }
}

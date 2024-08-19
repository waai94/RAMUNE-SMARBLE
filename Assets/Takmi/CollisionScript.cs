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
        // 子オブジェクトの現在のワールド回転を取得
        Quaternion targetRotation = Quaternion.identity; // ワールド空間での回転はゼロ

        // 子オブジェクトの現在のローカル回転
        Quaternion localRotation = transform.localRotation;

        // 親オブジェクトの回転を考慮して、子オブジェクトのローカル回転を計算
        Quaternion adjustedLocalRotation = Quaternion.Inverse(transform.parent.rotation) * targetRotation;

        // 子オブジェクトのローカル回転を設定
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

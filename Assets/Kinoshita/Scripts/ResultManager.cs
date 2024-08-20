using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [SerializeField] GameObject Finished;
    [SerializeField] GameObject[] setSetActiveFalse;
    [SerializeField] GameObject[] setSetActiveTrue;
    bool isAwake = false;
    float time = 0;


    // Update is called once per frame
    void Update()
    {
        if (Finished.activeSelf)
        {
            time += Time.deltaTime;
        }

        if (isAwake == false && time > 2)// ƒŠƒUƒ‹ƒgo‚·‚Ü‚Å‚ÌŠÔ
        {
            isAwake = true;
            for (int i = 0; i < setSetActiveTrue.Length; i++)
            {
                setSetActiveTrue[i].SetActive(true);
            }
            for (int i = 0; i < setSetActiveFalse.Length; i++)
            {
                setSetActiveFalse[i].SetActive(false);
            }
        }

    }
}

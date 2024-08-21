using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField] GameObject Finished;
    [SerializeField] GameObject[] setSetActiveFalse;
    [SerializeField] GameObject[] setSetActiveTrue;
    [SerializeField] GameObject[] drink;
    bool isAwake = false;
    float time = 0;


    [SerializeField] GameManagerScript gameManager;
    [SerializeField] GameObject OkaneText;


    // Update is called once per frame
    void Update()
    {
        float sum = 0;

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

            StartCoroutine(drinkSet());

            for (int i = 0; i < gameManager.result.Length; i++)
            {
                /*
                string r = gameManager.result[i].ToString("f1") + "% ";
                string l = (100 - gameManager.result[i]).ToString("f1") + "% ";
                */

                
            }

            
        }

        IEnumerator drinkSet()
        {
            for (int i = 0; i < drink.Length; i++)
            {
                yield return new WaitForSeconds(0.5f);
                drink[i].SetActive(true);

                sum += gameManager.okane[i];
                int intSum = (int)sum;
                string okane = intSum.ToString() + "YEN";
                OkaneText.GetComponent<Text>().text = okane;
            }
        }
    }
}

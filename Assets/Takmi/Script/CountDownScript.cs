using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour
{
    int three = 3;

    [SerializeField] Text countText;
    [SerializeField] GameObject counter;
    [SerializeField] GameObject glass;
    Animator startAnim;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Count),1.0f,1.0f);
        startAnim = counter.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (three > 0)
        {
            countText.text = three.ToString();
        }
        else
        {
            countText.text = "Let's go!";
            startAnim.SetBool("start",true);
        }
       
    }

    void Count()
    {
        
        if (three < 0)
        {
            counter.SetActive(false);
            Instantiate(glass);
            CancelInvoke();

        }
        else
        {
            three--;
        }
    }
}

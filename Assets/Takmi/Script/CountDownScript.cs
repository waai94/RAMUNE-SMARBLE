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
    AudioSource AudioSource;
    Animator startAnim;

    [SerializeField] AudioClip startse;
    [SerializeField] AudioClip BGM;
    [SerializeField] AudioClip count;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Count),1.0f,1.0f);
        startAnim = counter.GetComponent<Animator>();
        AudioSource = this.GetComponent<AudioSource>();
        startAnim.Play("startanim", 0, 0);

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
            countText.text = "Let's Mixin'!";
            //startAnim.SetBool("start",true);
           
       
        }
       
    }

    void Count()
    {
     
        if (three <= 0)
        {
            counter.SetActive(false);
            Instantiate(glass);
            AudioSource.PlayOneShot(BGM);
          
            CancelInvoke();

        }
        else if (three ==1)
        {
            AudioSource.PlayOneShot(startse);
            three--;
            startAnim.Play("startanim", 0, 0);
        }
        else
        {
            three--;
            //  AudioSource.PlayOneShot(count);
            startAnim.Play("startanim", 0, 0);
        }
    }
}

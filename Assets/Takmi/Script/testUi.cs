using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class testUi : MonoBehaviour
{
   public Text texta;
    GameObject glass;
    GlassScript GS;
    [SerializeField]GameObject manager;
    GameManagerScript MS;


    // Start is called before the first frame update
    void Start()
    {
        // texta = this.GetComponent<Text>();
        MS = manager.GetComponent<GameManagerScript>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (texta!=null)
        {

            texta.text = MS.makestring();
        
        }

       
    }
}

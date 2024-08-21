using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("click");
        SceneManager.LoadScene("takmiscnee_copy3");
    }
}

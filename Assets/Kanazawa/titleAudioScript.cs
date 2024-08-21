using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleAudioandSceneScript : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip UISE;      //UIのSE
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void UIAudioplay()
    {
        //UIのSEを鳴らすよ！
        AudioSource.PlayOneShot(UISE);
    }

    //ゲームシーンに切り替える
    public void StartScene()
    {
        SceneManager.LoadScene("takmiscnee_copy3");
    }
}

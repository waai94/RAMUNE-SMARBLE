using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleAudioandSceneScript : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip UISE;      //UI��SE
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void UIAudioplay()
    {
        //UI��SE��炷��I
        AudioSource.PlayOneShot(UISE);
    }

    //�Q�[���V�[���ɐ؂�ւ���
    public void StartScene()
    {
        SceneManager.LoadScene("takmiscnee_copy3");
    }
}

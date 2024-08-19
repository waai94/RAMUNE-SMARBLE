using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassScript : MonoBehaviour
{//‰t‘Ì‚Ì’PˆÊ‚Íml
    [SerializeField] float GlassSize = 0;
    [SerializeField] float MinGlassSize = 240f;
    [SerializeField] float MaxGlassSize = 590f;

    public float NowGlassTaiseki = 0;
    // Start is called before the first frame update
    void Start()
    {
        MaxGlassSize = Random.Range(MinGlassSize, MaxGlassSize);
    }

    // Update is called once per frame
    void Update()
    {
        print(NowGlassTaiseki);    }
}

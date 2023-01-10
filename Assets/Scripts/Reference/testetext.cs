using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testetext : MonoBehaviour
{
    public Text txt;
    private float time;
    private float i;

    // Start is called before the first frame update
    void Start()

    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        i += Time.deltaTime;
        txt.text = i.ToString();
    }
}

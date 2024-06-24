using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public static int hp = 3;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    // Start is called before the first frame update
    void Start()
    {
        hp = 3;

        heart1.GetComponent<Image>().enabled = true;
        heart2.GetComponent<Image>().enabled = true;
        heart3.GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (hp)
        {
            case 2:
                heart3.GetComponent<Image>().enabled = false; break;
            case 1:
                heart2.GetComponent <Image>().enabled = false; break;
            case 0:
                heart1.GetComponent<Image>().enabled = false; break;
        }
    }
}
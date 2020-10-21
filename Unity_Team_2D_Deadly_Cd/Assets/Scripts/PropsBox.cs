using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsBox : MonoBehaviour
{
    public SpriteRenderer bgImage;
    //public Text bgText;
    public float bgTime = 0;

    private void PropBox()
    {
        float _overtime = 0;
        _overtime += Time.deltaTime;
        if (_overtime >= bgTime)
        {
            float tmp = 255;
            tmp -= Time.deltaTime;
            bgImage.color = new Color(1, 1, 1, tmp);
        }
    }
    private void Update()
    {
        //PropBox();
    }
}

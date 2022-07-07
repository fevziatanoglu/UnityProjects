using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float backGroundSpeed = -1;
    void Update()
    {
        //Arka plan sürekli sola gitsin
        gameObject.transform.Translate(new Vector3(backGroundSpeed, 0, 0) * Time.deltaTime);
        if (gameObject.transform.position.x < -30f)
        {
            //Kamera açýsýndan çýktýðýnda kameranýn soluna geçsin
            gameObject.transform.position = new Vector3(51.5f,0,10);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update


    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AmmoUp"){
            GameManager.ammoAmount+=5;
        }

        if (collision.gameObject.tag == "LifeUp")
        {
         
            GameManager.playerLife++;   
        }

        if (collision.gameObject.tag == "Enemy")
        {
            
            GameManager.playerLife--;
        }
    }




}

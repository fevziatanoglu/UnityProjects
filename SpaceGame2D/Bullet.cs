using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
            
            gameObject.GetComponent<Rigidbody2D>().transform.Translate(new Vector3(10,0,0)*  Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}

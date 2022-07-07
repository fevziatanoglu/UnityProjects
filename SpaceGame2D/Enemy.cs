using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource explosionSound;

    void Update()
    {
        //Dusmanlar surekli sola gitsin
        //gameObject.GetComponent<Rigidbody2D>().transform.Translate(new Vector3(-10, 0, 0) * Time.deltaTime);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameManager.ExplosionSound();
            GameManager.score += 50;
            Destroy(this.gameObject);
        }


        if (collision.gameObject.tag == "Base")
        {
            GameManager.playerLife -= 2;
            Destroy(this.gameObject);
        }

    }
}

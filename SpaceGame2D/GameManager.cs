using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isStart = false;

    //Player
    public GameObject playerObject;
    public Transform player;
    public GameObject PlayerPNG;
    public float playerSpeed = 1;
    public Vector2 direction;

    //Bullet
    public GameObject bullet;

    public bool aimPointBool = false;
    public List<Transform> aimPoints;
    public float bulletSpeed = 10;

    
    public float enemyTimer = 1.5f;


    public static int ammoAmount = 10;
    public List<GameObject> enemies;
    public List<GameObject> powerUps;
    public float powerUpsTimer = 5;

    public static int playerLife =5;
    public static float score;
    public AudioSource bulletSound;
    public static AudioSource explosionSound;
    //UI
    public GameObject joysticks;
    public GameObject uIGame;
    public GameObject menu;
    public GameObject gameOverScreen;
    public TMPro.TMP_Text lastScoreText;
    public TMPro.TMP_Text lifeText;
    public TMPro.TMP_Text ammoText;
    public TMPro.TMP_Text scoreText;
    // Update is called once per frame
     void Start()
    {
        explosionSound = gameObject.GetComponent<AudioSource>();
        menu.SetActive(true);
        uIGame.SetActive(false);
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
        isStart = false;
        

        ammoAmount = 10;
        playerLife = 5;
        score = 0;
        gameOverScreen.SetActive(false);    
    }

    void Update()
    {
        if (isStart)
        {
         Game();
        }                
     }


    public void Game()
    {
        Life();
        Score();
        PlayerMove();
        //Shooting(bullet, aimPoints, bulletSpeed);



        enemyTimer -= 1 * Time.deltaTime;
        if (enemyTimer <= 0) { Generate(enemies, -11); Generate(enemies, -11); enemyTimer = 2.5f; }

        powerUpsTimer -= 1 * Time.deltaTime;
        if (powerUpsTimer <= 0) { Generate(powerUps, -8); powerUpsTimer = 5f; }

    }


    public void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 movment = new Vector3(x, y, 0);

        player.Translate((JoysticksControl.joystickVec) * playerSpeed * Time.deltaTime);
        PlayerPNG.transform.rotation = Quaternion.Euler(0, 0, JoysticksControl.joystickVec.y * 30);

    }
    public void Generate(List<GameObject> gameObjects,float generateSpeed)
    {
            
            //x 10da ve y -4,4 arasýndaki bi konumda , girilen game object türünde , girilen hýz baþlangýç hýzý,-5 arasýnda hýzala bi obje oluþtur
            Vector2 generatePosition = new Vector2(10,Random.RandomRange(-4,4));
            GameObject clone = Instantiate(gameObjects[Random.Range(0,gameObjects.Count)], generatePosition, Quaternion.identity);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.RandomRange(generateSpeed,-5), 0);
            
                    
    }

    public void Shooting(GameObject bullet, List<Transform> aimPoints, float bulletSpeed)
    {
        bulletSound.Play();
        //Mermi miktarýno yazdýr
        ammoText.text =ammoAmount.ToString();
        GameObject bulletClone;
        //AimPointBool true ise üst taraftan false ise alt taraftan ateþ et ve mermi miktarýný 1 azalt
        if (aimPointBool== false && ammoAmount >0)
        {bulletClone = Instantiate(bullet, aimPoints[1].position, Quaternion.Euler(PlayerPNG.transform.rotation.eulerAngles)); aimPointBool = true; ammoAmount--; }

        else if ( aimPointBool == true && ammoAmount > 0)
        {bulletClone = Instantiate(bullet, aimPoints[0].position, Quaternion.Euler(PlayerPNG.transform.rotation.eulerAngles)); aimPointBool = false; ammoAmount--; }
    }

  public void Life()
    {
        
        if (playerLife > 5) { playerLife = 5; }
        lifeText.text =playerLife.ToString();
        GameOver();
    }

    public void GameOver()
    {
        if (playerLife <= 0)
        {
            gameOverScreen.SetActive(true);
            lastScoreText.text = "Score : " + score.ToString("00");
            Time.timeScale = 0;


        }

    }

    public void Score()
    {
        score += 10*Time.deltaTime;
        scoreText.text = score.ToString("00");

    }

    public void ShootingButton()
    {
        Shooting(bullet, aimPoints, bulletSpeed);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void StartButton()
    {
        isStart = true;
        joysticks.SetActive(true);
        menu.SetActive(false);
        uIGame.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public static void ExplosionSound()
    {
        explosionSound.Play();
    }

}
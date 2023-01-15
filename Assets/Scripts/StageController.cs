using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageController : MonoBehaviour
{
    [Header("Player GameObject")]
    public GameObject player; // Player game object 
    public GameObject playerIdle; // Player idle
    public GameObject playerHit; // Sprite hit the barrel
    private bool positionPlayer = true; // Get side of player (true = left, false = right)
    private float playerScaleHorizontal; // Player sprite side cotroller

    // Barrel Settings
    private List<GameObject> listBarreal;
    private int listSize = 8;
    private float barrelSize = 1.2f;

    // Load prefabs
    [Header("Load prefabs")]
    public GameObject prefabBarrel;
    public GameObject prefabBarrelLeft;
    public GameObject prefabBarrelRight;

    [Header("Load components")]
    public GameObject hud;
    public GameObject lifeBar;
    public GameObject playAgain;
    public GameObject txtPressStart;
    public Text txtScore;
    public Text txtLevel;

    [Header("Audio Source")]
    private AudioSource sound_hit;
    private AudioSource sound_dead;
    private AudioSource sound_break;
    private AudioSource sound_levelup;

    // Stage controller
    private float life;
    private float lifeLost;
    private float lifeGain;
    private int level;
    private int levelParameter;
    private float dropBarrelSafe;
    
    private static int score;
    private bool game_start;
    private bool game_over;

    // Constructs
    public static int GetScore {
        get {return score;}
    }

    // Game Start 
    private void Awake() {
        score = 0;
        life = lifeBar.transform.localScale.x;
        lifeLost = 0.15f;
        lifeGain = 0.035f;
        dropBarrelSafe = 0.7f;
        levelParameter = 30;
        level = 1;
        game_start = false;
        game_over = false;
        playerHit.SetActive(false); 
        listBarreal = new List<GameObject>();   
    }

    void Start()
    {
        playerScaleHorizontal = player.transform.localScale.x;
        sound_hit = GameObject.Find("Sounds/Hit").GetComponent<AudioSource>();
        sound_dead = GameObject.Find("Sounds/Dead").GetComponent<AudioSource>();
        sound_break = GameObject.Find("Sounds/BreakBarrel").GetComponent<AudioSource>();
        sound_levelup = GameObject.Find("Sounds/LevelUP").GetComponent<AudioSource>();
        CreateObstacles();
        InvokeRepeating("LevelUP", 0f, 1.0f);
    }

    void Update()
    { 
        if (!game_over) 
        {
            if(game_start) {
                if (Input.GetButtonDown("Fire1")) {                
                    if (Input.mousePosition.x > Screen.width/2 ) {
                        HitRight();
                    } else {
                        HitLeft();
                    }
                }

                if (Input.GetButtonDown("Horizontal")) {
                    if (Input.GetAxis("Horizontal") > 0 ) {
                        HitRight();
                    } else {
                        HitLeft();
                    }  
                }
            } else {
                if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Horizontal")) {
                    game_start = true;
                }
            }
        }
        CanvasGUI();
        SetLifeBar();
    }
    

    private void HitRight() {
        positionPlayer = true;
        playerHit.SetActive(true);
        playerIdle.SetActive(false);  
        sound_hit.Play();
        player.transform.position = new Vector2(1.1f, player.transform.position.y);
        player.transform.localScale = new Vector2(-playerScaleHorizontal, player.transform.localScale.y);
        Invoke("HitAction", 0.2f);
        listBarreal[0].SendMessage("TapRight");
        sound_break.Play();
        listBarreal.RemoveAt(0);
        CheckPlay();
        spawnBarrel();

    }

    private void HitLeft() {
        positionPlayer = false;
        playerHit.SetActive(true);
        playerIdle.SetActive(false);  
        sound_hit.Play();
        player.transform.position = new Vector2(-1.1f, player.transform.position.y);
        player.transform.localScale = new Vector2(playerScaleHorizontal, player.transform.localScale.y);
        Invoke("HitAction", 0.2f);
        listBarreal[0].SendMessage("TapLeft");
        sound_break.Play();
        listBarreal.RemoveAt(0);
        CheckPlay();
        spawnBarrel();

    }

    private void HitAction() {
        playerHit.SetActive(false);
        playerIdle.SetActive(true);   

    }

    private GameObject NewBarrel(Vector2 position) {

        GameObject newBarrel;
        if (listBarreal.Count > 2) {
            if (Random.value <= dropBarrelSafe){
                newBarrel = Instantiate(prefabBarrel);
            } else {
                if (Random.value <= ((1.0f - dropBarrelSafe)/2)){
                    newBarrel = Instantiate(prefabBarrelLeft);
                } else {
                    newBarrel = Instantiate(prefabBarrelRight);
                }
            }
        } else {
            newBarrel = Instantiate(prefabBarrel);
        }
        newBarrel.transform.position = position;

        return newBarrel;

    }

    void CreateObstacles() {
        for (int i=0; i <= listSize; i++) {
            GameObject newBarrel = NewBarrel(new Vector2(0,-3.6f+(i*barrelSize)));
            listBarreal.Add(newBarrel);

        }
    }

    void spawnBarrel() {
        GameObject newBarrel = NewBarrel(new Vector2(0,-3.6f+((listSize + 1)* barrelSize)));
        listBarreal.Add(newBarrel);
         for (int i=0; i <= listSize; i++) {
            listBarreal[i].transform.position = new Vector2(listBarreal[i].transform.position.x, listBarreal[i].transform.position.y - barrelSize);
        }
    }

    private void SetLifeBar() {
        if (game_start && !game_over) {
            if (lifeBar.transform.localScale.x > 0f) {
                life = life - lifeLost * Time.deltaTime;
                lifeBar.transform.localScale = new Vector2(life, lifeBar.transform.localScale.y);
            } else {
                lifeBar.transform.localScale = new Vector2(0f, lifeBar.transform.localScale.y);
                GameOver();
            }
        }
    }

    private void SetScore() {
        score++;
        // print(lifeBar.transform.localScale.x);
        if (lifeBar.transform.localScale.x < (1.0f - lifeGain)) {
            life = life + lifeGain;
            lifeBar.transform.localScale = new Vector2(life, lifeBar.transform.localScale.y);
        } else {
            lifeBar.transform.localScale = new Vector2(1f, lifeBar.transform.localScale.y);
        }

    }

    void CheckPlay() {
        if (listBarreal[0].gameObject.CompareTag("Empty")) {
            // print("Acertou");
            SetScore();
        } else if (listBarreal[0].gameObject.CompareTag("EnemyLeft") && !positionPlayer || listBarreal[0].gameObject.CompareTag("EnemyRight") && positionPlayer) {
            
                // print("Errou!!");
                GameOver();
            } else {
                // print("Acertou");
                SetScore();
        }
    }

    private void LevelUP() {
        if (score > levelParameter && !game_over) {
            levelParameter = levelParameter + 30;
            level++;
            sound_levelup.Play();
            
            // There are 3 possibilities to increase the difficulty, all randomly.
            // Increase the speed that life falls (20%)
            if (Random.value > 0.8f) {
                lifeLost = lifeLost + 0.02f ; // Defaul 0.15f - Increase to difficulty
                if (lifeLost > 0.3f) {
                    lifeLost = 0.3f;
                }
            // Decrease health recovery per hit (40%)
            } else if (Random.value > 0.6f) {
                lifeGain = lifeGain - 0.005f ; // Defaul 0.035f - Decrease to difficulty
                if (lifeGain < 0.015f) {
                    lifeGain = 0.015f;
                }
            // Decrease safe barrel drop rate (60%)
            } else {
                dropBarrelSafe = dropBarrelSafe - 0.1f ; // Defaul 0.7f - Decrease to difficulty
                if (dropBarrelSafe < 0.1f) {
                    dropBarrelSafe = 0.1f;
                }
            }
        }
        if (!game_over) {
            txtLevel.text = "Lv." + level.ToString(); 
        }
    }

    public void GameOver() {
        game_over = true;

        playerHit.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.35f, 0.35f);
        playerIdle.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.35f, 0.35f);

        player.GetComponent<Rigidbody2D>().isKinematic = false;

        if (positionPlayer) {
            player.GetComponent<Rigidbody2D>().AddTorque(-100.0f);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(10.0f, 3.0f);
        } else {
            player.GetComponent<Rigidbody2D>().AddTorque(100.0f);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(-10.0f, 3.0f);
        }
        sound_dead.Play();
    }

    // Responsable for all elements at CANVAS (UI)
    private void CanvasGUI() {
        if (game_start && !game_over) {
            if (txtPressStart.activeSelf) {
                txtPressStart.SetActive(false);
            }
            if (!hud.activeSelf) {
                hud.SetActive(true);
            }
            txtScore.text = "Score: " + score.ToString();
            
        }

        if (game_over) {
            /*if (!txtPressStart.activeSelf) {
                txtPressStart.SetActive(true);
            }
            txtScore.transform.position = new Vector2(Screen.width/2,
                                                      Screen.height/2);
            txtScore.fontSize = 60;*/
            if (!playAgain.activeSelf) {
                
                Invoke("CanvasGUIModal", 1.5f);
            }
            

        }
    }

    private void CanvasGUIModal() {
        playAgain.SetActive(true);
        if (hud.activeSelf) {
            hud.SetActive(false);
        }
    }   
    
}

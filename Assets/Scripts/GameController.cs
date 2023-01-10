using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    /* 
    [Header("Set Enemy Game Object")]
    public GameObject enemyPrefab;
    public List<GameObject> enemys = new List<GameObject>();
    private GameObject player;
    private GameObject playAgainPanel;
    private Text pressStart;
    private Text textScore;
    [System.NonSerialized] public int score; //Not visible in Inspector
    [System.NonSerialized] public bool gameover = false;
    [System.NonSerialized] public bool gamestart = false;
    */
    private static int game_score;
    private static bool game_over;
    private static bool game_start;

    public static int GetScore {
        get { return game_score; }
    }
    
    // Func for export values
    public static bool GetGameStart {
        get { return game_start;}
    }

    public static bool GetGameOver {
        get { return game_over;}
    }
    
    private void Awake() {
        game_score = 0;
        game_over = false;
        game_start = false;
    }
    
    void Start() {
        /*
        player = GameObject.FindGameObjectWithTag("Player");
        playAgainPanel = GameObject.Find("Play Again Panel");
        textScore = GameObject.Find("Score").GetComponent<Text>();
        pressStart = GameObject.Find("Press Start").GetComponent<Text>();
        pressStart.text = "Touch for start";
        */
    }

    
    void Update()
    {
        if(!game_over) {
            //CheckPoints();
        } else if (game_over) {
            //Invoke("PlayAgain", 0.3f);
        }
        CanvasGUI();
    }


    private void RespawnEnemys() 
    {
        if(!game_over) {
            /*
            float heightRandom = 10.0f * Random.value - 5;
            GameObject newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector2(15.0f, heightRandom);
            enemys.Add(newEnemy);
            EnemyVelocity();
            */
        }

    }

    /*
    public void CheckPoints(){
        if (score % 3 == 0 && score > 0) {
            enemySpeed = enemySpeed - 0.1f/275;
            print(enemySpeed.ToString());
        }
        
        foreach (var enemy in enemys.ToArray())
        {
            if(enemy != null){
                if(player.transform.position.x > enemy.transform.position.x) {
                    enemys.Remove(enemy);
                    score++;
                }
            }
        } 
    }*/

    /*private void EnemyVelocity(){
        
        foreach (var enemy in enemys.ToArray())
        {
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(enemySpeed,0);
        }
    }*/

    private void CanvasGUI() {
        /*
        if (!gamestart) {
            if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("space") || Input.GetKeyDown("return")) {       
                playAgainPanel.SetActive(false);
                pressStart.text = "";
                InvokeRepeating("RespawnEnemys", 1.0f, 1.5f);
                gamestart = true;
            }
        } else {
            textScore.text = "Score: " + score.ToString();
        }
        if (gameover) {
            playAgainPanel.SetActive(true);
            pressStart.text = "Touch for Play again";
            pressStart.transform.position = new Vector2(Screen.width/2,Screen.height/2 - 50);
            textScore.transform.position  = new Vector2(Screen.width/2,Screen.height/2 + 40);
            textScore.fontSize = 100;

        }*/
    }

    private void PlayAgain() {
        /*if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("space") || Input.GetKeyDown("return") ) { 
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }*/
    }


    public void GameOver() {
        game_over = true;
    }    
}

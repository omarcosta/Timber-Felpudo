using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{   
    [Header("Effect: Spark")]
    public int pointsStartSparkExplosion = 50;
    public int pointsStartSpark = 80;
    public int pointsLimiteSpark = 120;
    public GameObject sparkPrefab;
    public GameObject sparkExplosionPrefab;
    private GameObject spark;
    private AudioSource soundSpark;
    private AudioSource soundSparkExplosion;
    private bool sparkRun = false;
    private bool sparkExplosionRun = true;
    private bool destroySpark = false;


    [Header("Effect: Fire")]
    public int pointsStartFireExplosion = 120;
    public int pointsStartFire = 150;
    public int pointsLimiteFire = 10000;
    public GameObject firePrefab;
    public GameObject fireExplosionPrefab;
    private GameObject fire;
    private AudioSource soundFire;
    private AudioSource soundFireExplosion;
    private AudioSource soundBigExplosion;
    private bool fireRun = false;
    private bool fireExplosionRun = true;
    private bool destroyFire = false;


    //GameController controlVariables
    private GameObject player;
    private int score;
    private bool gameover;
    
    void Start() {
        InvokeRepeating("GetControlVariables", 1.0f, 1.0f);
        player = GameObject.FindGameObjectWithTag("Player");
        soundSpark = GameObject.Find("Effects/Sounds/Spark").GetComponent<AudioSource>();
        soundFire = GameObject.Find("Effects/Sounds/Fire").GetComponent<AudioSource>();
        soundSparkExplosion = GameObject.Find("Effects/Sounds/Spark Explosion").GetComponent<AudioSource>();
        soundFireExplosion = GameObject.Find("Effects/Sounds/Fire Explosion").GetComponent<AudioSource>();
        soundBigExplosion = GameObject.Find("Effects/Sounds/Big Explosion").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetControlVariables();
        if (!gameover) { // If game is run 
            if (!destroySpark) { // Spark Effect
                if (score > pointsStartSparkExplosion &&  score < pointsStartSpark && sparkExplosionRun) { // Spark Explosions ---> 75
                    InvokeRepeating("EffectSparkExplosions", 1.0f, 3.0f);
                    sparkExplosionRun = false;
                } else if (score > pointsStartSpark && score < pointsLimiteSpark) { // Call SPARK ---> 115
                    EffectSpark();
                } else if (score > pointsLimiteSpark) {
                    destroySpark = true; // Finish this effect
                    EffectSpark();
                }
            } else if (!destroyFire) { // Fire Effect
                if (score > pointsStartFireExplosion &&  score < pointsStartFire && fireExplosionRun) { // Fire Explosions ---> 115
                    soundBigExplosion.Play();
                    Destroy(soundBigExplosion, 7f);
                    InvokeRepeating("EffectFireExplosions", 0f, 3.0f);
                    fireExplosionRun = false;
                } else if (score > pointsStartFire && score < pointsLimiteFire) { // Call Fire ---> 75
                    EffectFire(); 
                } else if (score > pointsLimiteFire ) {
                    destroyFire = true; // Finish this effect
                    EffectFire();
                }
            }
        } else {
            destroyFire = true;
            destroySpark = true;
            EffectSpark();
            EffectFire();
        }


    }


    private void GetControlVariables(){
        score = GameController.GetScore;
        gameover = GameController.GetGameOver;
        //GameController controlVariables = new GameController();
        //score = controlVariables.score;
        
    }

    // Spark effects
    private void EffectSpark() {
        if (!destroySpark) {   
            if (!sparkRun) {
                spark = Instantiate(sparkPrefab);
                spark.transform.position = player.transform.position;
                sparkRun = true;
                soundSpark.Play();
            } else {
                spark.transform.position = player.transform.position;
            }
        } else {
            Destroy(spark);
            //soundSpark.Stop();
            Destroy(soundSpark, 0f);
        }
    }

    private void EffectSparkExplosions() {
        if (!gameover) {
            if (!destroySpark) {
                GameObject newSpark = Instantiate(sparkExplosionPrefab);
                newSpark.transform.position = player.transform.position;
                soundSparkExplosion.Play();
            } else {
                Destroy(soundSparkExplosion);
            }
        }
    }

    // Fire Effets 
    private void EffectFire() {
        if (!destroyFire) {   
            if (!fireRun) {
                fire = Instantiate(firePrefab);
                fire.transform.position = player.transform.position;
                soundFire.Play();
                fireRun = true;
            } else {
                fire.transform.position = player.transform.position;
            }
        } else {
            Destroy(fire, 0f);
            //soundFire.Stop();
            Destroy(soundFire, 0f);
        }
    }

    private void EffectFireExplosions() {
        if (!gameover) {
            if (!destroyFire) {
                GameObject newFire = Instantiate(fireExplosionPrefab);
                newFire.transform.position = player.transform.position;
                soundFireExplosion.Play();
            } else {
                Destroy(soundFireExplosion);
                Destroy(soundBigExplosion);
            }
        }
    }
}

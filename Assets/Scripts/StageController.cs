using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public GameObject player;
    public GameObject playerIdle;
    public GameObject playerHit;

    private float playerScaleHorizontal;

    private void Awake() {
        playerHit.SetActive(false);    
    }

    void Start()
    {
        playerScaleHorizontal = player.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Horizontal")) {
            
            if (Input.mousePosition.x > Screen.width/2 ) {
                HitRight();
            } else {
                HitLeft();
            }

        }

        if (Input.GetButtonDown("Horizontal")) {
            float keyHorizontal = Input.GetAxis("Horizontal");
            print(keyHorizontal.ToString());
            if (Input.GetAxis("Horizontal") > 0 ) {
                HitRight();
            } else {
                HitLeft();
            }
        }
        
    }

    private void HitRight() {
        playerHit.SetActive(true);
        playerIdle.SetActive(false);  
        player.transform.position = new Vector2(1.1f, player.transform.position.y);
        player.transform.localScale = new Vector2(-playerScaleHorizontal, player.transform.localScale.y);
        Invoke("HitAction", 0.2f);

    }

    private void HitLeft() {
        playerHit.SetActive(true);
        playerIdle.SetActive(false);  
        player.transform.position = new Vector2(-1.1f, player.transform.position.y);
        player.transform.localScale = new Vector2(playerScaleHorizontal, player.transform.localScale.y);
        Invoke("HitAction", 0.2f);

    }

    private void HitAction() {
        playerHit.SetActive(false);
        playerIdle.SetActive(true);   

    }
}

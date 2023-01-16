using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private void Start() {
        
    GetComponent<Rigidbody2D>().gravityScale = 0f;
    GetComponent<Rigidbody2D>().isKinematic= true;
    }
    
    void TapRight() {
        GetComponent<Rigidbody2D>().isKinematic= false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(-10,2);
        GetComponent<Rigidbody2D>().gravityScale = 2f;
        GetComponent<Rigidbody2D>().AddTorque(100.0f);
        Invoke("DestroyBarrel", 2f);
    }

    void TapLeft() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(10,2);
        GetComponent<Rigidbody2D>().gravityScale = 2f;
         GetComponent<Rigidbody2D>().isKinematic= false;
        GetComponent<Rigidbody2D>().AddTorque(-100.0f);
        Invoke("DestroyBarrel", 2f);

    }

    void DestroyBarrel() {
        Destroy(this.gameObject);
    }
}

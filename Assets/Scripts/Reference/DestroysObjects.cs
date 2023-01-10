using System.Collections;
using UnityEngine;
public class DestroysObjects : MonoBehaviour
{   
    [Header("Destroy Mode")]
    //public enum DestroyMode { Time, Locate };
	//public DestroyMode destroyMode;
    public bool destroyForTimeSeconds = false;
    public bool destroyForPosition = false;

    [Header("Time Settings")]
    public float timeDestroySeconds = 0f;

    [Header("Position Settings")]
    public bool descending = true;
    public float valueX = 0f;
    public float valueY = 0f;
    public float valueZ = 0f;

    
    void Start()
    {
        if(destroyForTimeSeconds && destroyForPosition)
        {
            print("Select only one destroy mode.");
            
        } else if (destroyForTimeSeconds)
        {
            Invoke("RemoveNodeForTime", timeDestroySeconds);

        } else {
            print("Select a destroy mode.");
        }
        
    }

    void Update()
    {
        if (destroyForPosition && !destroyForTimeSeconds)
        {
            if (descending)
            {
                if (valueX != 0)
                {
                    if (this.transform.position.x < valueX)
                    {
                        RemoveNodeForPosition();
                    }
                } else if (valueY != 0)
                {
                    if (this.transform.position.y < valueY)
                    {
                        RemoveNodeForPosition();
                    }
                } else if (valueZ != 0)
                {
                    if (this.transform.position.z < valueZ)
                    {
                        RemoveNodeForPosition();
                    }
                } else 
                {
                    print("Position not defined.");
                }

            } else 
            {
                if (valueX != 0)
                {
                    if (this.transform.position.x > valueX)
                    {
                        RemoveNodeForPosition();
                    }
                } else if (valueY != 0)
                {
                    if (this.transform.position.y > valueY)
                    {
                        RemoveNodeForPosition();
                    }
                } else if (valueZ != 0)
                {
                    if (this.transform.position.z > valueZ)
                    {
                        RemoveNodeForPosition();
                    }
                } else 
                {
                    print("Position not defined.");
                }
            }
        }
    }

    public void RemoveNodeForTime(){
        Destroy(this.gameObject);
    }
    public void RemoveNodeForPosition(){
        Destroy(this.gameObject);
    }
}

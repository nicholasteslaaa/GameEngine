using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    KeyCode UpKey;
    KeyCode DownKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 10f;
    public bool isTouchedUpperBorder= false;
    public bool isTouchedLowerBorder= false;
    
    
    void Start()
    {
        string player = gameObject.name;
        if (player == "Player1"){
            UpKey = KeyCode.W;
            DownKey = KeyCode.S;
        }
        else if (player == "Player2"){
            DownKey = KeyCode.DownArrow;
            UpKey = KeyCode.UpArrow;

        }

    }

    // Update is called once per frame
    void Update()
    {   Debug.Log(BallController.instance.Winner);
        if (BallController.instance.Winner == "0"){
            float moveY = 0f;
            if (!isTouchedUpperBorder && Input.GetKey(UpKey)){
                moveY = 1f;
                }
            if (!isTouchedLowerBorder && Input.GetKey(DownKey)){
                moveY = -1f;
            }
            
            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y + (moveY * moveSpeed * Time.deltaTime));
            transform.position = newPosition;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.name == "UpperBorder"){
            isTouchedUpperBorder = true;
        }
        if(coll.gameObject.name == "LowerBorder"){
            isTouchedLowerBorder = true;
        }   
    }

    void OnTriggerExit2D(Collider2D coll)
    {   
        if (coll.gameObject.name != "Ball"){
            isTouchedUpperBorder= false;
            isTouchedLowerBorder= false;
        }
        
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int force;
    private int score1;
    private int score2;
    public Text txScore1;
    public Text txScore2;
    public Text txWinner;
    private GameObject panel;
    public string Winner;
    Rigidbody2D rigid;
    public static BallController instance;
    public AudioSource sound;
    public AudioClip Hit;
    public AudioClip Point;
    
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sound = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2,0).normalized;
        rigid.AddForce(arah*force);
        panel = GameObject.Find("Panel");
        panel.SetActive(false);
        Winner="0";

    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKey(KeyCode.Escape)){
            ResetBall();
            panel.SetActive(true);
            txWinner.text = "";
        }
        if (score1 == 5 || score2 == 5){
            if (score1 > score2) Winner = "1";
            else Winner = "2";
            ResetBall();
            panel.SetActive(true);
            txWinner.text = "Winner: Player "+Winner;
        }
        txScore1.text = score1.ToString();
        txScore2.text = score2.ToString();
        
    }
    
    private void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag == "Player"){
            sound.PlayOneShot(Hit);
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.linearVelocityX, sudut).normalized;
            rigid.linearVelocity = new Vector2(0,0);
            rigid.AddForce(arah * force * 2f);
        }
        if(coll.gameObject.name == "RightBorder"){
            sound.PlayOneShot(Point);
            score1+=1;
            ResetBall();
            Vector2 arah = new Vector2(2,0).normalized;
            rigid.AddForce(arah*force);
        }
        if(coll.gameObject.name  == "LeftBorder"){
            sound.PlayOneShot(Point);
            score2+=1;
            ResetBall();
            Vector2 arah = new Vector2(-2,0).normalized;
            rigid.AddForce(arah*force);
        }
    }

    void ResetBall(){
        transform.localPosition = new Vector2(0,0);
        rigid.linearVelocity = new Vector2(0,0);
    }
}

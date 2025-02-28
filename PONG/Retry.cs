using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Retry : MonoBehaviour
{   
    
    public Button mybutton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        if (mybutton.gameObject.name == "RetryButton"){
            mybutton.onClick.AddListener(start);
        }
        else if (mybutton.gameObject.name == "Menu"){
            mybutton.onClick.AddListener(menu);
        }
        else if (mybutton.gameObject.name == "StartButton"){
            mybutton.onClick.AddListener(start);
        }
    }
    

    // Update is called once per frame
    public void start(){
        SceneManager.LoadScene ("Gameplay");
    }
    public void menu(){
        SceneManager.LoadScene ("mainMenu");
    }
    
    
}

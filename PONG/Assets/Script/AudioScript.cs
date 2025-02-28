using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [SerializeField] AudioSource music;
    public AudioClip BackGroundMusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        music.clip = BackGroundMusic;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

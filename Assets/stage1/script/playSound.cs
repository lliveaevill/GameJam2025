using UnityEngine;

public class playSound : MonoBehaviour
{
    public AudioClip se;
    AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(se);
    }
}

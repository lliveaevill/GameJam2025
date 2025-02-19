using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class gomi : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] GameObject particle;
    [SerializeField] string sceneName;
    private Vector3 screenPoint;
    private Vector3 offset;
    [SerializeField] float timer;
    public AudioClip se;
    AudioSource audioSource;
    bool c;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint);
        transform.position = currentPosition;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "dustBox")
        {
            GManager.instance.stage1_score += score;
            Vector3 pos = this.transform.position;
            Instantiate(particle, new Vector3 (pos.x,pos.y,pos.z),Quaternion.identity);
            Destroy(gameObject);
            if (GManager.instance.stage1_score == score * 8)
            {
                SceneManager.LoadScene("Stage2");
            }

        }
    }
}

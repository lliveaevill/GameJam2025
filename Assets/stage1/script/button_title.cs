using UnityEngine;
using UnityEngine.SceneManagement;

public class button_title : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] AudioClip clip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        if (clip != null)
        {
            AudioManager.instance.PlaySE(clip);
        }
        SceneManager.LoadScene(sceneName);
    }
}

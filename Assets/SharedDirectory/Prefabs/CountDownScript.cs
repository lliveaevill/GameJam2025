using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownScript : MonoBehaviour
{
    [SerializeField] float timer = 30.0f;
    [SerializeField] string nextSceneName;

    Text timerText;

    /*
    GameObject instructionImageObj;
    [SerializeField] float instructionTimer = 3.0f;
    */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerText = GetComponent<Text>();
        timerText.text = "Žc‚è:" + (Mathf.Floor(timer * 10) / 10) + "•b";

        /*
        instructionImageObj = transform.Find("Image").gameObject;
        instructionImageObj.SetActive(true);
        timerText.text = "ŠJŽn‚Ü‚Å:" + (Mathf.Floor(timer * 10) / 10) + "•b";
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        instructionTimer -= Time.deltaTime;
        if(instructionTimer >= 0)
        {
            timerText.text = "ŠJŽn‚Ü‚Å:" + (Mathf.Floor(instructionTimer * 10) / 10) + "•b";
            return;
        }
        else if(instructionImageObj.activeSelf)
        {
            instructionImageObj.SetActive(false);
        }
        */



        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            timerText.text = "Žc‚è:" + 0 + "•b";
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            timerText.text = "Žc‚è:" + (Mathf.Floor(timer * 10) / 10) + "•b";
        }
    }
}

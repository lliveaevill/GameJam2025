using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer_stage1 : MonoBehaviour
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
        timerText.text = "残り:" + (Mathf.Floor(timer * 10) / 10) + "秒";

        /*
        instructionImageObj = transform.Find("Image").gameObject;
        instructionImageObj.SetActive(true);
        timerText.text = "開始まで:" + (Mathf.Floor(timer * 10) / 10) + "秒";
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        instructionTimer -= Time.deltaTime;
        if(instructionTimer >= 0)
        {
            timerText.text = "開始まで:" + (Mathf.Floor(instructionTimer * 10) / 10) + "秒";
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
            timerText.text = "残り:" + 0 + "秒";
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            timerText.text = "残り:" + (Mathf.Floor(timer * 10) / 10) + "秒";
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
public class SampleStage_ClearTextScript : MonoBehaviour
{

    //GMangerのインスタンスを取得してスコアが10なら「goodplay」と表示する
    [SerializeField] Text clearText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(GManager.instance.sample_score >= 10)
        {
            clearText.text = "うまいね";
        }
        else
        {
            clearText.text = "減ったっぴ";
        }
        //スコアをリセット
        GManager.instance.sample_score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

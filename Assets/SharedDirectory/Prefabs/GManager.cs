using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;

    // シーン間で共有したい変数を宣言
    // アクセスする際の例：  GManager.instance.totalScore += 10;
    public int totalScore = 0;

    // SampleStage用
    public bool sample_clear = false;
    public int sample_score = 0;

    // Stage1用
    public bool stage1_clear = false;
    public int stage1_score = 0;

    // Stage2用
    public bool stage2_clear = false;
    public int stage2_score = 0;

    // Stage3用
    public bool stage3_clear = false;
    public int stage3_score = 0;

    // Stage4用
    public bool stage4_clear = false;
    public int stage4_score = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


}
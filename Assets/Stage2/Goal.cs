using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class Goal : MonoBehaviour
{
    [SerializeField] private Image imageComponent; // 表示する画像のUIコンポーネント

    [Header("Poor Score (Category 1)")]
    [SerializeField] private Sprite[] poorScoreSprites;
    [SerializeField] private AudioClip[] poorScoreBgmClips;

    [Header("Below Average Score (Category 2)")]
    [SerializeField] private Sprite[] belowAvgScoreSprites;
    [SerializeField] private AudioClip[] belowAvgScoreBgmClips;

    [Header("Good Score (Category 3)")]
    [SerializeField] private Sprite[] goodScoreSprites;
    [SerializeField] private AudioClip[] goodScoreBgmClips;

    [Header("Excellent Score (Category 4)")]
    [SerializeField] private Sprite[] excellentScoreSprites;
    [SerializeField] private AudioClip[] excellentScoreBgmClips;

    [SerializeField] private AudioSource audioSource;        // BGM再生用AudioSource
    [SerializeField] private float updateDelay = 5f;           // 更新間隔（秒）

    // 各カテゴリーのしきい値（例：score < 10 : Poor、10～19 : Below Average、20～29 : Good、30以上 : Excellent）
    [SerializeField] private int poorThreshold = 1;
    [SerializeField] private int belowAvgThreshold = 3;
    [SerializeField] private int goodThreshold = 60;

    [SerializeField] private GameObject[] obj;

    void Start()
    {
        // シーン開始時に一度更新
        UpdateImageAndBGM(GManager.instance.stage1_score);
        // 定期更新開始
        StartCoroutine(PeriodicUpdate());
    }

    IEnumerator PeriodicUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(updateDelay);
            UpdateImageAndBGM(GManager.instance.stage1_score);
        }
    }

    void UpdateImageAndBGM(int score)
    {
        Debug.Log("Score: " + score);

        // カテゴリー別に分岐し、各カテゴリー内で5点ごとに次の画像/BGMに進む（配列のインデックスの計算）
        if (score < poorThreshold)
        {
            // Category 1: Poor Score
            int index = score / 5;
            if(index >= poorScoreSprites.Length)
            {
                index = poorScoreSprites.Length - 1;
            }
            imageComponent.sprite = poorScoreSprites[index];
            if (index < poorScoreBgmClips.Length && audioSource.clip != poorScoreBgmClips[index])
            {
                audioSource.clip = poorScoreBgmClips[index];
                audioSource.Play();
            }
        }
        else if (score < belowAvgThreshold)
        {
            // Category 2: Below Average
            int index = (score - poorThreshold) / 5;
            if(index >= belowAvgScoreSprites.Length)
            {
                index = belowAvgScoreSprites.Length - 1;
            }
            imageComponent.sprite = belowAvgScoreSprites[index];
            if (index < belowAvgScoreBgmClips.Length && audioSource.clip != belowAvgScoreBgmClips[index])
            {
                audioSource.clip = belowAvgScoreBgmClips[index];
                audioSource.Play();
            }
        }
        else if (score < goodThreshold)
        {
            // Category 3: Good Score
            int index = (score - belowAvgThreshold) / 5;
            if(index >= goodScoreSprites.Length)
            {
                index = goodScoreSprites.Length - 1;
            }
            imageComponent.sprite = goodScoreSprites[index];
            if (index < goodScoreBgmClips.Length && audioSource.clip != goodScoreBgmClips[index])
            {
                audioSource.clip = goodScoreBgmClips[index];
                audioSource.Play();
            }
            obj[0].SetActive(true);
        }
        else
        {
            // Category 4: Excellent Score
            int index = (score - goodThreshold) / 5;
            if(index >= excellentScoreSprites.Length)
            {
                index = excellentScoreSprites.Length - 1;
            }
            imageComponent.sprite = excellentScoreSprites[index];
            if (index < excellentScoreBgmClips.Length && audioSource.clip != excellentScoreBgmClips[index])
            {
                audioSource.clip = excellentScoreBgmClips[index];
                audioSource.Play();
            }
             obj[1].SetActive(true);
        }
    }
}
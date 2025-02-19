using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stage2Button : MonoBehaviour
{
    int clickNum = 0;
    bool isCooldown = false;

    [Header("移動設定")]
    [SerializeField] Vector3 speed;
    [SerializeField] float cooldownTime = 2.0f; // クールタイム（秒）
    [SerializeField] AudioClip clickSound;      // ボタンクリック時のサウンド

    [Header("UI設定")]
    [SerializeField] GameObject image;          // 5回目以降に表示する画像など
    [SerializeField] List<TypewriterEffectWithSound> typewriterEffects;  // テキスト表示用スクリプトのリスト
    [SerializeField] List<string> messages;     // メッセージリスト

    private AudioSource audioSource;

    void Start()
    {
        // AudioSourceの取得または追加
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime;
        if (transform.position.x >= 10 || transform.position.x <= -10)
        {
            speed *= -1;
        }
        Debug.Log("Score: " + clickNum);
    }

    public void Button1Click() {
        if (isCooldown) return;

        clickNum++;
        GManager.instance.sample_score += 1;

        // クリック音を再生
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        // クリック数に応じてメッセージを更新
        for (int i = 0; i < typewriterEffects.Count; i++)
        {
            int messageIndex = (clickNum - 1) * 4 + i;
            if (messageIndex < messages.Count)
            {
                typewriterEffects[i].DisplayText(messages[messageIndex]);
            }
            else
            {
                // メッセージが足りない場合、リストの最初に戻る
                typewriterEffects[i].DisplayText(messages[messageIndex % messages.Count]);
            }
        }

        // 5回以上クリックされたら画像を表示
        if (clickNum >= 5 && image != null)
        {
            image.SetActive(true);
        }

        StartCoroutine(Cooldown());

        // メッセージリストの最後まで表示したらクリック数をリセット
        if ((clickNum - 1) * 4 >= messages.Count)
        {
            clickNum = 0;
        }
    }

    IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}
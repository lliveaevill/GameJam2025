using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypewriterEffectWithSound : MonoBehaviour
{
    [Header("テキスト設定")]
    public Text legacyText;             // UI Textコンポーネント（Inspectorでアサイン）
    public float delay = 0.1f;          // 各文字表示間の待機時間（秒）

    [Header("サウンド設定")]
    public AudioClip tickSound;         // 各文字表示時に再生する短い音
    [Range(0f, 1f)]
    public float tickVolume = 0.5f;     // 音量

    [Header("揺れ設定")]
    public float shakeAmount = 5f;      // UIの揺れの強さ

    private AudioSource audioSource;
    private RectTransform imageRectTransform;
    
    private string currentFullText = "";

    void Start()
    {
        // AudioSourceの取得または自動追加
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (legacyText == null)
        {
            Debug.LogError("Legacy Textコンポーネントがアサインされていません！");
            return;
        }

        // Textの親のRectTransform（例えば背景画像）を取得
        imageRectTransform = legacyText.transform.parent.GetComponent<RectTransform>();

        // 初期状態は空文字
        legacyText.text = "";
    }

    // 外部から呼び出してメッセージを表示する
    public void DisplayText(string newText)
    {
        StopAllCoroutines();  // 既存の表示コルーチンがあれば停止
        currentFullText = newText;
        legacyText.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        for (int i = 0; i <= currentFullText.Length; i++)
        {
            legacyText.text = currentFullText.Substring(0, i);

            // 1文字目以降に短音を再生
            if (i > 0 && tickSound != null)
            {
                audioSource.PlayOneShot(tickSound, tickVolume);
            }

            // 親のUI要素を少し揺らす（あれば）
            if (imageRectTransform != null)
            {
                Vector3 originalPosition = imageRectTransform.localPosition;
                imageRectTransform.localPosition = originalPosition + (Vector3)Random.insideUnitCircle * shakeAmount;
                yield return new WaitForSeconds(delay);
                imageRectTransform.localPosition = originalPosition;
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }
        }
    }
}

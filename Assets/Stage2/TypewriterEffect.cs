using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    [Header("設定")]
    public Text legacyText;      // InspectorにLegacy Textコンポーネントをアサイン
    public string fullText = "ここに表示したい全文を入力します。";
    public float delay = 0.1f;   // 各文字を表示するまでの待機時間

    private string currentText = "";

    void Start()
    {
        if (legacyText == null)
        {
            Debug.LogError("Legacy Textコンポーネントがアサインされていません！");
            return;
        }
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        // fullTextの全長にわたって、1文字ずつ追加していく
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            legacyText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}

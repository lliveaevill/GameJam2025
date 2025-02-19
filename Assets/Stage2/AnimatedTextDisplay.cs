using UnityEngine;
using DG.Tweening;           // DOTween名前空間
using TMPro;                // TextMeshProを使う場合

public class AnimatedTextDisplay : MonoBehaviour
{
    public TextMeshProUGUI animatedText;  // TextMeshProUGUIコンポーネント
    public string message = "Hello, World!";
    public float fadeInDuration = 1f;
    public float moveDistance = 50f;

    // ボタンが押されたときに呼び出すメソッド
    public void ShowAnimatedText()
    {
        // 表示するメッセージをセット
        animatedText.text = message;

        // 初期状態を設定（透明＆下にオフセット）
        animatedText.alpha = 0;
        Vector3 originalPos = animatedText.transform.localPosition;
        animatedText.transform.localPosition = originalPos - new Vector3(0, moveDistance, 0);

        // DOTweenでフェードイン＆上方向に移動させるアニメーション
        animatedText.DOFade(1, fadeInDuration);
        animatedText.transform.DOLocalMoveY(originalPos.y, fadeInDuration);
    }
}
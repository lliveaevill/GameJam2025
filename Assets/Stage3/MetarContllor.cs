using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MetarContllor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;  // public でもOK
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public RectTransform needle;  // 針のUI要素
    public RectTransform meter;   // メーターの背景（長方形のサイズを基準にする）
    //public Text scoreText;        // スコアを表示するテキスト
    public float speed = 2.0f;    // 針の移動速度
    public float maxScore = 1.0f; // メーターのスコアの最大値
    private bool isMoveNeedle = true; // 針が動いているかどうか
    private float value = 0.0f; // 針の位置（0～1）

    void Start()
    {
        // nullチェック
        if (needle == null)
        {
            Debug.LogError("Needle (針) がアタッチされていません！", this);
        }
        if (meter == null)
        {
            Debug.LogError("Meter (メーター背景) がアタッチされていません！", this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isMoveNeedle = !isMoveNeedle;
            Debug.Log("isMoveNeedle: " + isMoveNeedle);

            if (!isMoveNeedle)
            {
                float score = CalculateScore();
                scoreText.text = "Score: " + score.ToString("F2");
            }
        }

        if (isMoveNeedle)
        {
            value = Mathf.PingPong(Time.time * speed, 1.0f); // 0～1 の範囲で往復
        }

        SetNeedle(value);
    }

    public void SetNeedle(float value)
    {
        if (needle == null || meter == null) return; // nullチェック

        float minX = meter.rect.xMin;
        float maxX = meter.rect.xMax;
        float newX = Mathf.Lerp(minX, maxX, value);
        needle.anchoredPosition = new Vector2(newX, needle.anchoredPosition.y);
    }

    public float CalculateScore()
    {
        // 最高スコアを中心にする二次関数
        return maxScore * (1 - 4 * Mathf.Pow(value - 0.5f, 2));
    }
}

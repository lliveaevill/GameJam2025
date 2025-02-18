using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MetarContllor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;  // public �ł�OK
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public RectTransform needle;  // �j��UI�v�f
    public RectTransform meter;   // ���[�^�[�̔w�i�i�����`�̃T�C�Y����ɂ���j
    //public Text scoreText;        // �X�R�A��\������e�L�X�g
    public float speed = 2.0f;    // �j�̈ړ����x
    public float maxScore = 1.0f; // ���[�^�[�̃X�R�A�̍ő�l
    private bool isMoveNeedle = true; // �j�������Ă��邩�ǂ���
    private float value = 0.0f; // �j�̈ʒu�i0�`1�j

    void Start()
    {
        // null�`�F�b�N
        if (needle == null)
        {
            Debug.LogError("Needle (�j) ���A�^�b�`����Ă��܂���I", this);
        }
        if (meter == null)
        {
            Debug.LogError("Meter (���[�^�[�w�i) ���A�^�b�`����Ă��܂���I", this);
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
            value = Mathf.PingPong(Time.time * speed, 1.0f); // 0�`1 �͈̔͂ŉ���
        }

        SetNeedle(value);
    }

    public void SetNeedle(float value)
    {
        if (needle == null || meter == null) return; // null�`�F�b�N

        float minX = meter.rect.xMin;
        float maxX = meter.rect.xMax;
        float newX = Mathf.Lerp(minX, maxX, value);
        needle.anchoredPosition = new Vector2(newX, needle.anchoredPosition.y);
    }

    public float CalculateScore()
    {
        // �ō��X�R�A�𒆐S�ɂ���񎟊֐�
        return maxScore * (1 - 4 * Mathf.Pow(value - 0.5f, 2));
    }
}

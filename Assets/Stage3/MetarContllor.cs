using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class MetarContllor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public RectTransform needle;  // �j��UI�v�f
    public RectTransform meter;   // ���[�^�[�̔w�i�i�����`�̃T�C�Y����ɂ���j
    public float speed = 2.0f;    // �j�̈ړ����x
    public float maxScore = 10.0f; // ���[�^�[�̃X�R�A�̍ő�l
    public float minScore = 0.0f;
    private bool isMoveNeedle = true; // �j�������Ă��邩�ǂ���
    private float value = 0.0f; // �j�̈ʒu�i0�`1�j
    private float waitSceneTime = 1.0f; // �V�[���J�ڂ���܂ł̑҂�����

    [SerializeField] private BackGroundChanger backGroundChanger;

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
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            isMoveNeedle = !isMoveNeedle;
            Debug.Log("isMoveNeedle: " + isMoveNeedle);
            Debug.Log("value: " + value);

            if (!isMoveNeedle)
            {
                //float score = CalculateScore();
                float score = CalculateScore2();
                scoreText.text = "Score: " + score.ToString("F2");
            }
        }

        if (!isMoveNeedle)
        {
            waitSceneTime -= Time.deltaTime;

            if (waitSceneTime <= 0.0f)
            {
                // �V�[���J��
                SceneManager.LoadScene("Stage3");
            }
        }

        if (value <= 0.3f || value >= 0.85f)
        {
            backGroundChanger.ChangeBackground();
            Debug.Log("ChangeBackground");
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
        //float normalizedScore = 1 - 4 * Mathf.Pow(value - 0.5f, 2);

        // �ϓ��ɃX�R�A���v�Z����
        float normalizedScore = 1 - Mathf.Abs(2 * value - 1);

        return Mathf.Lerp(minScore, maxScore, normalizedScore);
    }

    public float CalculateScore2()
    {
        float score = 0.0f;

        if (value >= 0.0f && value < 0.268f)
        {
            score = minScore;
        }
        else if (value >= 0.268f && value < 0.48f)
        {
            score = maxScore / 2;
        }
        else if (value >= 0.48f && value < 0.52f)
        {
            score = maxScore;
        }
        else if (value >= 0.52f && value < 0.732f)
        {
            score = maxScore / 2;
        }
        else if (value >= 0.732f && value <= 1.0f)
        {
            score = minScore;
        }

        return score;
    }
}

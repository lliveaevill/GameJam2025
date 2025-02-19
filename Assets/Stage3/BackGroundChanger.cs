using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class BackGroundChanger : MonoBehaviour
{
    public RawImage backgroundImage; // �w�i�摜��UI�v�f
    public Texture[] backgroundTextures; // �ύX����e�N�X�`��

    private int currentIndex = 0;

    [SerializeField] float cooldownDuration = 0.5f; // �N�[���^�C���̕b��
    private float lastChangeTime = -10f; // �Ō�ɕύX��������

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (backgroundTextures.Length > 0  && backgroundImage != null)
        {
            backgroundImage.texture = backgroundTextures[currentIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBackground()
    {
        if (backgroundTextures.Length == 0 || backgroundImage == null) return;

        //�N�[���^�C�����Ȃ牽�����Ȃ�
        if (Time.time - lastChangeTime < cooldownDuration)
        {
            Debug.Log("�N�[���^�C�����I �w�i�ύX�ł��܂���");
            return;
        }

        currentIndex = (currentIndex + 1) % backgroundTextures.Length;
        backgroundImage.texture = backgroundTextures[currentIndex];

        //�Ō�ɕύX�������Ԃ��X�V
        lastChangeTime = Time.time;
    }
}

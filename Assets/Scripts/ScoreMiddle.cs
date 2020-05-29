using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMiddle : MonoBehaviour
{
    private Image m_image;
    void Start()
    {
        m_image = GetComponent<Image>();
    }
    public Sprite score0; public Sprite score1; public Sprite score2; public Sprite score3; public Sprite score4; public Sprite score5; public Sprite score6; public Sprite score7; public Sprite score8; public Sprite score9;
    void Update()
    {
        switch (((Manager.instance.score % 100) - Manager.instance.score % 10) / 10)
        {
            case 0:
                m_image.sprite = score0;
                break;
            case 1:
                m_image.sprite = score1;
                break;
            case 2:
                m_image.sprite = score2;
                break;
            case 3:
                m_image.sprite = score3;
                break;
            case 4:
                m_image.sprite = score4;
                break;
            case 5:
                m_image.sprite = score5;
                break;
            case 6:
                m_image.sprite = score6;
                break;
            case 7:
                m_image.sprite = score7;
                break;
            case 8:
                m_image.sprite = score8;
                break;
            case 9:
                m_image.sprite = score9;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class titleController : MonoBehaviour{

    [SerializeField] TextMeshProUGUI tmpText;//Text
    [SerializeField] Image blackoutImage;//�摜
    int blinkDuration = 1;//�����̖��łɕK�v�ȕb��

    void Start(){

        StartCoroutine(BlinkText());
    }

    //��ʂ��N���b�N������Ó]����������
    void Update(){

        if (Input.GetMouseButtonDown(0)) {
            blackoutImage.gameObject.SetActive(false);
            tmpText.gameObject.SetActive(false);
        }
    }

    //���ł��J��Ԃ�����BIEnumerator�͖����ɗ����ł��Ȃ�
    //Time.deltaTime�͌��݂̃t���[�����ɑ΂���1�t���[�������b�������Ă����炵��
    IEnumerator BlinkText(){

        while (true) {
            for (float t = 0; t <= 1; t += Time.deltaTime / blinkDuration) {
                SetAlpha(t);
                yield return null;
            }
            for (float t = 1; t >= 0; t -= Time.deltaTime / blinkDuration) {
                SetAlpha(t);
                yield return null;
            }
        }
    }

    void SetAlpha(float alpha) {
        Color c = tmpText.color;
        c.a = alpha;
        tmpText.color = c;
    }
}

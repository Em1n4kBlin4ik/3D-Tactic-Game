using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{

    public Light dirLight;

    private ParticleSystem ps;
    private bool _isRain = false;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        StartCoroutine(weather());
    }

    private void Update()
    {
        if(_isRain && dirLight.intensity > 0.25f)     // ��� �����, � ������������� ����� ������, ��� 0.25f, �� ������������� ����� ����� ���������
        {
            LightIntensity(-1);
        } else if (!_isRain && dirLight.intensity < 0.5f)   // ��� �� �����, � ������������� ����� ������, ��� 0.5f, �� ������������� ����� ����� ���������
        {
                LightIntensity(1);
            }

    }

    private void LightIntensity(int v)
    {
        dirLight.intensity += 0.1f * Time.deltaTime * v;
    }

    IEnumerator weather()
    {
        while(true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(10f, 20f));  //����� �� �������� ������ �����

            if(_isRain) 
            { 
                ps.Stop();    // ���� ��� �����, �� �������������
            } else
            {
                ps.Play();    // ���� �� ���, �� ���������
            }

            _isRain = !_isRain;   // ���� ���� true, �� ������ false � ��������
        }
    }
}

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
        if(_isRain && dirLight.intensity > 0.25f)     // Идёт дождь, а интенсивность света больше, чем 0.25f, то интенсивность света нужно уменьшить
        {
            LightIntensity(-1);
        } else if (!_isRain && dirLight.intensity < 0.5f)   // Идёт не дождь, а интенсивность света меньше, чем 0.5f, то интенсивность света нужно увеличить
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
            yield return new WaitForSeconds(UnityEngine.Random.Range(10f, 20f));  //Время на ожидание начала дождя

            if(_isRain) 
            { 
                ps.Stop();    // Если идёт дождь, то останавливаем
            } else
            {
                ps.Play();    // Если не идёт, то запускаем
            }

            _isRain = !_isRain;   // Если было true, то ставит false и наоборот
        }
    }
}

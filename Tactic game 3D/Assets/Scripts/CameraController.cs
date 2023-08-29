using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public float rotateSpeed = 10.0f, speed = 10.0f, zoomer = 10.0f; // �������� ��������, ��������, �������� �����������|��������� ������

    private float _mult = 1f; // ��������� ������������ ������

    private void Update()
    {

        float horiz_ = Input.GetAxis("Horizontal"); // �������� �� �����������
        float vert_ = Input.GetAxis("Vertical"); // �������� �� ���������

        float rotate = 0f;
        if(Input.GetKey(KeyCode.Q))  
        {
            rotate = -1f;                                  // �������� �����
        }                                                  
        else if(Input.GetKey(KeyCode.E)) 
        { 
            rotate = 1f;                                  // �������� ������
        } 

        _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;   // ��� ������� �� LShift, �������� = 2, ���� ���, �������� = 1 (��������� �������� �������� null)

        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * _mult, Space.World);   // �������� ������ � �����

        transform.Translate(new Vector3(horiz_, 0, vert_) * Time.deltaTime * _mult * speed, Space.Self); // ������������ �����,�����,������,�����

        transform.position += transform.up * zoomer * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel"); // ���������� �������� �� Y

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -20f, 30f), transform.position.z);
    }
}

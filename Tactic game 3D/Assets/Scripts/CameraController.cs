using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public float rotateSpeed = 10.0f, speed = 10.0f, zoomer = 10.0f; // Скорость вращения, скорость, скорость приближения|отдаления камеры

    private float _mult = 1f; // Ускорение передвижения камеры

    private void Update()
    {

        float horiz_ = Input.GetAxis("Horizontal"); // Значение по горизонтали
        float vert_ = Input.GetAxis("Vertical"); // Значение по вертикали

        float rotate = 0f;
        if(Input.GetKey(KeyCode.Q))  
        {
            rotate = -1f;                                  // Вращение влево
        }                                                  
        else if(Input.GetKey(KeyCode.E)) 
        { 
            rotate = 1f;                                  // Вращение вправо
        } 

        _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;   // При нажатии на LShift, значение = 2, если нет, значение = 1 (Возвращая обратное значение null)

        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * _mult, Space.World);   // Вращение вправо и влево

        transform.Translate(new Vector3(horiz_, 0, vert_) * Time.deltaTime * _mult * speed, Space.Self); // Передвижение вперёд,назад,вправо,влево

        transform.position += transform.up * zoomer * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel"); // Увеличение значения по Y

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -20f, 30f), transform.position.z);
    }
}

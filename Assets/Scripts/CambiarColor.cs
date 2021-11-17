using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarColor : MonoBehaviour
{
    public Color[] colores;
    public SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.color = colores[0];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spr.color = spr.color == colores[0] ? spr.color = colores[1] : spr.color = colores[0];
        }
    }
}

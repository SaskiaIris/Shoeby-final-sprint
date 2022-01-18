using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorchanger : MonoBehaviour
{
    private Color firstColor, secondColor, thirdColor, fourthColor, fifthColor;
    
    public SkinnedMeshRenderer Render;

    public int colorNumber;

    void Start()
    {
        Render = this.gameObject.GetComponent<SkinnedMeshRenderer>();
        colorNumber = 0;
        Debug.Log(Render);
        Debug.Log(Render.material);

        //these colors are from https://www.color-hex.com/color-palette/547
        firstColor = new Color32(141, 85, 36, 255);
        secondColor = new Color32(198, 134, 66, 255);
        thirdColor = new Color32(224, 172, 105, 255);
        fourthColor = new Color32(241, 194, 125, 255);
        fifthColor = new Color32(255, 219, 172, 255);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            NextNumber();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PrevNumber();
        }

        switch (colorNumber)
        {
            case 1:
                Render.material.SetColor("_Color", firstColor);
                break;
            case 2:
                Render.material.SetColor("_Color", secondColor);
                break;
            case 3:
                Render.material.SetColor("_Color", thirdColor);
                break;
            case 4:
                Render.material.SetColor("_Color", fourthColor);
                break;
            case 5:
                Render.material.SetColor("_Color", fifthColor);
                break;
        }
    }

    public void NextNumber()
    {
        colorNumber++;
        if (colorNumber >= 6)
        {
            colorNumber = 1;
        }
    }

    public void PrevNumber()
    {
        colorNumber--;
        if (colorNumber <= 0)
        {
            colorNumber = 5;
        }
    }
}

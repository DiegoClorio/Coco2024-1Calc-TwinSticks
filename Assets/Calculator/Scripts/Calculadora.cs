using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculadora : MonoBehaviour
{
    [SerializeField] private TMP_InputField firstNumText;
    [SerializeField] private TMP_InputField secondNumText;
    [SerializeField] private TMP_Text resultText;

    public void Add()
    {
        float.TryParse(firstNumText.text, out float firstNum);
        float.TryParse(secondNumText.text, out float secondNum);
        float resultNum = firstNum + secondNum;
        resultText.text = "Resultado = " + resultNum;

    }

    public void Subtract()
    {
        float.TryParse(firstNumText.text, out float firstNum);
        float.TryParse(secondNumText.text, out float secondNum);
        float resultNum = firstNum - secondNum;
        resultText.text = "Resultado = " + resultNum;

    }

    public void Multiply()
    {
        float.TryParse(firstNumText.text, out float firstNum);
        float.TryParse(secondNumText.text, out float secondNum);
        float resultNum = firstNum * secondNum;
        resultText.text = "Resultado = " + resultNum;

    }

    public void Divide()
    {
        float.TryParse(firstNumText.text, out float firstNum);
        float.TryParse(secondNumText.text, out float secondNum);
        float resultNum = firstNum / secondNum;
        resultText.text = "Resultado = " + resultNum;

    }
}

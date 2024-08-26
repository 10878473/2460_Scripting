
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class DataFloat : ScriptableObject
{
    public float value;
    
    public void IncreaseValue(float number){
        value += number;        
    }
    public void DecreaseValue(float number){
        value -= number;
        Debug.Log("Lowered value to"+value);
    }
    public void SetValue(float number){
        value = number;    
    }
    public void MultiplyValue(float number){
        value *= number; 
    }

    public void DivideValue(float number)
    {
        value /= number;//this will break with divide by 0 -> Fix with either try except, or only allow nonzero input. Unsure the syntax of only allowing nonzero.
    }

    public void DisplayNumber(Text text)
    {
        text.text = value.ToString(CultureInfo.InvariantCulture);//todo - Look up what inveriantculture does
    }

    public void displayasPercent(Image percentBar)
    {
        if (percentBar != null)
        {
            if (value <0)
            {
                value = 0;
            }

            if (value > 1)
            {
                value = 1;
            }
            percentBar.fillAmount = value;    
        }
        
    }
}

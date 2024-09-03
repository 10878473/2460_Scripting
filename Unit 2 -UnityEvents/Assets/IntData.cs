using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int value;
    

    public void addValue(int number)
    {
        Debug.Log("Adding " + number + " to IntData");
        value += number;
        Debug.Log("IntData value is now" + value);
    }

    public void setValue(int number)
    {
        value = number;
    }

    public void DisplayText(Text txt)
    {
        txt.text = value.ToString();
    }

    public void DisplayImage(Image img)
    {        
        img.fillMethod = Image.FillMethod.Horizontal;
        img.fillAmount = value/100f;
        Debug.Log("IntData display image is now" + img.fillAmount.ToString());
        //this works best for values between 0-100. If implemented as a healthbar, divide the int value by the max hp value.
    }
    
}

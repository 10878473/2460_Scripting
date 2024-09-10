using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TMP_Text))]
public class TextLabelBehavior : MonoBehaviour
{
    private TMP_Text label;
    

    public UnityEvent startEvent;
    // Start is called before the first frame update
    void Start()
    {
        startEvent.Invoke();
        label = GetComponent<TMP_Text>();
    }

    
    public void UpdateLabel(IntData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }
    public void UpdateLabel(FloatData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }
}

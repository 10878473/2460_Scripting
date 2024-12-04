using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TmproTextLabelBehavior : MonoBehaviour
{
    private TMP_Text label;
    public UnityEvent startEvent;
    
    private void Start()
    {
        label = GetComponent<TMP_Text>();
        startEvent.Invoke();
    }

    public void UpdateLabel(FloatData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }

    public void UpdateLabel(IntData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }
}
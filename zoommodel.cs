using UnityEngine;
using UnityEngine.UI;

public class zoommodel : MonoBehaviour
{
    public GameObject objectToScale;
    public Slider slider;

    private void Start()
    {
        // Set the initial value of the slider to the object's current scale
        slider.value = objectToScale.transform.localScale.x;
    }

    public void OnSliderValueChanged()
    {
        // Get the value of the slider and use it to set the object's new scale
        float newScale = slider.value;
        objectToScale.transform.localScale = new Vector3(newScale, newScale, newScale);
    }
}

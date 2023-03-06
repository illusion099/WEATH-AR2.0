using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    public GameObject objectToScale1;
    public Slider slider1;

    private void Start()
    {
        // Set the initial value of the slider to the object's current scale
        slider1.value = objectToScale1.transform.localRotation.eulerAngles.y;
    }

    public void OnSliderValueChanged()
    {
        // Get the value of the slider and use it to set the object's new scale
        float newScale = slider1.value;
        objectToScale1.transform.localRotation = Quaternion.Euler(0f, newScale, 0f); ;
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Slider slider;  // Reference to the Slider component

    [SerializeField]
    private float sliderMaxMin = 10;    // Maximum and minimum values for the Slider

    [SerializeField]
    private float maxAngle = 45f;   // Maximum angle of rotation for the handle

    [SerializeField]
    private Transform handleTransform;  // Reference to the Transform component of the handle

    [SerializeField]
    private TMP_Text textStrong;// Reference to the TextMeshProUGUI component for displaying the value

    void Start()
    {
        slider.maxValue = sliderMaxMin;
        slider.minValue = -sliderMaxMin;

        slider.value = 0f;
    }

    public void ChangeSpeedEngine()
    {
        // Calculate the proportional value based on the slider's value,
        // mapping it from the slider's range to a value between -1 and 1.
        // This allows us to obtain a normalized value that can be used for various calculations or controls,
        // such as adjusting the rotation power of the gear.
        float proportionalValue = (slider.value - slider.minValue) / (slider.maxValue - slider.minValue) * 2f - 1f;

        // Calculate the rotation angle of the handle based on the proportional value and the maximum angle
        float angle = proportionalValue * maxAngle;

        // Assign the rotation angle to the handle's transform
        handleTransform.localRotation = Quaternion.Euler(-angle, 0f, 0f);

        ShowStrongEngineText();
    }

    public void ResetEngineStrong()
    {
        slider.value = 0;
        ShowStrongEngineText();
    }

    private void ShowStrongEngineText()
    {
        textStrong.text = slider.value.ToString("F0");

        if (slider.value >= slider.minValue/2 && slider.value <= slider.maxValue/2)
        {
            textStrong.color = Color.green;
        }
        else
        {
            textStrong.color = Color.red;
        }
    }
}

using UnityEngine;
using DG.Tweening;


public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject panel; // Reference to the panel object

    [SerializeField]
    private GameObject buttonInfo;

    [SerializeField]
    private Vector2 hiddenPosition; // Position of the panel when hidden

    [SerializeField]
    private Vector2 shownPosition; // Position of the panel when shown

    private float animationDuration = 0.5f; // Duration of the animation in seconds

    private void Start()
    {
        InfoPanel(); // Hide the panel initially
    }

    public void InfoPanel()
    {
        buttonInfo.SetActive(false);
        Invoke(nameof(ShowBurronInfo), animationDuration);

            if (panel.activeSelf)
            {
                panel.transform.DOMove(hiddenPosition, animationDuration); // Move the panel to the hidden position over time using DoTween

                Invoke(nameof(HidePanel), animationDuration*2);// If the panel is visible, hide it
            }
            else
            {
                ShowPanel(); // If the panel is hidden, show it
            }
        
    }

    private void ShowPanel()
    {
        panel.SetActive(true); // Set the flag to visible
        panel.transform.DOMove(shownPosition, animationDuration); // Move the panel to the shown position over time using DoTween

    }

    private void HidePanel()
    {
        panel.SetActive(false);
    }

    private void ShowBurronInfo()
    {
        buttonInfo.SetActive(true);
    }
}

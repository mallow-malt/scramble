using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private Text TimeText;
    // [SerializeField] private Text ChecklistText;
    // [SerializeField] private Slider ScrambledSlider;
    // [SerializeField] private Slider CookedSlider;
    // [SerializeField] private float SliderFillSpeed = 0.5f;
    
    private void Start()
    {
        Timer.UpdateTimer += UpdateTimer;
    }

    private void UpdateTimer(string NewTime)
    {
        if(TimeText.text != NewTime)
            TimeText.text = NewTime;
    }

    private void Update()
    {
        
    }
}

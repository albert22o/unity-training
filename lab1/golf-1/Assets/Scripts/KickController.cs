using UnityEngine;
using UnityEngine.UI;

public class KickController : MonoBehaviour
{
    [SerializeField] Slider Slider;
    private bool increase = true;
    private float delta = 90f;
    public float Force { get { return Slider.value; } }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Choice();
    }
    void Choice()
    {
        if (increase)
        {
            if (Slider.maxValue != Slider.value)
            {
                Slider.value += delta * Time.deltaTime;
            }
            else
            {
                increase = false;
            }
        }
        else
        {
            if (Slider.minValue != Slider.value)
            {
                Slider.value -= delta * Time.deltaTime;
            }
            else { increase = true; }
        }
    }
}

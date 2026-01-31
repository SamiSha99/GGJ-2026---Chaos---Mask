using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}

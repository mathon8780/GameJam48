using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AttributesPanel : MonoBehaviour
    {
        [SerializeField] private Slider hpSlider;
        [SerializeField] private Text calmness;


        private void OnEnable()
        {
            //事件注册
            EventManager.Instance.RegisterEventListener<HpChanged>(UpdateHpChanged);
            EventManager.Instance.RegisterEventListener<CalmnessChanged>(UpdateCalmness);
        }

        private void OnDisable()
        {
            EventManager.Instance?.UnregisterEventListener<HpChanged>(UpdateHpChanged);
            EventManager.Instance?.UnregisterEventListener<CalmnessChanged>(UpdateCalmness);
        }

        private void UpdateHpChanged(HpChanged e)
        {
            hpSlider.value = e.CurrentHP / e.MaxHP;
        }

        private void UpdateCalmness(CalmnessChanged value)
        {
            calmness.text = value.CurrentCalmness.ToString("0");
        }
    }
}
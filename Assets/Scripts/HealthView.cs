using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] public Slider _slider;
    [SerializeField] private float _delay;

    [SerializeField] private float changeFactor;
    [SerializeField] private Button decreaseButton;
    [SerializeField] private Button increaseButton;

    private float _targetHealth;

    private void Awake()
    {
        _slider.value = 1;

        decreaseButton.onClick.AddListener(() =>
        {
            _health.HealthPlaeyr -= changeFactor;
        });

        increaseButton.onClick.AddListener(() =>
        {
            _health.HealthPlaeyr += changeFactor;
        });
    }

    private void Update()
    {
        _targetHealth = _health.HealthPlaeyr / _health.StartHealth;

        if (_slider.value == _targetHealth) return;

        ChangHealthSlow(_targetHealth);
    }

    private void ChangHealthSlow(float targetHealth)
    {
        _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, _delay * Time.deltaTime);
    }
}

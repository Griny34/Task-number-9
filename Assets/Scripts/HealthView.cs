using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] public Slider _slider;
    [SerializeField] private float _delay;

    private float _targetHealth;
    private Coroutine _coroutine;
    private float _maxValue = 1;

    private void Awake()
    {
        _slider.value = _maxValue;
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChang;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChang;
    }

    private void OnHealthChang()
    {        
        _targetHealth = _health.HealthPlaeyr / _health.MaxHealth;

        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangHelth(_targetHealth));
    }

    private IEnumerator ChangHelth(float targetHealth)
    {
        while (targetHealth != _slider.value)
        {
            ChangHealthSlow(targetHealth);
            yield return null;
        }
    }

    private void ChangHealthSlow(float targetHealth)
    {
        _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, _delay * Time.deltaTime);
    }
}

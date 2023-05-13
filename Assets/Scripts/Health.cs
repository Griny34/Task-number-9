using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthMax;
    [SerializeField] private float _healthMin;

    private float _health;

    public float MaxHealth => _healthMax;
    public float HealthPlaeyr
    {
        get => _health;
        private set
        {
            _health = value;

            HealthChanged?.Invoke();
        }
    }

    public event UnityAction HealthChanged;

    private void Awake()
    {
        _health = _healthMax;
    }

    private void Update()
    {
        ControlBordersHealth();
    }

    private void ControlBordersHealth()
    {
        HealthPlaeyr = Mathf.Clamp(HealthPlaeyr, _healthMin, _healthMax);
    }

    public void TakeDamag(float damag)
    {       
        HealthPlaeyr -= damag;
    }

    public void TakeHeal(float heal)
    {
        HealthPlaeyr += heal;
    }
}

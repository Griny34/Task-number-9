using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthStart;

    private float _health;

    public float StartHealth => _healthStart;
    public float HealthPlaeyr
    {
        get => _health;
        private set
        {
            _health = value;

            if (_health > StartHealth)
            {
                _health = StartHealth;
            }

            if (_health < 0)
            {
                _health = 0;
            }

            OnHealthChang?.Invoke();
        }
    }

    public event UnityAction OnHealthChang;

    private void Awake()
    {
        _health = _healthStart;
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

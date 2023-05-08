using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthStart;

    private float _health;

    public float StartHealth => _healthStart;
    public float HealthPlaeyr
    {
        get => _health;
        set
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

    public delegate void HealthChang();
    public event HealthChang OnHealthChang;

    private void Awake()
    {
        _health = _healthStart;
    }
}

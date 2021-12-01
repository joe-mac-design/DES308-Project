using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private HealthController _playerHealth;
    [SerializeField] private Image _totalHealthBar;
    [SerializeField] private Image _currentHealthBar;

    private void Start()
    {
        _totalHealthBar.fillAmount = _playerHealth._currentHealth / 3;
    }

    private void Update()
    {
        _currentHealthBar.fillAmount = _playerHealth._currentHealth / 3;
    }

}

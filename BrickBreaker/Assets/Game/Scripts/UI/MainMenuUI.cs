using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Transform _gameTextTransform;
    [SerializeField] private TextMeshProUGUI _gameText;

    [Header("Animation Settings")]
    [SerializeField] private float _animationTime;
    [SerializeField] private float _firstFontSize = 84f;
    [SerializeField] private float _lastFontSize = 104f;
    [SerializeField] private Quaternion _firtRotationValue;
    [SerializeField] private Quaternion _lastRotationValue;

    private float _elapsedTime = 0;

    private void Update()
    {
        AnimateGameText();
    }

    private void AnimateGameText()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime <= _animationTime / 2)
        {
            float percentage = _elapsedTime / _animationTime;
            _gameTextTransform.localRotation = Quaternion.Lerp(_firtRotationValue,_lastRotationValue, percentage);
            _gameText.fontSize = Mathf.Lerp(_firstFontSize, _lastFontSize, percentage);
        }
        else if (_elapsedTime <= _animationTime)
        {
            float percentage = _elapsedTime / _animationTime;
            _gameTextTransform.localRotation = Quaternion.Lerp(_lastRotationValue, _firtRotationValue, percentage);
            _gameText.fontSize = Mathf.Lerp(_lastFontSize, _firstFontSize, percentage);
        }
        else
        {
            _elapsedTime = 0;
        }

    }
}

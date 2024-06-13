using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _counterDelay;

    private bool _isClicked = false;
    private Coroutine _countSecondsJob;
    private int _counter;

    private void OnEnable()
    {
        _text.text = "";
        _button.onClick.AddListener(CounterManager);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(CounterManager);
    }

    private void CounterManager()
    {
        if (_isClicked == false)
        {
            _countSecondsJob = StartCoroutine(CountSeconds());
            _isClicked = true;
        }
        else
        {
            StopCoroutine(_countSecondsJob);
            _isClicked = false;
        }
    }

    private IEnumerator CountSeconds()
    {
        WaitForSeconds delay = new WaitForSeconds(_counterDelay);

        while (true)
        {
            _counter += 1;
            _text.text = _counter.ToString();

            yield return delay;
        }
    }
}
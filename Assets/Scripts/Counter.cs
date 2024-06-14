using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _delay;

    private bool _isClicked = false;
    private Coroutine _øncrementCounterJob;
    private int _counter;

    private void OnEnable()
    {
        _text.text = "";
        _button.onClick.AddListener(ToggleCounting);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ToggleCounting);
    }

    private void ToggleCounting()
    {
        if (_isClicked == false)
        {
            _øncrementCounterJob = StartCoroutine(IncrementCounter());
            _isClicked = true;
        }
        else
        {
            StopCoroutine(_øncrementCounterJob);
            _isClicked = false;
        }
    }

    private IEnumerator IncrementCounter()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (true)
        {
            _counter += 1;
            _text.text = _counter.ToString();

            yield return delay;
        }
    }
}
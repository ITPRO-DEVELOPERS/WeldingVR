using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlovesScript : MonoBehaviour
{
    [SerializeField] private Material _glovesMaterial;
    [SerializeField] private PuttingGloves _puttingGloves;
    [SerializeField] private bool _gloveSide;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject mask;
    public Back back;
    public string item;
    //true - left
    //false - right
    [SerializeField] private GameObject _glove;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out _puttingGloves))
        {
            if (_gloveSide == _puttingGloves._handSide)
            {
                _puttingGloves._handRenderer.material = _glovesMaterial;
                Destroy(_glove);
                text.text = item;
                back.count++;
                mask.SetActive(true);
            }
        }
    }
}

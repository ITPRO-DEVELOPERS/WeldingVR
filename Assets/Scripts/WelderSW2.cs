using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WelderSW2 : MonoBehaviour
{
    private static bool _sw2On;
    [SerializeField] private Animator _switch2Animation;
    [SerializeField] private indexFinger _indexFinger;
    [SerializeField] private TextMeshProUGUI itemDescription;
    public string itemDescriptiontext;

    public void Switch2On()
    {
        _switch2Animation.SetBool("Sw2", _sw2On);
        _sw2On = !_sw2On;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out _indexFinger))
        {
            Switch2On();

            itemDescription.text = itemDescriptiontext;

        }
    }
}

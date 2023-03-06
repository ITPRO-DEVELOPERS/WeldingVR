using HurricaneVR.Framework.Core.Grabbers;
using HurricaneVR.Framework.Core;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using static UnityEditor.Progress;

public class Grababbled : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;

    public void ItemGrab(HVRGrabberBase grabberBase, HVRGrabbable hVRGrabbable)
    {
        ItemsInfo itemsInfo = hVRGrabbable.GetComponent<ItemsInfo>();
        itemName.text = itemsInfo.itemName;
        itemDescription.text = itemsInfo.itemDescription;
        //_audio.clip = hardware.HardwareAudio;

    }

    public void ItemReleased(HVRGrabberBase grabberBase, HVRGrabbable hVRGrabbable)
    {
        ItemsInfo itemsInfo = hVRGrabbable.GetComponent<ItemsInfo>();
        itemName.text = "";
        itemDescription.text = "";
        itemDescription.text = itemsInfo.itemNext;

    }
}

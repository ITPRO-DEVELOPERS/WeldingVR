using HurricaneVR.Framework.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ItemsInfo : MonoBehaviour
{
    [SerializeField] private HVRGrabbable grabbable;
    public string itemName;
    public string itemDescription;
    public string itemNext;
    
    public void Release()
    {
        grabbable.ForceRelease();
    }

    public enum ItemType
    {
        Seam,
        Electrode,
        Croc,
        Mask,
        Apron
    }
}

using System.Collections.Generic;
using nsDB;
using UnityEngine;

public class LabLoader : MonoBehaviour
{
    public static LabLoader instance;
    
    [SerializeField] private GameObject labLayout;
    [SerializeField] private GameObject labUIPrefab;

    private List<LaboratoryWork> _laboratoryWorks;

    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }

    /// <summary>
    /// Загрузить и отобразить лабораторные работы
    /// </summary>
    public void LoadLabs()
    {
        _laboratoryWorks = Nucleus.instance.GetLabs();

        foreach (LaboratoryWork lab in _laboratoryWorks)
        {
            Instantiate(labUIPrefab, labLayout.transform).TryGetComponent(out LabUI labUI);
            labUI.labId = lab.lab_id;
            labUI.labNameText.SetText(lab.lab_name);
            labUI.labDescriptionText.SetText(lab.lab_description);
        }
    }

    /// <summary>
    /// Удалить лабораторную работу
    /// </summary>
    /// <param name="labId">ID удаляемой лабораторной работы</param>
    public void DeleteLab(int labId)
    {
        Nucleus.instance.DeleteLab(labId);
    }
    
    /// <summary>
    /// Удалить UI лабораторных работа
    /// </summary>
    public void RemoveLabs()
    {
        for (int i = 0; i < labLayout.transform.childCount; i++)
        {
            Destroy(labLayout.transform.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// Перезагрузить лабораторные работы
    /// </summary>
    public void ReloadLabs()
    {
        RemoveLabs();
        LoadLabs();
    }
}
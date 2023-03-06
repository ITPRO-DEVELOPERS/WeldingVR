using System;
using System.Collections.Generic;
using System.Globalization;
using nsDB;
using SQLite4Unity3d;
using UnityEngine;

public class Nucleus : MonoBehaviour
{
    public static Nucleus instance;
    
    public static int currentTeacherId = -1;

    private SQLiteConnection _db = DB.database.getConn();
    
    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
        
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// Создать преподавателя
    /// </summary>
    /// <param name="teacherName">Имя преподавателя</param>
    /// <param name="teacherPassword">Пароль преподавателя</param>
    /// <param name="teacherFio">ФИО преподавателя</param>
    public bool CreateTeacher(string teacherName, string teacherPassword, string teacherFio)
    {
        try
        {
            Teacher newTeacher = new ();
            newTeacher.tch_name = teacherName; 
            newTeacher.tch_password = teacherPassword;
            newTeacher.tch_fio = teacherFio;
        
            _db.Insert(newTeacher);
        
            currentTeacherId = newTeacher.tch_id;

            return true;
        }
        catch (SQLiteException e)
        {
            Debug.LogException(e);
            return false;
        }
    }

    /// <summary>
    /// Авторизовать преподавателя
    /// </summary>
    /// <param name="teacherName">Имя преподавателя</param>
    /// <param name="teacherPassword">Пароль преподавателя</param>
    /// <returns>True при успешной атворизации</returns>
    public bool AuthorizeTeacher(string teacherName, string teacherPassword)
    {
        List<Teacher> records = _db.Query<Teacher>("select * from teachers where tch_name = ? and tch_password = ?", new object[] {teacherName, teacherPassword});
        
        if (records.Count == 0) return false;

        currentTeacherId = records[0].tch_id;
        return true;
    }

    /// <summary>
    /// Создать лабораторную работу
    /// </summary>
    /// <param name="labName">Название лабораторной работы</param>
    /// <param name="labDescription">Описание лабораторной работы</param>
    public bool CreateLab(string labName, string labDescription)
    {
        try
        {
            DateTime date = DateTime.Now;
        
            LaboratoryWork newLab = new ()
            {
                lab_name = labName,
                lab_description = labDescription,
                lab_usr_id = 1,
                lab_tch_id = currentTeacherId,
                lab_start_time = date.ToString(),
                lab_end_time = date.ToString(),
                lab_difficulty = 1
            };

            _db.Insert(newLab);
            _db.Commit();

            return true;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return false;
        }
    }
    
    /// <summary>
    /// Отредактировать лабораторную работу
    /// </summary>
    /// <param name="labId">ID лабораторной работы</param>
    /// <param name="newLabName">Новое название лабораторной работы</param>
    /// <param name="newLabDescription">Новое описание лабораторной работы</param>
    public void EditLab(int labId, string newLabName, string newLabDescription)
    {
        LaboratoryWork editedLab = GetLabById(labId);

        editedLab.lab_name = newLabName;
        editedLab.lab_description = newLabDescription;

        _db.Update(editedLab);
        _db.Commit();
    }
    
    /// <summary>
    /// Удалить лабораторную работу
    /// </summary>
    /// <param name="labId"></param>
    /// <returns></returns>
    public bool DeleteLab(int labId)
    {
        try
        {
            List<LaboratoryWork> records = _db.Query<LaboratoryWork>("select * from laboratory_works where lab_id = ?", labId);

            _db.Delete(records[0]);
            _db.Commit();
            
            return true;
        }
        catch (Exception e)
        {
            Debug.LogException(e);

            return false;
        }
    }
    
    /// <summary>
    /// Получить все лабораторные работы
    /// </summary>
    /// <returns>Список из лабораторных работ</returns>
    public List<LaboratoryWork> GetLabs()
    {
        List<LaboratoryWork> records = _db.Query<LaboratoryWork>("select * from laboratory_works");

        return records;
    }

    /// <summary>
    /// Получить лабораторную работу по ID
    /// </summary>
    /// <param name="labId">ID лабораторной работы</param>
    /// <returns>Объект лабораторной работы</returns>
    public LaboratoryWork GetLabById(int labId)
    {
        List<LaboratoryWork> records = _db.Query<LaboratoryWork>("select * from laboratory_works where lab_id = ?", labId);
        return records[0];
    }
    
    public bool CheckAuthorization()
    {
        return currentTeacherId >= 0;
    }
}
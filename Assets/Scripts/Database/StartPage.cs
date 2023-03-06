using SQLite4Unity3d;
using System;
using nsDB;
using UnityEngine;

public class StartPage : MonoBehaviour
{ 
    private SQLiteConnection _db = DB.database.getConn();
    
    private void Start()
    {
        string sr = PlayerPrefs.GetString("isfirst", "1");
        if (sr.Equals("1"))
        {
            DB.database.droptables();
            DB.database.createtables();
            PlayerPrefs.SetString("isfirst", "0");
        }
        try
        {
            SQLiteConnection db = DB.database.getConn();
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }

        _db.Commit();
    }
}

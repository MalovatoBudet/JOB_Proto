using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    [SerializeField] int _points;
    public int Points
    {
        get { return _points; }
        set { _points = value; }
    }

    [SerializeField] StateEnum _stateEnum;
    public StateEnum StateEnum
    {
        get { return _stateEnum; }
        set { _stateEnum = value; }
    }

    public static Progress Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Load();
    }
    public void SavePoints(int points)
    {
        _points = points;
        Save();
    }

    public void SaveEnum(StateEnum stateEnum)
    {
        _stateEnum = stateEnum;
        Save();
    }

    [ContextMenu(nameof(DeleteSave))]
    public void DeleteSave()
    {
        SaveSystem.DeleteSave();
    }

    [ContextMenu(nameof(Save))]
    public void Save()
    {
        SaveSystem.Save(this);
    }

    [ContextMenu(nameof(Load))]
    public void Load()
    {
        ProgressData progressData = SaveSystem.Load();

        if (progressData != null)
        {
            _points = progressData.Points;
            _stateEnum = progressData.StateEnum;
        }
        else
        {
            _points = 0;
            _stateEnum = StateEnum.InsertCoin;
        }
    }
}
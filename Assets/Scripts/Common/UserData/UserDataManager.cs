using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : SingletonBehaviour<UserDataManager>
{
    public bool ExistsSaveData { get; private set; }
    public List<IUserData> UserDataList { get; private set; } = new List<IUserData>();

    protected override void Init()
    {
        base.Init();
        
        UserDataList.Add(new UserSettingsData());
        UserDataList.Add(new UserGoodsData());
    }

    public void SetDefaultUserData()
    {
        for (int i = 0; i < UserDataList.Count; ++i)
        {
            UserDataList[i].SetDefaultData();
        }
    }

    public void LoadUserData()
    {
        ExistsSaveData = PlayerPrefs.GetInt("ExistSaveData") == 1 ? true : false;

        if (ExistsSaveData)
        {
            for (int i = 0; i < UserDataList.Count; ++i)
            {
                UserDataList[i].LoadData();
            }
        }
    }

    public void SaveUserData()
    {
        bool hasSaveError = false;

        for (int i = 0; i < UserDataList.Count; ++i)
        {
            bool isSaveSuccess = UserDataList[i].SaveData();
            if (isSaveSuccess == false)
            {
                hasSaveError = true;
            }
        }

        if (hasSaveError == false)
        {
            ExistsSaveData = true;
            PlayerPrefs.SetInt("ExistSaveData", 1);
            PlayerPrefs.Save();
        }
    }
}

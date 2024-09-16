using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataTableManager : SingletonBehaviour<DataTableManager>
{
    private const string DATA_PATH = "Datatable";

    private const string CHAPTER_DATA_TABLE = "ChapterDataTable";
    private List<ChapterData> ChapterDataTable = new List<ChapterData>();

    protected override void Init()
    {
        base.Init();

        LoadChapterDataTable();
        
    }

    private void LoadChapterDataTable()
    {
        var parseDataTable = CSVReader.Read($"{DATA_PATH}/{CHAPTER_DATA_TABLE}");

        foreach (var data in parseDataTable)
        {
            var chapterData = new ChapterData()
            {
                ChapterNo = Convert.ToInt32(data["chapter_no"]),
                TotalStatge = Convert.ToInt32(data["total_stage"]),
                ChpaterRewardGem = Convert.ToInt32(data["chapter_reward_gem"]),
                ChpaterRewardGold = Convert.ToInt32(data["chapter_reward_gold"])
            };
            
            ChapterDataTable.Add(chapterData);
        }
    }

    public ChapterData GetChapterData(int chapterNo)
    {
        return ChapterDataTable.FirstOrDefault(item => item.ChapterNo == chapterNo);
    }
}

public class ChapterData
{
    public int ChapterNo;
    public int TotalStatge;
    public int ChpaterRewardGem;
    public int ChpaterRewardGold;
}

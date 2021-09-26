using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int,string[]> talkData;
    Dictionary<int,Sprite> portraitData;
    // Start is called before the first frame update
    public Sprite[] portraitArr;
    void Awake()
    {
        talkData = new Dictionary<int,string[]>();
        portraitData = new Dictionary<int,Sprite>();
        GenerateData();
        
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000,new string[]{"안녕?:0",
        "여긴 무인도야:1",
        });
        talkData.Add(2000,new string[]{"여어:1",
        "이곳을 나갈수있을까..:0"});
        talkData.Add(100,new string[]{"평범한 나무이다"});
        talkData.Add(10,new string[]{"평범한 꽃이다",});
        //Quest Talk
        talkData.Add(10+1000, new string[] {"안녕?:0",
                                            "무인도에 온걸 환영해ㅎㅎ:1",
                                            "내 옆에 있는 루도한테 한번 말을 걸어볼래?:0"});
        talkData.Add(11+2000, new string[] {"ㅎㅇㅎㅇ내가 루도야:0",
                                            "이곳에 처음왔구나?:1",
                                            "그좀 도와줄게 있는데..:0"
                                            ,"저기있는 꽃좀 갖다줄래?:1"});
        talkData.Add(20+1000, new string[] {"꽃이 어딨냐고?:3",
                                            "누구한테 줄려고..:2",
                                            "밑에 쭉 내려가봐:1",});
        talkData.Add(20+2000, new string[] {"찾으면 꼭꼭 갖다줘:1"
                                           ,}); 
        talkData.Add(20+10, new string[] {"꽃을 발견했다",});  
        talkData.Add(21+2000, new string[] {"찾았구나!고마워:2",});                                                                         
        portraitData.Add(1000+0,portraitArr[0]);
        portraitData.Add(1000+1,portraitArr[1]);
        portraitData.Add(1000+2,portraitArr[2]);
        portraitData.Add(1000+3,portraitArr[3]);
        portraitData.Add(2000+0,portraitArr[4]);
        portraitData.Add(2000+1,portraitArr[5]);
        portraitData.Add(2000+2,portraitArr[6]);
        portraitData.Add(2000+3,portraitArr[7]);
        
    
    }
    public string GetTalk(int id, int talkIndex)
    {
        if(!talkData.ContainsKey(id)){
            if(!talkData.ContainsKey(id-id%10))
                return GetTalk(id-id%100,talkIndex);//Get First Talk
            else
                return GetTalk(id-id%10,talkIndex);//Get First Quest Talk 
            }
    
        
        if(talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];

    }
    public Sprite GetPortrait(int id, int portraitIndex){
        return portraitData[id+portraitIndex];
    }
}

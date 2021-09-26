using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    //public GameObject QuestPanel;
    //public Text QuestName;
    public Image portraitImg;
    public QuestManager questManager;
    public Text talkText;
    public GameObject scanObject;
    public GameObject MenuSet;
    public GameObject Inventory;
    public GameObject player;
    public bool isAction;
    public bool isQuest;
    public int talkIndex;
    public Text questTalk;
    void Start(){
        
        GameLoad();
        questTalk.text = questManager.CheckQuest();
    }
    void Update(){
        //Sub Menu 설정
        if(Input.GetButtonDown("Cancel")){
            if(MenuSet.activeSelf)
                MenuSet.SetActive(false);
            else
                MenuSet.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.I)){
            if(Inventory.activeSelf)
                Inventory.SetActive(false);
            else
                Inventory.SetActive(true);
        }

            
    }
    public void Action(GameObject scanObj)
    {
       
    
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);
          

        
        talkPanel.SetActive(isAction);
       
        //QuestPanel.SetActive(isQuest);
       
    }
    void Talk(int id,bool isNpc)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id+questTalkIndex , talkIndex);
        
        if(talkData==null){
            isAction = false;
            talkIndex = 0;
            questTalk.text = questManager.CheckQuest(id);
            return;
        }
        if(isNpc){
            talkText.text = talkData.Split(':')[0];
            portraitImg.sprite = talkManager.GetPortrait(id,int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1,1,1,1);
        }
        else{
            talkText.text = talkData;
            portraitImg.color = new Color(0,0,0,0);
        }
        /*if(questManager.CheckQuest(id) != null)
        {
            QuestName.text = questManager.CheckQuest(id);
            isQuest = true;
        }
        else
        {
            isQuest = false;
        }*/
        isAction = true;
        talkIndex++;
    }
    public void GameSave(){
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();
    }
    public void GameLoad(){
        if(!PlayerPrefs.HasKey("PlayerX"))
            return;
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");
        player.transform.position = new Vector3(x,y,0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
        questManager.ControlObject();

    }
    public void GameExit()
    {
        Application.Quit();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
  #region Singleton
  public static Inventory instance;
  private void Awake()
  {
    if(instance != null)
    {
      Destroy(gameObject);
      return;
    }
    instance = this;
  }
  #endregion

  public delegate void OnSlotCountChange(int val);
  public OnSlotCountChange onSlotCountChange;

  public delegate void OnChangeItem();
  public OnChangeItem onChangeItem;
  public List<Item> items= new List<Item>();
  private int slotCnt;

  public int SlotCnt{
    get=> slotCnt;
    set{
      slotCnt = value;
      onSlotCountChange.Invoke(slotCnt);
    }
  }
  void Start(){
    SlotCnt = 3;
  }
  

  
  public bool AddItem(Item _item)
  {
    if(items.Count < SlotCnt){
      items.Add(_item);
      
      onChangeItem.Invoke();
      return true;
    }
      
      
      
      return false;
    
  }
  private void OnTriggerEnter2D(Collider2D collision){
      if(collision.CompareTag("FieldItem"))
      {
          
          FieldItem fielditems = collision.GetComponent<FieldItem>();
          if(AddItem(fielditems.GetItem()))
            fielditems.DestroyItem();
      }
  }
}

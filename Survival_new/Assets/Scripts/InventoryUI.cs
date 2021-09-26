using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    
    Inventory inven;
    public Slot[] slots;
    public Transform slotHolder;
    private void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inven.onSlotCountChange += SlotChange;
        inven.onChangeItem += RedrawSlotUI;
        
    }
    private void SlotChange(int val)
    {
        for(int i=0;i<slots.Length;i++)
        {
            if(i<inven.SlotCnt)
                slots[i].GetComponent<Button>().interactable = true;
            else
                slots[i].GetComponent<Button>().interactable = false;

        }
    
    }

    public void AddSlot()
    {
        inven.SlotCnt++;
        
    }
    void RedrawSlotUI()
    {
        for(int i=0;i<slots.Length;i++){
            slots[i].RemoveSlot();
        }
        for(int i=0;i<inven.items.Count;i++){
            slots[i].item = inven.items[i];
            slots[i].UpdateSlotUI();
        }

    }
}

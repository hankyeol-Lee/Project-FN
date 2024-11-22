using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Image image;
    // Start is called before the first frame update
    private Item _item;
    public Item item{
        get{return _item;}
        set{
            _item = value;
            if(_item != null){
                image.sprite = item.ItemIcon;
                image.color = new Color(1,1,1,1);

            }
            else{
                image.color = new Color(1,1,1,0);
            }
        }
    }
}

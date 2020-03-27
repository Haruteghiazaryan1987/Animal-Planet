using System;
using System.Collections;
using System.Collections.Generic;
using Scrips;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    private const string ITEM_SPRITE_FORMAT = "Sprites/{0}";
    private Dictionary<string, Sprite> itemsSprite;

    private void Awake()
    {
        LoadResources();
    }

    public void LoadResources()    
    {
        itemsSprite = new Dictionary<string, Sprite>();
        var itemNames = Enum.GetNames(typeof(ImageTypes));
        for (int i = 0; i < itemNames.Length; i++)
        {
            var item = Resources.Load<Sprite>(string.Format(ITEM_SPRITE_FORMAT, itemNames[i].ToLower())); 
            itemsSprite.Add(itemNames[i], item);
        }
    }
    public Sprite GetSpriteByItemType(String item)
    {
        string index =item;
        if (!itemsSprite.ContainsKey(index))
        {
            return null;
        }
        return itemsSprite[index];
    }
}

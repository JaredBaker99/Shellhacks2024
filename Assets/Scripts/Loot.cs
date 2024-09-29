using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public int dropChance;

    public Loot(Sprite lootSprite, string lootName, int dropChance)
    {
        this.lootSprite = lootSprite;
        this.lootName = lootName;
        this.dropChance = dropChance;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBrawler", menuName = "Brawler/Stats", order = 1)]
public class BrawlerStats_SO : ScriptableObject
{
    public string nameBrawler;
    public string rusDescriptionBrawler;
    public string enDescriptionBrawler;
    public Sprite imageBrawler;
    public Sprite avatarBrawler;

    public int valueAttack;
    public int valueHealth;
    public int valueSuper;

}

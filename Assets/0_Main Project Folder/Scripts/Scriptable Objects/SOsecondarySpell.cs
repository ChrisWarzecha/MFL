using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Secondary Spell")]
public class SOsecondarySpell : ScriptableObject
{
    public string spellName;

    public float scale;

    public Sprite icon;

    public Sprite splashArt;

    public Sprite playerCellBackground;

    public string cheesyVittyQuote;

    //public float dmg;

    //public float timeBetweenCasts;
}
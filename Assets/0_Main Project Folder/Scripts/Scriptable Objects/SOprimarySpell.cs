using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Primary Spell")]
public class SOprimarySpell : ScriptableObject
{
    public string spellName;

    public Color Color;

    public Sprite icon;

    public Sprite splashArt;

    public Sprite playerCellBackground;

    public string cheesyVittyQuote;

    //public float dmg;

    //public float timeBetweenCasts;
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySpell : MonoBehaviour
{
    public bool isPrimary;

    public SOprimarySpell primarySpell;

    public SOsecondarySpell secondarySpell;

    public Image icon;

    public Image splashArt;

    public TMP_Text spellName;

    public TMP_Text wittyQuote;


    // Start is called before the first frame update
    private void Start()
    {
        if (isPrimary)
        {
            icon.sprite = primarySpell.icon;
            splashArt.sprite = primarySpell.splashArt;
            spellName.text = primarySpell.spellName;
            wittyQuote.text = primarySpell.cheesyVittyQuote;
        }
        else
        {
            icon.sprite = secondarySpell.icon;
            splashArt.sprite = secondarySpell.splashArt;
            spellName.text = secondarySpell.spellName;
            wittyQuote.text = secondarySpell.cheesyVittyQuote;
        }
    }
}
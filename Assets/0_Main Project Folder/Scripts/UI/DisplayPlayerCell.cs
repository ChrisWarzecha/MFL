using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerCell : MonoBehaviour
{
    public SOprimarySpell primarySpell;
    public SOsecondarySpell secondarySpell;

    public Image primarySpellIcon;
    public Image primarySpellBackground;

    public Image secondarySpellIcon;
    public Image secondarySpellBackground;


    private void Start()
    {
    }


    private void Update()
    {
        //UpdatePrimarySpell();
        //UpdateSecondarySpell();
    }

    public void UpdatePrimarySpell()
    {
        if (primarySpell == null)
        {
            Debug.Log("primarySpell.icon = 0");
        }
        else
        {
            primarySpellIcon.sprite = primarySpell.icon;
            primarySpellBackground.sprite = primarySpell.playerCellBackground;
        }
    }

    public void UpdateSecondarySpell()
    {
        if (secondarySpell == null)
        {
            Debug.Log("secondarySpell.icon = 0");
        }
        else
        {
            secondarySpellIcon.sprite = secondarySpell.icon;
            secondarySpellBackground.sprite = secondarySpell.playerCellBackground;
        }
    }

    public void SetPrimarySpell(SOprimarySpell pSpell)
    {
        primarySpell = pSpell;
    }

    public void SetSecondarySpell(SOsecondarySpell sSpell)
    {
        secondarySpell = sSpell;
    }
}
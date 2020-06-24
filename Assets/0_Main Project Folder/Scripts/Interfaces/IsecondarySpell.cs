using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IsecondarySpell
{
    void OnCast(float cd, float dmg, GameObject vfxPrefab);

    void OnInteraction(GameObject go);
}
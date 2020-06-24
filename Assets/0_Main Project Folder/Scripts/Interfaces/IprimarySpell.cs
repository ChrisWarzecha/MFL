using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public interface IprimarySpell
{
    void OnCast(float dmg, GameObject vfxPrefab);

    void OnInteraction(GameObject go);

    void HandleTimeBetweenCast(float cooldown);
}
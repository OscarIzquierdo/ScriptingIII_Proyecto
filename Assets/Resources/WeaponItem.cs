using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WeaponItem
{

    private string       m_name;

    private float        m_damage = 80.0f;

    private float        m_forceToApply = 20.0f;

    private float        m_weaponRange = 9999.0f;

    private int          m_ammoCapacity = 3;

    private float        m_rateOfShot = 10.0f;

    private AudioClip    m_fireSound;

    private AudioClip    m_reloadSound;

    private float        m_accuracy;

    private float        m_accuracyDropPerShot;

    private float        m_accuracyRecoverPerSecond;

    public string Name { get => m_name; set => m_name = value; }
    public float Damage { get => m_damage; set => m_damage = value; }
    public float ForceToApply { get => m_forceToApply; set => m_forceToApply = value; }
    public float WeaponRange { get => m_weaponRange; set => m_weaponRange = value; }
    public int AmmoCapacity { get => m_ammoCapacity; set => m_ammoCapacity = value; }
    public float RateOfShot { get => m_rateOfShot; set => m_rateOfShot = value; }
    public AudioClip FireSound { get => m_fireSound; set => m_fireSound = value; }
    public AudioClip ReloadSound { get => m_reloadSound; set => m_reloadSound = value; }
    public float Accuracy { get => m_accuracy; set => m_accuracy = value; }
    public float AccuracyDropPerShot { get => m_accuracyDropPerShot; set => m_accuracyDropPerShot = value; }
    public float AccuracyRecoverPerSecond { get => m_accuracyRecoverPerSecond; set => m_accuracyRecoverPerSecond = value; }
}

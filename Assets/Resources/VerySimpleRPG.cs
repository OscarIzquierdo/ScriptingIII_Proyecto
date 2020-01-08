using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerySimpleRPG : MonoBehaviour
{
    public Transform m_raycastSpot;
    public float m_damage = 80.0f;
    public float m_forceToApply = 20.0f;
    public float m_weaponRange = 9999.0f;
    public Texture2D m_crosshairTexture;
    private bool m_canShot;


    public AudioClip m_fireSound;
    public AudioClip m_reloadSound;
    AudioSource audioSc;


    public float m_currentAccuracy;
    public float m_currentAccuracyDropPerShot;
    public float m_currentAccuracyRecoverPerSecond;

    public float m_recoilBack;
    public float m_recoilRecovery;
    public float m_roundsPerSec;

    GameObject m_weapon;
    public GameObject grenade;
    public Transform m_grenadePosition;

    public GameObject shootSpot;
    public RocketScript m_rockCmp;
    private void Start()
    {
        m_weapon = GameObject.FindGameObjectWithTag("Weapon");
        m_currentAccuracy = 0;
        m_currentAccuracyDropPerShot = 0.1F;
        m_currentAccuracyRecoverPerSecond = 0.1F;
       
        m_roundsPerSec = 0;
        m_recoilBack = 0.1f;
        m_recoilRecovery = 4f;
        m_canShot = false;

        audioSc = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (m_canShot == false)
        {
            m_roundsPerSec -= Time.deltaTime;
        }
        
        if (m_roundsPerSec <= 0 & m_canShot == false)
        {
            m_canShot = true;
            m_rockCmp = grenade.GetComponent<RocketScript>();

        }
        
        m_weapon.transform.position = Vector3.Lerp(m_weapon.transform.position, transform.position, m_recoilRecovery * Time.deltaTime);
        m_currentAccuracy = Mathf.Lerp(m_currentAccuracy, m_currentAccuracy, m_currentAccuracyRecoverPerSecond * Time.deltaTime);

        if (Input.GetButton("Fire1"))
        {
            
            if (m_roundsPerSec <= 0 & m_canShot == true)
            {
                Shot();
                m_roundsPerSec = 2.0f;
            }

        }

    }




    private void OnGUI()
    {
        Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
        Rect auxRect = new Rect(center.x - 20, center.y - 20, 20, 20);
        GUI.DrawTexture(auxRect, m_crosshairTexture, ScaleMode.StretchToFill);
    }


    private void Shot()
    {
        m_canShot = false;
        shootSpot.GetComponent<ParticleSystem>().Play();

        GameObject proj = Instantiate(grenade, m_grenadePosition.position, m_grenadePosition.rotation) as GameObject;

        proj.SendMessage("ShootRPG", 100);
        m_weapon.transform.Translate(new Vector3(0, 0, -m_recoilBack), Space.Self);

        GetComponent<AudioSource>().PlayOneShot(m_fireSound);
    }
}

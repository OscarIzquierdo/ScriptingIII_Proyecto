using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerySimpleSMG : MonoBehaviour
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
    public float m_roundsPerSec = 0.2f;

    public float m_recoilBack;
    public float m_recoilRecovery;

    GameObject m_weapon;
    public GameObject shootSpot;

    public int ammoClip = 30;
    int currentAmmo;
    UIAmmo textoUI;

    private void Start()
    {
        m_weapon = GameObject.FindGameObjectWithTag("Weapon");
        m_currentAccuracy = 0;
        m_currentAccuracyDropPerShot = 0.1F;
        m_currentAccuracyRecoverPerSecond = 0.1F;

        m_recoilBack = 0.1f;
        m_recoilRecovery = 5f;
        ammoClip = 30;
        currentAmmo = ammoClip;
        textoUI = FindObjectOfType<UIAmmo>();

        audioSc = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        //print("currentammo" + currentAmmo);
        m_weapon.transform.position = Vector3.Lerp(m_weapon.transform.position, transform.position, m_recoilRecovery * Time.deltaTime);
        m_currentAccuracy = Mathf.Lerp(m_currentAccuracy, m_currentAccuracy, m_currentAccuracyRecoverPerSecond * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            //print("Recargo");
        }

        if (Input.GetButton("Fire1") && currentAmmo > 0)
            {
                m_roundsPerSec -= Time.deltaTime;
                if(m_roundsPerSec <= 0)
                {
                    Shot();
                    m_roundsPerSec = 0.2f;
                }
                
            }
        textoUI.SetText(currentAmmo);
    }

    private void OnGUI()
    {
        Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
        Rect auxRect = new Rect(center.x - 20, center.y - 20, 20, 20);
        GUI.DrawTexture(auxRect, m_crosshairTexture, ScaleMode.StretchToFill);
    }


    private void Shot()
    {
        currentAmmo = currentAmmo - 1;
        m_canShot = false;

        shootSpot.GetComponent<ParticleSystem>().Play();

        float accuracyModifier = (100 - m_currentAccuracy) / 1000;
        Vector3 directionForward = m_raycastSpot.forward;
        directionForward.x += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
        directionForward.y += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
        directionForward.z += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);

        m_currentAccuracy -= m_currentAccuracyDropPerShot;
        m_currentAccuracy -= Mathf.Clamp(m_currentAccuracy, 0, 100);

        m_weapon.transform.Translate(new Vector3(0, 0, -m_recoilBack), Space.Self);
        Ray ray = new Ray(m_raycastSpot.position, directionForward);


        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, m_weaponRange))
        {
            hit.collider.SendMessage("QuitarVida", 10);
            //Debug.Log("Hit " + hit.transform.name);
            if (hit.rigidbody)
            {
                hit.rigidbody.AddForce(ray.direction * m_forceToApply);
               // Debug.Log("Hit");
            }
        }

        GetComponent<AudioSource>().PlayOneShot(m_fireSound);
    }
    private void Reload()
    {
        audioSc.PlayOneShot(m_reloadSound);
        currentAmmo = ammoClip;
    }
}

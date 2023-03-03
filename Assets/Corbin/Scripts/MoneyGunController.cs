using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGunController : MonoBehaviour
{

    public GameObject bullet;
    public Transform muzzle;
    bool canShoot = true;
    public float fireRate;

    public GameObject weapon2;

    bool canSwapWeapon = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }

        if (Input.GetButtonDown("Fire3") && canSwapWeapon)
        {
            SwapWeapon();
        }
    }

    IEnumerator Shoot()
    {
        canSwapWeapon = false;
        Instantiate(bullet, muzzle.position, muzzle.rotation);
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
        canSwapWeapon = true;
    }

    void SwapWeapon()
    {
        gameObject.SetActive(false);
        weapon2.SetActive(true);
    }
}

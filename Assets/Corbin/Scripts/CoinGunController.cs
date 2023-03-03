using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGunController : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;
    bool canShoot = true;
    public float fireRate;
    public int bulletCount;

    public GameObject weapon1;

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

    void SwapWeapon()
    {
        gameObject.SetActive(false);
        weapon1.SetActive(true);
    }

    IEnumerator Shoot()
    {
        canSwapWeapon = false;
        Quaternion newRot = muzzle.rotation;
        float spread = 1;

        for (int i = 0; i < bulletCount; i++)
        {
            float addedOffset = i - bulletCount / 4 * spread;
            Debug.Log(addedOffset);
            newRot = Quaternion.Euler(muzzle.eulerAngles.x, muzzle.eulerAngles.y, muzzle.eulerAngles.z + addedOffset);

            Instantiate(bullet, muzzle.position, newRot);
        }
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
        canSwapWeapon = true;
    }
}

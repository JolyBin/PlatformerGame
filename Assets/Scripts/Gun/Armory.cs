using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armory : MonoBehaviour
{
    public Gun[] Guns;
    public int CurrentGunIndex;
    void Start()
    {
        TakeGunByIndex(CurrentGunIndex);
    }

    public void TakeGunByIndex(int gunIndex)
    {
        for (int i = 0; i < Guns.Length; i++)
        {
            if(i == gunIndex)
            {
                Guns[i].Activate();
                CurrentGunIndex = i;
            }
            else
            {
                Guns[i].Deactivate();
            }
        }
    }

    public void AddBulltes(int gunIndex, int numberOfBullets)
    {
        Guns[gunIndex].AddBullets(numberOfBullets);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeGunByIndex(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TakeGunByIndex(1);
        }
    }
}

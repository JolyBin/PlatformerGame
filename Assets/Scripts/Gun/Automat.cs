using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    [Header("Automat")]
    public int NumberOfBullets = 30;
    public Text BulletsText;
    public Armory Armory;

    public override void Shoot()
    {
        if (NumberOfBullets == 0)
        {
            Armory.TakeGunByIndex(0);
            return;
        }
        base.Shoot();
        NumberOfBullets--;
        UpdateText();

    }

    public override void Activate()
    {
        base.Activate();
        BulletsText.enabled = true;
        UpdateText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        BulletsText.enabled = false;
    }

    void UpdateText()
    {
        BulletsText.text = "Пули: " + NumberOfBullets.ToString();
    }

    public override void AddBullets(int numberOfBullets)
    {
        base.AddBullets(numberOfBullets);
        NumberOfBullets += numberOfBullets;
        UpdateText();
        Armory.TakeGunByIndex(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public bool HasGrabbedThisPowerup;

    public string PlayerString;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DoublePlayerInput>() != null)
        {
            PlayerString = other.tag;

            GiveString(PlayerString);

            Debug.Log(gameObject.name + "PowerUp Grabbed");
            HasGrabbedThisPowerup = true;

            DoPowerup();

            ObjectPool.instance.ReturnObject(gameObject, PowerupObjectPool.instance.powerupsObjectPool);
        }
    }

    /// <summary>
    /// Gives 1st String value to the target string
    /// </summary>
    /// <param name="ValueString"></param>
    /// <returns></returns>
    public string GiveString(string ValueString)
    { 
        UIManager.Instance.PlayerStringUI = ValueString;
        return null;
    }

    virtual public void DoPowerup()
    {
        //gets used in subclasses
    }
}

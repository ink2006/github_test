using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetEngineFuelManager : MonoBehaviour
{

    [SerializeField] float maxFuel;
    float currentFuel;
    [SerializeField] float waitRechargeFuel; // 재충전 대기시간
    float currentWaitRechargeFuel;

    [SerializeField] float rechargeSpeed; // 재충전 속도

    [SerializeField] Slider slider_JetEngine;
    [SerializeField] Text txt_JetEngine;

    public bool IsFuel { get; private set; }

    PlayerController thePC;

    void Start()
    {
        currentFuel = maxFuel;
        slider_JetEngine.maxValue = maxFuel;
        slider_JetEngine.value = currentFuel;
        thePC = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        CheckFuel();
        UsedFuel();       

        slider_JetEngine.value = currentFuel;
        txt_JetEngine.text = Mathf.Round(currentFuel / maxFuel * 100f).ToString() + "%";

    }

    void FuelRecharge()
    {
        if(currentFuel < maxFuel)
        {
            currentWaitRechargeFuel += Time.deltaTime;
            if(currentWaitRechargeFuel >= waitRechargeFuel)
            {
                currentFuel += rechargeSpeed * Time.deltaTime;
            }
        }
        else
        {
            slider_JetEngine.gameObject.SetActive(false);
        }
    }

    void UsedFuel()
    {
        if (thePC.IsJet)
        {
            slider_JetEngine.gameObject.SetActive(true);

            currentFuel -= Time.deltaTime;
            currentWaitRechargeFuel = 0;
            if (currentFuel <= 0)
                currentFuel = 0;
        }
        else
        {
            FuelRecharge();
        }
    }

    void CheckFuel()
    {
        if (currentFuel > 0)
            IsFuel = true;
        else
            IsFuel = false;
    }

}

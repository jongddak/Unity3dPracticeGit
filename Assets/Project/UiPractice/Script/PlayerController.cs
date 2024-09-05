using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   


    [Header("Ui")]
    [SerializeField] TextMeshProUGUI curAmmotext;
    [SerializeField] TextMeshProUGUI maxAmmotext;

    [Header("Model")]
    [SerializeField] PlayerModel model;

  //  [Header("Property")]
 
    

    private void OnEnable()
    {
        model.OncurAmmoChanged += UpdateCurAmmo;
    }
    private void OnDisable()
    {
        model.OncurAmmoChanged -= UpdateCurAmmo;
    }
    private void Start()
    {
        UpdateCurAmmo(model.curAmmo);
        maxAmmotext.text = $"/ {model.maxAmmo}";
    }
    private void UpdateCurAmmo(int curAmmo) 
    {
        curAmmotext.text = $"{model.curAmmo}";
    }
}

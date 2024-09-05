using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerModel : MonoBehaviour
{
    // 모델은 데이터 보관 및 이벤트만 !

    [SerializeField] int maxammo;
    public int maxAmmo { get {return maxammo;}}

    [SerializeField] int curammo;
    public int curAmmo { get { return curammo; } set { curammo = value; OncurAmmoChanged?.Invoke(curammo); } }
    public UnityAction<int> OncurAmmoChanged;

    
}

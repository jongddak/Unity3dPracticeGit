using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerModel : MonoBehaviour
{
    // ���� ������ ���� �� �̺�Ʈ�� !

    [SerializeField] int maxammo;
    public int maxAmmo { get {return maxammo;}}

    [SerializeField] int curammo;
    public int curAmmo { get { return curammo; } set { curammo = value; OncurAmmoChanged?.Invoke(curammo); } }
    public UnityAction<int> OncurAmmoChanged;

    
}

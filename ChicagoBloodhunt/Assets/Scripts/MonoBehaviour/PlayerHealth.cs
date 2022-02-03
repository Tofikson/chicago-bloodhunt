using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float maxHp = 70f;
    public float currentHP;
    public List<Sprite> paskiHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = SaveCurrentHP.LoadHP();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP > maxHp)
        {
            currentHP = maxHp;
        }
        GameObject.Find("HP").GetComponent<RawImage>().texture = paskiHP[(int)Mathf.Ceil(currentHP / 10)].texture;

        if(maxHp == 0)
        {
            //death
        }
    }

    public void playerHit(float damage)
    {
        currentHP -= damage;
    }

    public void playerHeal(float heal)
    {
        currentHP += heal;
    }
}

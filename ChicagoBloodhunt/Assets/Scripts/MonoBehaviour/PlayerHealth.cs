using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float maxHp = 70f;
    public float currentHP;
    public List<Sprite> paskiHP;
    public GameLost lose;

    // Start is called before the first frame update
    void Start()
    {
        if (lose == null)
        {
            lose = GameObject.Find("SceneSwitch").GetComponent<GameLost>();
        }
        currentHP = SaveCurrentHP.LoadHP();
    }

    // Update is called once per frame
    void Update()
    {
        if (lose.gameLost) return;

        if (currentHP > maxHp)
        {
            currentHP = maxHp;
        }

        if(currentHP <= 0)
        {
            currentHP = 0f;
            gameObject.GetComponent<VampireBuff>().ActivateVampBuff();
        }
            GameObject.Find("HP").GetComponent<RawImage>().texture = paskiHP[(int)Mathf.Ceil(currentHP / 10)].texture;
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

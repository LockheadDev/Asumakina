using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlyr : MonoBehaviour
{
    public int health;
    public int armorvalue;

    public int numofhearts=3;

    public int numofarmor=2;

    public Image[] hearts;
    public Image[] armors;

    public Sprite armor;
    public Sprite heart;

    public Sprite emptyheart;

    public Sprite emptyarmor;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        UpdateArmor();
    }


    void UpdateHealth()
    {
        if (health > numofhearts)
        {
            health = numofhearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = heart;
            }
            else
            {
                hearts[i].sprite = emptyheart;
            }

            if (i < numofhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    void UpdateArmor()
        {
            if (armorvalue > numofarmor)
            {
                armorvalue = numofarmor;
            }

            for (int i = 0; i < armors.Length; i++)
            {
                if (i < armorvalue)
                {
                   armors[i].sprite = armor;
                }
                else
                {
                    armors[i].sprite = emptyarmor;
                }

                if (i < numofarmor)
                {
                    armors[i].enabled = true;
                }
                else
                {
                    armors[i].enabled = false;
                }
            }
        }
    }

    

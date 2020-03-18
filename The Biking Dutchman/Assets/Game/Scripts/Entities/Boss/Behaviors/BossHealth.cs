using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private StateMachine controller;

    private float maxHealth = 20000;
    private float currentHealth;

    private float maxBarX = 2.09f;
    private int playerDamage; //Set to a random value for now.

    [SerializeField]
    private SpriteRenderer bar;

    [SerializeField]
    private GameObject hitPrefab;
    private float hitTextRange = 2;

    private void OnEnable()
    {
        AttackState.OnHit += TakeDamage;
    }
    private void OnDisable()
    {
        AttackState.OnHit -= TakeDamage;
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<StateMachine>();
        currentHealth = maxHealth;
    }

    private void TakeDamage()
    {
        playerDamage = Random.Range(200, 500);
        currentHealth -= playerDamage;
        HitText();
        UpdateBar();
        
        if(currentHealth <= 0)
        {
            controller.ChangeState("DEAD");
        }
    }

    private void UpdateBar()
    {
        float barX = Mathf.Lerp(0, maxBarX, currentHealth / maxHealth);
        bar.size = new Vector2(barX, bar.size.y);
    }

    private void HitText()
    {
        float x = transform.position.x + Random.Range(-hitTextRange, hitTextRange);
        float y = transform.position.y + 5 + Random.Range(-hitTextRange, hitTextRange);
        float z = transform.position.y - 2;

        Vector3 randomPos = new Vector3(x, y, z);
        GameObject hitText = Instantiate(hitPrefab);
        hitText.transform.position = randomPos;
        hitText.GetComponent<TextMesh>().text = playerDamage + "K";
    }
}

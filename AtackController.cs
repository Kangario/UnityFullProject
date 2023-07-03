
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public float attackRange = 1f;       // Дальность атаки
    public float attackInterval = 2f;    // Интервал между атаками
    public float damage = 1;
    private bool isAttacking = false;    // Флаг, указывающий на то, происходит ли атака в данный момент
    private float attackTimer = 0f;      // Таймер для отсчета интервала между атаками

    public void Update()
    {
        Debug.DrawLine(transform.position, new Vector3(transform.position.x + attackRange,
               transform.position.y + attackRange, transform.position.z + attackRange), Color.red);
        // Проверяем, находится ли персонаж в состоянии атаки или если уже прошло достаточное время для новой атаки
        if (!isAttacking && attackTimer <= 0f)
        {
            // Проверяем нажатие кнопки атаки (в примере используется левая кнопка мыши)
            if (Input.GetMouseButton(0))
            {
                Attack();
            }
        }

        // Если происходит атака, запускаем таймер и устанавливаем флаг isAttacking в true
        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f)
            {
                isAttacking = false;
                attackTimer = 0f;
            }
        }
    }

    public void Attack()
    {
        // Помечаем, что атака началась и сбрасываем таймер
        isAttacking = true;
        attackTimer = attackInterval;

        // Выполняем логику атаки, например, пускаем анимацию и определяем попадание по цели
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {

            hit.collider.gameObject.GetComponent<Stats>().TakeDamage(damage);


            // Если было попадание, обрабатываем его соответствующим образом
            Debug.Log("Попадание в: " + hit.transform.name);
            // Добавьте здесь логику, связанную с нанесением урона цели и другие действия атаки
           
        }
    }
}

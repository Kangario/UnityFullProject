
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public float attackRange = 1f;       // ��������� �����
    public float attackInterval = 2f;    // �������� ����� �������
    public float damage = 1;
    private bool isAttacking = false;    // ����, ����������� �� ��, ���������� �� ����� � ������ ������
    private float attackTimer = 0f;      // ������ ��� ������� ��������� ����� �������

    public void Update()
    {
        Debug.DrawLine(transform.position, new Vector3(transform.position.x + attackRange,
               transform.position.y + attackRange, transform.position.z + attackRange), Color.red);
        // ���������, ��������� �� �������� � ��������� ����� ��� ���� ��� ������ ����������� ����� ��� ����� �����
        if (!isAttacking && attackTimer <= 0f)
        {
            // ��������� ������� ������ ����� (� ������� ������������ ����� ������ ����)
            if (Input.GetMouseButton(0))
            {
                Attack();
            }
        }

        // ���� ���������� �����, ��������� ������ � ������������� ���� isAttacking � true
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
        // ��������, ��� ����� �������� � ���������� ������
        isAttacking = true;
        attackTimer = attackInterval;

        // ��������� ������ �����, ��������, ������� �������� � ���������� ��������� �� ����
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {

            hit.collider.gameObject.GetComponent<Stats>().TakeDamage(damage);


            // ���� ���� ���������, ������������ ��� ��������������� �������
            Debug.Log("��������� �: " + hit.transform.name);
            // �������� ����� ������, ��������� � ���������� ����� ���� � ������ �������� �����
           
        }
    }
}

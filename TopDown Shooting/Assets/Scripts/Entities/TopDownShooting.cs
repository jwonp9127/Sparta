using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private TopDownCharacterController _controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.right; // ������ �ִ� �� ����ϰڴ�.

    public GameObject testPrefab;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnShoot()
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        Instantiate(testPrefab, projectileSpawnPosition.position, Quaternion.identity);
    }

    private void OnAim(Vector2 newAimdirection)
    {
        _aimDirection = newAimdirection;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

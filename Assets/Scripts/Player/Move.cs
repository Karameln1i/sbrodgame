using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{

    // Сериализуем переменные для выбора значений напрямую из движка
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    
    private Input _input;
    private Rigidbody _rigidbody;
    private Vector2 direction;

    // Метод Awake вызывается один раз - когда происходит загрузка скрипта
    private void Awake()
    {
        _input = new Input();
        // Что это за штука?
        _input.Player.Jump.performed += ctx => Jump();
    }

    // Вань, объясни нахуя это надо плз
    private void OnEnable()
    {
        _input.Enable();
    }

    // Это типа ты включаешь-выключаешь контроллер инпута или что?
    private void OnDisable()
    {
        _input.Disable();
    }
    // Метод Start вызывается один раз - когда скрипт инициализирован
    private void Start()
    {
        // Поскольку каждый раз вызывать компонент слишком ресурсозатратно,
        // мы вызываем его лишь один раз, чтобы сохранить в переменную её копию. 
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Метод Update вызывается каждый ПРОРИСОВАННЫЙ кадр.
    // Это означает, что все действия внутри этого метода будут зависеть от фреймрейта.
    // По этой причине использовать его для работы с физикой - плохая практика.
    private void Update()
    {
        // Сохраняем направление движения до следующего кадра,
        // то есть до момента, когда мы можем гарантированно получить инпут.
        direction = _input.Player.Move.ReadValue<Vector2>();
    }

    /*
    * Метод FixedUpdate вызывается независимо от фреймрейта.
    * В нашем проекте обновление происходит 100 раз в секунду.
    * Данный метод используется для работы с физикой движка, потому что
    * она не должна зависеть от количества кадров в секунду у игрока.
    */
    private void FixedUpdate()
    {
        Movement(direction);
    }

    private void Movement (Vector3 direction)
    {
        float scaleMoveSpeed = _speed * Time.deltaTime;
        Vector3 moveDirection = new Vector3(direction.x,0,direction.y);
        transform.position += moveDirection*scaleMoveSpeed;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up*_jumpForce);
    }
}

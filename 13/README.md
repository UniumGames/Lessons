### Обработка столкновений

Часто нам нужно выполнить какое-то действие при столкновении объектов в игре: засчитать очки при попадании пули во врага, проиграть анимацию сжатия, когда мяч падает на землю, отрисовать вмятины при столкновении машин, проиграть звук при ударе мяча о биту и тд

Для обработки столкновений скрипт получает события `OnCollisionEnter`, `OnCollisionStay` и `OnCollisionExit`. Работа с ними полностью аналогична работе с событиями триггеров.

- Событие `OnCollisionEnter` будет посылаться, когда объекты только начали касаться друг друга
- `OnCollisionExit `, когда объекты только перестали касаться друг друга
- `OnCollisionStay `, пока объекты касаются друг друга

Обрати внимание, что:

- События столкновений срабатывают только для объектов, у которых есть коллайдер и параметр `Is Trigger` отключен
- В событие столкновения параметром передается объект типа `Collision`, а не `Collider`. Из этого объекта можно получить объект, с которым произошло столкновение, и другие данные о столкновении

```csharp
void OnCollisionEnter(Collision collision) {
	// сохраним объект, с которым произошло столкновение
	GameObject other = collision.gameObject;
	// и выведем его имя
	print(other.name);
}
```

### Задаем скорость твердому телу

Объекты, которым добавлен `Rigidbody`, управляются физическим движком. И чтобы избежать проблем при взаимодействии объектов, не рекомендуется изменять их координаты непосредственно

Чтобы объект двигался с постоянной скоростью, следует задать значение поля `velocity` его компонента `Rigidbody`

```csharp
void Start () {
    // сохраняем Rigidbody в переменную
    Rigidbody body = GetComponent<Rigidbody>();
    
    // задаем скорость 10 по оси х
    body.velocity = new Vector3(10, 0, 0);
}
```


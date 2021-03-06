### Инструкция по проекту Airplane

[Скачать материалы](https://github.com/UniumGames/Lessons/raw/master/22/sprites.png)

1. Создай слои для того, чтобы все было по своим местам.

   Порядок слоев примерно такой:

   - Background
   - Mountain
   - Ground
   - Plane

2. Нужно будет добавить самолет и создать анимацию для самолета

3. Создаем скрипт `PlaneController` полета самолета и накладываем его на самолет. Он заставит наш самолет лететь все время вперед и со временем ускоряться
  ![](https://github.com/UniumGames/Lessons/raw/master/22/img/image1.png)

4. Создать скрипт `CameraController` перемещения камеры и накладываем на камеру
  ![](https://github.com/UniumGames/Lessons/raw/master/22/img/image2.png)

5. Создаем бесконечный игровой уровень. Для этого берем 2 картинки фона и ставим рядом друг с другом, объединяем их в одном объекте и добавляем коллайдер (включаем триггер), также не забудь создать новый тег и назвать его `Background`. После создаем из этого префаб и
  переносим в папку `Resources` (если ее нет, то создаем)
  ![](https://github.com/UniumGames/Lessons/raw/master/22/img/image3.png)

6. Зачем здесь триггер? При касании триггера впереди самолета будет добавляться новый фон, а когда самолет улетит, старый будет исчезать. Создаем новый скрипт `SpawnBackground` и добавляем его на самолет. В параметре `B` нода `Add Float` нужно задать значение, на которое будет смещен наш новый фон. У меня получилось примерно 21. Самостоятельно протестируйте, какое вам нужно смещение
  ![](https://github.com/UniumGames/Lessons/raw/master/22/img/image4.png)

7. Нужно добавить к самолету компоненты `Circle Collider 2D` и `Rigidbody 2D`, а параметр `Gravity Scale = 0`, чтобы самолет не падал

8. Новый фон у нас добавляется, а вот старый до сип пор остается, чтобы это исправить нужно будет создать скрипт `DestroyUnusedObject`, который будет отслеживать расстояние между камерой и старым фоном, и при достижении определенного значения, он будет уничтожать старый фон. Вот этот скрипт, его нужно будет наложить на префаб фона

   ![](https://github.com/UniumGames/Lessons/raw/master/22/img/image5.png)

9. Теперь нужно будет создать управление самолетом. Оно будет похоже на игру `Flappy Bird`, т. е. игрок нажимает кнопку и самолет взмывает вверх. Поэтому нужно будет вернуть значение `Gravity Scale` в `Rigidbody 2D` нашего самолета. Нужно будет открыть код `PlaneController` и добавить его в скрипт полета самолета
  ![](https://github.com/UniumGames/Lessons/raw/master/22/img/image6.png)

10. Основное мы сделали, но теперь возникает проблема, что самолет может вылететь за пределы игры, чтобы этого избежать нужно будет добавить коллайдеры. Один сверху, это может быть обычный `Box Collider 2D`, а снизу добавляем спрайты земли и на них накладываем `Polygon Collider 2D` и добавляем его в фон. Чтобы все изменения, которые мы сделали с фоном, появились и в префабе нужно нажать кнопку `Apply` на нашем объекте
  ![](https://github.com/UniumGames/Lessons/raw/master/22/img/image7.png)
  ![](https://github.com/UniumGames/Lessons/raw/master/22/img/image8.png)
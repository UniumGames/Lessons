### Задание №7: Найди друга

 [Скачать материалы](http://unity3d.unium.ru/storage/lesson15/skeleton.zip)

На уровне много вражеских скелетов. Когда игрок подходим к ним, то воспроизводится анимация атаки. Задача игрока найти дружелюбного скелета, который вместо нападения, будет танцевать.

1. Добавь пакет «**Skeleton**».

2. Выдели модель на панели «**Project**». На панели «**Inspector**» выбери следующие настройки:

   ![img](http://unity3d.unium.ru/lessons/lesson15/images/humanoid_rig.jpg)

3. в соседней закладке «**Animations**» включи параметр «**Import Animation**». Нажми кнопку «**Apply**», чтобы появились дополнительные настройки:

   ![img](http://unity3d.unium.ru/lessons/lesson15/images/import2.jpg)

4. в таблице анимаций добавь следующие анимации:

   - «**Skeleton@Idle**». «**Start**»= 0, «**End**» = 240. «**LoopTime**» включен.
   - «**Skeleton@Attack**». «**Start**»= 315, «**End**» = 350. «**LoopTime**» включен.
   - «**Skeleton@Dance**». «**Start**»= 458, «**End**» = 1275. «**LoopTime**» включен.

5. На панели «**Project**» нажми ![img](http://unity3d.unium.ru/images/rmb.png) → «**Create**» → «**Animator Controller**». Введи имя аниматора «**SkeletonNPC**». Открой редактор аниматора.

6. Создай новое состояние с помощью ![img](http://unity3d.unium.ru/images/rmb.png) → «**Create State**» → «**Empty**». Выдели новое состояние и настрой его:

   ![img](http://unity3d.unium.ru/lessons/lesson15/images/npc1.jpg)

7. добавь модель скелета на сцену.

8. в компоненте «**Animator**» в параметре «**Controller**» выбери аниматор «**SkeletNPC**».

9. Запусти игру. Скелет будет стоять на месте и будет проигрываться анимация спокойствия (Idle).

10. Открой аниматор «**SkeletNPC**». Добавь состояния «**Attack**» (выбери анимацию атаки), «**Dance**» (выбери анимацию танца). Создай переходы:

    ![img](http://unity3d.unium.ru/lessons/lesson15/images/npc2.jpg)

11. Добавь Bool параметры «**attack**», «**dance**»:

    ![img](http://unity3d.unium.ru/lessons/lesson15/images/npc3.jpg)

12. Настроим переходы. Выключи в каждом переходе настройку «**Has Exit Time**».

13. ![img](http://unity3d.unium.ru/lessons/lesson15/images/npc4.jpg)

14. Добавь к объекту скелета компонент «**Box Collider**». Настрой его параметры так, чтобы коллайдер был перед скелетом. Включи настройку «**is Trigger**»

    ![img](http://unity3d.unium.ru/lessons/lesson15/images/npc5.jpg)

15. Создай скрипт по имени «**Skeleton**». Присвой его скелету.
    Скрипт должен работать так: 

    - Содержит публичную переменную `isFriend` типа `bool` (логическая). Она отвечает за то, друг данный скелет или враг. Друг будет танцевать, а враг - атаковать

       ```csharp
       public bool isFriend;
       ```

    - При входе в триггер проверяется друг ли этот  скелет. Если друг, то активируем параметр `dance`. Иначе (если враг), активируем параметр `attack`

    - При выходе из триггера выключаем оба параметра аниматора (`dance` и `attack`)

17. Скопируй несколько скелетов на сцене. В компоненте скрипта можно настраивать какой скелет будет дружественным:

    ![img](http://unity3d.unium.ru/lessons/lesson15/images/npc7.jpg)

Необходимые знания:

[Создание анимации (Animation)](https://github.com/UniumGames/Lessons/tree/master/15#%D0%A1%D0%BE%D0%B7%D0%B4%D0%B0%D0%BD%D0%B8%D0%B5-%D0%B0%D0%BD%D0%B8%D0%BC%D0%B0%D1%86%D0%B8%D0%B8-animation), [Граф состояний (Animator)](https://github.com/UniumGames/Lessons/tree/master/15#%D0%93%D1%80%D0%B0%D1%84-%D1%81%D0%BE%D1%81%D1%82%D0%BE%D1%8F%D0%BD%D0%B8%D0%B9-animator), [замена модели в Third Person Character](https://github.com/UniumGames/Lessons/tree/master/15#%D0%97%D0%B0%D0%BC%D0%B5%D0%BD%D0%B0-%D0%BC%D0%BE%D0%B4%D0%B5%D0%BB%D0%B8-%D0%B2-third-person-character), [управление графом состояния с помощью параметров](https://github.com/UniumGames/Lessons/tree/master/15#%D0%A3%D0%BF%D1%80%D0%B0%D0%B2%D0%BB%D0%B5%D0%BD%D0%B8%D0%B5-%D0%B3%D1%80%D0%B0%D1%84%D0%BE%D0%BC-%D1%81%D0%BE%D1%81%D1%82%D0%BE%D1%8F%D0%BD%D0%B8%D1%8F-%D1%81-%D0%BF%D0%BE%D0%BC%D0%BE%D1%89%D1%8C%D1%8E-%D0%BF%D0%B0%D1%80%D0%B0%D0%BC%D0%B5%D1%82%D1%80%D0%BE%D0%B2), [импорт анимации](https://github.com/UniumGames/Lessons/tree/master/15#%D0%98%D0%BC%D0%BF%D0%BE%D1%80%D1%82-%D0%B0%D0%BD%D0%B8%D0%BC%D0%B0%D1%86%D0%B8%D0%B8)

Критерии качества:

- скелет воспроизводит анимацию спокойствия;
- при приближении игрока меняется анимация скелета;
- добавлены несколько скелетов. Среди них есть враги и дружелюбные;
- создан красивый уровень.
### Задание №7: Найди друга

 [Скачать материалы](http://unity3d.unium.ru/storage/lesson15/skeleton.zip)

На уровне много вражеских скелетов. Когда игрок подходим к ним, то воспроизводится анимация атаки. Задача игрока найти дружелюбного скелета, который вместо нападения, будет танцевать.

1. Добавь пакет «**Skeleton**».

2. Выдели модель на панели «**Project**». На панели «**Inspector**» выбери следующие настройки:

   ![img](http://unity3d.unium.ru/lessons/lesson15/images/humanoid_rig.jpg)

3. в соседней закладке «**Animations**» включи параметр «**Import Animation**». Нажми кнопку «**Apply**», чтобы появились дополнительные настройки:

   ![img](http://unity3d.unium.ru/lessons/lesson15/images/import2.jpg)

4. в таблице анимаций добавь следующие анимации:

   - «**Skelet@Idle**». «**Start**»= 0, «**End**» = 240. «**LoopTime**» включен.
   - «**Skelet@Attack**». «**Start**»= 315, «**End**» = 350. «**LoopTime**» включен.
   - «**Skelet@Dance**». «**Start**»= 458, «**End**» = 1275. «**LoopTime**» включен.

5. На панели «**Project**» нажми ![img](http://unity3d.unium.ru/images/rmb.png) → «**Create**» → «**Animator Controller**». Введи имя аниматора «**SkeletNPC**». Открой редактор аниматора.

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

15. Создай скрипт по имени «**Skelet**». Присвой его к скелету.

16. [![img](http://unity3d.unium.ru/lessons/lesson15/images/npc6.jpg)](http://unity3d.unium.ru/lessons/lesson15/images/npc6.jpg)

17. Скопируй несколько скелетов на сцене. В компоненте скрипта можно настраивать какой скелет будет дружественным:

    ![img](http://unity3d.unium.ru/lessons/lesson15/images/npc7.jpg)

Необходимые знания:

[Создание анимации (Animation)](http://unity3d.unium.ru/lessons/lesson15/index.html#createanim), [Граф состояний (Animator)](http://unity3d.unium.ru/lessons/lesson15/index.html#createanimator), [замена модели в Third Person Character](http://unity3d.unium.ru/lessons/lesson15/index.html#changemesh), [управление графом состояния с помощью параметров](http://unity3d.unium.ru/lessons/lesson15/index.html#scriptanimator), [импорт анимации](http://unity3d.unium.ru/lessons/lesson15/index.html#importanim).

Критерии качества:

- скелет воспроизводит анимацию спокойствия;
- при приближении игрока меняется анимация скелета;
- добавлены несколько скелетов. Среди них есть враги и дружелюбные;
- создан красивый уровень.
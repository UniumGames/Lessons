### Инструкция к проекту Angry Birds

[Скачать материалы](https://github.com/UniumGames/Lessons/blob/master/21/Sprites.zip)

1. Создай слои в Sorting Layers и выстрой их в правильно порядке. Здесь важно учесть, что наша рогатка состоит из 2 частей, так как снаряд будет пролетать между рогатками, то длинная часть должна быть за снарядом, а короткая перед снарядом

  ![](https://github.com/UniumGames/Lessons/raw/master/21/img/image1.png)

2. Добавить коллайдер к земле, чтобы астероид не упал.

3. Настрой снаряд. Здесь нужно добавить 

    - Circle Collider 2D
    - Rigidbody 2D, задать значание Gravity Scale=0
    - Spring Joint 2D

4. Нужно настроить Spring Joint 2D. Здесь вначале нужно установить правильно начальные точки. На картинке показаны расположения точек. Крайняя точка настраивается параметром Connected Anchor. Промежуточная точка настраивается параметром Distance, предварительно отключив параметр Auto Configure Distance. Также нужно будет установить параметр Frequency = 3

    ![](https://github.com/UniumGames/Lessons/raw/master/21/img/image2.png)

5. После настройки этого компонента его нужно будет отключить, убрав галочку с компонента.

6. Теперь нужно написать код для запуска снаряда. Все 3 кода пишутся в одном скрипте.

    ![](https://github.com/UniumGames/Lessons/raw/master/21/img/image3.png)

    ![](https://github.com/UniumGames/Lessons/raw/master/21/img/image4.png)

    ![](https://github.com/UniumGames/Lessons/raw/master/21/img/image5.png)

7. После проверки работы кода, можно добавить платформы с коллайдерами и физикой для первого уровня. К примеру, вот так:

    ![](https://github.com/UniumGames/Lessons/raw/master/21/img/image6.png)

8. Последним этапом будет создание врага. В нашем случае это птичка. Чтобы была возможность ее уничтожить, на птичку наложим 2 коллайдера: Polygon Collider 2D и Circle Collider 2D (триггер). Расположение второго колайдера можно увидеть на картинке.

    ![](https://github.com/UniumGames/Lessons/raw/master/21/img/image7.png)

9. После этого пишем код и добавляем его на птичку

    ![](https://github.com/UniumGames/Lessons/raw/master/21/img/image8.png)

10. Теперь можно дорабатывать игру, различными способами. Это и новые уровни, враги, меню и тд.
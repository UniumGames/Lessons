### Задание №1: Забей гол (часть №2)

[Скачать текстуры](http://unity3d.unium.ru/storage/lesson11/goal.zip)

Открой проект `Забей гол!`. Создадим главное меню для этой игры, состоящее из трех кнопок: `Старт`, `Титры` и `Выход`.

Добавь новую сцену по имени `Main Menu`. Импортируй в проект текстуру `забей Гол Sprites.png`. На панели `Inspector` в параметре `Texture Type` выбери `Sprite (2D and UI)`, в параметре `Sprite Mode` выбери `Multiple`. Нажми кнопку `Sprite Editor`.

![](http://unity3d.unium.ru/lessons/lesson11/images/goal1.png)

В редакторе `Sprite Editor` с помощью прямоугольного выделения создай спрайты (обрати внимание на зеленую кнопку). Задай каждому элементу имя. Закрой редактор `Sprite Editor`.

![](http://unity3d.unium.ru/lessons/lesson11/images/goal2.png)

Добавь на сцену объект `GameObject` → `UI` → `Canvas`. На канас добавь пустой объект  `GameObject` → `Create Empty`. Переименуй его в `Main Menu`, в него будут добавляться все элементы меню.

Добавь в `Main Menu` объект `GameObject` → `UI` → `Image`. Переименуй объект в `Background`. Увеличь его размер и `Anchor Points` на весь экран:

![](http://unity3d.unium.ru/lessons/lesson11/images/goal3.png)

На панели `Inspector` в параметре `Source Image` выбери спрайт травы, а в параметре `Image Type` выбери `Tiled`. Проверь, что спрайт травы отображается на всей площади экрана. Задний фон главного меню готов.

![](http://unity3d.unium.ru/lessons/lesson11/images/goal4.jpg)

Теперь добавим логотип игры. Добавь в `Main Menu` объект `GameObject` → `UI` → `Image` с именем `Logo`. В параметре `Source Image` выбери спрайт логотипа игры `Забей гол!`, в параметре `Image Type` выбери `Simple` и включи настройку `Preserve Aspect`.

![](http://unity3d.unium.ru/lessons/lesson11/images/goal5.jpg)

Размести созданное изображение так, как на рисунке.

![](http://unity3d.unium.ru/lessons/lesson11/images/goal6.png)

Теперь добавим кнопки. Начнем с кнопки в виде мяча, на котором будет написано `СТАРТ`. Добавь в `Main Menu` `GameObject` → `UI` → `Button`. Переименуй объект в `Button Start`. На панели `Inspector` выбери следующие настройки:

![](http://unity3d.unium.ru/lessons/lesson11/images/goal7.jpg)

- в параметре `Source Image` выбери спрайт кнопки мяча в обычном состоянии (normal);
- в параметре `Image Type` выбери `Simple`;
- включи настройку `Preserve Aspect`;
- в параметре `Transition` выбери `Sprite Swap`;
- в параметре `Pressed Sprite` выбери спрайт кнопки мяча в нажатом состоянии.

Измени положение и `Anchor Points` так, как на рисунке:

![](http://unity3d.unium.ru/lessons/lesson11/images/goal8.png)

Выбери объект `Text`, который находится внутри объекта `Button Start`. На панели `Inspector` выбери следующие настройки:

![](http://unity3d.unium.ru/lessons/lesson11/images/goal9.jpg)

Измени размер и `Anchor Points` объектов `Button Start` и `Text` так, как на рисунке:

![](http://unity3d.unium.ru/lessons/lesson11/images/goal10.png)

Теперь добавим кнопку `Выход`. Добавь в `Main Menu` `GameObject` → `UI` → `Button`. Переименуй объект в в `Button Exit`. На панели `Inspector` выбери следующие настройки:

- в параметре `Source Image` выбери спрайт кнопки кнопки с зеленым контуром;
- в параметре `Image Type` выбери `Sliced`;
- включи настройку `Fill Center`.

Выбери объект `Text`, который находится внутри объекта `Button Exit`. На панели `Inspector` выбери следующие настройки:

- в параметре `Text` введи текст `Выход`;
- в параметре `Font Style` выбери `Bold`;
- включи настройку `Best Fit`;
- в параметре `Color` выбери красный цвет.

Измени размер и `Anchor Points` объектов `Button Exit` и `Text` так, как на рисунке:

![](http://unity3d.unium.ru/lessons/lesson11/images/goal11.png)

Таким же образом создай кнопку `Титры`.

Пример готового меню:

![](http://unity3d.unium.ru/lessons/lesson11/images/goal12.png)

Запусти игру. Кнопки нажимаются, но ничего не происходит.

Начнем с кнопки `СТАРТ`. Открой уровень `Main Menu`. В главном меню нажми `File` → `Build Settings…`. Нажми кнопку `Add Open Scenes`. Открой уровень `Football`. Снова выбери `File` → `Build Settings…` и нажми `Add Open Scenes`.

Вернись в сцену `Main Menu`. Cоздай новый скрипт `MainMenu.cs`. В скрипте создай три публичные переменные, чтобы передать в скрипт ссылки на созданные кнопки:

```csharp
public Button startButton;
public Button creditsButton;
public Button exitButton;
```

Далее создай методы-обработчики нажатия кнопок

```csharp
// загружаем сцену с именем Football
void LoadGame() {
	SceneManager.LoadScene("Football");
}

// завершаем игру
void ExitGame() {
	Application.Quit();
}
```

И свяжите созданные методы и события нажатия на соответствующие кнопки

```csharp
void Start() {
	startButton.onClick.AddListener(LoadGame);
	exitButton.onClick.AddListener(ExitGame);
}
```

Добавь созданный скрипт объекту `Main Menu` и проверь работу кнопок. Не забудь в редакторе перетащить кнопки в свойства скрипта

Самостоятельно сделай так, чтобы при нажатии кнопки `Титры` загружался уровень, на котором будет написано твое имя.

Критерии качества:

- работает кнопка запуска игры;
- работает кнопка выхода;
- при нажатии на кнопку титры загружается уровень с титрами.
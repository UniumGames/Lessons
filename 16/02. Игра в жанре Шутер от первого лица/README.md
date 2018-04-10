### Задание №1: Подготовка

[Скачать материалы](http://unity3d.unium.ru/storage/lesson16/fps.zip)

![](http://unity3d.unium.ru/lessons/lesson16/images/task2/borderlands2.jpg)

Шутер от первого лица (англ. First Person Shooter) — это жанр видеоигр, в котором игровой процесс основывается на сражениях с использованием огнестрельного и метательного оружия с видом от первого лица: игрок воспринимает происходящее глазами главного героя. В этом занятии ты узнаешь все основные темы, связанные с созданием игры в этом жанре.

Создай тестовый уровень с персонажем **FPSController** (вид от первого лица). Добавь пакет [FPS](http://unity3d.unium.ru/storage/lesson16/fps.zip).В проекте появятся следующие папки: «**Materials**» – материалы, «**Models**» содержит модель ракеты, ракетницы и паука. «**Sounds**» содержит звуки паука, взрыва. «**Textures**» – текстуры.

### Задание №2: Гранатомет

Предоставим игроку оружие, напоминающее гранатомет. Добавь на сцену объект «**RocketLauncher**» из папки «**Models**». Расположи гранатомет на сцене так, чтобы он был виден в правом нижнем углу камеры. Запустив игру, оружие не будет следовать за игроком. Это надо исправить! Перетащи объект «**RocketLauncher**» внутрь объекта «**FPSController**» → «**FirstPersonCharacter**»:

![](http://unity3d.unium.ru/lessons/lesson16/images/task2/fps1.jpg)

Выключи тень у оружия. Выдели его и в компоненте «**Mesh Renderer**» в параметре «**Cast Shadow**» выбери «**Off**». Теперь тень от оружия не создается.

Гранатомет не стреляет. Ракеты должны вылетать из дула гранатомета. Создай пустой объект («**GameObject**» → «**Create Empty**»). Расположи его внутри дула гранатомета.

![](http://unity3d.unium.ru/lessons/lesson16/images/task2/fps2.jpg)

Переименуй созданный пустой объект в «**Spawn**». На панели «**Inspector**» перетащи его внутрь гранатомета:

![img](http://unity3d.unium.ru/lessons/lesson16/images/task2/fps3.jpg)

При нажатии ![img](http://unity3d.unium.ru/images/lmb.png) гранатомет должен выпускать ракету. Создай новый скрипт по имени «**RocketLaunching**» и присвой его к «**RocketLauncher**»:

<details><summary>RocketLaunching</summary>

```csharp
public GameObject rocket;
public float launchDelay = 3;
float time = 3;

void Update () {
	time += Time.deltaTime;
	if(Input.GetKey(KeyCode.Mouse0)){
         // обеспечиваем задержку между выстрелами
		if(time > launchDelay){
			Instantiate(rocket, transform.position, transform.rotation);
			time = 0;
		}
	}
}
```

</details>

На панели «**Project**» создай новую папку по имени «**Resources**». Создай префаб по имени «**Rocket**» в этой папке. Добавь к префабу модель ракеты из папки «**Models**». Добавь следующие компоненты:

- «**Box Collider**»
- «**Rigidbody**». Выключи параметр «**Use Gravity**»;
- «**Constant Force**». В параметре «**Relative Force**» по оси Z введи значение «**15**».

Запусти игру. Проверь, что гранатомет стреляет.

### Задание №3: Ракеты

Сейчас ракеты летят бесконечно и при столкновении с объектами они не взрываются. Начнем с создания взрыва.

Воспользуемся готовыми системами частиц для создания взрыва. Добавь пакет «**Assets**» → «**Import Package**» → «**ParticleSystems**».

Перетащи на панели «**Project**» префаб «**Standard Assets**» → «**ParticleSystems**» → «**Prefabs**» → «**Explosion**» в папку «**Resources**».

Выдели его. Удали компонент «**Explosion Physics Force**». Добавь компонент «**Audio Source**». В параметре «**AudioClip**» выбери звук взрыва по имени «**Explosion**».

Создай новый скрипт по имени «**Rocket**» и добавь его к префабу «**Rocket**».

Скрипт должен:

1. Автоматически уничтожать ракету через 5 секунд, если она не попала в цель
2. Cоздавать `Explosion` при столкновении ракеты и удалять саму ракету со сцены. Через 5 секунд после попадания, частицы взрыва тоже следует удалить

<details><summary>Rocket</summary>

```csharp
public GameObject explosion;

void Start() {
	// автоматическое уничтожение ракеты
	// через 5 секунд
	Destroy(gameObject, 5);
}

void OnCollisionEnter(Collision collision) {
	GameObject explosionClone = Instantiate(explosion, transform.position, transform.rotation);
	Destroy(explosionClone, 5);
	Destroy(gameObject);
}
```

</details>

### Задание №4: Создание врагов

В качестве врагов в нашей игре будут пауки, которые станут нападать на игрока при приближении.

Создай префаб по имени «**Spider**» и добавь в него модель «**Spider**» из папки «**Models**».

Паук должен иметь свой тэг, по которому скрипт будет определять врага. Выдели префаб паука. На панели «**Inspector**» в параметре «**Tag**» выбери «**Add Tag…**»

![](http://unity3d.unium.ru/lessons/lesson16/images/task2/fps4.jpg)

Введи имя «**Enemy**»:

![](http://unity3d.unium.ru/lessons/lesson16/images/task2/fps5.jpg)

Снова выдели префаб паука и выбери созданный тэг «**Enemy**»:

![](http://unity3d.unium.ru/lessons/lesson16/images/task2/fps6.jpg)

Добавь к префабу компонент «**Nav Mesh Agent**» и выбери следующие настройки:

![](http://unity3d.unium.ru/lessons/lesson16/images/task2/fps7.jpg)

Выдели все неподвижные объекты на тестовом уровне (пол, стены) и включи настройку «**Static**»:

![](http://unity3d.unium.ru/lessons/lesson16/images/task2/fps8.jpg)

Открой панель «**Window**» → «**Navigation**» и нажми кнопку «**Bake**»:

![](http://unity3d.unium.ru/lessons/lesson16/images/task2/fps9.jpg)

Синим цветом обозначается область, где паук может ходить:

![](http://unity3d.unium.ru/lessons/lesson16/images/task2/fps10.jpg)

### Задание №5: Искусственный интеллект (часть №1)

Создай новый скрипт по имени «**SpiderAI**» и присвой его к префабу паука.

Скрипт:

1. Ищет на сцене игрока. Для поиска используется метод Find: `GameObject.Find("FPSController")`
2. Постоянно обновляет цель паука: заставляет его идти к игроку через компонент `NavMeshAgent`

<details><summary>SpiderAI</summary>

```csharp
Transform player;

void Start() {
	// сохраняем игрока
	player = GameObject.Find("FPSController").transform;
}

void Update() {
	// получаем NavMeshAgent паука
	NavMeshAgent agent = GetComponent<NavMeshAgent>();
	// и приказываем ему двигаться к игроку
	agent.SetDestination(player.position);
}
```

</details>

Запусти игру. Проверь, что паук обходит препятствия и идет к игроку.

### Задание №6: Убийство врагов

При выстреле из гранатомета пауки не умирают. Реализовать это можно с помощью пользовательских событий. Посмотри рисунок:

![img](http://unity3d.unium.ru/lessons/lesson16/images/task2/fps11.jpg)

В центре изображен взрыв от ракеты. Взрыв должен поражать врагов с радиусом 3 единицы (радиус воздействия взрыва на рисунке). Во время взрыва всем паукам посылается событие с именем «**Damage**» вместе с данными (имя события может быть любым). В событие передаются первым параметром координаты положения взрыва, вторым параметром — сила взрыва. По умолчанию «**25**» единицы.

Чтобы событие расылалось внеси необходимые изменения в скрипт `Rocket`

<details><summary>Rocket</summary>

```csharp
public GameObject explosion;
// создаем событие DamageEvent
public static Action<Vector3, int> DamageEvent;

void Start() {
	// автоматическое уничтожение ракеты
	// через 5 секунд
	Destroy(gameObject, 5);
}

void OnCollisionEnter(Collision collision) {
	int damage = 25;
	// рассылаем событие DamageEvent
	DamageEvent(transform.position, damage);

	GameObject explosionClone = Instantiate(explosion, transform.position, transform.rotation);
	Destroy(explosionClone, 5);
	Destroy(gameObject);
}
```

</details>

Далее, у каждого врага есть здоровье (Health на рисунке). Каждый паук на сцене получает событие «**Damage**» с данными. Эти данные обрабатываются. Далее проверяет расстояние паука до взрыва и, если это расстояние меньше радиуса поражения, — отнимается здоровье у врага. Если это здоровье будет меньше нуля — паук умирает и удаляется со сцены.

Создай новый скрипт по имени «**SpiderHealth**» и добавь его к префабу паука.

<details><summary>SpiderHealth</summary>

```csharp
public int health = 100;

void Start() {
	// подписываемся на событие DamageEvent
	Rocket.DamageEvent += TakeDamage;
}

void TakeDamage(Vector3 explosionPos, int damage) {
	float dist = Vector3.Distance(transform.position, explosionPos);
	// если игрок в радиусе поражения,
	// то наносим урон
	if (dist < 3) {
		health -= damage;
	}
}

void Update() {
	// удаляем паука, 
	// когда у него кончилось здоровье
	if (health <= 0) {
		Destroy(gameObject);
	}
}
```

</details>

Запусти игру. Проверь, что паук умирает после четырех выстрелов.

### Задание №7: Искусственный интеллект (часть №2)

Скрипт искусственного интеллекта имеет ряд недостатков. Паук постоянно бежит к игроку и не атакует. Также, паук должен двигаться в сторону игрока только тогда, когда игрок находится в зоне его видимости. Общий алгоритм ты можешь увидеть на рисунке:

Открой скрипт «**SpiderAI**». Внесем в него изменения:

![img](http://unity3d.unium.ru/lessons/lesson16/images/task2/spiderai2.jpg)

Запусти игру. Проверь, что пауки преследуют игрока, когда он находится на близком расстоянии и в зоне видимости.

### Задание №8: Система жизней игрока

Когда паук нападает на игрока – игроку не причиняется урон и он не умирает. Создай скрипт по имени «**PlayerHealth**» и добавь его к игроку.

![img](http://unity3d.unium.ru/lessons/lesson16/images/task2/playerhealth.jpg)

Открой скрипт «**SpiderAI**». Внеси в него изменения:

![img](http://unity3d.unium.ru/lessons/lesson16/images/task2/spiderai3.jpg)

Запусти игру. Проверь, что у игрока отнимается здоровье (переменная Health уменьшается). А если создать готовую игру, то происходит выход из игры, когда игрок умирает.

### Задание №9: Анимация

На панели «**Project**» нажми ![img](http://unity3d.unium.ru/images/rmb.png) → «**Create**» → «**Animator Controller**». Введи имя аниматора «**Spider**». Открой редактор аниматора. Добавь параметры «**run**», «**attack**» типа «**Bool**». Настрой граф состояний следующим образом:

![img](http://unity3d.unium.ru/lessons/lesson16/images/task2/fps13.jpg)

Создай новый скрипт по имени «**SpiderAnim**» и присвой его к префабу паука.

![img](http://unity3d.unium.ru/lessons/lesson16/images/task2/spideranim.jpg)

Выдели префаб паука. В компоненте «**Animator**» в параметре «**Controller**» выбери «**Spider**». Запусти игру. Проверь, что анимация атаки, перемещения работают.

### Задание №10: Звук атаки

Добавим звук атаки паука. Перетащи аудио файл «**Attack**» из папки «**Sounds**» в папку «**Resources**».

![img](http://unity3d.unium.ru/lessons/lesson16/images/task2/spidersound.jpg)

Теперь, когда паук атакует, то воспроизводится звук атаки.

### Задание №11: Улучшения

- добавь отображение количества жизней у игрока в правом нижнем углу экрана;
- добавь ограниченное количество ракет;
- добавь на экране количество доступных для выстрела ракет;
- создай разных пауков: одним требуется один выстрел, другим пять;
- сделай паука босса, для которого надо 20 ракет.

Критерии качества:

- гранатомет стреляет ракетами;
- при попадании ракеты в цель ракета уничтожается и на месте ее возникает взрыв;
- пауки преследуют игрока;
- пауки умирают после нескольких выстрелов ракет;
- паук преследует игрока только, когда он находится в зоне видимости;
- происходит выход из игры, если игрок умирает;
- воспроизводятся анимации паука (атака, бег);
- при атаке паука воспроизводится звук;
- пауки имеют разное количество жизней;
- есть босс-паук;
- добавлено главное меню;
- на экране отображается количество жизней игрока, количество ракет

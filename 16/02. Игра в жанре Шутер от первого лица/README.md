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
2. Cоздавать частицы взрыва при столкновении ракеты и удалять саму ракету со сцены. Через 5 секунд после попадания, частицы тоже следует удалить

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
2. Постоянно обновляет цель паука: заставляет его идти к игроку, вызывая метод `SetDestination()` компонента `NavMeshAgent`

<details><summary>SpiderAI</summary>

```csharp
Transform player;

void Start() {
	// сохраняем transform игрока
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

В центре изображен взрыв от ракеты. Взрыв должен поражать врагов с радиусом 3 единицы (радиус воздействия взрыва на рисунке). Во время взрыва всем паукам посылается событие с именем «**Damage**» вместе с данными (имя события может быть любым). В событие передаются первым параметром координаты положения взрыва, вторым параметром — сила взрыва. По умолчанию «**25**» единиц.

Чтобы событие рассылалось, внеси необходимые изменения в скрипт `Rocket`

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
	if(DamageEvent != null){
		DamageEvent(transform.position, damage);
	}

	GameObject explosionClone = Instantiate(explosion, transform.position, transform.rotation);
	Destroy(explosionClone, 5);
	Destroy(gameObject);
}
```

</details>

Далее, у каждого врага есть здоровье (Health на рисунке). Каждый паук на сцене получает событие «**DamageEvent**» с данными. Эти данные обрабатываются. Далее проверяет расстояние паука до взрыва и, если это расстояние меньше радиуса поражения — отнимается здоровье у врага. Если здоровье кончилось — паук умирает и удаляется со сцены

Создай новый скрипт по имени «**SpiderHealth**» и добавь его к префабу паука

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
	// удаляем паука и отписываемся от события,
	// когда у него кончилось здоровье
	if (health <= 0) {
		Rocket.DamageEvent -= TakeDamage;
		Destroy(gameObject);
	}
}
```

</details>

Запусти игру. Проверь, что паук умирает после четырех выстрелов.

### Задание №7: Искусственный интеллект (часть №2)

Скрипт искусственного интеллекта имеет ряд недостатков. Паук постоянно бежит к игроку и не атакует. Также, паук должен двигаться в сторону игрока только тогда, когда игрок находится в зоне его видимости. Общий алгоритм ты можешь увидеть на рисунке:

![](http://unity3d.unium.ru/lessons/lesson16/images/task2/fps12.jpg)

Открой скрипт «**SpiderAI**». Внесем в него изменения:

- Добавь публичную переменную `shouldMove` типа `bool`. Она будет хранить, должен ли двигаться паук. Исправь код так, чтобы он двигался только, когда `shouldMove` равна `true`
- Вычисли угол между пауком и игроком с помощью метода `Vector3.Angle`
- Вычисли расстояние до игрока с помощью метода `Vector3.Distance`
- Активируй переменную `shouldMove`, если игрок на расстоянии от 2 до 5 и находится спереди паука

<details><summary>SpiderAI</summary>

```csharp
Transform player;
// надо ли двигаться
public bool shouldMove = true;

void Start() {
	// сохраняем игрока
	player = GameObject.Find("FPSController").transform;
}

void Update() {
	// вектор, направленный от паука к игроку
	Vector3 targetDir = player.position - transform.position;
	// угол между пауком и игроком
	float angle = Vector3.Angle(targetDir, transform.forward);
	// расстояние до игрока
	float dist = Vector3.Distance(player.position, transform.position);
	// если игрок на расстоянии от 2 до 5 и спереди паука,
	// то идем к нему
	if (dist <= 5 && dist > 2 && angle <= 90) {
		shouldMove = true;
	} else {
		shouldMove = false;
	}

	if (shouldMove) {
		// получаем NavMeshAgent паука
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		// и приказываем ему двигаться к игроку
		agent.SetDestination(player.position);
	}
}
```

</details>

Запусти игру. Проверь, что пауки преследуют игрока, когда он находится на близком расстоянии и в зоне видимости.

### Задание №8: Система жизней игрока

Когда паук нападает на игрока – игроку не причиняется урон и он не умирает. Для рассылки сообщения об атаке мы снова воспользуемся пользовательскими событиями

Открой скрипт «**SpiderAI**». Внеси в него изменения:

- Добавь публичную переменную `shouldAttack` типа `bool`. Она будет хранить, должен ли паук атаковать`
- Активируй переменную `shouldAttack`, если игрок ближе двух и находится спереди паука
- Создай новое событие `AttackEvent`
- Когда паук должен атаковать, рассылай это событие раз в секунду и передавай в нем урон 20 единиц

<details><summary>SpiderAI</summary>

```csharp
Transform player;
float time = 0;

// надо ли двигаться
public bool shouldMove = true;
// надо ли атаковать
public bool shouldAttack = true;
// событие атаки
public static Action<int> AttackEvent;

void Start() {
	// сохраняем игрока
	player = GameObject.Find("FPSController").transform;
}

void Update() {
	// вектор, направленный от паука к игроку
	Vector3 targetDir = player.position - transform.position;
	// угол между пауком и игроком
	float angle = Vector3.Angle(targetDir, transform.forward);
	// расстояние до игрока
	float dist = Vector3.Distance(player.position, transform.position);
	// если игрок на расстоянии от 2 до 5 и спереди паука,
	// то идем к нему
	if (dist <= 5 && dist > 2 && angle <= 90) {
		shouldMove = true;
	} else {
		shouldMove = false;
	}

	if (shouldMove) {
		// получаем NavMeshAgent паука
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		// и приказываем ему двигаться к игроку
		agent.SetDestination(player.position);
	}

	// если игрок ближе двух и спереди паука,
	// то атакуем
	if (dist <= 2 && angle <= 90) {
		shouldAttack = true;
	} else {
		shouldAttack = false;
	}

	// раз в секунду отправляем событие атаки с уроном 20
	if (shouldAttack) {
		time += Time.deltaTime;
		if (time > 1) {
			time = 0;
			if(AttackEvent != null){
				AttackEvent(20);
			}
		}
	}
}
```

</details>

Создай скрипт по имени «**PlayerHealth**» и добавь его к игроку

В скрипте:

- Добавь публичную переменную `health` типа `int`, в которой будет храниться здоровье игрока (изначально 100)
- Слушай событие `AttackEvent`
- В обработчике события уменьшай здоровье на полученный урон
- Если здоровье упадет ниже нуля, то завершай игру с помощью метода `Application.Quit()`

<details><summary>PlayerHealth</summary>

```csharp
public int health = 100;

void Start() {
	SpiderAI.AttackEvent += TakeDamage;
}

void TakeDamage(int damage) {
	health -= damage;
	if (health <= 0) {
		SpiderAI.AttackEvent -= TakeDamage;
		Application.Quit();
	}
}
```

</details>

Запусти игру. Проверь, что у игрока отнимается здоровье (переменная health уменьшается). А если создать готовую игру, то происходит выход из игры, когда игрок умирает.

### Задание №9: Анимация

На панели «**Project**» создай папку **Animation**. В ней нажми ![img](http://unity3d.unium.ru/images/rmb.png) → «**Create**» → «**Animator Controller**». Введи имя аниматора «**Spider**». Открой редактор аниматора. Добавь параметры «**run**», «**attack**» типа «**Bool**». Настрой граф состояний следующим образом:

![img](http://unity3d.unium.ru/lessons/lesson16/images/task2/fps13.jpg)

Создай новый скрипт по имени «**SpiderAnim**» и присвой его к префабу паука

<details><summary>PlayerHealth</summary>

```csharp
void Update () {
	Animator animator = GetComponent<Animator>();
	SpiderAI ai = GetComponent<SpiderAI>();
	// задаем параметр аниматора run в зависимости от того,
	// что хранится в shouldMove компонента SpiderAI
	animator.SetBool("run", ai.shouldMove);
	// задаем параметр аниматора attack в зависимости от того,
	// что хранится в shouldAttack компонента SpiderAI
	animator.SetBool("attack", ai.shouldAttack);
}
```

</details>

Выдели префаб паука. В компоненте «**Animator**» в параметре «**Controller**» выбери «**Spider**». Запусти игру. Проверь, что анимация атаки, перемещения работают.

### Задание №10: Звук атаки

Добавим звук атаки паука. Настрой `Audio Source` так, как было описано в [занятии 3](http://unity3d.unium.ru/lessons/lesson3/index.html#addsound). При этом отключи опцию `Play on Awake` (проиграть при старте), так как мы будем запускать проигрывание клипа из скрипта

Напиши скрипт `AttackSound` в котором раз в секунду [включай звук](https://github.com/UniumGames/Lessons/tree/master/12#%D0%94%D0%BE%D0%B1%D0%B0%D0%B2%D0%BB%D0%B5%D0%BD%D0%B8%D0%B5-%D0%B7%D0%B2%D1%83%D0%BA%D0%B0-%D1%81-%D0%BF%D0%BE%D0%BC%D0%BE%D1%89%D1%8C%D1%8E-%D1%81%D0%BA%D1%80%D0%B8%D0%BF%D1%82%D0%B0), если паук атакует

<details><summary>AttackSound</summary>

```csharp
float time = 0;
void Update () {
	SpiderAI ai = GetComponent<SpiderAI>();
	// если паук атакует,
	// раз в секунду проигрываем звук атаки
	if (ai.shouldAttack) {
		time += Time.deltaTime;
		if (time > 1) {
			time = 0;
			// получаем компонент AudioSource
			AudioSource audio = GetComponent<AudioSource>();
			// и проигрываем добавленный в него звук
			audio.Play();
		}
	}
}
```

</details>

Теперь, когда паук атакует, то воспроизводится звук атаки.

### Задание №11: Улучшения

- добавь отображение количества жизней у игрока в правом нижнем углу экрана;
- добавь ограниченное количество ракет;
- добавь на экране количество доступных для выстрела ракет;
- создай разных пауков: одним требуется один выстрел, другим пять;
- добавь зоны, в которых генерируются пауки, когда игрок к ним приближается;
- добавь заскриптованных пауков, которые нападают из неожиданных мест;
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

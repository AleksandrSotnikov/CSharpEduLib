# Гайд по созданию новой лекции в CSharpEduLib (на основе Lecture_1_1)

Главная цель: быстро и единообразно создать полноценную лекцию в структуре проекта CSharpEduLib — с теорией, примерами, заданиями и тестами — по шаблону Лекции 1.1.

Результат: в каталоге `src/CSharpEduLib.Content/Lectures/<Module>/<Lecture_X_Y_Title>/` появятся все необходимые файлы и папки, полностью готовые к использованию библиотекой и тестовой инфраструктурой.

## 1) Где создавать новую лекцию

Базовый путь к лекциям:
- `CSharpEduLib/src/CSharpEduLib.Content/Lectures`

Шаблон модуля и лекции:
- `Module_<номер>_<краткое-название-модуля>`
- `Lecture_<номер_модуля>_<номер_лекции>_<краткое-название>`

Пример из модуля 1:
- `src/CSharpEduLib.Content/Lectures/Module_1_Basics/Lecture_1_1/`

Рекомендуемая нотация имен:
- `Module_<номер>_<англ-название-модуля>` (пример: `Module_1_Basics`)
- `Lecture_<номер_модуля>_<номер_лекции>_<англ-название>` (пример: `Lecture_1_2_Variables`)

## 2) Обязательная структура папки лекции

Внутри `Lecture_X_Y_Title` создаются следующие файлы и папки:

- `Theory.md` — теоретический материал лекции
- `CodeExamples.md` — поясненные примеры кода
- `Examples.json` — структурированная версия примеров
- `Exercises.json` — индекс упражнений
- `Exercises.more.json` — расширенные метаданные упражнений (опционально)
- `QA.md` — вопросы и ответы
- `Exercises/` — каталог с упражнениями:
  - `Exercise_<N>_<ShortName>/`
    - `StudentSolution.cs` — точка, куда студент пишет решение, с TODO и XML-комментариями
    - `README.md` (опционально)

Минимум для запуска — `Theory.md`, `CodeExamples.md`, `Examples.json`, `Exercises/`, `Exercises.json`.

## 3) Содержимое ключевых файлов

### 3.1) Theory.md
- Введение, цели, основные понятия
- Разделы по теме, кодовые блоки, ожидаемый вывод
- Отсылки к примерам и упражнениям

### 3.2) CodeExamples.md
- Человеко-читаемые примеры с кодом и пояснениями
- Нумерация/идентификаторы `ex01`, `ex02`, …

### 3.3) Examples.json
Структура элемента:
```json
{
  "id": "ex01",
  "title": "Краткое название",
  "code": "строка с кодом"
}
```
- Следите за соответствием примерам из `CodeExamples.md`

### 3.4) Exercises*.json
- `Exercises.json` — краткий список (id, title)
- `Exercises.more.json` — расширенные поля (теги, уровень, подсказки)

### 3.5) QA.md
- Частые вопросы и разбор типичных ошибок

### 3.6) Exercises/<Exercise_N>/StudentSolution.cs
- Namespace должен соответствовать пути:
  `CSharpEduLib.Content.Lectures.Module_<M>_<Name>.Lecture_<M>_<N>.Exercises.Exercise_<K>_<ShortName>`
- XML-комментарии: формулировка задачи, ожидаемый результат, подсказка
- Публичный статический метод `Run(...)` c `NotImplementedException` до решения

## 4) Нейминг и пространства имен
- Пути и namespace всегда должны совпадать по шаблону `Lecture_1_1`

## 5) Связь с тестами
- Тесты ищут `StudentSolution.Run(...)` по ожидаемому namespace
- До решения студентом метод бросает `NotImplementedException`

## 6) Чек-лист
- [ ] Создана папка лекции
- [ ] Добавлены: `Theory.md`, `CodeExamples.md`, `Examples.json`, `Exercises.json`, `QA.md`, `Exercises/`
- [ ] Согласованы ID примеров между MD и JSON
- [ ] Во всех `StudentSolution.cs` корректные namespace, XML, TODO, `Run(...)`

## 7) Лучшие практики
- Делайте примеры короткими и понятными
- В `CodeExamples.md` указывайте ожидаемый вывод
- В `QA.md` собирайте типичные вопросы
- В `StudentSolution.cs` оставляйте ровно столько подсказок, чтобы направить, но не решить за студента

## 8) Быстрый шаблон
```
src/CSharpEduLib.Content/Lectures/Module_<M>_<Name>/Lecture_<M>_<N>_<Title>/
├── Theory.md
├── CodeExamples.md
├── Examples.json
├── Exercises.json
├── Exercises.more.json (опц.)
├── QA.md
└── Exercises/
    ├── Exercise_1_<ShortName>/StudentSolution.cs
    └── ... Exercise_10_<ShortName>/StudentSolution.cs
```

## 9) Проверка
- Проверить соответствие неймспейсов
- Прогнать тесты (ожидаемо падают до решений студентов)
- При специфических зависимостях — добавить инструкции в `Theory.md`

# SolfOrd Testcase (Тестовое задание)
# Введение
_Репозиторий содержит в себе:_
- /clientHtmlApp: Клиентское приложение на HTML, Bootstrap5, JS Native.
- /Database: Библиотека классов, которая работает с базой данных.
- /Domain: Доменная область для работы с базой данных.
- /API: (Asp .NET Core 6 WebApi) Интерфейс для работы с базой данных в стиле REST
_Используемые пакеты и библиотеки:_
- Microsoft.EntityFrameworkCore
- Swashbuckle.AspNetCore.SwaggerGen
- Swashbuckle.AspNetCore.SwaggerUI
- Automapper
# Пример работы
Главная страница представляет из себя список с заказами <br/>
![alt text](https://sun9-45.userapi.com/impg/TD-mmNufxmWX3muCHtCKmp_z6hQV_MiZiCrfWg/FRzrYfIk6C8.jpg?size=1918x982&quality=96&sign=9c0d55b05b789edd7bc8c6dc2a93855d&type=album)
Мы можем добавить заказ, нажав на кнопку, мы перейдем на страницу с созданием заказа <br/>
![alt text](https://sun9-25.userapi.com/impg/Mft9kAXbrVRsS9WS5PZkhwWQWpCg8XmmP_YRxw/FDrAcaSy1h8.jpg?size=1920x980&quality=96&sign=f961bd759ade1340e5ce7bc5be95499c&type=album)
Также мы не можем создать заказ с таким же номером, так как это поле у нас уникально <br/>
![alt text](https://sun9-10.userapi.com/impg/403GEjf1VHzIyLIGZz2WUcqzMQYpQNmvxeaL8g/0nGihnRnoP4.jpg?size=1918x980&quality=96&sign=e6d9ea5a116204debba72243b87d9a56&type=album)
То же самое, если попробовать создать заказ с совпадающим номером и именем <br/>
![alt text](https://sun9-14.userapi.com/impg/Aa0X3uHlbhxV1l5tfhlPDUKWt7dKWyUf_78xjQ/b0M4Fw3aZjY.jpg?size=1918x976&quality=96&sign=fa72f07e76733f9313dc0ec6e5809fa0&type=album)
Вернемся к главной странице, на ней реализована фильтрация со стороны сервера (пример с датой)<br/>
_До:_<br/>
![alt text](https://sun9-7.userapi.com/impg/3fIf3dP43AOprGBgtXbjLALuYKpMlpLrgee0SA/cyjxCuPfU2U.jpg?size=1924x982&quality=96&sign=0d501a63b9db50eee35532ce921746ad&type=album)
_После:_<br/>
![alt text](https://sun9-79.userapi.com/impg/HMd0vReQZQloYxq1talZMiOnpPWMz-lb9la_FA/HsGE0IC01F8.jpg?size=1922x978&quality=96&sign=f99624bcbdefd9b6975faffd95ae1c1b&type=album)
Так у нас выглядит информация о заказе <br/>
![alt text](https://sun9-82.userapi.com/impg/EylLdua3ZfbWU9AUNo0hxFwRAhDb3uuUoWxN1g/EaaZA9neGiA.jpg?size=1920x978&quality=96&sign=92ea71595756afc259201275dab204d9&type=album)
Страница с редактированием выглядит идентично странице создания, отличие в том, что все поля заполняются автоматически

используется asp net core 8.0.7 mvc
приложение разделено на dal и bll, bll - чисто заглушка.
основная страница генерируется/заполняется статически, crud операции реализованы как api controller, запросы посылаются клиентом через js-fetch.
по функционалу - вроде бы все по тз.
sql скрипт для создания таблиц и для хранимой процедуры находится в dataAccess/sql.
module SeedStations

open MongoDB.Bson

let elacticStations : ElasticModels.Station array = 
    [| 
       { 
           id = "5c2e1d0c867a6335386700d7"
           name = {
               ua = "Академмістечко"
               en = "Akademmistechko"
           }
           branch = "Red"
           location = 
           {
               lat = 50.464861
               lon = 30.355083
           }
       }
       { 
           id = "5c2e1d0c867a6335386700d8"
           name = {
               ua = "Житомирська"
               en = "Zhytomyrska"
           }
           branch = "Red"
           location = 
           {
               lat = 50.456175
               lon = 30.365628
           }
       }
       { 
           id = "5c2e1d0c867a6335386700d9"
           name = {
               ua = "Святошин"
               en = "Svyatoshyn"
           }
           branch = "Red"
           location = 
           {
               lat = 50.457903
               lon = 30.390614
           }
       }
       { 
           id = "5c2e1d0c867a6335386700da"
           name = {
               ua = "Нивки"
               en = "Nyvky"
           }
           branch = "Red"
           location = 
           {
               lat = 50.458653
               lon = 30.404042
           }
       }
       { 
           id = "5c2e1d0c867a6335386700db"
           name = {
               ua = "Берестейська"
               en = "Beresteyska"
           }
           branch = "Red"
           location = 
           {
               lat = 50.458333
               lon = 30.420833
           }
       }
       { 
           id = "5c2e1d0c867a6335386700dc"
           name = {
               ua = "Шулявська"
               en = "Shulyavska"
           }
           branch = "Red"
           location = 
           {
               lat = 50.455
               lon = 30.445278
           }
       }
       { 
           id = "5c2e1d0c867a6335386700dd"
           name = {
               ua = "Політехнічний Інститут"
               en = "Polytechnical Institute"
           }
           branch = "Red"
           location = 
           {
               lat = 50.450833
               lon = 30.466111
           }
       }
       { 
           id = "5c2e1d0c867a6335386700de"
           name = {
               ua = "Вокзальна"
               en = "Vokzalna"
           }
           branch = "Red"
           location = 
           {
               lat = 50.441667
               lon = 30.4875
           }
       }
       { 
           id = "5c2e1d0c867a6335386700df"
           name = {
               ua = "Університет"
               en = "Universytet"
           }
           branch = "Red"
           location = 
           {
               lat = 50.444167
               lon = 30.505833
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e0"
           name = {
               ua = "Театральна"
               en = "Teatralna"
           }
           branch = "Red"
           location = 
           {
               lat = 50.444722
               lon = 30.518056
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e1"
           name = {
               ua = "Хрещатик"
               en = "Khreshatyk"
           }
           branch = "Red"
           location = 
           {
               lat = 50.357425
               lon = 30.439872
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e2"
           name = {
               ua = "Арсенальна"
               en = "Arsenalna"
           }
           branch = "Red"
           location = 
           {
                lat = 50.443889
                lon = 30.545556
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e3"
           name = {
               ua = "Дніпро"
               en = "Dnipro"
           }
           branch = "Red"
           location = 
           {
               lat = 50.441111
               lon = 30.558611
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e4"
           name = {
               ua = "Гідропарк"
               en = "Hydropark"
           }
           branch = "Red"
           location = 
           {
               lat = 50.445556
               lon = 30.576944
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e5"
           name = {
               ua = "Лівобережна"
               en = "Livoberezhna"
           }
           branch = "Red"
           location = 
           {
               lat = 50.451389
               lon = 30.598889
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e6"
           name = {
               ua = "Дарниця"
               en = "Darnytsya"
           }
           branch = "Red"
           location = 
           {
               lat = 50.455556
               lon = 30.613056
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e7"
           name = {
               ua = "Чернігівська"
               en = "Chernihivska"
           }
           branch = "Red"
           location = 
           {
               lat = 50.459722
               lon = 30.630833
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e8"
           name = {
               ua = "Лісова"
               en = "Lisova"
           }
           branch = "Red"
           location = 
           {
               lat = 50.464639
               lon = 30.645556
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e9"
           name = {
               ua = "Героїв Дніпра"
               en = "Heroiv Dnipra"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.5225
               lon = 30.498611
           }
       }
       { 
           id = "5c2e1d0c867a6335386700ea"
           name = {
               ua = "Мінська"
               en = "Minska"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.512222
               lon = 30.498333
           }
       }
       { 
           id = "5c2e1d0c867a6335386700eb"
           name = {
               ua = "Оболонь"
               en = "Obolon"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.501111
               lon = 30.498056
           }
       }
       { 
           id = "5c2e1d0c867a6335386700ec"
           name = {
               ua = "Почайна"
               en = "Pochayna"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.486667
               lon = 30.497778
           }
       }
       { 
           id = "5c2e1d0c867a6335386700ed"
           name = {
               ua = "Тараса Шевченка"
               en = "Tarasa Shevchenka"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.473056
               lon = 30.505
           }
       }
       { 
           id = "5c2e1d0c867a6335386700ee"
           name = {
               ua = "Контрактова Площа"
               en = "Kontraktova square"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.465
               lon = 30.516667
           }
       }
       { 
           id = "5c2e1d0c867a6335386700ef"
           name = {
               ua = "Поштова Площа"
               en = "Poshtova square"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.459167
               lon = 30.525556
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f0"
           name = {
               ua = "Майдан Незалежності"
               en = "Maydan Nezalezhnosti"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.45
               lon = 30.524167
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f1"
           name = {
               ua = "Площа Льва Толстого"
               en = "Lva Tolstoho square"
           }
           branch = "Blue"
           location = 
           {
                lat = 50.439444
                lon = 30.516944
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f2"
           name = {
               ua = "Олімпійська"
               en = "Olimpiyska"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.431944
               lon = 30.516389
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f3"
           name = {
               ua = "Палац Україна"
               en = "Palats Ukraina"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.420833
               lon = 30.520833
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f4"
           name = {
               ua = "Либідська"
               en = "Lybidska"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.420833
               lon = 30.520833
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f5"
           name = {
               ua = "Деміївська"
               en = "Demiyvska"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.404792
               lon = 30.516833
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f6"
           name = {
               ua = "Голосіївська"
               en = "Holosiivska"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.3975
               lon = 30.508333
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f7"
           name = {
               ua = "Васильківська"
               en = "Vasylkivska"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.393333
               lon = 30.488056
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f8"
           name = {
               ua = "Виставковий Центр"
               en = "Vystavkovyi Tsentr"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.382581
               lon = 30.477536
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f9"
           name = {
               ua = "Іподром"
               en = "Ipodrom"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.376556
               lon = 30.469117
           }
       }
       { 
           id = "5c2e1d0c867a6335386700fa"
           name = {
               ua = "Теремки"
               en = "Teremky"
           }
           branch = "Blue"
           location = 
           {
               lat = 50.367044
               lon = 30.454203
           }
       }
       { 
           id = "5c2e1d0c867a6335386700fb"
           name = {
               ua = "Сирець"
               en = "Syrets"
           }
           branch = "Green"
           location = 
           {
               lat = 50.476111
               lon = 30.430556
           }
       }
       { 
           id = "5c2e1d0c867a6335386700fc"
           name = {
               ua = "Дорогожичі"
               en = "Dorohozhychi"
           }
           branch = "Green"
           location = 
           {
               lat = 50.473611
               lon = 30.449444
           }
       }
       { 
           id = "5c2e1d0c867a6335386700fd"
           name = {
               ua = "Лук'янівська"
               en = "Lukyanivska"
           }
           branch = "Green"
           location = 
           {
               lat = 50.462222
               lon = 30.481667
           }
       }
       { 
           id = "5c2e1d0c867a6335386700fe"
           name = {
               ua = "Золоті Ворота"
               en = "Zoloti vorota"
           }
           branch = "Green"
           location = 
           {
               lat = 50.448333
               lon = 30.513333
           }
       }
       { 
           id = "5c2e1d0c867a6335386700ff"
           name = {
               ua = "Палац Спорту"
               en = "Palats Sportu"
           }
           branch = "Green"
           location = 
           {
               lat = 50.438056
               lon = 30.520833
           }
       }   
       { 
           id = "5c2e1d0c867a633538670100"
           name = {
               ua = "Кловська"
               en = "Klovska"
           }
           branch = "Green"
           location = 
           {
               lat = 50.436944
               lon = 30.531667
           }
       }
       { 
           id = "5c2e1d0c867a633538670101"
           name = {
               ua = "Печерська"
               en = "Pecherska"
           }
           branch = "Green"
           location = 
           {
               lat = 50.4275
               lon = 30.538889
           }
       }
       { 
           id = "5c2e1d0c867a633538670102"
           name = {
               ua = "Дружби Народів"
               en = "Druzhby narodiv"
           }
           branch = "Green"
           location = 
           {
               lat = 50.418056
               lon = 30.545
           }
       }
       { 
           id = "5c2e1d0c867a633538670103"
           name = {
               ua = "Видубичі"
               en = "Vydubychi"
           }
           branch = "Green"
           location = 
           {
               lat = 50.402222
               lon = 30.560833
           }
       }
       { 
           id = "5c2e1d0c867a633538670104"
           name = {
               ua = "Славутич"
               en = "Slavutych"
           }
           branch = "Green"
           location = 
           {
               lat = 50.394167
               lon = 30.604167
           }
       }
       { 
           id = "5c2e1d0c867a633538670105"
           name = {
               ua = "Осокорки"
               en = "Osokorky"
           }
           branch = "Green"
           location = 
           {
               lat = 50.395278
               lon = 30.616111
           }
       }
       { 
           id = "5c2e1d0c867a633538670106"
           name = {
               ua = "Позняки"
               en = "Poznyaky"
           }
           branch = "Green"
           location = 
           {
               lat = 50.398056
               lon = 30.633333
           }
       }
       { 
           id = "5c2e1d0c867a633538670107"
           name = {
               ua = "Харківська"
               en = "Kharkivska"
           }
           branch = "Green"
           location = 
           {
               lat = 50.400833
               lon = 30.652222
           }
       }
       { 
           id = "5c2e1d0c867a633538670108"
           name = {
               ua = "Вирлиця"
               en = "Vyrlytsya"
           }
           branch = "Green"
           location = 
           {
               lat = 50.403333
               lon = 30.666111
           }
       }
       { 
           id = "5c2e1d0c867a633538670109"
           name = {
               ua = "Червоний Хутір"
               en = "Chervoniy Khutir"
           }
           branch = "Green"
           location = 
           {
               lat = 50.408889
               lon = 30.694444
           }
       }
    |]

let seed = 
    ElasticAdapter.seedStations elacticStations    
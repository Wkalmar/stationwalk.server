﻿module SeedStations

open MongoDB.Bson

let stations : DbModels.Station array =
    [|
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700d7"))
           name = {
               ua = "Академмістечко"
               en = "Akademmistechko"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.464861)
               lon = decimal(30.355083)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700d8"))
           name = {
               ua = "Житомирська"
               en = "Zhytomyrska"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.456175)
               lon = decimal(30.365628)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700d9"))
           name = {
               ua = "Святошин"
               en = "Svyatoshyn"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.457903)
               lon = decimal(30.390614)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700da"))
           name = {
               ua = "Нивки"
               en = "Nyvky"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.458653)
               lon = decimal(30.404042)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700db"))
           name = {
               ua = "Берестейська"
               en = "Beresteyska"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.458333)
               lon = decimal(30.420833)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700dc"))
           name = {
               ua = "Шулявська"
               en = "Shulyavska"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.455)
               lon = decimal(30.445278)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700dd"))
           name = {
               ua = "Політехнічний Інститут"
               en = "Polytechnical Institute"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.450833)
               lon = decimal(30.466111)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700de"))
           name = {
               ua = "Вокзальна"
               en = "Vokzalna"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.441667)
               lon = decimal(30.4875)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700df"))
           name = {
               ua = "Університет"
               en = "Universytet"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.444167)
               lon = decimal(30.505833)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e0"))
           name = {
               ua = "Театральна"
               en = "Teatralna"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.444722)
               lon = decimal(30.518056)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e1"))
           name = {
               ua = "Хрещатик"
               en = "Khreshatyk"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.4473701)
               lon = decimal(30.5196683)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e2"))
           name = {
               ua = "Арсенальна"
               en = "Arsenalna"
           }
           branch = "Red"
           location =
           {
                lat = decimal(50.443889)
                lon = decimal(30.545556)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e3"))
           name = {
               ua = "Дніпро"
               en = "Dnipro"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.441111)
               lon = decimal(30.558611)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e4"))
           name = {
               ua = "Гідропарк"
               en = "Hydropark"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.445556)
               lon = decimal(30.576944)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e5"))
           name = {
               ua = "Лівобережна"
               en = "Livoberezhna"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.451389)
               lon = decimal(30.598889)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e6"))
           name = {
               ua = "Дарниця"
               en = "Darnytsya"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.455556)
               lon = decimal(30.613056)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e7"))
           name = {
               ua = "Чернігівська"
               en = "Chernihivska"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.459722)
               lon = decimal(30.630833)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e8"))
           name = {
               ua = "Лісова"
               en = "Lisova"
           }
           branch = "Red"
           location =
           {
               lat = decimal(50.464639)
               lon = decimal(30.645556)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e9"))
           name = {
               ua = "Героїв Дніпра"
               en = "Heroiv Dnipra"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.5225)
               lon = decimal(30.498611)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700ea"))
           name = {
               ua = "Мінська"
               en = "Minska"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.512222)
               lon = decimal(30.498333)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700eb"))
           name = {
               ua = "Оболонь"
               en = "Obolon"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.501111)
               lon = decimal(30.498056)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700ec"))
           name = {
               ua = "Почайна"
               en = "Pochayna"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.486667)
               lon = decimal(30.497778)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700ed"))
           name = {
               ua = "Тараса Шевченка"
               en = "Tarasa Shevchenka"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.473056)
               lon = decimal(30.505)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700ee"))
           name = {
               ua = "Контрактова Площа"
               en = "Kontraktova square"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.465)
               lon = decimal(30.516667)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700ef"))
           name = {
               ua = "Поштова Площа"
               en = "Poshtova square"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.459167)
               lon = decimal(30.525556)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f0"))
           name = {
               ua = "Майдан Незалежності"
               en = "Maydan Nezalezhnosti"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.45)
               lon = decimal(30.524167)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f1"))
           name = {
               ua = "Площа Льва Толстого"
               en = "Lva Tolstoho square"
           }
           branch = "Blue"
           location =
           {
                lat = decimal(50.439444)
                lon = decimal(30.516944)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f2"))
           name = {
               ua = "Олімпійська"
               en = "Olimpiyska"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.431944)
               lon = decimal(30.516389)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f3"))
           name = {
               ua = "Палац Україна"
               en = "Palats Ukraina"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.420833)
               lon = decimal(30.520833)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f4"))
           name = {
               ua = "Либідська"
               en = "Lybidska"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.420833)
               lon = decimal(30.520833)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f5"))
           name = {
               ua = "Деміївська"
               en = "Demiyvska"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.404792)
               lon = decimal(30.516833)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f6"))
           name = {
               ua = "Голосіївська"
               en = "Holosiivska"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.3975)
               lon = decimal(30.508333)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f7"))
           name = {
               ua = "Васильківська"
               en = "Vasylkivska"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.393333)
               lon = decimal(30.488056)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f8"))
           name = {
               ua = "Виставковий Центр"
               en = "Vystavkovyi Tsentr"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.382581)
               lon = decimal(30.477536)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f9"))
           name = {
               ua = "Іподром"
               en = "Ipodrom"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.376556)
               lon = decimal(30.469117)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700fa"))
           name = {
               ua = "Теремки"
               en = "Teremky"
           }
           branch = "Blue"
           location =
           {
               lat = decimal(50.367044)
               lon = decimal(30.454203)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700fb"))
           name = {
               ua = "Сирець"
               en = "Syrets"
           }
           branch = "Green"
           location =
           {
               lat = decimal(50.476111)
               lon = decimal(30.430556)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700fc"))
           name = {
               ua = "Дорогожичі"
               en = "Dorohozhychi"
           }
           branch = "Green"
           location =
           {
               lat = decimal(50.473611)
               lon = decimal(30.449444)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700fd"))
           name = {
               ua = "Лук'янівська"
               en = "Lukyanivska"
           }
           branch = "Green"
           location =
           {
               lat = decimal(50.462222)
               lon = decimal(30.481667)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700fe"))
           name = {
               ua = "Золоті Ворота"
               en = "Zoloti vorota"
           }
           branch = "Green"
           location =
           {
               lat = decimal(50.448333)
               lon = decimal(30.513333)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700ff"))
           name = {
               ua = "Палац Спорту"
               en = "Palats Sportu"
           }
           branch = "Green"
           location =
           {
               lat = decimal(50.438056)
               lon = decimal(30.520833)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a633538670100"))
           name = {
               ua = "Кловська"
               en = "Klovska"
           }
           branch = "Green"
           location =
           {
               lat = decimal(50.436944)
               lon = decimal(30.531667)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a633538670101"))
           name = {
               ua = "Печерська"
               en = "Pecherska"
           }
           branch = "Green"
           location =
           {
               lat = decimal(50.4275)
               lon = decimal(30.538889)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a633538670102"))
           name = {
               ua = "Дружби Народів"
               en = "Druzhby narodiv"
           }
           branch = "Green"
           location =
           {
               lat = decimal(50.418056)
               lon = decimal(30.545)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a633538670103"))
           name = {
               ua = "Видубичі"
               en = "Vydubychi"
           }
           branch = "Green"
           location =
           {
               lat = decimal(50.402222)
               lon = decimal(30.560833)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a633538670104"))
           name = {
               ua = "Славутич"
               en = "Slavutych"
           }
           branch = "Green"
           location =
           {
               lat = decimal(50.394167)
               lon = decimal(30.604167)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a633538670105"))
           name = {
               ua = "Осокорки"
               en = "Osokorky"
           }
           branch = "Green"
           location =
           {
               lat = decimal(50.395278)
               lon = decimal(30.616111)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a633538670106"))
           name = {
               ua = "Позняки"
               en = "Poznyaky"
           }
           branch = "Green"
           location =
           {
               lat = decimal(50.398056)
               lon = decimal(30.633333)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a633538670107"))
           name = {
               ua = "Харківська"
               en = "Kharkivska"
           }
           branch = "Green"
           location =
           {
               lat = decimal(50.400833)
               lon = decimal(30.652222)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a633538670108"))
           name = {
               ua = "Вирлиця"
               en = "Vyrlytsya"
           }
           branch = "Green"
           location =
           {
               lat = decimal(50.403333)
               lon = decimal(30.666111)
           }
       }
       {
           id = BsonObjectId(ObjectId("5c2e1d0c867a633538670109"))
           name = {
               ua = "Червоний Хутір"
               en = "Chervoniy Khutir"
           }
           branch = "Green"
           location =
           {
               lat = decimal(50.408889)
               lon = decimal(30.694444)
           }
       }
    |]

let seed =
    DbAdapter.seedStations stations
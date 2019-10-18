module SeedStations

open MongoDB.Bson

let stations : MongoModels.Station array = 
    [| 
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700d7"))
           branch = "Red"
           location = 
           {
               lattitude = 50.464861
               longitude = 30.355083
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700d8"))
           branch = "Red"
           location = 
           {
               lattitude = 50.456175
               longitude = 30.365628
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700d9"))
           branch = "Red"
           location = 
           {
               lattitude = 50.457903
               longitude = 30.390614
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700da"))
           branch = "Red"
           location = 
           {
               lattitude = 50.458653
               longitude = 30.404042
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700db"))
           branch = "Red"
           location = 
           {
               lattitude = 50.458333
               longitude = 30.420833
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700dc"))
           branch = "Red"
           location = 
           {
               lattitude = 50.455
               longitude = 30.445278
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700dd"))
           branch = "Red"
           location = 
           {
               lattitude = 50.450833
               longitude = 30.466111
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700de"))
           branch = "Red"
           location = 
           {
               lattitude = 50.441667
               longitude = 30.4875
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700df"))
           branch = "Red"
           location = 
           {
               lattitude = 50.444167
               longitude = 30.505833
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e0"))
           branch = "Red"
           location = 
           {
               lattitude = 50.444722
               longitude = 30.518056
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e1"))
           branch = "Red"
           location = 
           {
               lattitude = 50.357425
               longitude = 30.439872
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e2"))
           branch = "Red"
           location = 
           {
               lattitude = 50.443889
               longitude = 30.545556
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e3"))
           branch = "Red"
           location = 
           {
               lattitude = 50.441111
               longitude = 30.558611
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e4"))
           branch = "Red"
           location = 
           {
               lattitude = 50.445556
               longitude = 30.576944
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e5"))
           branch = "Red"
           location = 
           {
               lattitude = 50.451389
               longitude = 30.598889
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e6"))
           branch = "Red"
           location = 
           {
               lattitude = 50.455556
               longitude = 30.613056
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e7"))
           branch = "Red"
           location = 
           {
               lattitude = 50.459722
               longitude = 30.630833
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e8"))
           branch = "Red"
           location = 
           {
               lattitude = 50.464639
               longitude = 30.645556
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700e9"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.5225
               longitude = 30.498611
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700ea"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.512222
               longitude = 30.498333
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700eb"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.501111
               longitude = 30.498056
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700ec"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.486667
               longitude = 30.497778
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700ed"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.473056
               longitude = 30.505
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700ee"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.465
               longitude = 30.516667
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700ef"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.459167
               longitude = 30.525556
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f0"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.45
               longitude = 30.524167
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f1"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.439444
               longitude = 30.516944
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f2"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.431944
               longitude = 30.516389
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f3"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.420833
               longitude = 30.520833
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f4"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.420833
               longitude = 30.520833
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f5"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.404792
               longitude = 30.516833
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f6"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.3975
               longitude = 30.508333
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f7"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.393333
               longitude = 30.488056
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f8"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.382581
               longitude = 30.477536
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700f9"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.376556
               longitude = 30.469117
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700fa"))
           branch = "Blue"
           location = 
           {
               lattitude = 50.367044
               longitude = 30.454203
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700fb"))
           branch = "Green"
           location = 
           {
               lattitude = 50.476111
               longitude = 30.430556
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700fc"))
           branch = "Green"
           location = 
           {
               lattitude = 50.473611
               longitude = 30.449444
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700fd"))
           branch = "Green"
           location = 
           {
               lattitude = 50.462222
               longitude = 30.481667
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700fe"))
           branch = "Green"
           location = 
           {
               lattitude = 50.448333
               longitude = 30.513333
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a6335386700ff"))
           branch = "Green"
           location = 
           {
               lattitude = 50.438056
               longitude = 30.520833
           }
       }   
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a633538670100"))
           branch = "Green"
           location = 
           {
               lattitude = 50.436944
               longitude = 30.531667
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a633538670101"))
           branch = "Green"
           location = 
           {
               lattitude = 50.4275
               longitude = 30.538889
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a633538670102"))
           branch = "Green"
           location = 
           {
               lattitude = 50.418056
               longitude = 30.545
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a633538670103"))
           branch = "Green"
           location = 
           {
               lattitude = 50.402222
               longitude = 30.560833
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a633538670104"))
           branch = "Green"
           location = 
           {
               lattitude = 50.394167
               longitude = 30.604167
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a633538670105"))
           branch = "Green"
           location = 
           {
               lattitude = 50.395278
               longitude = 30.616111
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a633538670106"))
           branch = "Green"
           location = 
           {
               lattitude = 50.398056
               longitude = 30.633333
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a633538670107"))
           branch = "Green"
           location = 
           {
               lattitude = 50.400833
               longitude = 30.652222
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a633538670108"))
           branch = "Green"
           location = 
           {
               lattitude = 50.403333
               longitude = 30.666111
           }
       }
       { 
           _id = BsonObjectId(ObjectId("5c2e1d0c867a633538670109"))
           branch = "Green"
           location = 
           {
               lattitude = 50.408889
               longitude = 30.694444
           }
       }
    |]

let elacticStations : ElasticModels.Station array = 
    [| 
       { 
           id = "5c2e1d0c867a6335386700d7"
           name = {
               ua = "Академмістечко"
               en = "Akademmistechko"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700d8"
           name = {
               ua = "Житомирська"
               en = "Zhytomyrska"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700d9"
           name = {
               ua = "Святошин"
               en = "Svyatoshyn"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700da"
           name = {
               ua = "Нивки"
               en = "Nyvky"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700db"
           name = {
               ua = "Берестейська"
               en = "Beresteyska"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700dc"
           name = {
               ua = "Шулявська"
               en = "Shulyavska"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700dd"
           name = {
               ua = "Політехнічний Інститут"
               en = "Polytechnical Institute"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700de"
           name = {
               ua = "Вокзальна"
               en = "Vokzalna"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700df"
           name = {
               ua = "Університет"
               en = "Universytet"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e0"
           name = {
               ua = "Театральна"
               en = "Teatralna"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e1"
           name = {
               ua = "Хрещатик"
               en = "Khreshatyk"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e2"
           name = {
               ua = "Арсенальна"
               en = "Arsenalna"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e3"
           name = {
               ua = "Дніпро"
               en = "Dnipro"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e4"
           name = {
               ua = "Гідропарк"
               en = "Hydropark"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e5"
           name = {
               ua = "Лівобережна"
               en = "Livoberezhna"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e6"
           name = {
               ua = "Дарниця"
               en = "Darnytsya"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e7"
           name = {
               ua = "Чернігівська"
               en = "Chernihivska"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e8"
           name = {
               ua = "Лісова"
               en = "Lisova"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700e9"
           name = {
               ua = "Героїв Дніпра"
               en = "Heroiv Dnipra"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700ea"
           name = {
               ua = "Мінська"
               en = "Minska"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700eb"
           name = {
               ua = "Оболонь"
               en = "Obolon"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700ec"
           name = {
               ua = "Почайна"
               en = "Pochayna"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700ed"
           name = {
               ua = "Тараса Шевченка"
               en = "Tarasa Shevchenka"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700ee"
           name = {
               ua = "Контрактова Площа"
               en = "Kontraktova square"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700ef"
           name = {
               ua = "Поштова Площа"
               en = "Poshtova square"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f0"
           name = {
               ua = "Майдан Незалежності"
               en = "Maydan Nezalezhnosti"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f1"
           name = {
               ua = "Площа Льва Толстого"
               en = "Lva Tolstoho square"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f2"
           name = {
               ua = "Олімпійська"
               en = "Olimpiyska"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f3"
           name = {
               ua = "Палац Україна"
               en = "Palats Ukraina"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f4"
           name = {
               ua = "Либідська"
               en = "Lybidska"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f5"
           name = {
               ua = "Деміївська"
               en = "Demiyvska"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f6"
           name = {
               ua = "Голосіївська"
               en = "Holosiivska"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f7"
           name = {
               ua = "Васильківська"
               en = "Vasylkivska"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f8"
           name = {
               ua = "Виставковий Центр"
               en = "Vystavkovyi Tsentr"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700f9"
           name = {
               ua = "Іподром"
               en = "Ipodrom"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700fa"
           name = {
               ua = "Теремки"
               en = "Teremky"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700fb"
           name = {
               ua = "Сирець"
               en = "Syrets"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700fc"
           name = {
               ua = "Дорогожичі"
               en = "Dorohozhychi"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700fd"
           name = {
               ua = "Лук'янівська"
               en = "Lukyanivska"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700fe"
           name = {
               ua = "Золоті Ворота"
               en = "Zoloti vorota"
           }
       }
       { 
           id = "5c2e1d0c867a6335386700ff"
           name = {
               ua = "Палац Спорту"
               en = "Palats Sportu"
           }
       }   
       { 
           id = "5c2e1d0c867a633538670100"
           name = {
               ua = "Кловська"
               en = "Klovska"
           }
       }
       { 
           id = "5c2e1d0c867a633538670101"
           name = {
               ua = "Печерська"
               en = "Pecherska"
           }
       }
       { 
           id = "5c2e1d0c867a633538670102"
           name = {
               ua = "Дружби Народів"
               en = "Druzhby narodiv"
           }
       }
       { 
           id = "5c2e1d0c867a633538670103"
           name = {
               ua = "Видубичі"
               en = "Vydubychi"
           }
       }
       { 
           id = "5c2e1d0c867a633538670104"
           name = {
               ua = "Славутич"
               en = "Slavutych"
           }
       }
       { 
           id = "5c2e1d0c867a633538670105"
           name = {
               ua = "Осокорки"
               en = "Osokorky"
           }
       }
       { 
           id = "5c2e1d0c867a633538670106"
           name = {
               ua = "Позняки"
               en = "Poznyaky"
           }
       }
       { 
           id = "5c2e1d0c867a633538670107"
           name = {
               ua = "Харківська"
               en = "Kharkivska"
           }
       }
       { 
           id = "5c2e1d0c867a633538670108"
           name = {
               ua = "Вирлиця"
               en = "Vyrlytsya"
           }
       }
       { 
           id = "5c2e1d0c867a633538670109"
           name = {
            ua = "Червоний Хутір"
            en = "Chervoniy Khutir"
           }
       }
    |]

let seed = 
    DAL.seedStations stations
    ElasticAdapter.seedStations elacticStations
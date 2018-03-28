module SeedStations

let stations : Station array = 
    [| 
       { 
           name = "Академмістечко"
           branch = Branch.Red
           location = {
               lattitude = 50.464861
               longitude = 30.355083
           }
       }
       { 
           name = "Житомирська"
           branch = Branch.Red
           location = {
               lattitude = 50.456175
               longitude = 30.365628
           }
       }
       { 
           name = "Святошин"
           branch = Branch.Red
           location = {
               lattitude = 50.457903
               longitude = 30.390614
           }
       }
       { 
           name = "Нивки"
           branch = Branch.Red
           location = {
               lattitude = 50.458653
               longitude = 30.404042
           }
       }
       { 
           name = "Берестейська"
           branch = Branch.Red
           location = {
               lattitude = 50.458333
               longitude = 30.420833
           }
       }
       { 
           name = "Шулявська"
           branch = Branch.Red
           location = {
               lattitude = 50.455
               longitude = 30.445278
           }
       }
       { 
           name = "Політехнічний Інститут"
           branch = Branch.Red
           location = {
               lattitude = 50.450833
               longitude = 30.466111
           }
       }
       { 
           name = "Вокзальна"
           branch = Branch.Red
           location = {
               lattitude = 50.441667
               longitude = 30.4875
           }
       }
       { 
           name = "Університет"
           branch = Branch.Red
           location = {
               lattitude = 50.444167
               longitude = 30.505833
           }
       }
       { 
           name = "Театральна"
           branch = Branch.Red
           location = {
               lattitude = 50.444722
               longitude = 30.518056
           }
       }
       { 
           name = "Хрещатик"
           branch = Branch.Red
           location = {
               lattitude = 50.357425
               longitude = 30.439872
           }
       }
       { 
           name = "Арсенальна"
           branch = Branch.Red
           location = {
               lattitude = 50.443889
               longitude = 30.545556
           }
       }
       { 
           name = "Дніпро"
           branch = Branch.Red
           location = {
               lattitude = 50.441111
               longitude = 30.558611
           }
       }
       { 
           name = "Гідропарк"
           branch = Branch.Red
           location = {
               lattitude = 50.445556
               longitude = 30.576944
           }
       }
       { 
           name = "Лівобережна"
           branch = Branch.Red
           location = {
               lattitude = 50.451389
               longitude = 30.598889
           }
       }
       { 
           name = "Дарниця"
           branch = Branch.Red
           location = {
               lattitude = 50.455556
               longitude = 30.613056
           }
       }
       { 
           name = "Чернігівська"
           branch = Branch.Red
           location = {
               lattitude = 50.459722
               longitude = 30.630833
           }
       }
       { 
           name = "Лісова"
           branch = Branch.Red
           location = {
               lattitude = 50.464639
               longitude = 30.645556
           }
       }
       { 
           name = "Героїв Дніпра"
           branch = Branch.Blue
           location = {
               lattitude = 50.5225
               longitude = 30.498611
           }
       }
       { 
           name = "Мінська"
           branch = Branch.Blue
           location = {
               lattitude = 50.512222
               longitude = 30.498333
           }
       }
       { 
           name = "Оболонь"
           branch = Branch.Blue
           location = {
               lattitude = 50.501111
               longitude = 30.498056
           }
       }
       { 
           name = "Петрівка"
           branch = Branch.Blue
           location = {
               lattitude = 50.486667
               longitude = 30.497778
           }
       }
       { 
           name = "Тараса Шевченка"
           branch = Branch.Blue
           location = {
               lattitude = 50.473056
               longitude = 30.505
           }
       }
       { 
           name = "Контрактова Площа"
           branch = Branch.Blue
           location = {
               lattitude = 50.465
               longitude = 30.516667
           }
       }
       { 
           name = "Поштова Площа"
           branch = Branch.Blue
           location = {
               lattitude = 50.459167
               longitude = 30.525556
           }
       }
       { 
           name = "Майдан Незалежності"
           branch = Branch.Blue
           location = {
               lattitude = 50.45
               longitude = 30.524167
           }
       }
       { 
           name = "Площа Льва Толстого"
           branch = Branch.Blue
           location = {
               lattitude = 50.439444
               longitude = 30.516944
           }
       }
       { 
           name = "Олімпійська"
           branch = Branch.Blue
           location = {
               lattitude = 50.431944
               longitude = 30.516389
           }
       }
       { 
           name = "Палац Україна"
           branch = Branch.Blue
           location = {
               lattitude = 50.420833
               longitude = 30.520833
           }
       }
       { 
           name = "Либідська"
           branch = Branch.Blue
           location = {
               lattitude = 50.420833
               longitude = 30.520833
           }
       }
       { 
           name = "Деміївська"
           branch = Branch.Blue
           location = {
               lattitude = 50.404792
               longitude = 30.516833
           }
       }
       { 
           name = "Голосіївська"
           branch = Branch.Blue
           location = {
               lattitude = 50.3975
               longitude = 30.508333
           }
       }
       { 
           name = "Васильківська"
           branch = Branch.Blue
           location = {
               lattitude = 50.393333
               longitude = 30.488056
           }
       }
       { 
           name = "Виставковий Центр"
           branch = Branch.Blue
           location = {
               lattitude = 50.382581
               longitude = 30.477536
           }
       }
       { 
           name = "Іподром"
           branch = Branch.Blue
           location = {
               lattitude = 50.376556
               longitude = 30.469117
           }
       }
       { 
           name = "Теремки"
           branch = Branch.Blue
           location = {
               lattitude = 50.367044
               longitude = 30.454203
           }
       }
       { 
           name = "Сирець"
           branch = Branch.Green
           location = {
               lattitude = 50.476111
               longitude = 30.430556
           }
       }
       { 
           name = "Дорогожичі"
           branch = Branch.Green
           location = {
               lattitude = 50.473611
               longitude = 30.449444
           }
       }
       { 
           name = "Лук'янівська"
           branch = Branch.Green
           location = {
               lattitude = 50.462222
               longitude = 30.481667
           }
       }
       { 
           name = "Золоті Ворота"
           branch = Branch.Green
           location = {
               lattitude = 50.448333
               longitude = 30.513333
           }
       }
       { 
           name = "Палац Спорту"
           branch = Branch.Green
           location = {
               lattitude = 50.438056
               longitude = 30.520833
           }
       }   
       { 
           name = "Кловська"
           branch = Branch.Green
           location = {
               lattitude = 50.436944
               longitude = 30.531667
           }
       }
       { 
           name = "Печерська"
           branch = Branch.Green
           location = {
               lattitude = 50.4275
               longitude = 30.538889
           }
       }
       { 
           name = "Дружби Народів"
           branch = Branch.Green
           location = {
               lattitude = 50.418056
               longitude = 30.545
           }
       }
       { 
           name = "Видубичі"
           branch = Branch.Green
           location = {
               lattitude = 50.402222
               longitude = 30.560833
           }
       }
       { 
           name = "Славутич"
           branch = Branch.Green
           location = {
               lattitude = 50.394167
               longitude = 30.604167
           }
       }
       { 
           name = "Осокорки"
           branch = Branch.Green
           location = {
               lattitude = 50.395278
               longitude = 30.616111
           }
       }
       { 
           name = "Позняки"
           branch = Branch.Green
           location = {
               lattitude = 50.398056
               longitude = 30.633333
           }
       }
       { 
           name = "Харківська"
           branch = Branch.Green
           location = {
               lattitude = 50.400833
               longitude = 30.652222
           }
       }
       { 
           name = "Вирлиця"
           branch = Branch.Green
           location = {
               lattitude = 50.403333
               longitude = 30.666111
           }
       }
       { 
           name = "Червоний Хутір"
           branch = Branch.Green
           location = {
               lattitude = 50.408889
               longitude = 30.694444
           }
       }
    |]

let seed = 
    DAL.seedStations stations
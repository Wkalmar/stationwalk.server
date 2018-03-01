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
    |]

let seed = 
    DAL.seedStations stations
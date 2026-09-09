using System.Collections.Generic;
using System.Linq;

namespace DELETE
{
    public class Plane
    {
        public int PlaneId { get; set; }
        public string PlaneName { get; set; }
        public int Capacity { get; set; }
        public int MaxSpeed { get; set; }
        public int BuiltYear { get; set; }
        public int TypeId { get; set; }

        public Plane(int planeId, string planeName, int capacity, int maxSpeed, int builtYear, int typeId)
        {
            PlaneId = planeId;
            PlaneName = planeName;
            Capacity = capacity;
            MaxSpeed = maxSpeed;
            BuiltYear = builtYear;
            TypeId = typeId;
        }

    }//PlaneId;PlaneName;Capacity;MaxSpeed;BuiltYear;TypeId;TypeName

    public class PlaneType
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public PlaneType(int typeId, string typeName)
        {
            TypeId = typeId;
            TypeName = typeName;
        }
    }

    internal class Model
    {
        //II.rész -> Model-View LINQ, filebeolvasás

        // A Program.cs file-ban csak az adatok kiíratását végezd el.
        // A Model.cs file-ban függvények segítségével készítsd el az alábbi feladatokat.

        // 1. feladat
        // Készíts két megfelelő adatszerkezetű tárolót public láthatósággal,
        // amelyekben majd eltárolod az adatokat.
        // Az egyik adatkonténerbe az alábbi adatok kerüljenek:
        // PlaneId : int, PlaneName : string, Capacity : int, MaxSpeed : int, BuiltYear : int, TypeId : int
        // A másik adatkonténerbe az alábbi adatok kerüljenek:
        // TypeId : int, TypeName : string
        // Lehetőség szerint készíts osztályokat az összetett adatok eltárolására
        // (pl. Plane és PlaneType).

        // 2. feladat
        // Készíts egy private függvényt, amely beolvassa a planes.txt file tartalmát.
        // A sorok szerkezete:
        // PlaneId;PlaneName;Capacity;MaxSpeed;BuiltYear;TypeId;TypeName
        // A megfelelő adatokat mentsd el a megfelelő adatkonténerbe.
        // Fontos: egy PlaneType csak egyszer szerepeljen a megfelelő adatkonténerben.
        // Ha például több személyszállító repülőgép található a file-ban,
        // a "Személyszállító" típus csak egyszer kerüljön bele a típusok listájába.

        List<Plane> Planes = new List<Plane>();
        List<PlaneType> PlaneTypes = new List<PlaneType>();

        private void ReadFile()
        {
            StreamReader str = new StreamReader("planes.txt");

            while (!str.EndOfStream)
            {
                // 0PlaneId;1PlaneName;2Capacity;3MaxSpeed;4BuiltYear;5TypeId;6TypeName

                string[] lineContent = str.ReadLine().Split(';');


                PlaneType currentPlaneType = new PlaneType(

                    Convert.ToInt32(lineContent[5]), 
                    lineContent[6]

                );


                Plane currentPlane = new Plane(

                    Convert.ToInt32(lineContent[0]),
                    lineContent[1],
                    Convert.ToInt32(lineContent[2]),
                    Convert.ToInt32(lineContent[3]),
                    Convert.ToInt32(lineContent[4]),
                    Convert.ToInt32(lineContent[5])

                );

                if (!PlaneTypes.Contains(currentPlaneType))
                {
                    PlaneTypes.Add(currentPlaneType);
                    Planes.Add(currentPlane);
                }
                else 
                {
                    Planes.Add(currentPlane);
                }
            }

            str.Close();
        }

        // 3. feladat
        // Készíts konstruktort, amelyben meghívod a filebeolvasásra szolgáló függvényt.

        public Model()
        {
            ReadFile();
        }

        // 4. feladat
        // Készíts függvényt, amely paraméterként kap egy repülőgéptípust.
        // Add vissza azoknak a repülőgépeknek a neveit, amelyek az adott típushoz tartoznak.

        public List<string> GetPlanesByType(PlaneType planeType)
        {
            return Planes.Where(x => PlaneTypes.First(y => y.TypeId == x.TypeId).TypeName == planeType.TypeName).Select(x => x.PlaneName).ToList();
        }

        // 5. feladat
        // Készíts függvényt, amely paraméterként kap egy évszámot.
        // Add vissza azoknak a repülőgépeknek a neveit, amelyek a paraméterként megkapott évben már léteztek.

        public List<string> _5(int year)
        {
            return Planes.Where(x=>x.BuiltYear <= year).Select(x=>x.PlaneName).ToList();
        }

        // 6. feladat
        // Készíts statisztikát, amely megmondja, hogy típusonként hány repülőgép tartozik az adott típushoz.
        // Add vissza egy szótárban a típus nevét és a hozzá tartozó darabszámot.

        public Dictionary<string, int> _6()
        {
            return Planes.GroupBy(x=>x.TypeId, PlaneTypes.Select(y=>y.TypeId))
        }

        // 7. feladat
        // Készíts függvényt, amely megmondja,hogy az egyes típusokhoz tartozó repülőgépek közül mekkora a legnagyobb maximális sebesség.
        // Add vissza egy szótárban a típus nevét és a hozzá tartozó sebességértéket.

        public Dictionary<string, int> _7()
        {
            return PlanesDict.ToDictionary(x => x.Key.TypeName, x => x.Value.Max(x=>x.MaxSpeed));
        }

        // 8. feladat
        // Készíts függvényt, amely visszaadja azoknak a repülőgépeknek a neveit ABC-sorrendben, amelyek neve legalább 3 szóból áll.

        public List<string> _8()
        {
            return PlanesDict.SelectMany(x=>x.Value).Where(x=>x.PlaneName.Split(' ').Length >= 3).OrderBy(x=>x.PlaneName).Select(x=>x.PlaneName).ToList();
        }

        // 9. feladat
        // Készíts függvényt, amely megmondja, hogy típusonként mennyi az átlagos sebesség.
        // Add vissza egy szótárban a típus nevét és a hozzá tartozó lebegőpontos értéket.

        public Dictionary<string, double> _9()
        {
            return PlanesDict.ToDictionary(x => x.Key.TypeName, x => x.Value.Average(x=>x.MaxSpeed));
        }

        // 10. feladat
        // Készíts függvényt, amely paraméterként kap egy minimum kapacitást.
        // Add vissza azoknak a repülőgépeknek a neveit, amelyek kapacitása legalább akkora, mint a paraméterként kapott érték.
        // Az eredményt rendezd kapacitás szerint növekvő sorrendbe.

        public List<string> _10(int minCapacity)
        {
            return PlanesDict.SelectMany(x=>x.Value).Where(x=>x.Capacity >= minCapacity).OrderBy(x=>x.Capacity).Select(x=>x.PlaneName).ToList();
        }

        // 11. feladat
        // Készíts függvényt, amely paraméterként kap egy darabszámot.
        // Add vissza a megadott darabszámú leggyorsabb repülőgép nevét.
        // A repülőgépeket MaxSpeed alapján rendezd csökkenő sorrendbe.
        //
        // Például:
        // ha a paraméter értéke 5,
        // akkor az 5 leggyorsabb repülőgép nevét add vissza.

        public List<string> _11(int dbSzam)
        {
            return PlanesDict.SelectMany(x => x.Value).OrderByDescending(x=>x.MaxSpeed).Select(x => x.PlaneName).Take(dbSzam).ToList();
        }

        // 12. feladat
        // Készíts függvényt, amely paraméterként kap egy minimum és egy maximum kapacitást.
        // Add vissza azoknak a repülőgépeknek a neveit, amelyek kapacitása a két megadott érték közé esik.
        // Az eredményt rendezd ABC-sorrendbe.

        public List<string> _12(int minCapacity, int maxCapacity)
        {
            return PlanesDict.SelectMany(x => x.Value).Where(x => x.Capacity >= minCapacity && x.Capacity < maxCapacity).OrderBy(x => x.PlaneName).Select(x => x.PlaneName).ToList();
        }

        // 13. feladat
        // Készíts függvényt, amely paraméterként kap egy évszámot és egy minimum maximális sebességet.
        // Add vissza azoknak a repülőgépeknek a neveit, amelyek a paraméterként kapott év után készültek, és maximális sebességük legalább akkora, mint a paraméterként kapott sebesség.
        // Az eredményt MaxSpeed szerint csökkenő sorrendbe rendezd.

        public List<string> _13(int speed, int year)
        {
            return PlanesDict.SelectMany(x => x.Value).Where(x => x.BuiltYear > year && x.MaxSpeed >= speed).OrderByDescending(x => x.MaxSpeed).Select(x => x.PlaneName).ToList();
        }

        // 14. feladat
        // Készíts függvényt, amely paraméterként kap egy minimum kapacitást.
        // A legalább ekkora kapacitású repülőgépek közül keresd meg a legnagyobb kapacitásút.
        // Add vissza a repülőgép nevét.

        public string _14(int minCapacity)
        {
            return PlanesDict.SelectMany(x => x.Value).Where(x => x.Capacity >= minCapacity).OrderByDescending(x => x.Capacity).Select(x => x.PlaneName).First();
        }

        // 15. feladat
        // Készíts függvényt, amely paraméterként kap egy repülőgéptípust.
        // Az adott típushoz tartozó repülőgépek közül keresd meg a legrégebben gyártott repülőgépet.
        // Add vissza a repülőgép nevét.

        public string _15(PlaneType tipus)
        {
            return PlanesDict[tipus].OrderBy(x => x.BuiltYear).Select(x => x.PlaneName).First();
        }

        // 16. feladat
        // Készíts függvényt, amely paraméterként kap egy évszámot.
        // Számítsd ki azoknak a repülőgépeknek az átlagos kapacitását, amelyek a paraméterként kapott évben vagy azután készültek.

        public double _16(int year)
        {
            return PlanesDict.SelectMany(x => x.Value).Where(x => x.BuiltYear > year).Average(x=>x.Capacity);
        }

        // 17. feladat
        // Készíts függvényt, amely paraméterként kap egy szövegrészletet.
        // Add vissza azoknak a repülőgépeknek a neveit, amelyek nevében szerepel a paraméterként kapott szöveg.
        // A keresés során ne számítson,hogy kis- vagy nagybetűkkel adták meg a keresett kifejezést.
        // Az eredményt ABC-sorrendben add vissza.

        public List<string> _17(string szoveg)
        {
            return PlanesDict.SelectMany(x => x.Value).Where(x => x.PlaneName.ToLower().Contains(szoveg.ToLower())).OrderBy(x=>x.PlaneName).Select(x=>x.PlaneName).ToList();
        }

        // 18. feladat
        // Készíts függvényt, amely paraméterként kap két szöveget.
        // A két szöveg egy-egy repülőgépnév kezdete legyen.
        // Add vissza azokat a repülőgépeket, amelyek neve az egyik vagy a másik paraméterként kapott szöveggel kezdődik.
        // Például:
        // "Airbus"
        // "Boeing"
        //
        //Rendezd őket gyártási év szerint csökkenő sorrendbe.

        public List<Plane> _17(string szoveg1, string szoveg2)
        {
            return PlanesDict.SelectMany(x => x.Value).Where(x => x.PlaneName.ToLower().StartsWith(szoveg1.ToLower()) || x.PlaneName.ToLower().StartsWith(szoveg2.ToLower())).ToList();
        }

        // 19. feladat
        // Készíts függvényt, amely paraméterként kap egy repülőgéptípust és egy minimum sebességet.
        // Add vissza az adott típushoz tartozó olyan repülőgépek neveit, amelyek maximális sebessége nagyobb, mint a paraméterként kapott minimum sebesség.
        // Az eredményt MaxSpeed szerint csökkenő sorrendbe rendezd.

        public List<string> _19(PlaneType planeType, int minSpeed)
        {
            return PlanesDict[planeType].Where(x=>x.MaxSpeed > minSpeed).OrderByDescending(x=>x.MaxSpeed).Select(x => x.PlaneName).ToList();
        }

        // 20. feladat
        // Készíts függvényt, amely típusonként kiszámítja az összes férőhely számát.
        // Add vissza egy szótárban:
        // TypeName -> összes Capacity
        // Például:
        // "Személyszállító" -> 1250

        public Dictionary<string, int> _20()
        {
            return PlanesDict.ToDictionary(x=>x.Key.TypeName, x=>x.Value.Capacity);
        }

        // 21. feladat
        // Készíts függvényt, amely típusonként megkeresi a legnagyobb kapacitású repülőgépet.
        // Add vissza minden típushoz a legnagyobb kapacitású repülőgép nevét.
        //
        // A feladat megoldásánál használj GroupBy-t,

        public List<string> _21()
        {
            return PlanesDict.GroupBy(x=>x.Key).Select(x=>x).OrderByDescending(x => x.Capacity).Select(x => x.PlaneName).Take(1).ToList();
        }

        // 22. feladat
        // Készíts függvényt, amely visszaadja a 3 legújabb olyan repülőgépet, amely legalább 150 fő befogadására képes.

        public List<Plane> _22()
        {
            return PlanesDict.SelectMany(x => x.Value).OrderByDescending(x => x.BuiltYear).Where(x=>x.Capacity >= 150).Take(3).ToList();
        }

        // 23. feladat
        // Készíts függvényt, amely paraméterként kap egy évszámot.
        // Számold meg típusonként, hogy hány olyan repülőgép van, amely a megadott év után készült.
        // Add vissza egy szótárban:
        // TypeName -> darabszám.

        public Dictionary<string, int> _23(int year)
        {
            return PlanesDict.ToDictionary(x => x.Key.TypeName, x => x.Value.Where(x=>x.BuiltYear > year).Count());
        }

        // 24. feladat
        // Készíts függvényt, amely megkeresi azokat a repülőgéptípusokat,  amelyekhez tartozó repülőgépek átlagos maximális sebessége  nagyobb 700 km/h-nál.
        // Add vissza csak a típusok neveit, az átlagos sebességük szerint csökkenő sorrendben.

        public List<string> _24()
        {
            return PlanesDict.Wh;
        }

        // 25. feladat
        // Készíts függvényt, amely visszaadja az első 3 olyan repülőgépet,
        // amelyek:
        //
        // - legalább 200 fő kapacitásúak,
        // - 1990 után készültek,
        // - maximális sebességük legalább 800 km/h.



        // 26. feladat
        // Készíts függvényt, amely minden repülőgépből egy szöveges adatot készít
        // Select használatával.
        //
        // A visszaadott lista elemei ilyen formájúak legyenek:
        //
        // "Airbus A350 - 350 fő - 945 km/h"
        //
        // A listát a repülőgépek neve szerint ABC-sorrendben add vissza.


        // 27. feladat
        // Készíts függvényt, amely megvizsgálja, hogy van-e olyan repülőgép az adatok között, amely:
        // - 2015 után készült,
        // - legalább 300 fő kapacitású,
        // - és legalább 900 km/h maximális sebességű.
        //
        // A függvény bool típusú értékkel térjen vissza.


        // 28. feladat
        // Készíts függvényt, amely típusonként visszaadja a három leggyorsabb repülőgépet.
        // (Group by)


        // 29. feladat
        // Készíts függvényt, amely meghatározza, melyik repülőgéptípus rendelkezik a legnagyobb összesített kapacitással.
        // (Group by)

        // 30. feladat
        // Minden függvényedet hívd meg a Program.cs file-ban,
        // és írd ki az eredményeket.

    }
}

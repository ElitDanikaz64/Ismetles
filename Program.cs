//12 szoftver szabadság alatt gyakorlás :

//I.rész -> Bevezetés

// Kérj be a felhasználótól tetszőleges mennyiségű egész számot egyetlen sorban, vesszővel elválasztva.
// Példa:
// 12,45,7,31,90,22,18,67

// A bekért szöveget bontsd szét vessző mentén.

// A kapott értékeket alakítsd át egész számokká, majd tárold el őket egy listában. (.ToList)

using DELETE;

List<int> szamok = new();
Console.ReadLine().Split(',').ToList().ForEach(x => szamok.Add(Convert.ToInt32(x)));


// 1. feladat
// Adja vissza a listában lévő legnagyobb számot

int GetMax()
{
    int max = szamok[0];

    foreach (int x in szamok)
        if (x > max)
            max = x;

    return max;

    /*
     vagy csak
    return szamok.Max();
     
     */
}

// 2. feladat
// Számítsa ki és adja vissza a listában található számok átlagát.
// Figyelj arra, hogy az eredmény lebegőpontos szám legyen.

double GetAvg()
{
    return szamok.Average();
}

// 3. feladat
// Számolja meg és adja vissza,hogy hány darab 30-nál nagyobb szám található a listában.

int CountAboveThirty()
{
    int counter = 0;

    foreach (int x in szamok)
        if (x > 30)
            counter++;

    return counter;
}

// A kiírás például ilyen formában történjen:
//
// Legnagyobb szám: 90
// A számok átlaga: 36,5
// 30-nál nagyobb számok száma: 4

Console.WriteLine($"Legnagyobb szám: {GetMax()}\nA számok átlaga: {GetAvg()}\n30-nál nagyobb számok száma: {CountAboveThirty()}");

// 4.feladat
// Adja vissza egy új listában az összes negatív számot.

List<int> GetNegatives()
{
    List<int> list = new();

    foreach (int x in szamok)
        if (x < 0)
            list.Add(x);

    return list;
}

// 5.feladat
// Add vissza a listában lévő számok közül a három legnagyobbat (Linq-t már ajánlott használni)
// Ha a listában háromnál kevesebb szám található,akkor az összes rendelkezésre álló számot adja vissza.

List<int> _5()
{
    if (szamok.Count <= 3) return szamok;

    return szamok.OrderByDescending(x=>x).Take(3).ToList();
}


// ---------------- kiírás innen ---------------- //

Model MODEL = new Model();



//III.rész -> Öröklődés:

// Készítsd el az alábbi osztályhierarchiát!
// Minden osztály külön file-ban legyen.

// Az osztályok:
// Vehicle
//   |
//   +-- AirVehicle
//          |
//          +-- Airplane
//          |      |
//          |      +-- PassengerPlane
//          |
//          +-- Helicopter
//
// A feladat során használd az öröklődést, private és protected adattagokat,
// konstruktorokat, függvényeket, valamint virtual és override függvényeket.


// 1. osztály – Vehicle

// Készíts egy Vehicle nevű osztályt.

// Protected adattag:
// - name : string

// Private adattag:
// - builtYear : int

// Készíts konstruktort.
// Paraméterei:
// - name : string
// - builtYear : int
// Feladata: állítsa be az osztály adattagjainak kezdőértékét.


// Készíts egy GetBuiltYear nevű függvényt.
// Paraméter: nincs
// Visszatérési típus: int
// Feladata: adja vissza a jármű gyártási évét.


// Készíts egy GetAge nevű függvényt.
// Paraméter:
// - currentYear : int
// Visszatérési típus: int
// Feladata: számítsa ki, hogy hány éves a jármű.
// Például: gyártási év: 2015, aktuális év: 2026, eredmény: 11


// Készíts egy virtual GetVehicleInfo nevű függvényt.
// Paraméter: nincs
// Visszatérési típus: string
// Feladata: adjon vissza egy szöveget a jármű nevéről és gyártási évéről.


// 2. osztály – AirVehicle

// Készíts egy AirVehicle nevű osztályt, amely a Vehicle osztályból öröklődik.

// Protected adattag:
// - maxSpeed : int

// Private adattag:
// - maxAltitude : int

// Készíts konstruktort.
// Paraméterei:
// - name : string
// - builtYear : int
// - maxSpeed : int
// - maxAltitude : int
// A konstruktorban az ősosztály konstruktorát is használd.


// Készíts egy GetMaxAltitude nevű függvényt.
// Paraméter: nincs
// Visszatérési típus: int
// Feladata: adja vissza a maximális repülési magasságot.


// Készíts egy IsFasterThan nevű függvényt.
// Paraméter:
// - speed : int
// Visszatérési típus: bool
// Feladata: adjon vissza true értéket, ha a légi jármű maximális sebessége
// nagyobb a paraméterként kapott sebességnél.
// Egyébként false értéket adjon vissza.


// 3. osztály – Airplane

// Készíts egy Airplane nevű osztályt, amely az AirVehicle osztályból öröklődik.

// Protected adattag:
// - capacity : int

// Private adattag:
// - fuelAmount : int

// Készíts konstruktort.
// Paraméterei:
// - name : string
// - builtYear : int
// - maxSpeed : int
// - maxAltitude : int
// - capacity : int
// - fuelAmount : int

// Használd az ősosztály konstruktorát.


// Készíts egy GetFuelAmount nevű függvényt.
// Paraméter: nincs
// Visszatérési típus: int
// Feladata: adja vissza az aktuális üzemanyag-mennyiséget.


// Készíts egy Refuel nevű függvényt.
// Paraméter:
// - amount : int
// Visszatérési típus: void
// Feladata: növelje az üzemanyag mennyiségét a paraméterként kapott értékkel.
// Negatív értéket ne lehessen hozzáadni.


// Készíts egy ConsumeFuel nevű függvényt.
// Paraméter:
// - amount : int
// Visszatérési típus: bool
// Feladata: ha van legalább annyi üzemanyag, mint a paraméterként kapott érték,
// csökkentse vele az üzemanyag mennyiségét és adjon vissza true értéket.
// Ha nincs elegendő üzemanyag, ne változtasson semmit és adjon vissza false értéket.


// Készíts egy HasLargeCapacity nevű függvényt.
// Paraméter:
// - limit : int
// Visszatérési típus: bool
// Feladata: adjon vissza true értéket, ha a repülőgép kapacitása
// legalább akkora, mint a paraméterként kapott határérték.


// 4. osztály – PassengerPlane

// Készíts egy PassengerPlane nevű osztályt, amely az Airplane osztályból öröklődik.

// Private adattag:
// - businessSeats : int

// Private adattag:
// - ticketPrice : int

// Készíts konstruktort.
// Paraméterei:
// - name : string
// - builtYear : int
// - maxSpeed : int
// - maxAltitude : int
// - capacity : int
// - fuelAmount : int
// - businessSeats : int
// - ticketPrice : int


// Készíts egy GetTicketPrice nevű függvényt.
// Paraméter: nincs
// Visszatérési típus: int
// Feladata: adja vissza egy normál jegy árát.


// Készíts egy CalculateRevenue nevű függvényt.
// Paraméter:
// - soldTickets : int
// Visszatérési típus: int
// Feladata: számítsa ki, hogy mennyi bevétel keletkezett,
// ha a paraméterként megadott számú jegyet eladták.
// Feltételezheted, hogy minden jegy azonos árú.


// Készíts egy GetBusinessSeatPercentage nevű függvényt.
// Paraméter: nincs
// Visszatérési típus: double
// Feladata:
// számítsa ki, hogy a teljes férőhely hány százaléka business osztály.
// Például:
// capacity = 200
// businessSeats = 20
// elvart_eredmeny = 10.0


// 5. osztály – Helicopter

// Készíts egy Helicopter nevű osztályt, amely az AirVehicle osztályból öröklődik.

// Private adattag:
// - rotorCount : int

// Private adattag:
// - isRescueHelicopter : bool

// Készíts konstruktort.
// Paraméterei:
// - name : string
// - builtYear : int
// - maxSpeed : int
// - maxAltitude : int
// - rotorCount : int
// - isRescueHelicopter : bool


// Készíts egy IsSuitableForRescue nevű függvényt.
// Paraméter: nincs
// Visszatérési típus: bool
// Feladata: adja vissza az isRescueHelicopter adattag értékét.


// Készíts egy GetRotorInfo nevű függvényt.
// Paraméter: nincs
// Visszatérési típus: string
// Feladata: adjon vissza egy szöveget a rotorok számáról.
// Például: "A helikopter 2 rotorral rendelkezik."


// 6. feladat – override

// Írd felül a PassengerPlane és a Helicopter osztályban
// a Vehicle osztályból örökölt GetVehicleInfo() függvényt.


// A PassengerPlane GetVehicleInfo() függvénye:
// Paraméter: nincs
// Visszatérési típus: string
// Feladata: adja vissza legalább az alábbi adatokat:
// - name
// - builtYear
// - maxSpeed
// - capacity
// - ticketPrice


// A Helicopter GetVehicleInfo() függvénye:
// Paraméter: nincs
// Visszatérési típus: string
// Feladata: adja vissza legalább az alábbi adatokat:
// - name
// - builtYear
// - maxSpeed
// - rotorCount
// - isRescueHelicopter


// 7. feladat – Példányosítás

// A Program.cs file-ban hozz létre legalább:
// - 2 darab PassengerPlane objektumot
// - 2 darab Helicopter objektumot


// Példa adatok:

// PassengerPlane:
// name: "Airbus A350"
// builtYear: 2013
// maxSpeed: 945
// maxAltitude: 13100
// capacity: 350
// fuelAmount: 120000
// businessSeats: 40
// ticketPrice: 150000


// PassengerPlane:
// name: "Boeing 787 Dreamliner"
// builtYear: 2009
// maxSpeed: 954
// maxAltitude: 13100
// capacity: 330
// fuelAmount: 110000
// businessSeats: 36
// ticketPrice: 170000


// Helicopter:
// name: "Airbus H145"
// builtYear: 2014
// maxSpeed: 268
// maxAltitude: 5200
// rotorCount: 2
// isRescueHelicopter: true


// Helicopter:
// name: "Robinson R44"
// builtYear: 1992
// maxSpeed: 240
// maxAltitude: 4300
// rotorCount: 2
// isRescueHelicopter: false


// 8. feladat – Függvények tesztelése

// Hívd meg az elkészített függvényeket a Program.cs file-ban.

// Írasd ki:
// - az összes jármű korát
// - melyik légi jármű gyorsabb 500 km/h-nál
// - az utasszállítók jegyárát
// - az utasszállítók business férőhelyeinek százalékát
// - a helikopterek rotorinformációját
// - hogy melyik helikopter alkalmas mentésre


// Tankolj 10000 egység üzemanyagot az egyik utasszállítóba.
// Írasd ki az új üzemanyag-mennyiséget.


// Fogyassz el 50000 egység üzemanyagot.
// Írasd ki, hogy sikeres volt-e a művelet,
// majd írasd ki az új üzemanyag-mennyiséget.


// Számítsd ki, hogy az első utasszállító mekkora bevételt termel,
// ha 280 jegyet értékesítettek.


// Végül hívd meg mindegyik objektum GetVehicleInfo() függvényét.
// Figyeld meg, hogy a PassengerPlane és a Helicopter objektumoknál az override-olt változat fut le.
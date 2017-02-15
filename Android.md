# Fordítás Android platformra és feltöltés a HockeyApp-ra, hogy telepíteni tudjunk Android készülékre az Interneten keresztül

## Alkalmazás felkészítése a telepítésre

A Day1.Droid projekt tulajdonságlapján (a *Solution Explorerben* jobb egérgomb a projekten, és **Properties** menüpont) az Android Manifest lapon, 
- az alkalmazás nevét (Application name)
- a csomag nevét (Package name)
- és az ikont (Application Icon) 
 
 kell kitölteni, a mellékelt módon, a 
- verzió számot és 
- a verzió nevet 
  
pedig **üresen kell hagyni**, ahogy ez a képen látszik is:
 
![](images/android01.png?raw=true) 
 
## Alkalmazás fordítása
 
 Az alkalmazás telepítéshez való fordításakor a következő lépéseket kell elvégezni
 
- A Day1.Droid projektet kell az induló projektté tenni (jobb egérgomb a *Solution Explorerben* a projekt nevén, majd a **Set as StartUp project** menüpont) Ezt vissza tudjuk ellenőrizni, ha a menüsorban figyelünk a konfiguráció és a processzortípus melletti lenyílóra, itt is lehet induló projektet választani, ez az előzőekben leírtakkal egyenértékű

![](images/android02.png?raw=true) 

- A konfigurációk közül a **Release**-t kell választani, csak ezzel a konfigurációval lehet a végén *.apk állományt gyártani.

![](images/android03.png?raw=true) 

- Újra kell gyártani a végeredményt a forrásból a Day1.Droid projekten a **Rebuild** segítségével
  
## Alkalmazás csomagolása
A Day1.Droid projekt nevén a *Solution Explorerben* az **Archive...** menüpontot kell választani. Ezzel kezdetét veszi a csomagkészítés. 

![](images/android04.png?raw=true) 

Ha elkészült a csomagunk, akkor a **Distribute...** gomb segítségével tudjuk az *.apk állomány kinyerni a gépből.

![](images/android05.png?raw=true) 

Választanunk kell egy terjesztési csatornát, itt az **Ad Hoc** gombot kell használni.

![](images/android06.png?raw=true) 

*Első alkalommal* készítenünk kell egy tanusítványt, amivel aláírjuk a csomagunkat. Ehhez kattintsunk a zöld plusz gombra

![](images/android07.png?raw=true) 

majd töltsük ki az Alias, a jelszó és még legalább egy mezőt, és nyomjunk a **Create** gombra.

![](images/android08.png?raw=true) 

Ez után válasszuk ki a tanusítványunkat, és nyomjunk a **Save As** gombra, 

![](images/android09.png?raw=true) 

és mentsük el a megfelelő helyre az *.apk állományunkat. 

![](images/android10.png?raw=true) 

A felugró ablakban adjuk meg a tanusítvány jelszavát.

![](images/android11.png?raw=true) 

## Alkalmazás feltöltése a HockeyApp-ra
Nyissuk meg a HockeyApp oldalunkat, és hozzunk létre egy Alkalmazást a **New App** gombbal. A felugró ablakba húzzuk be az előző pontban lementett apk csomagot.

![](images/android12.png?raw=true) 

Ezzel feltöltöttük a csomagot a HockeyApp-ra, és létrehoztunk egy alkalmazást.

![](images/android13.png?raw=true) 

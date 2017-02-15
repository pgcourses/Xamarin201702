# Fordítás Android platformra és a telepítés Android készülékre HockeyApp használatával

## Alkalmazás felkészítése a telepítésre

A Day1.Droid projekt tulajdonságlapján (a *Solution Explorerben* jobb egérgomb a projekten, és **Properties** menüpont), 
- az alkalmazás nevét (Application name)
- a csomag nevét (Package name)
- és az ikont (Application Icon) 
 
 kell kitölteni, a mellékelt módon, a 
- verzió számot és 
- a verzió nevet 
  
pedig **üresen kell hagyni**, ahogy ez a képen látszik is:
 
 
 
 
 ## Alkalmazás fordítása
 
 Az alkalmazás telepítéshez való fordításakor a következő lépéseket kell elvégezni
 
- A Day1.Droid projektet kell az induló projektté tenni (jobb egérgomb a *Solution Explorerben* a projekt nevén, majd a **Set as StartUp project** menüpont) Ezt vissza tudjuk ellenőrizni, ha a menüsorban figyelünk a konfiguráció és a processzortípus melletti lenyílóra, itt is lehet induló projektet választani, ez az előzőekben leírtakkal egyenértékű
- A konfigurációk közül a **Release**-t kell választani, csak ezzel a konfigurációval lehet a végén *.apk állományt gyártani.
- Újra kell gyártani a végeredményt a forrásból a Day1.Droid projekten a **Rebuild** segítségével
  
## Alkalmazás csomagolása
A Day1.Droid projekt nevén a *Solution Explorerben* az **Archive...* menüpontot kell választani. Ezzel kezdetét vecsi a csomagkészítés. Ha elkészült a csomagunk, akkor a **Distribute...** gomb segítségével tudjuk az *.apk állomány kinyerni a gépből.

Választanunk kell egy terjesztési csatornát, itt az **Ad Hoc** gombot kell használni.

*Első alkalommal* készítenünk kell egy tanusítványt, amivel aláírjuk a csomagunkat. Ehhez kattintsunk a zöld plusz gombra

majd töltsük ki az Alias, a jelszó és még legalább egy mezőt, és nyomjunk a **Create** gombra.

Ez után válasszuk ki a tanusítványunkat, és nyomjunk a **Save As** gombra, és mentsük el a megfelelő helyre az *.apk állományunkat. 

A felugró ablakban adjuk meg a tanusítvány jelszavát.

## Alkalmazás telepítése
Nyissuk meg a HockeyApp oldalunkat, és hozzunk létre egy Alkalmazást a **New App** gombbal. A felugró ablakba húzzuk be az előző pontban lementett apk csomagot.

Ezzel feltöltjük a csomagot a HockeyApp-ra, és létrehozunk egy alkalmazást.

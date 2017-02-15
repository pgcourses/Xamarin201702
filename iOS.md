# Fordítás iOS platformra és feltöltés a HockeyApp-ra, hogy telepíteni tudjunk iPhone készülékre az Interneten keresztül

## Előkészületek

A fizikai eszközön való tesztfuttatáshoz (az alkalmazás nem kerül ki az Apple App Store-ba) szükséges csomag létrehozásához szükséges a teljes azonosítása a következő négyesnek:
- fejlesztő
- BUILD számítógép
- Alkalmazás
- eszköz, amin tesztelünk

Ehhez 
- létre kell hoznunk egy ingyenes [AppleID-t](https://appleid.apple.com/), 
- kell egy [Apple Developer előfizetés](https://developer.apple.com/programs/enroll/) (magánszemélyeknek egy évre 99 USD.)
- létre kell hoznunk tanusítványt, ami azonosítja a fejlesztőt, 
- regisztrálni kell az eszközt az UDID azonosítójával, amin az alkalmazást tesztelni akarjuk
- létre kell hoznunk alkalmazás azonosítót,
- Ezeket össze kell kötnünk telepítési előírás segítségével (provisioning profile)
- A provisioning profile-nak és a hozzá tartozó tanusítványnak a BUILD gépen kell lennie letöltve

A provisioning profile leírása (az iPhone Developer Programból):
> A provisioning profile is a collection of digital entities that uniquely ties developers and devices to an authorized iPhone Development Team and enables a device to be used for testing. A Development Provisioning Profile must be installed on each device on which you wish to run your application code. Each Development Provisioning Profile will contain a set of iPhone Development Certificates, Unique Device Identifiers and an App ID. Devices specified within the provisioning profile can be used for testing only by those individuals whose iPhone Development Certificates are included in the profile. A single device can contain multiple provisioning profiles.

### Tanusítvány létrehozása
Tegyük fel, hogy megvan az ingyenes Apple ID-nk ÉS hogy már van éves előfizetésünk. Kell egy Xcode, amihez hozzáférünk, amivel fejlesztünk. Elindítjuk, majd az Xcode menüben a **Preferences...** menüpontot választjuk.

![](images/iOS01.png?raw=true) 

Itt az Accounts fülön a **+** jel segítségével 

![](images/iOS02.png?raw=true) 

felvesszük az AppleID-nket az Xcode alkalmazásba.

![](images/iOS03.png?raw=true) 

A megjelenő ID-t válasszuk ki, majd a részletes nézeten nyomjunk a View Details gombra.

![](images/iOS04.png?raw=true) 

Itt az aláíró tanusítványok közül most az **iOS Distribution** az érdekes. *Itt a **Create** gomb csak akkor aktív, ha már van éves előfizetésünk*. Ha még nincs tanusítványunk, akkor látszik és megnyomható a **Create** gomb, amit megnyomva létrehozzuk a szükséges tanusítványt, majd le is töltjük az Xcode-ot futtató számítógépre.

![](images/iOS05.png?raw=true) 

Ha ez megtörtént, akkor a Create gomb eltűnik.

## Az eszköz(ök) regisztrációja 
A tesztelésre használt iPhone és iPad eszközöket regisztrálnunk kell az Apple Developer portálunkon. Ehhez [nyissuk meg a portált](https://developer.apple.com).

![](images/iOS06.png?raw=true) 

A portálon válasszuk az **Account** menüpontot, 

![](images/iOS07.png?raw=true) 

majd lépjünk be az azonosítónkkal.

![](images/iOS08.png?raw=true) 

A megjelenő menüben válasszuk ki a **Certificates, ISs & Profiles** menüpontot. Itt van lehetőségünk az aláíró tanusítványainkat kezelni, eszköz azonosítót rögzíteni, alkalmazás azonosítót létrehozni, és telepítési előírást (provisioning profile) készíteni.

![](images/iOS09.png?raw=true) 

Az eszköz rögzítéséhez válasszuk a baloldali menüben a **Devices/All** menüpontot,

![](images/iOS10.png?raw=true) 

majd a + jellel adjuk hozzá az eszközt.

![](images/iOS11.png?raw=true) 

A megjelenő űrlapon adhatunk egy tetszőleges nevet az eszköznek, és be kell rögzítenünk az eszköz UDID azonosítóját. Ennek meghatározásáról itt lehet részletesebben olvasni.

## Alkalmazás azonosító létrehozása

![](images/iOS12.png?raw=true) 

Az Apple Developer portálon a baloldali **Identifiers/App IDs** menüpontot választva, a + jellel tudunk új alkalmazást regisztrálni.

![](images/iOS13.png?raw=true) 

Itt töltsük ki az App ID description-t  és az Explicit App IDt, majd rögzítsük az azonosítót.

## Provisioning profile létrehozása

Ezzel kötjük ösze a tesztelendő eszköz(öke)t és az alkalmazást, majd aláírjuk a megfelelő tanusítvánnyal. Így biztosítjuk, hogy a tanusítvánnyal és a provisioning profile-lal ellátott gépen tudjunk BUILD-et futtatni, majd a felsorolt eszköz(ök)ön futtatni.

![](images/iOS14.png?raw=true) 

Létrehozáshoz válasszuk a Baloldali **Provisioning Profiles/All** menüpontot, és a már bevált + jelet. 

![](images/iOS15.png?raw=true) 

Majd válasszuk az Ad Hoc terítést, 

![](images/iOS16.png?raw=true) 

Válasszuk ki az alkalmazás azonosítót,

![](images/iOS16.png?raw=true) 

Válasszuk ki az **iOS Distribution**  aláíró tanusítványt

![](images/iOS18.png?raw=true) 

Majd végül az eszköz(öke)t, amire a telepítést szeretnénk végezni.

![](images/iOS19.png?raw=true) 

Végül adjunk egy megjegyezhető nevet.

## A Provisioning Profile telepítése az Xcode alá

Nyissuk meg az Xcode preferences menüjét, és hívjuk elő az AppleID-nkhez tartozó részletes információkat. Itt a Provisioning Profiles alatt megjelenik a most létrehozott profile, mellette egy **Download** gomb.

![](images/iOS20.png?raw=true) 

Nyomjuk meg ezt a gombot, és így ez az Xcode képessé válik a megfelelő BUILD futtatására.

![](images/iOS21.png?raw=true) 

Ha minden rendben, eltűnik a **Download** gomb a profile neve mellől.

## BUILD

![](images/iOS21.png?raw=true) 

A Visual Studio-ban a Day1.iOS legyen az induló projekt (jobb egérgomb a projekt nevén a *Solution Explorerben* majd a **Set as StartUp Project** menüpont)

![](images/iOS22.png?raw=true) 

Vissza tudjuk ellenőrizni a menüsorban.

![](images/iOS23.png?raw=true) 

A konfigurációnak ezúttal az **Ad-Hoc** konfigurációt állítsunk be, mert a Visual Studio nem teszi a végeredmény *.ipa állományt elérhetővé release módban.

![](images/iOS24.png?raw=true) 

Ellenőrizzük, hogy a Visual Studio kapcsolódik az Xcodehoz.

![](images/iOS25.png?raw=true) 

Futtassunk egy **REBUILD**-et, 

![](images/iOS26.png?raw=true) 

majd keressük meg az *.ipa állományt 

![](images/iOS27.png?raw=true) 

a bin/Ad-Hoc könyvtárunk alatt.

## Alkalmazás feltöltése a HockeyApp-ra
Nyissuk meg a HockeyApp oldalunkat, és hozzunk létre egy Alkalmazást a **New App** gombbal. A felugró ablakba húzzuk be az előző pontban lementett ipa csomagot.

![](images/android12.png?raw=true) 

Ezzel feltöltöttük a csomagot a HockeyApp-ra, és létrehoztunk egy alkalmazást.

![](images/android13.png?raw=true) 




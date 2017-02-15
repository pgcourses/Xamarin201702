# Fordítás iOS platformra és feltöltés a HockeyApp-ra, hogy telepíteni tudjunk iPhone készülékre az Interneten keresztül

## Előkészületek

A fizikai eszközön való tesztfuttatáshoz (az alkalmazás nem kerül ki az Apple App Store-ba) szükséges csomag létrehozásához szükséges a teljes azonosítása a következő négyesnek:
- fejlesztő
- BUILD számítógép
- Alkalmazás
- eszköz, amin tesztelünk

Ehhez 
- létre kell hoznunk egy ingyenes [AppleID-t](https://appleid.apple.com/), 
- létre kell hoznunk tanusítványt, ami azonosítja a fejlesztőt, 
- kell egy [Apple Developer előfizetés](https://developer.apple.com/programs/enroll/) (magánszemélyeknek egy évre 99 USD.)
- regisztrálni kell az eszközt az UDID azonosítójával, amin az alkalmazást tesztelni akarjuk
- létre kell hoznunk alkalmazás azonosítót,
- Ezeket össze kell kötnünk telepítési előírás segítségével (provisioning profile)

A provisioning profile leírása (az iPhone Developer Programból):
> A provisioning profile is a collection of digital entities that uniquely ties developers and devices to an authorized iPhone Development Team and enables a device to be used for testing. A Development Provisioning Profile must be installed on each device on which you wish to run your application code. Each Development Provisioning Profile will contain a set of iPhone Development Certificates, Unique Device Identifiers and an App ID. Devices specified within the provisioning profile can be used for testing only by those individuals whose iPhone Development Certificates are included in the profile. A single device can contain multiple provisioning profiles.

### Tanusítvány létrehozása
Tegyük fel, hogy megvan az ingyenes Apple ID-nk. Kell egy Xcode, amihez hozzáférünk, amivel fejlesztünk. Elindítjuk, majd az Xcode menüben a **Preferences...** menüpontot választjuk.

Itt az Accounts fülön a + jel segítségével 

felvesszük az AppleID-nket az Xcode alkalmazásba.

A megjelenő ID-t válasszuk ki, majd a részletes nézeten nyomjunk a View Details gombra.

Itt az aláíró tanusítványok közül az iOS Development az érdekes. Ha még nincs tanusítványunk, akkor látszik egy **Create** gomb, amit megnyomva létrehozzuk a szükséges tanusítványt, majd le is töltjük az Xcode-ot futtató számítógépre.

Ha ez megtörtént, akkor a Create gomb eltűnik.












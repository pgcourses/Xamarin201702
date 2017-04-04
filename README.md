# Xamarin201702
Kódtár kiegészítés a NetAcademia Xamarin tanfolyamához: http://www.netacademia.hu/xamarin-xamarin-fejlesztes-mobileszkozokre

## Telepítés tesztre

Az [Android](https://github.com/Xamarin201702/Xamarin201702/blob/master/Android.md) és az [iOS](https://github.com/Xamarin201702/Xamarin201702/blob/master/iOS.md) alkalmazásainkat ezek szerint a leírások szerint kell előkészíteni és feltölteni a HockeyApp-ra.

## Automatikus telepítés bétatesztre
Az [Android](https://github.com/Xamarin201702/Xamarin201702/blob/master/AndroidContinuousIntegration.md) projekt telepítéséről készült dokumentáció a linken elérhető.

## Összefoglalás
Ezen a tanfolyamon Windows platformon, C# nyelven Visual Studio 2015 Community és Xamarin.Forms segítségével olyan alkalmazásokat fogunk írni, amelyeket az adott platformra fordítva natív alkalmazásokat kapunk Windows, Android és iOS környezetben. A tanfolyam elsősorban C#/.NET fejlesztőknek hasznos, hiszen így a C# nyelv segítségével kiszabadulunk a Windows környezetből különböző mobil platformokra.

Mobil platformok közül elsősorban az **iOS** és az **Android** lesz terítéken, azért is, mert a Windows környezethez képest a Windows Phone nem tartalmaz nagy meglepetéseket, és azért is, mert a Windows Phone-ok elterjedtsége (sajnos) elenyésző a két vezető platformhoz képest. De a tanfolyamon emulátor szintjén, illetve az utolsó alkalommal a telepítéssel foglalkozó részben kitérünk a Windows Phone-ra is.

Úgy is felfogható, és talán ez a gondolat visz a legmesszebb, hogy ha szükségünk van olyan Windows alkalmazásra, ami modern Windows felületet használ, akkor érdemes a Xamarin.Forms könyvtárat használni. Két előnyt tudunk így begyűjteni: teljes értékű, modern Windows felületet tudunk programozni XAML leírónyelvvel, és ha jól írjuk a programunkat, akkor kevés átalakítással mobil környezetre is natív alkalmazást tudunk belőle készíteni.

Ahhoz, hogy ennek a sokszínűségnek valamennyi elemét ki tudjuk használni, néhány előkészületet kell megtennünk.

## Előkészületek
### Visual Studio 2015 Community + Xamarin telepítése
#### Ha egyszerre telepítünk VS2015 + Xamarin -t

A tanfolyamon **Windows 10** operációs rendszeren futó [Visual Studio 2015 Community](https://www.visualstudio.com/vs/community/) fejlesztői keretrendszert fogunk használni. Ingyenesen elérhető önálló fejlesztők, nyílt forráskódú projektek, akadémiai kutatók számára. Továbbá oktatási célokra és kis (max 5 fős) fejlesztőcsapatoknak.

A különböző Windows verziókon a telepítés eltérhet, mivel -ahogy látni fogjátok- a teljes eszköztár igen számos beállítást igényel, így én a Windows 10 használatából indulok ki, aki eltérő Windows-t használ, annak érdemes a tanfolyam előtt végignéznie a leírást, hogy az eltéréseket idejében tudja kezelni.

Letölteni az előző linkről [vagy innen](https://www.visualstudio.com/free-developer-offers/) lehet. Ehhez a tanfolyamhoz úgy kell telepíteni, hogy a mobil fejlesztési csomagot is feltesszük.

Vigyázni kell a telepítés helyével, az Android SDK/NDK együtt több, mint 6 GB helyet kér magának, és a Windows és Android telefonok virtuális képei is elvisznek legalább 4GB-ot.

Ami még fontos tudnivaló, hogy egyszerre egy virtualizációs technológiát támogat a processzor, Windows 8 és efölött a **HyperV** használata javasolt.

[Részletes cikk angol nyelven a Visual Studio 2015 és a 2015 Xamarin telepítésről](https://msdn.microsoft.com/en-us/library/mt613162.aspx)

#### Ha már meglévő VS2015 mellé telepítünk Xamarint
Előhívjuk a Visual Studio 2015 telepítőt a következő módon: 
Contol Panel -> Program and Features -> Visual Studio 2015 -> Change -> Modify

És (ha még nincsenek) bepipáljuk az alábbi elemeket:

a \Windows and Web Development\Universal Windows App Development Tools alatt az 
- **Emulators for Windows 10 Mobile**

A \Cross Platform Mobile Development  alatt a 
- **C#/.NET (Xamarin v...)**

A \Cross Platform Mobile Development\Common Tools and Software Development Kits alatt az
- **Android Native Development Kit**
- **Android SDK**
- **Android SDK Setup**
- **Java SE Development Kit**

### Tesztelés
Az elkészült kódunkat három eszköz segítségével tudjuk tesztelni. Az első vonal az *emulátorok* világa, ez a Windows és Android készülékekhez már települt, az iPhone-ról később lesz szó. A második vonal a fejlesztő gépéhez csatlakoztatott eszközök világa. Ez környezetenként eltérő módon viselkedik. A harmadik vonal pedig amikor tesztelésre távoli, valamilyen módon az Internetre kötött telefonra telepítjük a programunkat. Erről is a későbbiekben lesz szó, a HockeyApp regisztrációnál.

### Android tesztelés
Androidos készüléket legegyszerűbben USB kábel segítségével tudjuk a Windows fejlesztőgéphez csatlakoztatni. Ehhez a készüléknek Developer módban kell lennie, engedélyezni kell a telefonon az USB hibakezelést és ha kell, telepítenünk kell a megfelelő USB drivert. [Egy összefoglaló cikk a témában](https://developer.xamarin.com/guides/android/getting_started/installation/set_up_device_for_development/)

A későbbiekben, több telefonra való telepítéshez sem kell majd már más, mint a lejjebb összefoglalt HockeyApp regisztráció.

Ha a Google Play-re szeretnénnk elhelyezni az alkalmazásunkat, akkor viszont szükségünk lesz egy 25 USD összegű [Google Play Developer registration Fee kifizetésére](https://play.google.com/apps/publish/signup/).

### iOS tesztelés
Ez a dolog a Windows-os .NET fejlesztő számára az izgalmasabb rész. Ahhoz, hogy iOS-re alkalmazást tudjunk fordítani és emulátoron megnézni, a következőkre van **feltétlenül** szükségünk:
- egy **Apple ID**, amit a https://appleid.apple.com/ oldalon tudunk ingyenesen regisztrálni
- egy hálózaton elérhető, **Xcode fejlesztési környezet**, ami **OS X**-et futtató **Macintosh** számítógépen van telepítve. 

Akinek még nincs Mac számítógépe, annak egyik lehetőség például egy [Mac mini](http://www.apple.com/hu/mac-mini/) beszerzése, használtan már elérhető 150 ezer forint körül. A másik lehetőség, amit én is használok a tanfolyam során (és a Xamarin is ajánlja), előfizetés vásárlása a [MacInCloud](http://www.macincloud.com/pricing/compare) szolgáltatónál. Itt havi 10.000 forint körüli áron egy megfelelően előre telepített Macintosh számítógépet lehet napi 5 órára bérelni. Az Xcode-on kívül ezen a számítógépen

- telepítve és megfelelően konfigurálva kell, hogy legyen a [Xamarin.iOS](https://developer.xamarin.com/guides/ios/getting_started/installation/mac/).

A MacInCloud szolgáltatással elérhető gépeken ez már előre van telepítve, a tanfolyamon ilyen gépet használok, ezért ezt fogom tudni megmutatni.

Ha nem csak emulátorban szeretnénk futtatni alkalmazásunkat, akkor a következő lehetőségeink vannak.

- Ha **saját Mac számítógépünkhöz fizikailag kábellel a saját iPhone-unkat csatlakoztatjuk**, akkor egy ideje lehet időkódos telepítési engedélyt kérni az Apple-től, ez a [free-provisioning](https://developer.xamarin.com/guides/ios/getting_started/installation/device_provisioning/free-provisioning/).

Ha nem ez a helyzet, vagy nem csak egyetlen telefonon időkódos kipróbálásra, hanem több készüléken telepítve szeretnénk futtatni a programunkat, illetve az Apple Store-ba is szeretnénk elhelyezni, akkor [Apple Developer](https://developer.apple.com/app-store/subscriptions/) előfizetést kell vásárolnunk, ez [egy évre magánszemélyeknek 99 USD](). A tanfolyamon ezzel fogok dolgozni, ezt fogom tudni megmutatni, illetve, ezt használva telepítünk majd.

### HockeyApp regisztráció

A [HockeyApp](http://hockeyapp.net/) egy alkalmazás disztribúciós szolgáltatás, ami két alkalmazásig ingyenesen használható. A tanfolyamon az általunk gyártott alkalmazásból kettő lesz, egy Androidos és egy iOS-es, így az ingyenes terv keretein belül fogjuk tudni több telefonra is telepíteni a végeredményt.

Ahhoz, hogy a telefonra telepített alkalmazásunk a hibaüzeneteket (crash) felküldje, a következő lépéseket kell elvégezni. [Részletek itt](https://components.xamarin.com/gettingstarted/hockeyappandroid)

### Megjegyzés
Ha valakinek nincs Androidos vagy iOS-es eszköze, attól még fogja tudni követni a tanfolyamot, és mivel felvétel készül, később, ha mégis ilyen feladat kerül elő, felvételről át fogja tudni ismételni.

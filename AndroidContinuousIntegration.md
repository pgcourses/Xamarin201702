# Alkalmazás automatikus fordítása és feltöltése a HockeyApp-ra 

## Előkészületek

### VisualStudio.com regisztráció
Első lépésként egy regisztrációt kell készíteni a visualstudio.com oldalra:

![](images/visualstudio.png?raw=true)

Ehhez kell egy microsoft account, majd a kezdéshez meg kell adni egy értelmes dns nevet, én a xamarin201702-t választottam a tanfolyam nevére utalásként. 

![](images/visualstudio2.png?raw=true)

Ha ezzel megvagyunk, érdemes egy új projektet felvinni, (mert a my first project név nem feltétlenül informatív), a nevet, a leírást kitöltése után a kódtár típusát hagyjuk alapértelmezett állapotban a Git-en, mert így könnyen tudjuk szinkronizálni a kódot a GitHub-bal.

![](images/visualstudio3.png?raw=true)

### HockeyApp regisztráció AppId

A hockeyapp.com oldalon válasszuk ki a szervizmenüből a regisztráció beállításait:

![](images/hockeyapp01.png?raw=true)

innen pedig az API Tokens menüpontot:

![](images/hockeyapp02.png?raw=true)

majd nevezzük el a tokenünket, amit létrehozunk. Ezt a tokent fogja az automatikus build arra használni, hogy az alkalmazásunkat a hockeyapp-ra feltöltse és release-t készítsen belőle.

![](images/hockeyapp03.png?raw=true)

Jegyezzük meg az API Token értékét, ez kell majd a BUILD-hez:

![](images/hockeyapp04.png?raw=true)

### Aláírási tanusítvány felvétele a kódtárba

A Visual Studio-ban az Android projekten nyomjunk jobb egérgombot, 

![](images/keystore01.png?raw=true)

és válasszuk a **View Archives...** menüpontot, majd válasszuk ki az egyik talapítőcsomagot, és nyomjuk meg az **Open Folder** gombot:

![](images/keystore02.png?raw=true)

Ez megnyitja azt a könyvtárat, ahova a Xamarin az egyes csomagokat elmenti. 

![](images/keystore03.png?raw=true)

Itt navigáljunk ki a **Mono for Android** mappába, ott egyet be a **KeyStore** mappába, aztán tovább a solution mappába:

![](images/keystore04.png?raw=true)

Amire szükségünk van, az a *.keystore állomány.

**Figyelem:** Ha a tanusítványunkat nagyobb biztonságban szeretnénk tudni, vagyis nem szeretnénk feltölteni kódolatlan formában a forráskódkezelő kódtár(ak)ba, akkor nem ezt az állományt érdemes használni, hanem openssl segítségével des3 titkosítást használva jelszóval titkosíthatjuk ezt az állományt (például a [Windows Subsystem for Linux](https://msdn.microsoft.com/en-us/commandline/wsl/install_guide) segítségével, a következő parancssal: **openssl des3 -in xamarin201702.keystore -out xamarin2017.keystore.encrypted**, majd adjuk meg a titkosítás jelszavát.), és ezt az állományt használjuk a továbbiakban. Ebben az esetben a Build folyamatunkat ki kell egészíteni két lépéssel: 
 - Egyrészt az aláírás előtt vissza kell állítani a titkosított állományból az eredetit, méghozzá a Build folyamathoz adott **Decrypt File (OpenSSL)** lépéssel a **Utility** kategóriából
![](images/keystore05.png?raw=true)
 - Aláírás után pedig azonnal törölni kell a titkosítatlan állományt ugyancsak a **Utility** kategória **Delete Files** lépésével
![](images/keystore06.png?raw=true)

Az aláíró állományunkat másoljuk át a forráskódunkba, és töltsük fel a kódtárba:

![](images/keystore07.png?raw=true)

### A VisualStudio.com kódtár felvétele a visual studio projektbe

A visualstudio.com oldalon a megnyitott projektünk oldalán hívjuk elő a kódtárat:

![](images/visualstudio4.png?raw=true)

majd kattintsunk a Clone gombra, hogy hozzáférjünk a kódtár webes eléréséhez:

![](images/visualstudio5.png?raw=true)

ha ez megvan, másoljuk az url-t a vágólapra:

![](images/visualstudio6.png?raw=true)

Nyissuk meg a Visual Studio 2015-ben a projektünket, majd a Team Explorer ablakot, és kattintsunk a Home linkre.

![](images/visualstudio7.png?raw=true)

Majd a Settings gombot használva hozzáférünk a lokális GitHub kódtár beállításaihoz:

![](images/visualstudio8.png?raw=true)

Itt válasszuk ki a Repository Settings-t:

![](images/visualstudio9.png?raw=true)

vegyünk fel egy újabb Remote-ot, 

![](images/visualstudio10.png?raw=true)

nevezzük el, és másoljuk be a linket a vágólapról:

![](images/visualstudio11.png?raw=true)

### Kód feltöltése a Build szerverre

Ha megvagyunk, akkor ezzel készen vagyunk az előkészületekkel. Ha a Build kódtárba szeretnénk a kódunkat feltölteni, akkor ehhez nyissuk meg a Team Explorer ablakot, és kattintsunk a Home linkre.

![](images/visualstudio7.png?raw=true)

Majd a szinkronizálás linkre:

![](images/visualstudio12.png?raw=true)

**Figyelem:** Ha nem ezen a gépen fejlesztünk kizárólagosan, akkor ez előtt a lépés előtt le kell tölteni Pull paranccsal a GitHub kódtárból az utolsó változatot.

A megjelenő ablakban nyissuk le a **Push** gomb lenyílóját, 

![](images/visualstudio13.png?raw=true)

és célként válasszuk a most rögzített **Build** remote-ot:

![](images/visualstudio14.png?raw=true)

majd nyomjuk meg a **Push** gombot:

![](images/visualstudio15.png?raw=true)

Mivel szükséges hozzá, elképzelhető, hogy a Visual Studio megkér, hogy a Microsoft-os bejelentkezésünket erősítsük meg névvel és jeszóval. Ezt követően a kódunk a megfelelő *.visualstudio.com projekt kódtárába feltöltődik.

![](images/visualstudio16.png?raw=true)

Ellenőrizhetjük a weboldalon is:

![](images/visualstudio17.png?raw=true)

## Build definíció létrehozása

A visualstudio.com oldalon a projekten belül kattintsunk a **Build & Release** linkre:

![](images/visualstudio18.png?raw=true)

majd a **+New** gombra:

![](images/visualstudio19.png?raw=true)

(Bekapcsoltam az új build definíció szerkesztőt, így a képeken látható kinézet eltérhet a konkrét esetben, de a tartalom azonos.)

A megjelenő listából közül válasszuk ki a **Xamarin.Android** template-et:

![](images/visualstudio20.png?raw=true)

**Figyelem:** vegyük észre, hogy nem Visual Studio buildet használunk, hanem Xamarin Studio buildet.

A 
 - Xamarin component restore, 
 - a (Visual Studio) Build solution **/*test*.csproj és a 
 - Test $(build.binariesdirectory)

![](images/visualstudio21.png?raw=true)

lépések törölhetőek, ezekre ebben a megoldásban nem lesz szükség. Ami marad, az a következő:

![](images/visualstudio22.png?raw=true)

Menjünk végig az egyes Build lépéseken. 
- Első a **Get sources**, ez arra szolgál, hogy letöltsük a kódtárból a build ügyfél gépre a forráskódot. Érdemes bekapcsolni az Advanced settings láthatóságát, hogy minden paramétert lássunk, de nem állítunk az alapértelmezett beállításokon. Ha itt bekapcsoljuk a Clean kapcsolót, akkor mindig üres kódtárba húzzuk le a forráskódot, különben (ha ugyanazt a klienst kapjuk) a korábbi forráskódra csak az azóta keletkezett commit módosítások kerülnek. Ez sebességben jelenthet különbséget, illetve, ha módosítunk a forráskódon a Build során, akkor erre vigyázni kell.
![](images/visualstudio23.png?raw=true)
- A **Nuget restore **\*.sln*** arra szolgál, hogy a nuget csomagokat letöltsük a forráskód mellé. Ezeken a beállításokon sem érdemes módosítani.
![](images/visualstudio24.png?raw=true)
- A **Build Xamarin.Android** projekt lépésben figyelni kell a Java Developer Toolkit (JDK) beállításra, és be kell állítani **JDK8**-ra, mást nem kell átállítani.
![](images/visualstudio25.png?raw=true)
- A következő lépés a **Signing and aligning APK file**. Itt tallózuk ki a korábban feltöltött *.keystore állományt (opcionálisan egy lépéssel korábban dekódoljuk), pipáljuk be a **Sign the APK** és a **Zipalign** kapcsolókat, majd töltsük ki a jelszavakat és az Alias-t. 
![](images/visualstudio26.png?raw=true)
- Ha a változók közé felvesszük rejtettnek őket, akkor többet a felületről nem olvashatók, így a jelszavak nagyobb biztonságban vannak. Ebben az esetben a változó értékére **$(változónév)** formában hivatkozhatunk bármelyik mezőben.
![](images/visualstudio27.png?raw=true)
- Az (egyelőre) utolsó lépés a **Publish Artifact: drop** beállításain nem kell módosítani:
![](images/visualstudio28.png?raw=true)

Ha ezzel megvagyunk, indíthatunk egy Build-et a Save & queue linkkel:

![](images/visualstudio29.png?raw=true)

hogy az eddigiek működését ellenőrizzük. Ha ez jól lefutott, akkor folytathatjuk tovább, két fontos rész hiányzik a build folyamatunkból.

- Verziózás
- Feltöltés a HockeyApp oldalra

Mindkettőhöz kiegészítéseket kell telepítenünk a Visual Studio Marketplace-ről, méghozzá a **Browse Marketplace** menüpont segítségével innen:

![](images/visualstudio30.png?raw=true)

A hockeyapp integrációhoz telepítsük a hockeyapp extension-t, 

![](images/visualstudio32.png?raw=true)

A verziózáshoz telepítsük a **Colin's ALM Corner Build & Release Tools**-t:

![](images/visualstudio31.png?raw=true)

Ha ez megvan, menjünk vissza a Build definícióba, és a **+ Add Task** link segítségével adjunk hozzá három Version Assemblies lépést a Build kategóriából:

![](images/visualstudio33.png?raw=true)

és egy HockeyApp lépést a Deploy kategóriából:

![](images/visualstudio34.png?raw=true)

a következőképpen rendezve őket:

![](images/visualstudio35.png?raw=true)

A három **Version Assemblies** a **Build Xamarin.Android** lépés elé kerül, **HockeyApp** pedig a Build legvégére.

A beállításuk pedig a következő:
- A verziózáshoz öt lépés kell
  - Az Android projektben az AndroidManifest.xml állományban [be kell állítani az android:versionVode="1" és az android.versionName="0.0.1.0" értékeket](https://github.com/Xamarin201702/Xamarin201702/commit/9d5ca1af43a0bf55e91ca1ea346ec298dbc1efad#diff-b6d73f2899c5113bcef8a800557a69b9), ezt fogja majd az automatikus Build átírni. Ehhez a legcélszerűbb (ahelyett, hogy kézzel írnánk az AndroidManifext állományt) jobb egérgombot nyomni az Android projekten (**Day1.Droid**) és megnyitni a **Properties** menüpontot:
  ![](images/visualstudio46.png?raw=true)
  - majd az **Android Manifest** lapon beállítani a két értéket
  ![](images/visualstudio47.png?raw=true)
  - be kell állítani a Build verziószámát a Build definíció **Options** fülén a Build number format mezőben **0.0.1.$(BuildID)**, hogy legyen egy verziószámunk hasonlóan a [SemVer](http://semver.org/) szerint, ez 0.0.1 és a negyedik szám pedig a build sorszáma, amit ezen a visualstudio.com account-on valah összesen indítottunk. Így ez a szám egyedi lesz minden Build során, az első három sorszámot pedig a [SemVer](http://semver.org/) szerint kézzel állíthatjuk be.
  ![](images/visualstudio42.png?raw=true)
  - be kell állítani az AndroidManifest.xml android:versionCode mezőt, ehhez a android:versionCode="0" értéket kell átírni úgy, hogy a Build verzóból levágjuk az utolsó számot és beírjuk az android:versionCode="0" mezőbe a 0 helyére így
  ![](images/visualstudio45.png?raw=true)
  - be kell állítani az AndroidManifest.xml android:versionName mezőt, ehhez csak az AndroidManifest.xml állományt kell kiválasztani, a többi beállítást már hagyhatjuk alapértelmezett beállításokkal, így:
  ![](images/visualstudio43.png?raw=true)
  - végül, hogy a dll-ben lekérdezhető legyen a build verziószáma, és a felhasználónak meg tudjuk mutatni, az AssemblyInfo állomány beállítása kell, ehhez elég megadnunk a Portable projektünk megfelelő mappáját, így:
  ![](images/visualstudio44.png?raw=true)
  Ahhoz pedig, hogy ezt a verziószámot az alkalmazásból elérjük, [a következő lekérdezés segíthet](https://github.com/Xamarin201702/Xamarin201702/blob/master/Day1/Day1/Day1/View/Pages/About.xaml.cs#L19):
```
    var asmn = new AssemblyName(typeof(App).GetTypeInfo().Assembly.FullName);
    labelVersion.Text = asmn.Version.ToString();
```
- A HockeyApp beállításához 
  - fel kell vennünk a szervizek közé külső szolgáltatónak. Ehhez a fogaskerék ikonra kell kattintani a HockeyApp Connection mező mellett:
  ![](images/visualstudio36.png?raw=true)
  - Az új szerviz végpont felvitelénél kiválasztva a HockeyApp-ot
  ![](images/visualstudio37.png?raw=true)
  - A kapott ablakba fel kell vinni a a HockeyApp szerviz API Tokenjét, a megnevezés tetszőleges, csak a VisualStudio.com build-ben hivatkozunk majd ezzel a névvel.
  ![](images/visualstudio39.png?raw=true)
  - Miután ezzel megvagyunk, visszamegyünk a Build definícióra, és a **HockeyApp connection** mező mellett a frissítés ikonra kattintunk:
  ![](images/visualstudio40.png?raw=true)
  - be kell még állítanunk az App ID-t, célszerűen ezt is változóként titkosítva, itt az App ID mezőben pedig $(változónév) segítségével a titkos értéket betöltve.
  - meg kell adnunk a Binary File Path mezőben a következőt: **$(build.binariesdirectory)/$(BuildConfiguration)/*.apk**
  ![](images/visualstudio41.png?raw=true)
  - Mást a HockeyApp-nál nem kell beállítani.

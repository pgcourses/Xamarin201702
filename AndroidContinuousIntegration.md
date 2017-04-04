# Alkalmaz�s automatikus ford�t�sa �s felt�lt�se a HockeyApp-ra 

## El�k�sz�letek

### VisualStudio.com regisztr�ci�
Els� l�p�sk�nt egy regisztr�ci�t kell k�sz�teni a visualstudio.com oldalra:

![](images/visualstudio.png?raw=true)

Ehhez kell egy microsoft account, majd a kezd�shez meg kell adni egy �rtelmes dns nevet, �n a xamarin201702-t v�lasztottam a tanfolyam nev�re utal�sk�nt. 

![](images/visualstudio2.png?raw=true)

Ha ezzel megvagyunk, �rdemes egy �j projektet felvinni, (mert a my first project n�v nem felt�tlen�l informat�v), a nevet, a le�r�st kit�lt�se ut�n a k�dt�r t�pus�t hagyjuk alap�rtelmezett �llapotban a Git-en, mert �gy k�nnyen tudjuk szinkroniz�lni a k�dot a GitHub-bal.

![](images/visualstudio3.png?raw=true)

### HockeyApp regisztr�ci� AppId

A hockeyapp.com oldalon v�lasszuk ki a szervizmen�b�l a regisztr�ci� be�ll�t�sait:

![](images/hockeyapp01.png?raw=true)

innen pedig az API Tokens men�pontot:

![](images/hockeyapp02.png?raw=true)

majd nevezz�k el a token�nket, amit l�trehozunk. Ezt a tokent fogja az automatikus build arra haszn�lni, hogy az alkalmaz�sunkat a hockeyapp-ra felt�ltse �s release-t k�sz�tsen bel�le.

![](images/hockeyapp03.png?raw=true)

Jegyezz�k meg az API Token �rt�k�t, ez kell majd a BUILD-hez:

![](images/hockeyapp04.png?raw=true)

### Al��r�si tanus�tv�ny felv�tele a k�dt�rba

A Visual Studio-ban az Android projekten nyomjunk jobb eg�rgombot, 

![](images/keystore01.png?raw=true)

�s v�lasszuk a **View Archives...** men�pontot, majd v�lasszuk ki az egyik talap�t�csomagot, �s nyomjuk meg az **Open Folder** gombot:

![](images/keystore02.png?raw=true)

Ez megnyitja azt a k�nyvt�rat, ahova a Xamarin az egyes csomagokat elmenti. 

![](images/keystore03.png?raw=true)

Itt navig�ljunk ki a **Mono for Android** mapp�ba, ott egyet be a **KeyStore** mapp�ba, azt�n tov�bb a solution mapp�ba:

![](images/keystore04.png?raw=true)

Amire sz�ks�g�nk van, az a *.keystore �llom�ny.

**Figyelem:** Ha a tanus�tv�nyunkat nagyobb biztons�gban szeretn�nk tudni, vagyis nem szeretn�nk felt�lteni k�dolatlan form�ban a forr�sk�dkezel� k�dt�r(ak)ba, akkor nem ezt az �llom�nyt �rdemes haszn�lni, hanem openssl seg�ts�g�vel des3 titkos�t�st haszn�lva jelsz�val titkos�thatjuk ezt az �llom�nyt (p�ld�ul a [Windows Subsystem for Linux](https://msdn.microsoft.com/en-us/commandline/wsl/install_guide) seg�ts�g�vel, a k�vetkez� parancssal: **openssl des3 -in xamarin201702.keystore -out xamarin2017.keystore.encripted**, majd adjuk meg a titkos�t�s jelszav�t.), �s ezt az �llom�nyt haszn�ljuk a tov�bbiakban. Ebben az esetben a Build folyamatunkat ki kell eg�sz�teni k�t l�p�ssel: 
 - Egyr�szt az al��r�s el�tt vissza kell �ll�tani a titkos�tott �llom�nyb�l az eredetit, m�ghozz� a Build folyamathoz adott **Decrypt File (OpenSSL)** l�p�ssel a **Utility** kateg�ri�b�l
![](images/keystore05.png?raw=true)
 - Al��r�s ut�n pedig azonnal t�r�lni kell a titkos�tatlan �llom�nyt ugyancsak a **Utility** kateg�ria **Delete Files** l�p�s�vel
![](images/keystore06.png?raw=true)

Az al��r� �llom�nyunkat m�soljuk �t a forr�sk�dunkba, �s t�lts�k fel a k�dt�rba:

![](images/keystore07.png?raw=true)

### A VisualStudio.com k�dt�r felv�tele a visual studio projektbe

A visualstudio.com oldalon a megnyitott projekt�nk oldal�n h�vjuk el� a k�dt�rat:

![](images/visualstudio4.png?raw=true)

majd kattintsunk a Clone gombra, hogy hozz�f�rj�nk a k�dt�r webes el�r�s�hez:

![](images/visualstudio5.png?raw=true)

ha ez megvan, m�soljuk az url-t a v�g�lapra:

![](images/visualstudio6.png?raw=true)

Nyissuk meg a Visual Studio 2015-ben a projekt�nket, majd a Team Explorer ablakot, �s kattintsunk a Home linkre.

![](images/visualstudio7.png?raw=true)

Majd a Settings gombot haszn�lva hozz�f�r�nk a lok�lis GitHub k�dt�r be�ll�t�saihoz:

![](images/visualstudio8.png?raw=true)

Itt v�lasszuk ki a Repository Settings-t:

![](images/visualstudio9.png?raw=true)

vegy�nk fel egy �jabb Remote-ot, 

![](images/visualstudio10.png?raw=true)

nevezz�k el, �s m�soljuk be a linket a v�g�lapr�l:

![](images/visualstudio11.png?raw=true)

### K�d felt�lt�se a Build szerverre

Ha megvagyunk, akkor ezzel k�szen vagyunk az el�k�sz�letekkel. Ha a Build k�dt�rba szeretn�nk a k�dunkat felt�lteni, akkor ehhez nyissuk meg a Team Explorer ablakot, �s kattintsunk a Home linkre.

![](images/visualstudio7.png?raw=true)

Majd a szinkroniz�l�s linkre:

![](images/visualstudio12.png?raw=true)

**Figyelem:** Ha nem ezen a g�pen fejleszt�nk kiz�r�lagosan, akkor ez el�tt a l�p�s el�tt le kell t�lteni Pull paranccsal a GitHub k�dt�rb�l az utols� v�ltozatot.

A megjelen� ablakban nyissuk le a **Push** gomb leny�l�j�t, 

![](images/visualstudio13.png?raw=true)

�s c�lk�nt v�lasszuk a most r�gz�tett **Build** remote-ot:

![](images/visualstudio14.png?raw=true)

majd nyomjuk meg a **Push** gombot:

![](images/visualstudio15.png?raw=true)

Mivel sz�ks�ges hozz�, elk�pzelhet�, hogy a Visual Studio megk�r, hogy a Microsoft-os bejelentkez�s�nket er�s�ts�k meg n�vvel �s jesz�val. Ezt k�vet�en a k�dunk a megfelel� *.visualstudio.com projekt k�dt�r�ba felt�lt�dik.

![](images/visualstudio16.png?raw=true)

Ellen�rizhetj�k a weboldalon is:

![](images/visualstudio17.png?raw=true)

## Build defin�ci� l�trehoz�sa

A visualstudio.com oldalon a projekten bel�l kattintsunk a **Build & Release** linkre:

![](images/visualstudio18.png?raw=true)

majd a **+New** gombra:

![](images/visualstudio19.png?raw=true)

(Bekapcsoltam az �j build defin�ci� szerkeszt�t, �gy a k�peken l�that� kin�zet elt�rhet a konkr�t esetben, de a tartalom azonos.)

A megjelen� list�b�l k�z�l v�lasszuk ki a **Xamarin.Android** template-et:

![](images/visualstudio20.png?raw=true)

**Figyelem:** vegy�k �szre, hogy nem Visual Studio buildet haszn�lunk, hanem Xamarin Studio buildet.

A 
 - Xamarin component restore, 
 - a (Visual Studio) Build solution **/*test*.csproj �s a 
 - Test $(build.binariesdirectory)

![](images/visualstudio21.png?raw=true)

l�p�sek t�r�lhet�ek, ezekre ebben a megold�sban nem lesz sz�ks�g. Ami marad, az a k�vetkez�:

![](images/visualstudio22.png?raw=true)

Menj�nk v�gig az egyes Build l�p�seken. 
- Els� a **Get sources**, ez arra szolg�l, hogy let�lts�k a k�dt�rb�l a build �gyf�l g�pre a forr�sk�dot. �rdemes bekapcsolni az Advanced settings l�that�s�g�t, hogy minden param�tert l�ssunk, de nem �ll�tunk az alap�rtelmezett be�ll�t�sokon. Ha itt bekapcsoljuk a Clean kapcsol�t, akkor mindig �res k�dt�rba h�zzuk le a forr�sk�dot, k�l�nben (ha ugyanazt a klienst kapjuk) a kor�bbi forr�sk�dra csak az az�ta keletkezett commit m�dos�t�sok ker�lnek. Ez sebess�gben jelenthet k�l�nbs�get, illetve, ha m�dos�tunk a forr�sk�don a Build sor�n, akkor erre vigy�zni kell.
![](images/visualstudio23.png?raw=true)
- A **Nuget restore **\*.sln*** arra szolg�l, hogy a nuget csomagokat let�lts�k a forr�sk�d mell�. Ezeken a be�ll�t�sokon sem �rdemes m�dos�tani.
![](images/visualstudio24.png?raw=true)
- A **Build Xamarin.Android** projekt l�p�sben figyelni kell a Java Developer Toolkit (JDK) be�ll�t�sra, �s be kell �ll�tani **JDK8**-ra, m�st nem kell �t�ll�tani.
![](images/visualstudio25.png?raw=true)
- A k�vetkez� l�p�s a **Signing and aligning APK file**. Itt tall�zuk ki a kor�bban felt�lt�tt *.keystore �llom�nyt (opcion�lisan egy l�p�ssel kor�bban dek�doljuk), pip�ljuk be a **Sign the APK** �s a **Zipalign** kapcsol�kat, majd t�lts�k ki a jelszavakat �s az Alias-t. 
![](images/visualstudio26.png?raw=true)
- Ha a v�ltoz�k k�z� felvessz�k rejtettnek �ket, akkor t�bbet a fel�letr�l nem olvashat�k, �gy a jelszavak nagyobb biztons�gban vannak. Ebben az esetben a v�ltoz� �rt�k�re **$(v�ltoz�n�v)** form�ban hivatkozhatunk b�rmelyik mez�ben.
![](images/visualstudio27.png?raw=true)
- Az (egyel�re) utols� l�p�s a **Publish Artifact: drop** be�ll�t�sain nem kell m�dos�tani:
![](images/visualstudio28.png?raw=true)

Ha ezzel megvagyunk, ind�thatunk egy Build-et a Save & queue linkkel:

![](images/visualstudio29.png?raw=true)

hogy az eddigiek m�k�d�s�t ellen�rizz�k. Ha ez j�l lefutott, akkor folytathatjuk tov�bb, k�t fontos r�sz hi�nyzik a build folyamatunkb�l.

- Verzi�z�s
- Felt�lt�s a HockeyApp oldalra

Mindkett�h�z kieg�sz�t�seket kell telep�ten�nk a Visual Studio Marketplace-r�l, m�ghozz� a **Browse Marketplace** men�pont seg�ts�g�vel innen:

![](images/visualstudio30.png?raw=true)

A hockeyapp integr�ci�hoz telep�ts�k a hockeyapp extension-t, 

![](images/visualstudio32.png?raw=true)

A verzi�z�shoz telep�ts�k a **Colin's ALM Corner Build & Release Tools**-t:

![](images/visualstudio31.png?raw=true)

Ha ez megvan, menj�nk vissza a Build defin�ci�ba, �s a **+ Add Task** link seg�ts�g�vel adjunk hozz� h�rom Version Assemblies l�p�st a Build kateg�ri�b�l:

![](images/visualstudio33.png?raw=true)

�s egy HockeyApp l�p�st a Deploy kateg�ri�b�l:

![](images/visualstudio34.png?raw=true)

a k�vetkez�k�ppen rendezve �ket:

![](images/visualstudio35.png?raw=true)

A h�rom **Version Assemblies** a **Build Xamarin.Android** l�p�s el� ker�l, **HockeyApp** pedig a Build legv�g�re.

A be�ll�t�suk pedig a k�vetkez�:
- A verzi�z�shoz �t l�p�s kell
  - Az Android projektben az AndroidManifest.xml �llom�nyban [be kell �ll�tani az android:versionVode="1" �s az android.versionName="0.0.1.0" �rt�keket](https://github.com/Xamarin201702/Xamarin201702/commit/9d5ca1af43a0bf55e91ca1ea346ec298dbc1efad#diff-b6d73f2899c5113bcef8a800557a69b9), ezt fogja majd az automatikus Build �t�rni. Ehhez a legc�lszer�bb (ahelyett, hogy k�zzel �rn�nk az AndroidManifext �llom�nyt) jobb eg�rgombot nyomni az Android projekten (**Day1.Droid**) �s megnyitni a **Properties** men�pontot:
  ![](images/visualstudio46.png?raw=true)
  - majd az **Android Manifest** lapon be�ll�tani a k�t �rt�ket
  ![](images/visualstudio47.png?raw=true)
  - be kell �ll�tani a Build verzi�sz�m�t a Build defin�ci� **Options** f�l�n a Build number format mez�ben **0.0.1.$(BuildID)**, hogy legyen egy verzi�sz�munk hasonl�an a [SemVer](http://semver.org/) szerint, ez 0.0.1 �s a negyedik sz�m pedig a build sorsz�ma, amit ezen a visualstudio.com account-on valah �sszesen ind�tottunk. �gy ez a sz�m egyedi lesz minden Build sor�n, az els� h�rom sorsz�mot pedig a [SemVer](http://semver.org/) szerint k�zzel �ll�thatjuk be.
  ![](images/visualstudio42.png?raw=true)
  - be kell �ll�tani az AndroidManifest.xml android:versionCode mez�t, ehhez a android:versionCode="0" �rt�ket kell �t�rni �gy, hogy a Build verz�b�l lev�gjuk az utols� sz�mot �s be�rjuk az android:versionCode="0" mez�be a 0 hely�re �gy
  ![](images/visualstudio45.png?raw=true)
  - be kell �ll�tani az AndroidManifest.xml android:versionName mez�t, ehhez csak az AndroidManifest.xml �llom�nyt kell kiv�lasztani, a t�bbi be�ll�t�st m�r hagyhatjuk alap�rtelmezett be�ll�t�sokkal, �gy:
  ![](images/visualstudio43.png?raw=true)
  - v�g�l, hogy a dll-ben lek�rdezhet� legyen a build verzi�sz�ma, �s a felhaszn�l�nak meg tudjuk mutatni, az AssemblyInfo �llom�ny be�ll�t�sa kell, ehhez el�g megadnunk a Portable projekt�nk megfelel� mapp�j�t, �gy:
  ![](images/visualstudio44.png?raw=true)
  Ahhoz pedig, hogy ezt a verzi�sz�mot az alkalmaz�sb�l el�rj�k, [a k�vetkez� lek�rdez�s seg�thet](https://github.com/Xamarin201702/Xamarin201702/blob/master/Day1/Day1/Day1/View/Pages/About.xaml.cs#L19):
```
    var asmn = new AssemblyName(typeof(App).GetTypeInfo().Assembly.FullName);
    labelVersion.Text = asmn.Version.ToString();
```
- A HockeyApp be�ll�t�s�hoz 
  - fel kell venn�nk a szervizek k�z� k�ls� szolg�ltat�nak. Ehhez a fogasker�k ikonra kell kattintani a HockeyApp Connection mez� mellett:
  ![](images/visualstudio36.png?raw=true)
  - Az �j szerviz v�gpont felvitel�n�l kiv�lasztva a HockeyApp-ot
  ![](images/visualstudio37.png?raw=true)
  - A kapott ablakba fel kell vinni a a HockeyApp szerviz API Tokenj�t, a megnevez�s tetsz�leges, csak a VisualStudio.com build-ben hivatkozunk majd ezzel a n�vvel.
  ![](images/visualstudio39.png?raw=true)
  - Miut�n ezzel megvagyunk, visszamegy�nk a Build defin�ci�ra, �s a **HockeyApp connection** mez� mellett a friss�t�s ikonra kattintunk:
  ![](images/visualstudio40.png?raw=true)
  - be kell m�g �ll�tanunk az App ID-t, c�lszer�en ezt is v�ltoz�k�nt titkos�tva, itt az App ID mez�ben pedig $(v�ltoz�n�v) seg�ts�g�vel a titkos �rt�ket bet�ltve.
  - meg kell adnunk a Binary File Path mez�ben a k�vetkez�t: **$(build.binariesdirectory)/$(BuildConfiguration)/*.apk**
  ![](images/visualstudio41.png?raw=true)
  - M�st a HockeyApp-n�l nem kell be�ll�tani.
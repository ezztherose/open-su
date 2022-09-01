# SU-Projekt

## Inlogg f�r olika anv�ndare
#### Reception
- anv�ndarnamn: jacob
- l�senord: jacob

#### Butik
- anv�ndarnamn: Tommy
- l�senord: tommy

#### Skidskola
- anv�ndarnamn: admin
- l�senord: admin

#### Skidl�rare
- anv�ndarnamn: emmy
- l�senord: emmy

## Hur man jobbar med "Fork" p� GitHub
- Hur fork fungerar: https://www.youtube.com/watch?v=HbSjyU2vf6Y
- Hur Github fungerar i Visual Studio: https://www.youtube.com/watch?v=jUiuIAZt6Dw
- Hur branches fungerar: https://www.youtube.com/watch?v=QV0kVNvkMxc
- ihops�ttning av branches: https://www.youtube.com/watch?v=XX-Kct0PfFc

## �verblick p� struktur
![�verblic](Doc/�verblick.png)

## F�r att f� ladda upp kod p� GitHub
1. Ta ner existerande kod fr�n GitHub
2. Koden som du sj�lv skriver m�ste fungera.
3. Pusha upp den nya koden. Skriv kommentar om vad som har gjorts.

## Standard: Notation
### Arv
- N�r man skall �rva fr�n en klass, �rv fr�n dess Interface ist�llet f�r klassen.

### Classer och interfaces
Classer skall b�rja med versal f�ljt av kamelnotation
```
GenericRepository
```

Interfaces skall b�rja "I" f�ljt av classens namn, d�r f�rsta tecekn skall vara versal f�ljt av kamelnotation
```
IGenericRepository
```

### Funktioner & Variabler
Funktioner b�rjar med versal och f�ljer sedan kamelnotationen. 
- AddKund()

Variabler kommer att se olika ut beroende p� om de �r **public** eller **private**.
- Public: b�rjar med sm� bokst�ver och f�ljer sedan kamelnotation. 
```
public string lastName
```

- Private: b�rjar med "_", sedan liten bokstav och efter det f�ljer den kamelnotation. 
```
private string _lastName
```

### Objekt i GUI
Kommer att anv�nda kamelnotation under arbetets g�ng med en f�rkortning av det objekt man skall anv�nda framf�r.
- TextBox: tb. Kommer att se f�ljande ut: tbFaktura.
- Label: lbl. Kommer att se f�ljande ut: lblFakturor.
- Forms: frm. Kommer att se f�ljande ut: frmAdmin.
- Buttons: btn. Kommer att se f�ljande ut: btnSpara.
- GridView: gv. Kommer att se f�ljande ut: gvKund.

## Skicka med vin inloggning
- en textfil med inloggningsuppgifter f�r de olika rollerna

## Ers�ttning f�r caluburn micro
**VI UNDVIKER WPF**
Alternativ:
- MVVM Light: https://github.com/lbugnion/mvvmlight (1)
- Prism: https://github.com/PrismLibrary/Prism (2)
- Catel: https://github.com/Catel/Catel (3)
- Stylet: https://github.com/canton7/Stylet (4)
- ReactiveUI: https://github.com/reactiveui/ReactiveUI (5)
- MvvmCross: https://www.mvvmcross.com/ (6)

Vilken av dessa ska vi anv�nda?

## GitHub WorkFlow - Terminal
### 1. Fetch
Kontrollerar om det har kommit n�gra nya "commits"

### 2. Pull 
Tar hem den senaste versionen

```
git pull origin
```
### 3. Branches
kolla vilken branch mman beginner sig i 

```
git branch
```

Byt branch

```
git checkout <branchName>
```

### 4. Kodning
Utvecklar applikationen p� sin egna lokala maskin.

Kontrollera s� att koden har kompilerats

### 5. Commit & Push
Commit skapar en ny version och push trycker upp den till github

L�gg till den nya koden/�ndringar som skall l�ggas till
```
git add . (inte bra)
git add "filnamn" (bra)
```

Skapa en commit
```
git commit -m "kommentar (byt ut till det man gjort)"
```

Skicka koden till GitHub
```
git push origing "but ut till branch"
```

## F�r GitHub
1. stash (sitt egna projekt)
2. pull fr�n master
3. commit stash (viktigt med kommentar)

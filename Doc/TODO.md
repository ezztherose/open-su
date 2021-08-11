# TODO
---

**Inf�r inl�mning 3**
- Kolla �ver datetimepicker i Konferens
- Gruppskidlektion
	- Skidl�rare
	- Det g�r inte att s�ka p� lektionen
- UX design (designen f�r alla forms --> g�r dem b�ttre s� att det �r l�tt att anv�nda)
- Felhantering

## hellu
**ALL LOGIK G�RS I BUSINESSLAYER**

```
public FacadeBusiness FacadeBusiness { get; set; }
```

i konstruktorn 
```
FacadeBusiness = new FacadeBusiness();
```

F�r att anropa Facade
```
FacFacadeBusiness.Facde(specifik).Metod();
```

- kolla �ver s� att det finns if-satser som kontrolerar att alla retur-v�rden inte e null, om de e null --> k�r en MessageBox.Show("")
- Kolla p� GridViews i GUI_Layer
	- Mata in r�tt listor i r�tt gridview
	- funktionalitet i GUT (ex: knappar textbox) --> textboxar sparar v�rden till en variabel (string)
		- Kanppar: om de e en gridview --> s� ska selectedRow omsluta exeverande kod med en if-sats, om ingen rad �r valr visa messageBox
	- Kolla �ver HideColum-metoderna och d�lj on�dig data

- bygg ut med mer "avancerad" filtering av funktionalitet (g�r r��t sak p� r�tt st�lle)

P�b�rja lite funktionalitet p� forms som inte har r�rts �n... 
	- ex: h�mta priser, 




## n
- CRUD - Facade (Yasin)
- Fixa till databastabeller
	- LogiPris: ID, Typ, Period, Vecka, Dagar, Pris, LogiID
	- Uthyrning: ID, Pris, AntalDagar, ArtikelID
	- Skidskola: ID, Kunskapsniv�?, Period, Pris, SkidskolaID 
- Funktionalitet i Forms:
	- Uthyrning (n�gon kollar �ver)
	- Bokning: beh�ver fixas
	- L�gga till kund, personal (l�ttare)
	- Hoppa runt i formsen (l�ttare)
	- Bel�ggningsStatistik (Tommy)
	- Fylla i GridViews med respektive lista (l�ttare)
	- L�gga till variabler + setter/getter [propfull + tab + tab] (Se till att koden ligger strukturerat)


## Ladda upp filer
- EJ FILER MED .caiche
- EJ FILEM MED .debug
- EJ FILEM MED .bin 

## Tabeller
- UtrustningPriser: skapa prisregister
- Utrustningen --> ha en tabell som endast h�ller koll p� hur mycket som har l�nats ut
	- G� p� ID och r�kna ut 
- Logi: LogiPri (in med LogiID)
	- H�lla koll p� allt som l�nats ut, egen tabell

## Handledning 2020-10-26
- Beh�vs getter/setter?
- Instans p� en egen tidsperiod
- Boka v.51 --> LogiBokning (matcha med de som den nya kunden vill boka) --> j�mf�r LogiBokning med Bokning
	- Popup: Bokad else utf�r bokning

- Utrustning: s�tta flagga tills �terl�mnad (bool)
- G�r om Utrustning till spcifika rader

### Bel�ggningsstatistik
- Period eller lista?
- Vecak eller ses�ng?
	- Ta bort datum och bara ha ses�ng: bara vinter eller sommar
	- Eller ska det vara 4s?
- Vad ska vara i Excel?
	- Kolla bilagor
	- Se bokade och ickebokade 
	- Gridview eller bara comboboxar? 







## RÖR EJ
- Butik formet

## Påbörjade
- Bokning
	- PrivatKund, gör samma för BokningFöretag
	- [] Kolla CRUD (Create, Read, Update, Delete) i Marknadschef så att den fungerar på alla delar

## Forms
- [] Skriva klart koden på formsen
- [] Mata in listor till formsen
- [] Kolla CRUD (Create, Read, Update, Delete) i SysAdmin så att den fungerar på alla delar

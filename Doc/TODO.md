# TODO
---

**Inför inlämning 3**
- Kolla över datetimepicker i Konferens
- Gruppskidlektion
	- Skidlärare
	- Det går inte att söka på lektionen
- UX design (designen för alla forms --> gör dem bättre så att det är lätt att använda)
- Felhantering

## hellu
**ALL LOGIK GÖRS I BUSINESSLAYER**

```
public FacadeBusiness FacadeBusiness { get; set; }
```

i konstruktorn 
```
FacadeBusiness = new FacadeBusiness();
```

För att anropa Facade
```
FacFacadeBusiness.Facde(specifik).Metod();
```

- kolla över så att det finns if-satser som kontrolerar att alla retur-värden inte e null, om de e null --> kör en MessageBox.Show("")
- Kolla på GridViews i GUI_Layer
	- Mata in rätt listor i rätt gridview
	- funktionalitet i GUT (ex: knappar textbox) --> textboxar sparar värden till en variabel (string)
		- Kanppar: om de e en gridview --> så ska selectedRow omsluta exeverande kod med en if-sats, om ingen rad är valr visa messageBox
	- Kolla över HideColum-metoderna och dölj onödig data

- bygg ut med mer "avancerad" filtering av funktionalitet (gör räät sak på rätt ställe)

Påbörja lite funktionalitet på forms som inte har rörts än... 
	- ex: hämta priser, 




## n
- CRUD - Facade (Yasin)
- Fixa till databastabeller
	- LogiPris: ID, Typ, Period, Vecka, Dagar, Pris, LogiID
	- Uthyrning: ID, Pris, AntalDagar, ArtikelID
	- Skidskola: ID, Kunskapsnivå?, Period, Pris, SkidskolaID 
- Funktionalitet i Forms:
	- Uthyrning (någon kollar över)
	- Bokning: behöver fixas
	- Lägga till kund, personal (lättare)
	- Hoppa runt i formsen (lättare)
	- BeläggningsStatistik (Tommy)
	- Fylla i GridViews med respektive lista (lättare)
	- Lägga till variabler + setter/getter [propfull + tab + tab] (Se till att koden ligger strukturerat)


## Ladda upp filer
- EJ FILER MED .caiche
- EJ FILEM MED .debug
- EJ FILEM MED .bin 

## Tabeller
- UtrustningPriser: skapa prisregister
- Utrustningen --> ha en tabell som endast håller koll på hur mycket som har lånats ut
	- Gå på ID och räkna ut 
- Logi: LogiPri (in med LogiID)
	- Hålla koll på allt som lånats ut, egen tabell

## Handledning 2020-10-26
- Behövs getter/setter?
- Instans på en egen tidsperiod
- Boka v.51 --> LogiBokning (matcha med de som den nya kunden vill boka) --> jämför LogiBokning med Bokning
	- Popup: Bokad else utför bokning

- Utrustning: sätta flagga tills återlämnad (bool)
- Gör om Utrustning till spcifika rader

### Beläggningsstatistik
- Period eller lista?
- Vecak eller sesång?
	- Ta bort datum och bara ha sesång: bara vinter eller sommar
	- Eller ska det vara 4s?
- Vad ska vara i Excel?
	- Kolla bilagor
	- Se bokade och ickebokade 
	- Gridview eller bara comboboxar? 







## RÃ–R EJ
- Butik formet

## PÃ¥bÃ¶rjade
- Bokning
	- PrivatKund, gÃ¶r samma fÃ¶r BokningFÃ¶retag
	- [] Kolla CRUD (Create, Read, Update, Delete) i Marknadschef sÃ¥ att den fungerar pÃ¥ alla delar

## Forms
- [] Skriva klart koden pÃ¥ formsen
- [] Mata in listor till formsen
- [] Kolla CRUD (Create, Read, Update, Delete) i SysAdmin sÃ¥ att den fungerar pÃ¥ alla delar

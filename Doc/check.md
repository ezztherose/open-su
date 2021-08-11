# --- Checka ---
## ButikSkiduthyrning
#### Formet
- Knapp: TaBortUthyrning --> Behövs denna?
- Knapp: TillUtskrift --> Ska denna skrivas ut nu direkt?
	- Om man ska kunna skriva ut, är det bättre att flytta "Excel" koden till en klass?
- Paket: Kolla hur det blir om man skall ta bort en sak, ska alla delar i paketet bort?
- Uppdatera formet efter olika knapptryck har lyckats

#### Koden
- Snygga till koden, ta bort kommentarer, kolla om man kan använda mindre "props" 
- Felhantering 
- Kolla "Tillgänglighet" --> Om utlånad == false;

## Bokning Av Logi
#### Form
- Uppdatera GUI
	- Gridviews --> skall uppdateras efter varjr lyckat knaptryck (som har med gridview att göra)
	- Knappar --> Länka till metoder

#### Kod
- Kodlogik
	- All kod som inte har med gui-delar att göra --> **SKALL LIGGA I FACADE (BUSINESS-LAYER)** 


## Skidskola klasser
Hur kopplar de samman, vart ska alla saker?

## frmLogipris
#### Kod
- Kolla upp Pris samt anrop av metoden?

## Lazy loading


## Handledning 2020-11-04
#### Databasen
- Faktura till kund --> Faktura tabellen i databasen
	- Matcha FakturaTabell (kundid) om privatkund/företagkund ID

#### Butikformen
- Saknar referens till ButikSkiduthyrning constructor.
	- konvertera allt explisit
	
#### Convert to Excel
- Bokning boknings ID f--> för att veta när det gäller
	- Kolla datum --> in/ut-checkning
	- Går till bokning logibokning
	- SLutändan räknar man hur många man får
- Boknings bekreftelse --> till word

## Blandat
[rader, columner]

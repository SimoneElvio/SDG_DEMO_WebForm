# SDG_DEMO_WebForm

## Requisiti software

- Visual Studio 2015
- SQL Server 2015 (o successivo)

## Configurazione database

Scarica il file .zip dalla cartella ***database*** ed esegui il restore in SQL Server.

Al suo interno troverai una serie di tabelle.
- Audit: storico accessi
- Errori: tracciamento errori
- Utenti: anagrafica utenti

## Configurazione Visual Studio
Dopo aver effettuato il download del progetto, occorre configurarlo come segue:
- Web.config: modificare la stringa di connessione inserendo l'utente e la password configurati per l'accesso
- nelle proprietà del progetto impostare il framework 4.5
- settare ___default.aspx___ come pagina di avvio del progetto

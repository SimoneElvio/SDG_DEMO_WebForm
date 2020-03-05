# SDG_DEMO_WebForm

## Requisiti software

- Visual Studio 2015
- SQL Server 2015 (o successivo)

## Configurazione Visual Studio
Dopo aver effettuato il download del progetto, occorre configurarlo come segue:
- Web.config: modificare la stringa di connessione inserendo l'utente e la password configurati per l'accesso
- nelle proprietà del progetto impostare il framework 4.5
- settare ___default.aspx___ come pagina di avvio del progetto

## Configurazione database

Scarica il file .zip dalla cartella ***database*** ed esegui il restore in SQL Server.

Al suo interno troverai una serie di tabelle.

**Tabella**|**Descrizione**
-----|-----
AUDIT| 
AZIONI|*
CAMPI\_NASCOSTI\_CLIENTE|Configurazione campi editor
CENTRI\_DI\_COSTO|*
CLIENTI|*
CONFIGURATION\_SETTING|Tabella di configurazione path
CROSS\_CLIENTE\_RUOLI|*
CROSS\_CLIENTE\_WORKFLOW|*
CROSS\_GRUPPI\_CLIENTE\_UTENTI|*
CROSS\_UTENTE\_CLIENTE|Tabella di cross tra Utente e Cliente
DIZIONARIO|Contiene tutti i testi presenti nel progetto (label, alert, titoli) in doppia lingua
ERRORI|Elenco degli errori registrati dal sistema
FUNZIONALITA|Elenco delle funzionalità del sistema
GRUPPI\_CLIENTE|*
LOCK|Record in uso
LOOKUP\_SOCIETA\_CLIENTE|*
LOOKUP\_TIPO\_INSTALLAZIONE|*
MAIL\_TEMPLATE|*
ObjectOwner|*
PERMESSI\_LOOKUP|Elenco delle tipologie di permesso
PERMESSO\_ACCESSO|Cross tra Ruoli, Funzionalità e Permesso
RUOLI|Elenco dei Ruoli del sistema
RUOLI\_UTENTE|Cross tra Ruoli e Utenti
SESSIONI\_UTENTI|Numero di sessioni aperte per ogni utente. Solitamente dovrebbe essere solo 1
SISTEMA|Altre configurazioni di base in aggiunta alla tabella CONFIGURATION\_SETTING
TESTI\_PAGINE|*
UTENTE|Anagrafica utenti



!(logo_piccolo_blu.jpg) # SDG_DEMO_WebForm

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
L'utenza di riferimento per accedere al database è ***sdg_sviluppo***

### Tabelle ###

Al suo interno troverai le seguenti tabelle. Quelle indicate con * non hanno importanza ai fini del training, mentre le altre sono tabelle che troverai anche in altri nostri progetti, con la stessa struttura.

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
UTENTE|Anagrafica utenti. La password è criptata, nel caso fosse necessario resettarla questo codice E7-E2-B6-A2-77-30-60-BE-B7-A1-17-A3-21-34-C1-83 corrisponde a ***password%***


### Stored Procedure ###

Nella sezione Stored Procedure sono disponibili per la consultazione le seguenti procedure:

**Procedura**|**Descrizione**
-----|-----
spAggiungiFunzionalita|Utilizzata in tutti i progetti per inserire nuove funzionalità senza passare da maschera
spCheckTravelPolicy|Esempio di elaborazione dati. Effettua dei controlli sui dati salvati in una richiesta viaggio
spDeleteExpiredLock|Reset dei lock rimasti appesi. Viene chiamata ciclicamente da un job per svuotare le sessioni
spGetTestoTagged|Esempio di elaborazione dati su tag testuali. Utilizzato nella creazione di mail da inviare ai clienti
Where_Am_I|Utilizzata in tutti i progetti. Serve per effettuare ricerche di stringhe in tutte le stored procedure del db

### Naming convention ###

Le tabelle con funzione di anagrafica hanno solamente il nome che le identifica (UTENTE, RUOLI, CLIENTI, ...)

Le tabelle con funzione di lookup sono precedute dalla parola ***LOOKUP*** (LOOKUP_TIPO_CLIENTE, LOOKUP_TIPO_INDIRIZZO, ...)

Le tabelle con funzione di cross tra due o più tabelle sono precedute dalla parola ***CROSS*** (CROSS_CLIENTE_RUOLI, CROSS_UTENTE_CLIENTE, ...)

I campi delle tabelle iniziano sempre con un triletterale che le identifica:
- CLI per i clienti
- UTE per gli utenti

Il triletterale dei campi delle lookup inizia solitamente con la lettera L.

Il triletterale dei campi delle cross inizia solitamente con la lettera C.

In tutte le tabelle sono sempre presenti i seguenti campi:
- [ACRONIMO]_ID_[NOME_TABELLA]
- [ACRONIMO]_ID_CREATO_DA
- [ACRONIMO]_ID_AGGIORNATO_DA
- [ACRONIMO]_ID_ELIMINATO_DA
- [ACRONIMO]_DATA_CREAZIONE
- [ACRONIMO]_DATA_AGGIORNAMENTO
- [ACRONIMO]_FLAG_ELIMINATO

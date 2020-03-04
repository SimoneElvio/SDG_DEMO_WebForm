// ---------------------------------------------------------------------------
// Progetto:    Broking System
// Nome File:   date.js
//
// Namespace:   BusinessObjects.Anagrafiche
// Descrizione: useful extensions to the JavaScript Date object.
//
// Autore:      SE - SDG srl
// Data:        31/05/2012
// ---------------------------------------------------------------------------
// Storia delle revisioni
// Autore:      
// Data:        
// Motivo:
// Rif. ECR:
// ---------------------------------------------------------------------------

// literals *******************************************************************

// used as param unit in Date.add()
Date.MILLI = 1;
Date.SECOND = Date.MILLI * 1000;
Date.MINUTE = Date.SECOND * 60;
Date.HOUR = Date.MINUTE * 60;
Date.DAY = Date.HOUR * 24;
Date.MONTH = -1;
Date.YEAR = -2;

Date.DAYS_IN_MONTH = new Array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);

// methods ********************************************************************

function _Date_toCanonString() {
    return this.getFullYear() +
			 _pad(this.getMonth() + 1) +
			 _pad(this.getDate());
}

function _Date_getFullYear() {
    var y = this.getYear();
    if (y < 100 && y > 0)
        y += 1900;
    return y;
}

function _Date_setFullYear(val) {
    this.setYear(val);
}

function _Date_compareTo(other) {
    return Date.compare(this, other);
}

function _Date_isLeapYear() {
    return Date.leapYear(this.getFullYear());
}

function _Date_add(date, unit, amount) {
    return Date.addDate(this, date, unit, amount);
}

function _Date_getDaysInMonth() {
    return Date.daysInMonth(this.getFullYear(), this.getMonth());
}

// utility functions **********************************************************

function _isLeapYear(year) {
    return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
}

function _compareDateStandard(d1, d2) {
    return (new Date(d1)).getTime() - (new Date(d2)).getTime();
}

function _compareDate(d1, d2, minRange) {

    /// <summary>
    /// Verifica la consecutività di 2 date.
    /// d1 o d2 possono assumere il valore "GETDATE" se il confronto deve essere fatto con la data odierna.
    /// </summary>
    /// <param name="d1" type="String">Data in formato stringa da utilizzare per i calcoli. Deve essere la data minore.</param>
    /// <param name="d2" type="String">Data in formato stringa da utilizzare per i calcoli. Deve essere la data maggiore.</param>
    /// <param name="minRange" type="Int">Differenza minima consentita tra le 2 date. Può valere 0,1,...[n]
    ///                                     0 nel caso in cui le date possono coincidere.
    ///                                     1 nel caso in cui le date devono avere almeno 1 giorno di differenza.
    ///                                     [n] per definite un numero specifico di intervallo tra le date.
    ////</param>

    var startDate;
    var endDate;

    if (d1 == 'GETDATE')
        startDate = _convertDateToString(new Date());
    else
        startDate = $('#' + d1).val();

    if (d2 == 'GETDATE')
        endDate = _convertDateToString(new Date());
    else
        endDate = $('#' + d2).val();


    if (startDate != '' && endDate != '' && startDate != undefined && endDate != undefined) {
        if ((_convertStringToDate(startDate) - _convertStringToDate(endDate)) < minRange) {
            return true;
        }
        else {
            removeValidateErrorMessage(d1);
            removeValidateErrorMessage(d2);

            return false;
        }
    }
}

//function _addDate(date, unit, amount) {
//    if (unit == Date.MONTH) {
//        var iniDay = date.getDate()
//        var iniDays = Date.daysInMonth(date.getFullYear(), date.getMonth())
//        var endDays
//        var segno = Math.abs(amount) / amount

//        if (date.getMonth() + amount > 11)
//            endDays = Date.daysInMonth(date.getFullYear() + segno, (date.getMonth() + amount) - 12)
//        else
//            endDays = Date.daysInMonth(date.getFullYear(), date.getMonth() + amount)

//        date.setMonth(date.getMonth() + amount);

//        // modifico la data se sono a fine mese
//        if (iniDay == iniDays)
//            date = Date.addDate(date, Date.DAY, endDays - iniDays)
//        // modifico la data se non sono a fine mese, ma il giorno del mese di
//        // partenza è maggiore del numero di giorni del mese di arrivo
//        else if (iniDay > endDays)
//            date = Date.addDate(date, Date.DAY, endDays - iniDay)
//    }
//    else if (unit == Date.YEAR) {
//        var iniDay = date.getDate()
//        var iniDays = Date.daysInMonth(date.getFullYear(), date.getMonth())
//        var endDays = Date.daysInMonth(date.getFullYear() + amount, date.getMonth())

//        date.setFullYear(date.getFullYear() + amount);

//        // modifico la data se sono a fine mese
//        if (iniDay == iniDays)
//            date = Date.addDate(date, Date.DAY, endDays - iniDays)
//    }
//    else {
//        date.setTime(date.getTime() + unit * amount);
//    }
//    return date;
//}

function _addDate(date, unit, amount) {

    /// <summary>
    /// Restituisce una data dopo aver aggiunto/tolto dei giorni/mesi/anni alla data di ingresso.
    /// </summary>
    /// <param name="date" type="String">Data da utilizzare per i calcoli. E' in formato stringa.</param>
    /// <param name="unit" type="String">Giorno (Date.DAY) / Mese (Date.MONTH) / Anno (Date.YEAR).</param>
    /// <param name="amount" type="Int">Quantità da aggiungere alla data (o togliere se il parametro in ingresso è negativo).</param>
    /// <returns name="date" type="String">Data calcolata.</returns>    
    date = _convertStringToDate(date);

    if (unit == Date.MONTH) {

        var iniDay = date.getDate();
        var iniDays = Date.daysInMonth(date.getFullYear(), date.getMonth());
        var endDays;
        var segno = Math.abs(amount) / amount;

        if (date.getMonth() + amount > 11) {
            endDays = Date.daysInMonth(date.getFullYear() + segno, (date.getMonth() + amount) - 12);
        }
        else {
            if (date.getMonth() + amount < 0) {
                endDays = Date.daysInMonth(date.getFullYear(), date.getMonth() + amount + 12);
            }
            else
                endDays = Date.daysInMonth(date.getFullYear(), date.getMonth() + amount);
        }


        date.setMonth(date.getMonth() + amount);

        if (iniDay == iniDays) {
            // modifico la data se sono a fine mese           
            //if (iniDay >= endDays)
            if (iniDay != undefined && endDays != undefined)
                date = Date.addDate(_convertDateToString(date), Date.DAY, endDays - iniDays);

        }
        else if (iniDay > endDays) {
            // modifico la data se non sono a fine mese, ma il giorno del mese di
            // partenza è maggiore del numero di giorni del mese di arrivo            
            date = Date.addDate(_convertDateToString(date), Date.DAY, endDays - iniDay);
        }
    }
    else if (unit == Date.YEAR) {
        //        var iniDay = date.getDate()
        //        var iniDays = Date.daysInMonth(date.getFullYear(), date.getMonth())
        //        var endDays = Date.daysInMonth(date.getFullYear() + amount, date.getMonth())
        date.setFullYear(date.getFullYear() + amount);
        // modifico la data se sono a fine mese
        //        if (iniDay == iniDays)
        //            date = Date.addDate(date, Date.DAY, endDays - iniDays)
    }
    else {
        //SVA: Modifiche per gestione ora legale.
        //Se il parametro UTC della mia data è 1 (vuol dire che mi trovo a cavallo del passaggio all'ora legale), per questo motivo sommo un ora in modo tale da
        //far si che sommando 24 ore alla mia data si arrivi sempre a mezzanotte.
        //Prima nel caso di ora legale ad una data si sommavano 24 ore -1 e per questo motivo si rimaneva sempre nello stesso giorno e non si andava mai avanti.
        date.setTime(date.getTime() + (unit * amount));
        var UTCMseconds = (date.getTimezoneOffset() * 60 * 1000) * -1;
        UTCMseconds = ((UTCMseconds == 3600000) ? UTCMseconds : 0);
        date.setTime(date.getTime() + UTCMseconds);
    }

    if (date.length == 10)
        date = _convertStringToDate(date);

    date = _convertDateToString(date);

    return date;
}

function _diffDays(dateEnd, dateStart, booAddInitDay) {
    // Il flag booAddInitDay (true, false) serve per
    // contare (true) o meno (false) nella differenza
    // anche il giorno iniziale
    var TheDiff = Date.compareStandard(dateEnd, dateStart) / Date.DAY;
    return (booAddInitDay ? TheDiff + 1 : TheDiff)
}

function _getDaysInMonth(year, month) {
    return month == 1 && Date.leapYear(year) ? 29 : Date.DAYS_IN_MONTH[month];
}

function _pad(n) {
    return (n < 10 ? "0" : "") + n;
}

function _convertStringToDate(string) {

    var TheDate = new Date(string.substring(6, 10),
                            string.substring(3, 5) - 1,
                            string.substring(0, 2));
    return TheDate;
}

function _convertDateToString(date) {
    return _pad(date.getDate()) + '/' + _pad(date.getMonth() + 1) + '/' + date.getFullYear().toString();
}

function _convertDateToSerialString(date) {
    return date.getFullYear().toString() + _pad(date.getMonth() + 1) + _pad(date.getDate());
}

//function _convertDateToSerialString(strDate) {
//    return anno + mese + giorno;
//    alert(strDate);
//    return strDate.substring(6, 10) + strDate.substring(3, 5) + strDate.substring(0, 2);
//}

//SE 30/03/05
// Verifica che la data inserita non ricada in uno di questi casi: Week-end, Festività.
// La funzione restituisce:
// 		""(stringa vuota) 	- data valida
// 		"Descrizione_Festa" 	- data NON valida
//
// In questo modo all'utente viene visualizzato un alert con la motivazione precisa.

function _isHolidayDate(date) {
    var holiday = "";

    var anno = date.substring(6, 10); //Estraggo l'anno da passare alla funzione per calcolare la data di Pasquetta.
    //var pasquetta = _convertDateToString(_Pasquetta(parseInt(anno)));
    var pasquetta = (_Pasquetta(parseInt(anno))).substring(0, 5);//Calcolo la data di Pasquetta.

    var data_confronto = date.substring(0, 5); //Estraggo la data da confrontare nel formato DD/MM.    

    //Creo l'array contenente le date festive.
    var arrDate = new Array(pasquetta, "01/01", "06/01", "25/04", "01/05", "02/06", "15/08", "01/11", "08/12", "25/12", "26/12");
    var int_arrDate = arrDate.length;

    //Creo l'array contenente i messaggi relativi alle date festive.
    var arrMsg = new Array("Lunedì dell'Angelo", "Capodanno", "Epifania", "25 Aprile", "1 Maggio", "2 Giugno", "Ferragosto", "1 Novembre", "8 Dicembre", "Natale", "S.Stefano");

    //Ciclo su tutti gli elementi del primo array.
    for (i = 0; i < int_arrDate; i++) {
        if (arrDate[i] == data_confronto)
            holiday = arrMsg[i];
    }

    //Verifico che non sia una sabato(valore=6) o una domenica(valore=0).
    if ((holiday == "") && (_convertStringToDate(date).getDay() == 0 || _convertStringToDate(date).getDay() == 6))
        holiday = "Week-end";

    return holiday;
}

//SE 30/03/05
// Calcola la data di Pasqua in base all'anno passato come parametro, e la restituisce nel formato DD/MM/YYYY (string).
function _Pasqua(Y) {
    var C = Math.floor(Y / 100);
    var N = Y - 19 * Math.floor(Y / 19);
    var K = Math.floor((C - 17) / 25);
    var I = C - Math.floor(C / 4) - Math.floor((C - K) / 3) + 19 * N + 15;
    I = I - 30 * Math.floor((I / 30));
    I = I - Math.floor(I / 28) * (1 - Math.floor(I / 28) * Math.floor(29 / (I + 1)) * Math.floor((21 - N) / 11));
    var J = Y + Math.floor(Y / 4) + I + 2 - C + Math.floor(C / 4);
    J = J - 7 * Math.floor(J / 7);
    var L = I - J;
    var M = 3 + Math.floor((L + 40) / 44);
    var D = L + 28 - 31 * Math.floor(M / 4);

    return _pad(D) + '/' + _pad(M) + '/' + _pad(Y);
}

//SE 30/03/05
// Utilizza la function _Pasqua() per calcolare la data di Pasqua, e incrementa il risultato di 1 giorno.
function _Pasquetta(Y) {
    var date = _Pasqua(Y);
    date = _addDate(date, Date.DAY, 1);
    return date;
}


// SVA 03/04/2015
// Utilizza la function millisecondi() per calcolare i millisecondi passando in ingresso i giorni.
// utile per calcolare la differenza tra due date nella dateCompare con valori <> da 0 e 1.
function millisecondi(days) {
    return (((60 * 60) * 24) * days) * 1000;
}



// initialization *************************************************************

Date.prototype.toCanonString = _Date_toCanonString;
if (!Date.prototype.getFullYear) {
    Date.prototype.getFullYear = _Date_getFullYear;
    Date.prototype.setFullYear = _Date_setFullYear;
}
Date.prototype.isLeapYear = _Date_isLeapYear;
Date.prototype.compareTo = _Date_compareTo;
Date.prototype.add = _Date_add;
Date.prototype.getDaysInMonth = _Date_getDaysInMonth;

Date.leapYear = _isLeapYear;
Date.compare = _compareDate;
Date.compareStandard = _compareDateStandard;    // Versione originale date.js
Date.addDate = _addDate;
Date.diffDays = _diffDays;
Date.daysInMonth = _getDaysInMonth;

Date.convertDateToString = _convertDateToString;
Date.convertStringToDate = _convertStringToDate;
Date.compareDate = _compareDate;
Date.compareDateWork = _compareDateWork;
Date.convertDateToSerialString = _convertDateToSerialString;

Date.pad = _pad;

//SE 30/03/05
Date.isHolidayDate = _isHolidayDate;




//SVA 07/04/2015
function _compareDateWork(d1, d2, minRange) {

    /// <summary>
    /// Verifica la consecutività di 2 date e se la differenza supera un determinato range ma solo dei giorni LAVORATIVI.
    /// d1 o d2 possono assumere il valore "GETDATE" se il confronto deve essere fatto con la data odierna.
    /// </summary>
    /// <param name="d1" type="String">Data in formato stringa da utilizzare per i calcoli. Deve essere la data minore.</param>
    /// <param name="d2" type="String">Data in formato stringa da utilizzare per i calcoli. Deve essere la data maggiore.</param>
    /// <param name="minRange" type="Int">Differenza minima consentita tra le 2 date. Può valere 0,1,...[n]
    ///                                     0 nel caso in cui le date possono coincidere.
    ///                                     1 nel caso in cui le date devono avere almeno 1 giorno di differenza.
    ///                                     [n] per definite un numero specifico di intervallo tra le date.
    ////</param>

    var startDate;
    var endDate;
    var diffDays = 0;

    if (d1 == 'GETDATE')
        startDate = _convertDateToString(new Date());
    else
        startDate = $('#' + d1).val();

    if (d2 == 'GETDATE')
        endDate = _convertDateToString(new Date());
    else
        endDate = $('#' + d2).val();


    if (startDate != '' && endDate != '' && startDate != undefined && endDate != undefined) {

        //Fino a che la data di partenza non è uguale a quella di arrivo calcolo i giorni che devono essere verificati
        while (_convertStringToDate(startDate) < _convertStringToDate(endDate)) {
            if ((_isHolidayDate(startDate) == "")) {
                diffDays++;
            }
            startDate = _addDate(startDate, Date.DAY, 1);
        }

        if (diffDays >= minRange)
            return true;
        else {
            removeValidateErrorMessage(d1);
            removeValidateErrorMessage(d2);
            return false;
        }
    }
}

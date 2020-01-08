function loadLokaty() {
    var http = new XMLHttpRequest();
    http.open("GET", "http://localhost:5000/lokaty/Lokaty");

    http.onload = function () {
        var select = document.getElementById("typeLokaty");
        if (select.hasChildNodes()) {
            while (select.lastChild) {
                select.removeChild(select.lastChild);
            }
        }

        var dane = http.response;
        var tab = JSON.parse(dane);
        for (var index in tab) {
            var opt = document.createElement('option');
            opt.value = tab[index];
            opt.innerHTML = tab[index];
            select.appendChild(opt);
        }

    }

    http.send();
}

document.getElementById("buttonPolicz").onclick = function () {
    var lokata = document.getElementById("typeLokaty").options[document.getElementById("typeLokaty").selectedIndex].value;
    var value = document.getElementById("kwota").value;
    var okres = document.getElementById("okres").value;

    przelicz(lokata, okres, value);
}

function przelicz(lokata, okres, value)
{
    var http = new XMLHttpRequest();
    http.open("GET", "http://localhost:5000/lokaty/Przelicz?lokata=" + lokata + "&okres=" + okres + "&value=" + value);

    http.onload = function () {
        var dane = http.response;
        var value = JSON.parse(dane);
        document.getElementById("kapital").innerHTML = value;
    }

    http.send();
}

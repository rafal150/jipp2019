function loadConverters()
{
    var http = new XMLHttpRequest();
    http.open("GET", "http://localhost:5000/converters/ConverterTypes");
    
    http.onload = function()
    {
        var select = document.getElementById("types");
        if(select.hasChildNodes())
        {
            while (select.lastChild) 
            {
                select.removeChild(select.lastChild);
            }
        }
        
        var dane = http.response;  
        var tab = JSON.parse(dane);
        for(var index in tab.types)
        {
            var opt = document.createElement('option');
            opt.value = tab.types[index].code;
            opt.innerHTML = tab.types[index].name;
            select.appendChild(opt);
        }

    }

    http.send();
}

function loadUnits(type)
{
    var http = new XMLHttpRequest();
    http.open("GET", "http://localhost:5000/converters/ConverterUnits?type="+type);

    http.onload = function()
    {
        var from = document.getElementById("from");
        if(from.hasChildNodes())
        {
            while (from.lastChild) 
            {
                from.removeChild(from.lastChild);
            }
        }
        var to = document.getElementById("to");
        if(to.hasChildNodes())
        {
            while (to.lastChild) 
            {
                to.removeChild(to.lastChild);
            }
        }

        var dane = http.response;  
        var tab = JSON.parse(dane);
        for(var index in tab.units)
        {
            var optF = document.createElement('option');
            optF.value = tab.units[index];
            optF.innerHTML = tab.units[index];
            from.appendChild(optF);

            var optT = document.createElement('option');
            optT.value = tab.units[index];
            optT.innerHTML = tab.units[index];
            to.appendChild(optT);
        }
    }

    http.send();
}

function convert(type, from, to, value)
{
    var http = new XMLHttpRequest();
    http.open("GET", "http://localhost:5000/converters/Converter?type="+type+"&from="+from+"&to="+to+"&value="+value);

    http.onload = function()
    {
        var dane = http.response;  
        var value = JSON.parse(dane);
        document.getElementById("toValue").innerHTML = value;
    }

    http.send();
}

document.getElementById("types").onchange = function()
{
    
}

document.getElementById("buttonType").onclick = function()
{
    var select = document.getElementById("types");
    var index = select.selectedIndex;
    document.getElementById("selType").value = select.options[index].value;

    loadUnits(document.getElementById("selType").value);
}

document.getElementById("buttonKonw").onclick = function()
{
    var type = document.getElementById("selType").value;
    var from = document.getElementById("from").options[document.getElementById("from").selectedIndex].value;
    var to = document.getElementById("to").options[document.getElementById("to").selectedIndex].value;
    var value = document.getElementById("fromValue").value;

    convert(type, from, to, value);
}
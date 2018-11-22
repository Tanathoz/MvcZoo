var orden_1 = Array("Seleccione orden", "Anura", "Caudata", "Gymnophiona", "Mugiliformes");
//4 ordenes

var orden_2 = new Array("Seleccione orden", "Accipitriformes", "Anseriformes", "Apodiformes", "Bucerotiformes", "Charadriiformes", "Ciconiiformes",
    "Coliiformes", "Columbiformes", "Coraciiformes", "Craciformes", "Cuculiformes", " Falconiformes", "Galbuliformes", "Galliformes", "Gaviiformes",
    "Gruiformes", " Musophagiformes", "Passeriformes", "Pelecaniformes", "Phaethontiformes", "Phoenicopteriformes", "Piciformes", "Podicipediformes",
    "Procellariiformes", "Psittaciformes", "Pteroclidiformes", "Sphenisciformes", "Strigiformes", "Struthioniformes", " Suliformes", "Tinamiformes",
    "Trogoniformes", "Upupiformes")

//33 ordenes

var orden_3 = new Array("Seleccione orden", "Artiodáctilos", "Carnívoros", "Cetáceos", "Dermapteros", "Desdentados", "Diprotodontos", "Escandentios",
    "Folidotos", "Hiracoideos", "Insectívoros", "Lagomorfos", "Macroscelídos", "Marsupiales", "Monotremas", "Perisodáctilos",
    "Pinnípedos", "Primates", "Proboscídeos", "Quirópteros ", "Roedores", "Sirénidos", "Tubulidentados", "Xenarthra")
//22 ordenes

var orden_4 = new Array("Seleccione orden", "Bericiformes", "Escorpeniformes", "Lofiformes", "Mugiliformes", "Tetraodontiformes", "Zeiformes")
//6 ordenes
var orden_5 = new Array("Seleccione orden", "Crocodylia", "Rhynchocephalia", "Squamata", "Testudines")
//4 ordenes

//69 ordenes en total

$(document).ready(function () {

    //   $("#familia").append('<option value="' + $(gestacn).val()+ '">' + $(gestacn).val()+ '</option>');
    var indice, numOrdenes, indiceFam, idOrden
    var famiNombres = new Array();
    var selector = document.querySelector('#claseDropDown');
    var ordenSelect = document.querySelector('#ordenDropDown');

    selector.addEventListener('change', function () {
        $('#ordenDropDown').empty().append('elige una opcion');

        indice = $('select[id=claseDropDown]').prop('selectedIndex');
        indice = parseInt(indice);
        misordenes = eval("orden_" + indice)
        num = misordenes.length
        //alert("indice" + indice);
        if (indice >= 1) {

            if (indice == 1)
                numOrdenes = 0;
            else if (indice == 2)
                numOrdenes = 4;
            else if (indice == 3)
                numOrdenes = 37;
            else if (indice == 4)
                numOrdenes = 60;
            else
                numOrdenes = 66;

            


            for (a = 0; a < num; a++) {
                idOrden = numOrdenes + a;
                $('<option value="' + idOrden + '">' + eval("orden_" + indice)[a] + '</option>').appendTo("#ordenDropDown");
            }
        }

        if (indice <= 0) {
           // alert("se metio");
            $("<option value='5'>Selecciona clase</option>").appendTo("#ordenDropDown");

        }

    });


    //sirve para archivos y hacer peticiones HTTP
    var request = new XMLHttpRequest();
    request.open('GET', 'http://tanathoz-001-site1.ctempurl.com/api/Especie');
    request.onreadystatechange = function () {
        if (request.readyState == 4) {
            console.log("los datos");
        } else {
            dump("Erroe loading page");
        }
    };
    request.send(null);

    ordenSelect.addEventListener('change', function () {
        


      
       
    }); 
});
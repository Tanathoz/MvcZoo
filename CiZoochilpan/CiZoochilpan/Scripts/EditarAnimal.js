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
    var familiaSelect = document.querySelector('#familiaDropDown');

    var modelo = @Html.Raw(Json.Encode(Model));
    $("#familiaDropDown").empty().append('<option value="' + modelo.familia + '">' + modelo.familia + '</option>');
    //alert("" + modelo.familia);
    console.log("a" + modelo.orden);
    //$("#familiaDropDown").empty().append('<option value="' + data[0].id + '">' + data[0].familia + '</option>');


    selector.addEventListener('change', function () {
        $('#ordenDropDown').empty().append('elige una opcion');

        indice = $('select[id=claseDropDown]').prop('selectedIndex');
        indice = parseInt(indice);
        misordenes = eval("orden_" + indice);
        num = misordenes.length;

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


    ordenSelect.addEventListener('change', function () {
        idOrden = $('select[id=ordenDropDown]').val();

        idOrden = parseInt(idOrden);
        var OptionOrden = document.getElementById("ordenDropDown");
        var ord = document.getElementById("orden");
        ord.value = OptionOrden.options[OptionOrden.selectedIndex].text;
        /* fetch('http://tanathoz-001-site1.ctempurl.com/api/Familia?id=29')
             .then(function (response) {
 
                 return response.json();
             })
             .then(function (myJson) {
                 console.log(JSON.stringify(myJson));
             }).catch(function (error) {
 
                 console.log("hubo un problema al obtener  la petición fetch:" + error.message);
             }); */

        fetch('http://tanathoz-001-site1.ctempurl.com/api/Familia?id=' + idOrden + '')
            .then(function (response) {

                return response.json();
                for (var i = 0; i < response.length; i++) {
                    console.log(response[i].nombre);
                }
            })
            .then(function (myJson) {
                $("#familiaDropDown").empty().append('<option value="1"> Seleciona Familia</option>');
                for (var i = 0; i < myJson.length; i++) {
                    console.log(myJson[i].nombre);
                    $('<option value="' + myJson[i].idFam + '">' + myJson[i].nombre + '</option>').appendTo("#familiaDropDown");
                }
                console.log(JSON.stringify(myJson));
            }).catch(function (error) {
                $("#familiaDropDown").empty().append('<option value="1"> No hay familias</option>');
                console.log("hubo un problema al obtener  la petición fetch:" + error.message);
            });


    });

    familiaSelect.addEventListener('change', function () {

        indiceFam = $('select[id=familiaDropDown]').val();
        indiceFam = parseInt(indiceFam);
        console.log("indice familia") + indiceFam;

        var selectedOption = document.getElementById("familiaDropDown");
        var famy = document.getElementById("familia");
        famy.value = selectedOption.options[selectedOption.selectedIndex].text;

        fetch('http://tanathoz-001-site1.ctempurl.com/api/Especie?id=' + indiceFam + '')
            .then(function (response) {
                return response.json();
            })
            .then(function (myJson) {
                $("#especieDropDown").empty().append('<option value="1"> Seleciona Especie</option>');
                for (var i = 0; i < myJson.length; i++) {
                    console.log(myJson[i].nombre);
                    $('<option value="' + myJson[i].nombre + '">' + myJson[i].nombre + '</option>').appendTo("#especieDropDown");
                }
                console.log(JSON.stringify(myJson));
            }).catch(function (error) {
                $("#especieDropDown").empty().append('<option value="1"> No hay especies</option>');
                console.log("hubo un problema al obtener  la petición fetch:" + error.message);
            });

    })

});
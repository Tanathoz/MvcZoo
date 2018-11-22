
    
    const app = document.getElementById('root');
    //console.log(app);
    const contenedor = document.createElement('div');
    contenedor.setAttribute('class', 'container');
    app.appendChild(contenedor);

    //sirve para archivos y hacer peticiones HTTP
    var request = new XMLHttpRequest();

    //abrimos una nueva conexión e indicamos el tipo de petición Get y la url
request.open('GET', 'https://ghibliapi.herokuapp.com/films', true);
    //accedemos al la información de respuesta desde la función onload
        request.onload = function () {
            // la variable datos contiene la respuesta de la api y es convertida a un arreglo de objetos
            var datos = JSON.parse(this.response);
    //Un estatus exitosa debe estar en el rango de 200 a 400, 404 not found
            if (request.status >= 200 && request.status < 400) {


        datos.forEach(movie => {
            console.log(movie.title, movie.director)
            //create a div elemente
            const card = document.createElement('div');
            //if we want add a class need the next line 
            // card.setAttribute('class', 'card');
            //create an h1 and set the text content to the films title
            const h1 = document.createElement('h1');
            h1.textContent = movie.title;

            //crear el elemento p que contendrá la descripción
            const p = document.createElement('p');
            movie.description = movie.description.substring(0, 300);
            p.textContent = `${movie.description}...`;

            contenedor.appendChild(card);

            //cada div contendrá un h1 y un p
            card.appendChild(h1);
            card.appendChild(p);


        });



    } else {
                const errorMessage = document.createElement('marquee');
    errorMessage.textContent = 'GAhh it is not working';
    app.appendChild(errorMessage);
    console.log('error');
}
}
// envió de petición
request.send();

fetch('http://tanathoz-001-site1.ctempurl.com/api/Especie')
            .then(function (response) {
                return response.json();
})
            .then(function (myJson) {
        console.log(JSON.stringify(myJson));
    });
   

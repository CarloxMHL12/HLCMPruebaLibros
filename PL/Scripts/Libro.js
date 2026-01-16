function mostrarBusqueda() {
    document.getElementById("formularioBusqueda").style.display = "block";
}

function verDetalle(idLibro) {
    $("#contenidoDetalle").load(
        "/Libro/Detalle?IdLibro=" + idLibro,
        function () {
            $("#modalDetalle").modal("show");
        }
    );
}


function soloNumeros(event, input) {

    input.onpaste = function (copiar) {
        copiar.preventDefault();
        input.classList.add("is-invalid");
        input.classList.remove("is-valid");
        return false;
    };

    var char = String.fromCharCode(event.which || event.charCode);
    var regexNumeros = /^[1-5]$/;

    if (!regexNumeros.test(char)) {
        input.classList.add("is-invalid");
        input.classList.remove("is-valid");
        event.preventDefault();
        return false;
    }

    input.classList.add("is-valid");
    input.classList.remove("is-invalid");
    return true;
}


function soloTitulo(event, input) {
    var valor = input.value;
    var regexTitulo = /^[A-Za-z0-9\s.,:;!?'"()\-_&/]+$/;

    if (regexTitulo.test(valor) && valor.trim().length > 0) {
        input.classList.add("is-valid");
        input.classList.remove("is-invalid");
        return true;
    } else {
        input.classList.add("is-invalid");
        input.classList.remove("is-valid");
        return false;
    }
}

function soloAnio(event, input) {


    input.onpaste = function (copiar) {
        copiar.preventDefault();
        input.classList.add("is-invalid");
        input.classList.remove("is-valid");
        return false;
    };

    var char = String.fromCharCode(event.which || event.charCode);
    var regexNumeros = /^[0-9]$/;


    if (!regexNumeros.test(char)) {
        input.classList.add("is-invalid");
        input.classList.remove("is-valid");
        event.preventDefault();
        return false;
    }


    if (input.value.length >= 4) {
        event.preventDefault();
        return false;
    }

    setTimeout(function () {
        var regexAnio = /^(19[0-9]{2}|20[0-2][0-6])$/;

        if (regexAnio.test(input.value)) {
            input.classList.add("is-valid");
            input.classList.remove("is-invalid");
        } else {
            input.classList.add("is-invalid");
            input.classList.remove("is-valid");
        }
    }, 0);

    return true;
}


function soloLetras(event, input) {

    input.onpaste = function (copiar) {
        copiar.preventDefault();
        input.classList.add("is-invalid");
        input.classList.remove("is-valid");
        return false;
    };

    var string = String.fromCharCode(!event.charCode ? event.which : event.charCode);
    var regexLetras = /^[A-Za-zÁÉÍÓÚáéíóúÜüÑñ' -]+$/;

    if (regexLetras.test(string)) {
        input.classList.add("is-valid");
        input.classList.remove("is-invalid");
        return true;
    } else {
        input.classList.add("is-invalid");
        input.classList.remove("is-valid");
        event.preventDefault();
        return false;
    }
}
let btnGuardar = document.getElementById("btnGuardar");
let txtNombre = document.querySelector(".txtNombre");
let txtApellido = document.querySelector(".txtApellido");
let txtCargo = document.querySelector(".txtCargo");
let txtPais = document.querySelector(".txtPais");
let validationNombre = document.querySelector(".validation-nombre");
let validationApellido = document.querySelector(".validation-apellido");
let validationCargo = document.querySelector(".validation-cargo");
let validationPais = document.querySelector(".validation-pais");

btnGuardar.addEventListener("click", (e) => {

    if (txtNombre.value.length > 10) {
        e.preventDefault();
        validationNombre.style.color = "red";
        validationNombre.style.display = "";
        validationApellido.style.display = "none";
        validationCargo.style.display = "none";
        validationPais.style.display = "none";


    }
    if (txtApellido.value.length > 20) {
        e.preventDefault();
        validationApellido.style.color = "red";
        validationApellido.style.display = "";
        validationNombre.style.display = "none";
        validationCargo.style.display = "none";
        validationPais.style.display = "none";
    }
    if (txtCargo.value.length > 30) {
        e.preventDefault();
        validationCargo.style.color = "red";
        validationCargo.style.display = "";
        validationNombre.style.display = "none";
        validationApellido.style.display = "none";
        validationPais.style.display = "none";
    }
    if (txtPais.value.length > 15) {
        e.preventDefault();
        validationPais.style.color = "red";
        validationPais.style.display = "";
        validationNombre.style.display = "none";
        validationCargo.style.display = "none";
        validationApellido.style.display = "none";
    }
})

function eliminarEmpleado(empleadoId) {
    if (empleadoId < 10) {
        let id = document.getElementById(`${empleadoId}`);
        if (id) {
            id.style.display = "none";
        }
    }
}


let btnGuardarCategoria = document.getElementById("btnGuardar");
let txtNombreCategoria = document.querySelector(".txtNombre");
let validationNombreCategoria = document.querySelector(".validation-nombre-categoria");

btnGuardarCategoria.addEventListener("click", (e) => {

    if (txtNombreCategoria.value.length > 15) {
        e.preventDefault();
        validationNombreCategoria.style.color = "red";
        validationNombreCategoria.style.display = "";

    }
})

function eliminarCategoria(categoriaID) {
    if (categoriaID < 9) {
        let id = document.getElementById(`${categoriaID}`);
        if (id) {
            id.style.display = "none";
        }
    }
}
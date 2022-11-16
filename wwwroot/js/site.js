// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function eliminarCasa(id) {
    console.log(id);
    var eliminar = confirm("Está seguro de eliminar esta seccion?");
    if (eliminar) {
    location.href = "../../Casa/DeleteConfirmed/" + id;}
}
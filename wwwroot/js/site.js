// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// function eliminarCasa(id) {
//     console.log(id);
//     var eliminar = confirm("Está seguro de eliminar esta casa?");
//     if (eliminar) {
//     location.href = "../../Casa/DeleteConfirmed/" + id;}
// }
function eliminarCasa(id) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: 'Estas segur@?',
        text: "Está seguro de eliminar esta casa?",
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Si',
        cancelButtonText: 'No',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            location.href = "../../Casa/DeleteConfirmed/" + id;
            swalWithBootstrapButtons.fire(
                'Eliminado!',
                'casa se elimino de la lista',
                'success'
            );
        }
        else {
            /* Read more about handling dismissals below */
            result.dismiss === Swal.DismissReason.cancel,
                swalWithBootstrapButtons.fire(
                    'Cancelado',
                    'Dejaste casa en la lista',
                    'error'
                )
        }
    })
}


// function eliminarCliente(id) {
// console.log(id);
// var eliminar = confirm ("esta seguro de elominar esta cliente?");
// if (eliminar) {
//     location.href = "../../Cliente/DeleteConfirmed/" + id
// }    
// }

function eliminarCliente(id) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: 'Estas segur@?',
        text: "Está seguro de eliminar este cliente?",
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Si',
        cancelButtonText: 'No',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            location.href = "../../Cliente/DeleteConfirmed/" + id;
            swalWithBootstrapButtons.fire(
                'Eliminado!',
                'El cliente se elimino de la lista',
                'success'
            );
        }
        else {
            /* Read more about handling dismissals below */
            result.dismiss === Swal.DismissReason.cancel,
                swalWithBootstrapButtons.fire(
                    'Cancelado',
                    'Dejaste el cliente en la lista',
                    'error'
                )
        }
    })
}









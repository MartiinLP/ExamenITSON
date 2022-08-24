$(document).ready(function () {

    $('#CreateAlumnoForm').validate({
        rules: {
            NombreC: {
                required: true
            },
            ApellidoPC: {
                required: true
            },
            ApellidoMC: {
                required: true
            }
        },
        messages: {
            NombreC: {
                required: "Proporcione un nombre"
            },
            ApellidoPC: {
                required: "Proporcione un apellido"
            },
            ApellidoMC: {
                required: "Proporcione una apellido"
            }
        },
        submitHandler: function (form) {
            return false;
        }
    });

    $('#UpdateAlumnoForm').validate({
        rules: {
            NombreU: {
                required: true
            },
            ApellidoPU: {
                required: true
            },
            ApellidoMU: {
                required: true
            }
        },
        messages: {
            NombreU: {
                required: "Proporcione un nombre"
            },
            ApellidoPU: {
                required: "Proporcione un apellido"
            },
            ApellidoMU: {
                required: "Proporcione un apellido"
            }
        },
        submitHandler: function (form) {
            return false;
        }
    });
});

function CreateAlumno() {
    event.preventDefault();
    var validacionCreate = $("#CreateAlumnoForm").valid();

    if (validacionCreate != false) {
        Swal.fire({
            title: '¿Desea Guardar?',
            text: "¡No se podrá revertir!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            cancelButtonText: 'Cancelar',
            confirmButtonText: 'Aceptar'
        }).then((result) => {
            if (result.value) {                   

                var alu = {
                    Nombres: $("#NombreC").val(),
                    ApellidoPaterno: $("#ApellidoPC").val(),
                    ApellidoMaterno: $("#ApellidoMC").val(),
                    EstaActivo: $("#EstaActivoC").val()
                }

                $.ajax({
                    type: "POST",
                    url: "/CreateAlumno",
                    data: { alumno: alu },
                    beforeSend: function () {
                        $("#btnCreateAlumno").prop("disabled", true);
                        Swal.fire({
                            title: 'Guardando...',
                            allowEscapeKey: false,
                            allowOutsideClick: false,
                            showConfirmButton: false,
                            onOpen: () => {
                                Swal.showLoading();
                            }
                        });
                    },
                    success: function (data) {
                        Swal.fire(
                            '¡Guardado!',
                            'Alumno añadida.',
                            'success'
                        ).then((result) => {
                            location.reload();
                        });
                    }
                });
            }
        });
    }
}

function UpdateAlumno() {
    event.preventDefault();
    
    var validacionUpdate = $("#UpdateAlumnoForm").valid();

    if (validacionUpdate != false) {
        Swal.fire({
            title: '¿Desea Guardar?',
            text: "¡No se podrá revertir!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            cancelButtonText: 'Cancelar',
            confirmButtonText: 'Aceptar'
        }).then((result) => {
            if (result.value) {                           
                var alu = {
                    Id: $("#Id").val(),
                    Nombres: $("#NombreU").val(),
                    ApellidoPaterno: $("#ApellidoPU").val(),
                    ApellidoMaterno: $("#ApellidoMU").val(),
                    EstaActivo: $("#EstaActivoU").val()
                }

                $.ajax({
                    type: "PUT",
                    url: "/UpdateAlumno",
                    data: { alumno: alu },
                    beforeSend: function () {
                        $("#btnUpdateAlumno").prop("disabled", true);
                        Swal.fire({
                            title: 'Guardando...',
                            allowEscapeKey: false,
                            allowOutsideClick: false,
                            showConfirmButton: false,
                            onOpen: () => {
                                Swal.showLoading();
                            }
                        });
                    },
                    success: function (data) {
                        Swal.fire(
                            'Listo',
                            '¡Se ha actualizado con éxito!.',
                            "success"
                        ).then((result) => {
                            location.reload();
                        });
                    }
                });
            }
        });
    }
}

function RemoveAlumno(Id) {
    event.preventDefault();
    Swal.fire({
        title: '¿Está seguro?',
        text: "¡Se eliminará el registro!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Eliminar',
        cancelButtonText: 'Cancelar',
    }).then((result) => {
        if (result.value) {

            $.ajax({
                type: "DELETE",
                url: "/RemoveAlumno?Id=" + Id,
                beforeSend: function () {
                    Swal.fire({
                        title: 'Eliminando...',
                        allowEscapeKey: false,
                        allowOutsideClick: false,
                        showConfirmButton: false,
                        onOpen: () => {
                            Swal.showLoading();
                        }
                    });
                },
                success: function (response) {
                    Swal.fire(
                        '¡Eliminado!',
                        'Registro eliminado.',
                        'success'
                    ).then((result) => {
                        location.reload();
                    })
                }
            });
        }
    })
}

function DetailsAlumno(Id, opcion) {
    event.preventDefault();
    $.ajax({
        type: "GET",
        url: "/DetailsAlumno/" + Id,
        success: function (response) {
            console.log(response);
            if (opcion == 'Editar') {
                $("#EstaActivoU").empty();
                
                $("#Id").val(response.id);
                $("#NombreU").val(response.nombres);
                $("#ApellidoPU").val(response.apellidoPaterno);
                $("#ApellidoMU").val(response.apellidoMaterno);                

                if (response.estaActivo == true) {
                    var option = '<option val="true" selected>Si</option>';
                    var option2 = '<option val="false">No</option>';
                    $("#EstaActivoU").append(option);
                    $("#EstaActivoU").append(option2);
                } else {
                    var option = '<option val="true">Si</option>';
                    var option2 = '<option val="false" selected>No</option>';
                    $("#EstaActivoU").append(option);
                    $("#EstaActivoU").append(option2);
                }

                $('#Update').modal('show');
            } else {
                $("#EstaActivoD").empty();
                $("#NombreD").val(response.nombres);
                $("#ApellidoPD").val(response.apellidoPaterno);
                $("#ApellidoMD").val(response.apellidoMaterno);                

                if (response.estaActivo == true) {
                    var option = '<option val="true" selected>Si</option>';                    
                    $("#EstaActivoD").append(option);                    
                } else {                    
                    var option2 = '<option val="false" selected>No</option>';                    
                    $("#EstaActivoD").append(option2);
                }
                $('#Detalles').modal('show');
            }
        },
        error: function (err) {
            console.log(err)
        }
    });
}

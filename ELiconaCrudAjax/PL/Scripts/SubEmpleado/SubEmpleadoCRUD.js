<reference path="SubEmpleadoCRUD.js" />

$(document).ready(function () { //click
    GetAll();
    EstadoGetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:57759/api/Empleado/GetAll',
        success: function (result) { //200 OK 
            $('#SubCategorias tbody').empty();
            $.each(result.Objects, function (i, empleado) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> '
                    + '<a href="#" onclick="GetById(' + empleado.IdEmpleado + ')">'
                    + '<img  style="height: 25px; width: 25px;" src="../img/edit.ico" />'
                    + '</a> '
                    + '</td>'
                    + "<td  id='id' class='text-center'>" + empleado.IdEmpleado + "</td>"
                    + "<td class='text-center'>" + empleado.NumeroNomina + "</td>"
                    + "<td class='text-center'>" + empleado.Nombre + "</td>"
                    + "<td class='text-center'>" + empleado.ApelldoPaterno + "</ td>"
                    + "<td class='text-center'>" + empleado.ApelldoMaterno + "</ td>"
                    + "<td class='text-center'>" + empleado.Estado.IdEstado + "</td>"
                    + "<td class='text-center'>" + empleado.Estado.Estado + "</td>"
                    //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#SubCategorias tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function EstadoGetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:57759/api/Estado/GetAll',
        success: function (result) {
            $("#ddlIdEstado").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, estado) {
                $("#ddlIdEstado").append('<option value="'
                    + estado.IdEstado + '">'
                    + estado.Estado + '</option>');
            });
        }
    });
}

function Add(empleado) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:57759/Empleado/Add',
        dataType: 'json',
        data: JSON.stringify(empleado),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
        }
    });
};


//function Add() {

//    var empleado = {
//        IdEmpleado: 0,
//        NumeroNomina: $('#txtNumeroNomina').val(),
//        Nombre: $('#txtNombre').val(),
//        ApellidoPaterno: $('#txtApellidoPaterno').val(),
//        ApellidoMaterno: $('#txtApellidoMaterno').val(),
//        Estado: {
//            IdEstado: $('#txtIdEstado').val()
//        }
//    }
//    $.ajax({
//        type: 'POST',
//        url: 'http://localhost:44389/api/Empleado/Add',
//        dataType: 'json',
//        data: JSON.stringify(empleado),
//        contentType: 'application/json; charset=utf-8',
//        success: function (result) {
//            $('#myModal').modal();
//        },
//        error: function (result) {
//            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
//        }
//    });
//};


function GetById(IdEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:57759/api/Empleado/GetById/?IdEmpleado=' + IdEmpleado,
        success: function (result) {
            $('#txtIdEmpleado').val(result.Object.IdEmpleado);
            $('#txtNumeroNomina').val(result.Object.NumeroNomina);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellidoPaterno').val(result.Object.ApellidoPaterno);
            $('#txtApellidoMaterno').val(result.Object.ApellidoMaterno);
            $('#ddlIdEstado').val(result.Object.Estado.IdEstado);
            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }


    });

}


function Update(empleado) {

    //var empleado = {
    //    IdEmpleado: $('#txtIdEmpleado').val(),
    //    NumeroNomina: $('#txtNumeroNomina').val(),
    //    Nombre: $('#txtNombre').val(),
    //    ApellidoPaterno: $('#txtApellidoPaterno').val(),
    //    ApellidoMaterno: $('#txtApellidoMaterno').val(),
    //    IdEstado: {
    //        IdEstado: $('#ddlIdEstado').val()

    //    }

    //}

    $.ajax({
        type: 'POST',
        url: 'http://localhost:57759/api/Empleado/Update',
        datatype: 'json',
        data: JSON.stringify(empleado),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#Modal').modal('show');
            GetAll();
            Console(respond);
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};

function Modal() {
    var mostrar = $('#ModalUpdate').modal('show');
    IniciarEmpleado();

}

function Eliminar(IdEmpleado) {

    if (confirm("¿Estas seguro de eliminar el Empleado seleccionado?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:57759/api/Empleado/Delete/?IdEmpleado=' + IdEmpleado,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};

function Actualizar() {
     var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(),
        NumeroNomina: $('#txtNumeroNomina').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        IdEstado: {
            IdEstado: $('#ddlIdEstado').val()

        }

    }

    if (empleado.IdEmpleado == '') {
        Add(empleado);

    }
    else {
        Update(empleado);
    }

   
}

function IniciarEmpleado() {

    var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(''),
        NumeroNomina: $('#txtNumeroNomina').val(''),
        Nombre: $('#txtNombre').val(''),
        ApellidoPaterno: $('#txtApellidoP').val(''),
        ApellidoMaterno: $('#txtApellidoM').val(''),
        Estado: {
            IdEstado: $('#ddlEstado').val(0)
        }
    }
}
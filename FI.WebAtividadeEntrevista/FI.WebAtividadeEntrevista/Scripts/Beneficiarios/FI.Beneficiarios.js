$(document).ready(function () {

    $("#CpfBeneficiario").inputmask("mask", { "mask": "999.999.999-99", 'autoUnmask': true, 'removeMaskOnSubmit': true }, { reverse: true });

    

    $("#btnBeneficiarios").click(function (e) {
        $('#ModalFormBeneficiario').modal('show');
    })

    $('#formCadastroBeneficiario').submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: urlBeneficiarioPost,
            method: "POST",
            data: {
                "NOME": $(this).find("#NomeBeneficiario").val(),
                "Cpf": $(this).find("#CpfBeneficiario").val(),
                "IDCliente": $(this).find('#IdCliente').val()
            },
            error:
            function (r) {
                if (r.status == 400)
                    ModalDialog("Ocorreu um erro", r.responseJSON);
                else if (r.status == 500)
                    ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
            },
            success:
            function (r) {
                ModalDialog("Mensagem", r)
                $("#formCadastroBeneficiario")[0].reset();
                if (document.getElementById("gridBeneficiarios"))
                    $('#gridBeneficiarios').jtable('load');
            }
        });
    })
})
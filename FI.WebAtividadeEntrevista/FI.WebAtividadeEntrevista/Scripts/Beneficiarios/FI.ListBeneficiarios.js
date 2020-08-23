$('#ModalFormBeneficiario').on('show.bs.modal', function (event) {
    BeneficiariosList.montarGrid();
});

BeneficiariosList = {
    montarGrid: function () {
        if (document.getElementById("gridBeneficiarios"))
            $('#gridBeneficiarios').jtable({
                paging: true, 
                actions: {
                    listAction: urlBeneficiariosList,
                },
                fields: {
                    Cpf: {
                        title: 'CPF',
                        width: '30%',
                    },
                    Nome: {
                        title: 'Nome',
                        width: '40%'
                    },
                    Alterar: {
                        title: '',
                        display: function (data) {
                            return '<button onclick="BeneficiariosList.update(' + data.record.ID + ')" class="btn btn-primary btn-sm">Alterar</button>';
                            return "";
                        }
                    },
                    Excluir: {
                        title: '',
                        display: function (data) {
                            return '<button onclick="BeneficiariosList.delete(' + data.record.ID + ')" class="btn btn-primary btn-sm">Excluir</button>';
                        }
                    }
                }
            });
       
        if (document.getElementById("gridBeneficiarios"))
            $('#gridBeneficiarios').jtable('load');
    },

    delete: function (id) {
        $.ajax({
            url: urlExcluirBeneficiario,
            method: "POST",
            data: { "Id": id },
            error:
                function (r) {
                    if (r.status == 400)
                        ModalDialog("Ocorreu um erro", r.responseJSON);
                    else if (r.status == 500)
                        ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
                },
            success:
                function (r) {
                    if (document.getElementById("gridBeneficiarios"))
                        $('#gridBeneficiarios').jtable('load');
                }
        });
    },

    update: function (id) {
        
        $.ajax({
            url: urlAlterarBeneficiario,
            method: "Get",
            data: { "Id": id },
            error:
                function (r) {
                    if (r.status == 400)
                        ModalDialog("Ocorreu um erro", r.responseJSON);
                    else if (r.status == 500)
                        ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
                },
            success:
                function (r) {
                    $("#NomeBeneficiario").val(r.Nome);
                    $("#CpfBeneficiario").val(r.Cpf)
                    BeneficiariosList.delete(id);
                    if (document.getElementById("gridBeneficiarios"))
                        $('#gridBeneficiarios').jtable('load');

                }
        });
    }
}


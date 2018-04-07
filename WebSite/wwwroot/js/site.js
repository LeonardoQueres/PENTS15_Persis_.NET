
$(function () {
    $('.busca-fornecedor').change(function () {
        var SelectedValue = $(this).val();
        CarregaDadosFornecedor(SelectedValue);
    });
});

function CarregaDadosFornecedor(Id) {
    $.ajax({
        url: urlObterFornecedor + '?Id=' + Id,
        dataType: 'json',
        success: function (data) {            
            $("#Cnpj").empty().val(data.Cnpj);
            $("#RazaoSocial").empty().val(data.RazaoSocial);
            $("#InscricaoMunicipal").empty().val(data.InscricaoMunicipal);
        },
        error: function (data) { 
            fw.alert.error('Fornecedor não cadastrado.');
        }
    });
}

$(document).ready(function () {
    
    // Sobrescreve os valores default do DatePicker
    $.fn.datepicker.defaults.format = "mm/dd/yyyy";
    $.fn.datepicker.defaults.autoclose = true;
    $.fn.datepicker.defaults.language = 'pt-BR';
    $.fn.datepicker.defaults.allowInputToggle = true;    
});

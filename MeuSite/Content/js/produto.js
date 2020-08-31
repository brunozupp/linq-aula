const BASE_URL = "http://localhost:50356";

window.onload = function () {

    $('.carousel.carousel-slider').carousel({
        fullWidth: true
    });

    setTimeout(function () {

        var containerMessage = document.getElementById("containerMessage");

        console.log(containerMessage);

        if (containerMessage != null) containerMessage.remove();
    }, 2000);
}

$("#formSave").submit(function (event) {

    event.preventDefault();

    // Validando se todos os inputs são válidos
    if (!validate()) {
        return;
    }

    // Evita o bug do tipo decimal que salva como zero
    var value = $("#ValorUnitario").val();
    $("#ValorUnitario").val(value.replace('.', ','));

    $.ajax({
        url: BASE_URL + "/Produto/Save",
        type: "POST",
        data: $("#formSave").serialize(),
        success: function (result) {
            window.location = BASE_URL + '/Produto/';
        },
        error: function (error) {
            window.location = BASE_URL + '/Produto/';
        }
    });

    // Retorna um estado de acordo com as validações programadas
    function validate() {

        if (isEmpty("Nome") || isEmpty("Descricao") || isEmpty("Quantidade") || isEmpty("ValorUnitario")) {
            return false;
        }

        return true;
    }

    // Verifica se o input está vazio
    function isEmpty(id) {
        return ($("#" + id).val().length <= 0) ? true : false;
    }
});
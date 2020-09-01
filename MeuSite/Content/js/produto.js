const BASE_URL = "http://localhost:50356";

window.onload = function () {

    $('.carousel.carousel-slider').carousel({
        fullWidth: true
    });

    autoplay();

    function autoplay() {
        $('.carousel').carousel('next');
        setTimeout(autoplay, 3500);
    }

    // Mensagem que vai fazer desaparecer a msg de aviso
    setTimeout(function () {

        var containerMessage = document.getElementById("containerMessage");

        console.log(containerMessage);

        if (containerMessage != null) containerMessage.remove();
    }, 2000);

    $(".btnDelete").on('click', function () {

        var id = { 'id': $(this).data("id") };

        console.log(id);

        $.confirm({
            boxWidth: '30%',
            useBootstrap: false,
            title: 'Deletar registro?',
            content: 'Não poderá ser desfeito',
            type: 'red',
            typeAnimated: true,
            buttons: {
                confirm: {
                    text: 'Deletar',
                    btnClass: 'btn-red',
                    action: function () {
                        $.ajax({
                            url: BASE_URL + "/Produto/Delete/",
                            data: id,
                            type: "POST",
                            //data: id,
                            success: function (result) {
                                window.location = BASE_URL + '/Produto/';
                            },
                            error: function (error) {
                               window.location = BASE_URL + '/Produto/';
                            }
                        });
                    }
                },
                fechar: function () {
                    
                },
            }
        });
    });
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


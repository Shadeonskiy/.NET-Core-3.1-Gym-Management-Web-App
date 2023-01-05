$(document).ready(function () {
    $('#myTable').DataTable({
        "scrollY": "450px",
        "scrollCollapse": true,
        "paging": true
    })
});

$(function () {

    if ($("a.confirmDeletion").length) {
        $("a.confirmDeletion").click(() => {
            if (!confirm("Ви впевнені, що хочете видалити запис?")) return false;
        });
    }

    if ($("div.alert.notification").length) {
        setTimeout(() => {
            $("div.alert.notification").fadeOut();
        }, 2000);
    }

});

function readURL(input) {
    if (input.files && input.files[0]) {
        let reader = new FileReader();

        reader.onload = function (e) {
            $("img#imgpreview").attr("src", e.target.result);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

function addOption() {
    name = document.querySelector('#period')
    if (name.value = '') {
        alert("Введіть період");
        return;
    }
    var select = document.getElementById("dynamic-select");
    select.options[select.options.length] = new Option(name.value, name.value);
}


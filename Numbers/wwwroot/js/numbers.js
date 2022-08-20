const DURATION = 5000;

$(document).ready(function () {
    setInterval(UpdateNumber, DURATION);
});

function UpdateNumber()
{
    $.get("/Home/GetRandomNumber", function (data) {
        $("#numberFromApi").html(data);
    });
}
const DURATION=5e3;function UpdateNumber(){$.get("/Home/GetRandomNumber",function(e){$("#numberFromApi").html(e)})}$(document).ready(function(){setInterval(UpdateNumber,5e3)});
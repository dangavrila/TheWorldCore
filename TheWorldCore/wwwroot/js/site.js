// site.js
(function startup() {
    var ele = document.getElementById("username");
    ele.innerHTML = "Anne Christie";

    var main = document.getElementById("main");
    main.onmouseenter = function () {
        main.style = " background: #888";
    };

    main.onmouseleave = function () {
        main.style = "";
    };
}) ();

var wait = setTimeout(function () {
    if (document.body != null) {
        clearTimeout(wait);

        requirejs.config({
            //baseUrl: '/Js/',
            paths: {
                "jquery": "/Js/utility/jquery.min",
                "bootstrap": "/Js/bootstrap/bootstrap.min",
                "master": "master",
            },
            shim: {
                'jquery': { exports: '$' },
                "bootstrap": {
                    deps: ['jquery'],
                    exports: 'bootstrap'
                },
                "master": { deps: ['jquery'] }
            }
        });

        require(['master', 'bootstrap'], function () {
            $("#logIn").click(function () {createDialog("/home/login");});

            $("#MessageMe").click(function () { location.href = "mailto:361703739@qq.com";});

            $("#SignOut").click(function () {   $.post("/home/SignOut", "", function () { location.href = "/home/index" }, "json"); });
        });



    }
}, 50);

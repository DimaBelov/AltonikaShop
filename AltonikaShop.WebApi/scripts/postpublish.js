var spawn = require('child_process').spawn;
var fileExists = require('file-exists');

var bashScript = 'bash -c "ssh 185.26.114.186 -l u2944939 \'echo Stop service and delete files && sh altonika-shop/scripts/webapi-clear.sh && exit\' && echo Push new files && scp -r /mnt/c/GitHub/AltonikaShop/AltonikaShop.WebApi/bin/Release/PublishOutput/. u2944939@185.26.114.186:/home/u2944939/altonika-shop/webapi && ssh 185.26.114.186 -l u2944939 \'echo Run service && sh altonika-shop/scripts/webapi-run.sh && exit\'"';
var openSshScript = "ssh 185.26.114.186 -l u2944939 'echo Stop service and delete files && sh altonika-shop/scripts/webapi-clear.sh && exit' && echo Push new files && scp -r /mnt/c/GitHub/AltonikaShop/AltonikaShop.WebApi/bin/Release/PublishOutput/. u2944939@185.26.114.186:/home/u2944939/altonika-shop/webapi && ssh 185.26.114.186 -l u2944939 'echo Run service && sh altonika-shop/scripts/webapi-run.sh && exit'";

fileExists('C:/Windows/System32/bash.exe').then(exists => {
    if (exists) {
        console.log('Run bash script');
        runBashScript();
    } else {
        console.log('Run OpenSSh script');
        runOpenSshScript();
    }
});

runBashScript = function () {
    var child =
        spawn(
            bashScript, {
                shell: true,
                stdio: 'inherit'
            });
}

runOpenSshScript = function () {
    var child =
        spawn(
            openSshScript, {
                windowsVerbatimArguments: true,
                shell: true,
                stdio: 'inherit'
            });
}
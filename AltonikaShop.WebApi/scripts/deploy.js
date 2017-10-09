var prompt = require('prompt');
var spawn = require('child_process').spawn;
var fileExists = require('file-exists');

//prompt.start();
//prompt.get({ properties: {password: {hidden: true} }}, function (err, result) {
//    exec(result.password);
//});

exec = function() {
    var and = " && ";
    var sshConnect = "ssh 185.26.114.186 -l u2944939";
    var deleteScript =
        `echo Stop service and delete files && ${sshConnect} 'sh altonika-shop/scripts/webapi-clear.sh && exit'`;
    var pushScript =
        "echo Push new files && scp -r /mnt/c/GitHub/AltonikaShop/AltonikaShop.WebApi/bin/Release/PublishOutput/. u2944939@185.26.114.186:/home/u2944939/altonika-shop/webapi";
    var runScript =
        `echo Run service && ${sshConnect} 'sh altonika-shop/scripts/webapi-run.sh && exit'`;

    var sshScript = `${deleteScript}${and}${pushScript}${and}${runScript}`;
    var bashScript = `bash -c "${sshScript}"`;

    fileExists('C:/Windows/System32/bash.exe').then(exists => {
        if (exists) {
            console.log('Run bash script');
            execScript(bashScript);
        } else {
            console.log('Run OpenSSh script');
            execScript(sshScript);
        }
    });
}

execScript = function(script) {
    var child =
        spawn(
            script, {
                shell: true,
                stdio: 'inherit'
            });
}

exec();

//runBashScript = function () {
//    var child =
//        spawn(
//            bashScript, {
//                shell: true,
//                stdio: 'inherit'
//            });
//}

//runSshScript = function () {
//    var child =
//        spawn(
//            sshScript, {
//                windowsVerbatimArguments: true,
//                shell: true,
//                stdio: 'inherit'
//            });
//}
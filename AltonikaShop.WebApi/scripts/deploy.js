var prompt = require('prompt');
var spawn = require('child_process').spawn;
var fileExists = require('file-exists');

//prompt.start();
//prompt.get({ properties: {password: {hidden: true} }}, function (err, result) {
//    exec(result.password);
//});

execScript = function (script) {
    var child =
        spawn(
            script, {
                shell: true,
                stdio: 'inherit'
            });
}

exec = function() {
    var and = " && ";
    var sshConnect = "ssh 185.26.114.186 -l u2944939";
    var deleteScript =
        `echo Stop service and delete files && ${sshConnect} 'sh altonika-shop/scripts/webapi-clear.sh'`;
    var pushScript =
        "echo Push new files && scp -r C:/Git/GitHub/AltonikaShop/AltonikaShop.WebApi/bin/Release/PublishOutput/. u2944939@185.26.114.186:/home/u2944939/altonika-shop/webapi";
    var runScript =
        `echo Run service && ${sshConnect} 'sh altonika-shop/scripts/webapi-run.sh'`;

    var getSshScript = () => `${deleteScript}${and}${pushScript}${and}${runScript}`;
    var getBashScript = () => `bash -c "${getSshScript()}"`;

    fileExists('C:/Windows/System32/bash.exe').then(exists => {
        if (exists) {
            pushScript = "echo Push new files && scp -r /mnt/c/GitHub/AltonikaShop/AltonikaShop.WebApi/bin/Release/PublishOutput/. u2944939@185.26.114.186:/home/u2944939/altonika-shop/webapi";
            console.log('Run bash script');
            execScript(getBashScript());
        } else {
            console.log('Run OpenSSh script');
            execScript(getSshScript());
        }
    });
}();
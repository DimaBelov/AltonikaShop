var spawn = require('child_process').spawn;
var fileExists = require('file-exists');

var and = " && ";
var sshConnect = "ssh 185.26.114.186 -l u2944939";
var deleteScript =
    `${sshConnect} 'echo Stop service and delete files && sh altonika-shop/scripts/webapi-clear.sh && exit'`;
var pushScript =
    "echo Push new files && scp -r /mnt/c/GitHub/AltonikaShop/AltonikaShop.WebApi/bin/Release/PublishOutput/. u2944939@185.26.114.186:/home/u2944939/altonika-shop/webapi";
var runScript =
    `${sshConnect} 'echo Run service && sh altonika-shop/scripts/webapi-run.sh && exit'`;

var sshScript = `${deleteScript}${and}${pushScript}${and}${runScript}`;
var bashScript = `bash -c "${sshScript}"`;

console.log(bashScript);

fileExists('C:/Windows/System32/bash.exe').then(exists => {
    if (exists) {
        console.log('Run bash script');
        runBashScript();
    } else {
        console.log('Run OpenSSh script');
        runSshScript();
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

runSshScript = function () {
    var child =
        spawn(
            sshScript, {
                windowsVerbatimArguments: true,
                shell: true,
                stdio: 'inherit'
            });
}
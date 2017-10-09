var spawn = require('child_process').spawn;
var child =
    spawn(
        'putty -ssh u2944939@185.26.114.186 -m %GITHUB_PATH%/AltonikaShop/AltonikaShop.WebApi/scripts/webapi-clear-script -t\n' +
        'psftp u2944939@185.26.114.186 -b %GITHUB_PATH%\AltonikaShop\AltonikaShop.WebApi\scripts\webapi-put-script -be\n' +
        'putty -ssh u2944939@185.26.114.186 -m %GITHUB_PATH%/AltonikaShop/AltonikaShop.WebApi/scripts/webapi-run-script -t', {
            windowsVerbatimArguments: true,
            shell: true,
            stdio: 'inherit'
        });
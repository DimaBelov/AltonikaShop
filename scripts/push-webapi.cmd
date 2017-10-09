set RU_SERVER_PW=2944939
putty -ssh -pw %RU_SERVER_PW% u2944939@185.26.114.186 -m C:/Git/GitHub/AltonikaShop/scripts/webapi-clear-script -t
psftp u2944939@185.26.114.186 -pw %RU_SERVER_PW% -b %GITHUB_PATH%\AltonikaShop\scripts\webapi-put-script -be
putty -ssh -pw %RU_SERVER_PW% u2944939@185.26.114.186 -m C:/Git/GitHub/AltonikaShop/scripts/webapi-run-script -t
set RU_SERVER_PW=
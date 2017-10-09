# putty -ssh u2944939@185.26.114.186 -m %GITHUB_PATH%/AltonikaShop/AltonikaShop.WebApi/scripts/webapi-clear-script -t
# psftp u2944939@185.26.114.186 -b %GITHUB_PATH%\AltonikaShop\AltonikaShop.WebApi\scripts\webapi-put-script -be
# putty -ssh u2944939@185.26.114.186 -m %GITHUB_PATH%/AltonikaShop/AltonikaShop.WebApi/scripts/webapi-run-script -t

putty -ssh u2944939@185.26.114.186 -m scripts/webapi-clear-script -t
psftp u2944939@185.26.114.186 -b scripts\webapi-put-script -be
putty -ssh u2944939@185.26.114.186 -m scripts/webapi-run-script -t

bash -c "ssh 185.26.114.186 -l u2944939 'echo Stop service and delete files && sh altonika-shop/scripts/webapi-clear.sh && exit' && echo Push new files && scp -r /mnt/c/GitHub/AltonikaShop/AltonikaShop.WebApi/bin/Release/PublishOutput/. u2944939@185.26.114.186:/home/u2944939/altonika-shop/webapi && ssh 185.26.114.186 -l u2944939 'echo Run service && sh altonika-shop/scripts/webapi-run.sh && exit'"
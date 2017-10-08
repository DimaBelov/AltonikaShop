(echo mkdir altonika-shop/test && echo cd altonika-shop/test && echo put -r C:/test/.)>batch.script
psftp u2944939@185.26.114.186 -b batch.script -be
del batch.script
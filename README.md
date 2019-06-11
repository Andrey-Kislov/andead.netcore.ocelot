# andead.netcore.ocelot

```
sudo cp /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/cert1.pem /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/cert1.old.pem
sudo cp /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/chain1.pem /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/chain1.old.pem
sudo cp /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/fullchain1.pem /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/fullchain1.old.pem
sudo cp /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/privkey1.pem /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/privkey1.old.pem
sudo mv /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/cert2.pem /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/cert1.pem
sudo mv /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/chain2.pem /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/chain1.pem
sudo mv /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/fullchain2.pem /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/fullchain1.pem
sudo mv /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/privkey2.pem /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/privkey1.pem

sudo openssl pkcs12 -export -out /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/cert.pfx -inkey /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/privkey1.pem -in /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/cert1.pem -certfile /etc/letsencrypt/archive/linux-docker.westeurope.cloudapp.azure.com/chain1.pem
```
